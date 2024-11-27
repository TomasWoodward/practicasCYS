'use strict';
const db=require('../db.js');
const jwt = require('jsonwebtoken');

/**
 * Iniciar sesión para obtener un token JWT
 *
 * body Auth_login_body 
 * returns inline_response_200
 **/


exports.authLoginPOST = function (body) {
  return new Promise(function (resolve, reject) {
    const { nombre, clave } = body;

    if (!nombre || !clave) {
      return reject(new Error('Faltan datos: nombre y clave son obligatorios'));
    }

    const query = 'SELECT * FROM usuarios WHERE nombre = ?';

    db.query(query, [nombre], function (error, results) {
      if (error) {
        return reject(error);
      }

      if (results.length === 0) {
        return reject(new Error('Usuario no encontrado'));
      }

      const user = results[0];

      if (user.clave !== clave) { 
        return reject(new Error('Contraseña incorrecta'));
      }

    
      const token = jwt.sign(
        { id: user.idUsuario },
        'clave_secreta', 
        { expiresIn: '24h' }
      );

      resolve({
        message: 'Usuario logueado correctamente',
        id: user.idUsuario,
        token: token,
      });
    });
  });
};


