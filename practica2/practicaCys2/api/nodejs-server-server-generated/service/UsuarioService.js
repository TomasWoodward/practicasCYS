'use strict';
const db=require('../db.js');

/**
 * Obtener todos los usuarios
 *
 * returns List
 **/
exports.usuariosGET = function() {
  return new Promise(function(resolve, reject) {
    const query = 'SELECT * FROM usuarios';
    
    db.query(query, (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve(results);
      }
    });
  });
}


/**
 * Eliminar un usuario
 *
 * idUsuario Integer 
 * no response value expected for this operation
 **/
exports.usuariosIdUsuarioDELETE = function(idUsuario) {
  return new Promise(function(resolve, reject) {
    const query = 'DELETE FROM usuarios WHERE idUsuario = ?';
    
    db.query(query, [idUsuario], (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve({ message: 'Usuario eliminado correctamente' });
      }
    });
  });
}


/**
 * Obtener un usuario por ID
 *
 * idUsuario Integer 
 * returns Usuario
 **/
exports.usuariosIdUsuarioGET = function(idUsuario) {
  return new Promise(function(resolve, reject) {
    const query = 'SELECT * FROM usuarios WHERE idUsuario = ?';
    
    db.query(query, [idUsuario], (error, results) => {
      if (error) {
        reject(error);
      } else if (results.length === 0) {
        reject(error);
      } else {
        resolve(results[0]);
      }
    });
  });
}


/**
 * Actualizar un usuario
 *
 * body Usuario 
 * idUsuario Integer 
 * no response value expected for this operation
 **/
exports.usuariosIdUsuarioPUT = function(body,idUsuario) {
  return new Promise(function(resolve, reject) {
    const { nombre, usuario, clave} = body;
    const query = 'UPDATE usuarios SET nombre = ?, clave = ? WHERE idUsuario = ?';
    
    db.query(query, [nombre, clave, idUsuario], (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve({ message: 'Usuario actualizado correctamente' });
      }
    });
  });
}


/**
 * Crear un nuevo usuario
 *
 * body Usuario 
 * returns Usuario
 **/
exports.usuariosPOST = function(body) {
  return new Promise(function(resolve, reject) {
    const { nombre, clave ,publicKey} = body;
    const query = 'INSERT INTO usuarios (nombre, clave , publicKey) VALUES (?,?, ?)';
    
    db.query(query, [nombre, clave, publicKey], (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve({ message: 'Usuario creado correctamente', id: results.insertId });
      }
    });
  });
}

