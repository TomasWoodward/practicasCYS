'use strict';


/**
 * Compartir un fichero
 *
 * body Compartir 
 * returns Compartir
 **/
exports.compartir = function(body) {
  return new Promise(function(resolve, reject) {
    const {archivo,usuario,kfile} = body;
    const query = 'INSERT INTO compartidos (archivo,usuario,kfile) VALUES (?,?,?)';
    
    db.query(query, [archivo,usuario,kfile], (error, results) => {
      if (error) {
        reject(error);
      } else {
        resolve({ message: 'Fichero compartido correctamente', id: results.insertId });
      }
    });
  });
}

