'use strict';


/**
 * Obtener todos los usuarios
 *
 * returns List
 **/
exports.usuariosGET = function() {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = [ {
  "clave" : "clave",
  "idUsuario" : 0,
  "publicKey" : "publicKey",
  "nombre" : "nombre"
}, {
  "clave" : "clave",
  "idUsuario" : 0,
  "publicKey" : "publicKey",
  "nombre" : "nombre"
} ];
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
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
    resolve();
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
    var examples = {};
    examples['application/json'] = {
  "clave" : "clave",
  "idUsuario" : 0,
  "publicKey" : "publicKey",
  "nombre" : "nombre"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
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
    resolve();
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
    var examples = {};
    examples['application/json'] = {
  "clave" : "clave",
  "idUsuario" : 0,
  "publicKey" : "publicKey",
  "nombre" : "nombre"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}

