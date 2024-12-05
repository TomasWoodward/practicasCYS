'use strict';

const db=require('../db.js');
/**
 * Compartir un fichero
 *
 * body Compartir 
 * returns Compartir
 **/
exports.compartir = function(body) {
  return new Promise(function(resolve, reject) {
    const {archivo,usuario,kfile,iv} = body;
    const query = 'INSERT INTO compartidos (archivo,usuario,kfile,iv) VALUES (?,?,?,?)';
    
    db.query(query, [archivo,usuario,kfile,iv], (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve({ message: 'Fichero compartido correctamente', id: results.insertId });
      }
    });
  });
}

exports.getFicherosByUser = function(usuario) {
  return new Promise(function(resolve, reject) {
    const query = 'SELECT f.* FROM compartidos c join fichero f on (c.archivo=f.idFichero) WHERE usuario = ?';
    
    db.query(query, [usuario], (error, results) => {
      if (error) {
        reject(error);
      } else if (results.length === 0) {
        reject(error);
      } else {
        resolve(results);
      }
    });
  }); 
}

