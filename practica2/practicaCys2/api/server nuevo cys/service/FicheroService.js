'use strict';
const db=require('../db.js');
const upload = require('../upload');

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

exports.getIdFichero = function(nombre) {
  return new Promise(function(resolve, reject) {
    const query = 'SELECT * FROM fichero WHERE nombre = ?';
    
    db.query(query, [nombre], (error, results) => {
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
    const {nombre,archivo} = body;
    const query = 'UPDATE fichero SET nombre=?,archivo = ? WHERE idFichero = ?';
    
    db.query(query, [nombre, archivo, idFichero], (error, results) => {
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
exports.ficherosPOST = function (req, res,body) {
  upload.single('archivo')(req, res, (err) => {
      if (err) {
          console.log("Error al subir archivo: ", err);
          return res.status(500).json({ message: 'Error al subir archivo', error: err });
      }

      const { nombre } = req.body; // Captura el nombre enviado en el formulario
      const archivo = req.file; // Captura información del archivo subido

      if (!archivo) {
          return res.status(400).json({ message: 'No se recibió un archivo' });
      }

      const rutaArchivo = archivo.path; // Ruta completa del archivo en el servidor

      // Inserta el nombre y la ruta del archivo en la base de datos
      const query = 'INSERT INTO fichero (nombre, archivo) VALUES (?, ?)';
      db.query(query, [nombre, rutaArchivo], (error, results) => {
          if (error) {
              console.log("Error al guardar en la base de datos: ", error);
              return res.status(500).json({ message: 'Error al guardar en la base de datos', error });
          } else {
              res.status(201).json({
                  message: 'Fichero creado correctamente',
                  id: results.insertId,
                  ruta: rutaArchivo,
              });
          }
      });
  });
};
