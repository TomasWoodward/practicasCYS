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
        return resolve({ status: 'error', message: 'Usuario no encontrado' });
      }

      const user = results[0];
      const password = clave;
      const salt = user.salt;

      try {
        const hashedPassword = await hashPassword(password, salt);

        if (!compareHashes(hashedPassword, user.clave)) {
          return resolve({ status: 'error', message: 'Contraseña incorrecta' });
        }

        const token = jwt.sign(
          { id: user.idUsuario },
          'clave_secreta',
          { expiresIn: '24h' }
        );

        resolve({ status: 'success', token: token });
      } catch (err) {
        return reject(err);
      }
    });
  });
};

exports.authRegisterPOST = function (body) {
  return new Promise(async function (resolve, reject) {
    const { nombre, clave, salt, publicKey, privateKey } = body;
    // Verificar que los datos requeridos estén presentes
    if (!nombre || !clave || !salt || !publicKey || !privateKey) {
      return resolve({
        status: "error",
        message: "Faltan datos: nombre, clave, salt, publicKey y privateKey son obligatorios"
      });
    }

    try {
      // Verificar si el usuario ya existe
      const checkUserQuery = 'SELECT * FROM usuarios WHERE nombre = ?';
      db.query(checkUserQuery, [nombre], async function (error, results) {
        if (error) {
          return resolve({
            status: "error",
            message: "Error al verificar el usuario existente",
            error: error.message
          });
        }

        if (results.length > 0) {
          return resolve({
            status: "error",
            message: "El usuario ya existe"
          });
        }

        // Crear el hash de la contraseña
        const hashedPassword = await hashPassword(clave, salt);
        // Insertar el nuevo usuario en la base de datos
        const insertQuery = 'INSERT INTO usuarios (nombre, clave, salt, publicKey, privateKey) VALUES (?, ?, ?, ?, ?)';
        db.query(insertQuery, [nombre, hashedPassword, salt, publicKey, privateKey], function (error, results) {
          if (error) {
            return resolve({
              status: "error",
              message: "Error al registrar el usuario",
              error: error.message
            });
          }

          resolve({
            status: "success",
            message: "Usuario registrado correctamente"
          });
        });
      });
    } catch (err) {
      resolve({
        status: "error",
        message: "Ocurrió un error inesperado",
        error: err.message
      });
    }
  });
};

