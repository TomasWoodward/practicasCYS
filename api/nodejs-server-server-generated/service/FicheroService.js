'use strict';


/**
 * Obtener todos los ficheros
 *
 * returns List
 **/
exports.ficherosGET = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "idFichero" : 0,
  "kfile" : "kfile",
  "ruta" : "ruta",
  "usuario" : 6,
  "iv" : "iv"
}, {
  "idFichero" : 0,
  "kfile" : "kfile",
  "ruta" : "ruta",
  "usuario" : 6,
  "iv" : "iv"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
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
    resolve();
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
    var examples = {};
    examples['application/json'] = {
  "idFichero" : 0,
  "kfile" : "kfile",
  "ruta" : "ruta",
  "usuario" : 6,
  "iv" : "iv"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
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
    resolve();
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
    var examples = {};
    examples['application/json'] = {
  "idFichero" : 0,
  "kfile" : "kfile",
  "ruta" : "ruta",
  "usuario" : 6,
  "iv" : "iv"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}

