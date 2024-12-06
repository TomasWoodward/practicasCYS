'use strict';

var utils = require('../utils/writer.js');
var Compartir = require('../service/CompartirService');

module.exports.compartir = function compartir (req, res, next, body) {
  Compartir.compartir(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};
module.exports.compartirGET = function compartirGET (req, res, next, idFichero, idUsuario) {
  Compartir.compartirGET(idFichero, idUsuario)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.getFicherosByUser = function getFicherosByUser (req, res, next, usuario) {
  Compartir.getFicherosByUser(usuario)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      console.log("error en getFicherosByUser");
      utils.writeJson(res, response);
    });
};
