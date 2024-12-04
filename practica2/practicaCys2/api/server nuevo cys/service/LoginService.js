'use strict';
const db = require('../db.js');
const jwt = require('jsonwebtoken');
const crypto = require('crypto');
/**
 * Iniciar sesión para obtener un token JWT
 *
 * body Auth_login_body 
 * returns inline_response_200
 **/

async function hashPassword(password, salt) {

    // Ejemplo: Crear un hashBuffer usando la API de Crypto
    const encoder = new TextEncoder();
    const password2 = encoder.encode(password);
    const salt2 = encoder.encode(salt);

    const baseKey = await crypto.subtle.importKey(
        "raw",
        password2,
        "PBKDF2",
        false,
        ["deriveBits"]
    );

    const hashBuffer = await crypto.subtle.deriveBits(
        {
            name: "PBKDF2",
            salt: salt2,
            iterations: 10000,
            hash: "SHA-256"
        },
        baseKey,
        256 // Longitud en bits
    );

    // Convierte el ArrayBuffer a Base64
    const hashBase64 = toBase64(hashBuffer);
    return hashBase64;
}

function toBase64(buffer) {
  return btoa(
      Array.from(new Uint8Array(buffer))
          .map(byte => String.fromCharCode(byte))
          .join("")
  );
}

function compareHashes(hash1, hash2) {
  return hash1 === hash2; // Comparamos las cadenas directamente
}



exports.authLoginPOST = function (body) {
  console.log('Entra  al servicio de login');
  return new Promise(function (resolve, reject) {
    const { nombre, clave } = body;

    if (!nombre || !clave) {
      return reject(new Error('Faltan datos: nombre y clave son obligatorios'));
    }

    const query = 'SELECT * FROM usuarios WHERE nombre = ?';

    db.query(query, [nombre], async function (error, results) {
      if (error) {
        return reject(error);
      }

      if (results.length === 0) {
        return reject(new Error('Usuario no encontrado'));
      }

      const user = results[0];
     
        const password = clave;
        const salt = user.salt;

        const hashedPassword = await hashPassword(password, salt);
        console.log("Hash generado:", hashedPassword);

        if (!compareHashes(hashedPassword, user.clave)) {
          console.log('Contraseña incorrecta');

          return reject(new Error('Contraseña incorrecta'));
        }

        const token = jwt.sign(
          { id: user.idUsuario },
          'clave_secreta',
          { expiresIn: '24h' }
        );

        resolve({
          token: token
        });
    });
  });
};


exports.authRegisterPOST = function (body) {

  return new Promise(async function (resolve, reject) {
    const { nombre, clave, salt, publicKey, privateKey } = body;

    if (!nombre || !clave) {
      return reject(new Error('Faltan datos: nombre y clave son obligatorios'));
    }
    const hashedPassword = await hashPassword(clave, salt);
    const query = 'INSERT INTO usuarios (nombre, clave, salt, publicKey, privateKey) VALUES (?, ?, ?, ?, ?)';

    db.query(query, [nombre, hashedPassword, salt, publicKey, privateKey], function (error, results) {
      if (error) {
        return reject(error);
      }

      resolve({
        message: 'Usuario registrado correctamente'
      });
    });
  });
};

