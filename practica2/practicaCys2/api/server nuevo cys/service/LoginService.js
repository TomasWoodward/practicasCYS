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
  const encoder = new TextEncoder();

  // Convierte la contraseña y el salt a formato Uint8Array
  const passwordData = encoder.encode(password);
  const saltData = encoder.encode(salt);

  // Genera una clave criptográfica base a partir de la contraseña
  const baseKey = await crypto.subtle.importKey(
    "raw",               // Formato de la clave
    passwordData,        // Datos de la clave (contraseña en este caso)
    "PBKDF2",            // Algoritmo que se usará
    false,               // No se podrá exportar esta clave
    ["deriveBits", "deriveKey"] // Usos permitidos
  );

  // Deriva una clave usando PBKDF2 con SHA-256 y 10,000 iteraciones
  const derivedKey = await crypto.subtle.deriveKey(
    {
      name: "PBKDF2",
      salt: saltData,
      iterations: 10000,
      hash: "SHA-256"
    },
    baseKey,              // Clave base
    { name: "HMAC", hash: "SHA-256", length: 256 }, // Formato de la clave derivada
    true,                 // La clave derivada puede exportarse
    ["sign"]              // Uso permitido de la clave derivada
  );

  // Exporta la clave derivada a un formato crudo para convertirla a hexadecimal
  const hashBuffer = await crypto.subtle.exportKey("raw", derivedKey);
  return btoa(String.fromCharCode(...new Uint8Array(hashBuffer))); // Devuelve el hash en Base64
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

  return new Promise(function (resolve, reject) {
    const { nombre, clave, salt, publicKey, privateKey } = body;

    if (!nombre || !clave) {
      return reject(new Error('Faltan datos: nombre y clave son obligatorios'));
    }

    const query = 'INSERT INTO usuarios (nombre, clave, salt, publicKey, privateKey) VALUES (?, ?, ?, ?, ?)';

    db.query(query, [nombre, clave, salt, publicKey, privateKey], function (error, results) {
      if (error) {
        return reject(error);
      }

      resolve({
        message: 'Usuario registrado correctamente'
      });
    });
  });
};

