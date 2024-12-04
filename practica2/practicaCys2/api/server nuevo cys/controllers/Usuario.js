'use strict';

var utils = require('../utils/writer.js');
var Usuario = require('../service/UsuarioService');

module.exports.getIdUsuario = function getIdUsuario (req, res, next, nombre) {
  Usuario.getIdUsuario(nombre)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.usuariosGET = function usuariosGET (req, res, next) {
  Usuario.usuariosGET()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.usuariosIdUsuarioDELETE = function usuariosIdUsuarioDELETE (req, res, next, idUsuario) {
  Usuario.usuariosIdUsuarioDELETE(idUsuario)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.usuariosIdUsuarioGET = function usuariosIdUsuarioGET (req, res, next, idUsuario) {
  Usuario.usuariosIdUsuarioGET(idUsuario)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.usuariosIdUsuarioPUT = function usuariosIdUsuarioPUT (req, res, next, body, idUsuario) {
  Usuario.usuariosIdUsuarioPUT(body, idUsuario)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.usuariosPOST = function usuariosPOST (req, res, next, body) {
  Usuario.usuariosPOST(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};
