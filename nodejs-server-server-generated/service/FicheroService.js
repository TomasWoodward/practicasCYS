'use strict';
const db=require('../db.js');


/**
 * Obtener todos los ficheros
 *
 * returns List
 **/
exports.ficherosGET = function() {
  return new Promise(function(resolve, reject) {
    const query = 'SELECT * FROM fichero';
    
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
 * Eliminar un fichero
 *
 * idFichero Integer 
 * no response value expected for this operation
 **/
exports.ficherosIdFicheroDELETE = function(idFichero) {
  return new Promise(function(resolve, reject) {
    const query = 'DELETE FROM fichero WHERE idFichero = ?';
    
    db.query(query, [idFichero], (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve({ message: 'Fichero eliminado correctamente' });
      }
    });
  });
}


/**
 * Obtener un fichero por ID
 *
 * idFichero Integer 
 * returns Fichero
 **/
exports.ficherosIdFicheroGET = function(idFichero) {
  return new Promise(function(resolve, reject) {
    const query = 'SELECT * FROM fichero WHERE idFichero = ?';
    
    db.query(query, [idFichero], (error, results) => {
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
 * Actualizar un fichero
 *
 * body Fichero 
 * idFichero Integer 
 * no response value expected for this operation
 **/
exports.ficherosIdFicheroPUT = function(body,idFichero) {
  return new Promise(function(resolve, reject) {
    const { ruta, usuario, claves} = body;
    const query = 'UPDATE fichero SET ruta = ?, usuario = ?, claves=? WHERE idFichero = ?';
    
    db.query(query, [ruta,usuario,claves, idFichero], (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve({ message: 'Fichero actualizado correctamente' });
      }
    });
  });
}


/**
 * Crear un nuevo fichero
 *
 * body Fichero 
 * returns Fichero
 **/
exports.ficherosPOST = function(body) {
  return new Promise(function(resolve, reject) {
    const {ruta, usuario, claves} = body;
    const query = 'INSERT INTO fichero (ruta, usuario,claves) VALUES (?,?, ?)';
    
    db.query(query, [ruta, usuario, claves], (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve({ message: 'Fichero creado correctamente', id: results.insertId });
      }
    });
  });
}

