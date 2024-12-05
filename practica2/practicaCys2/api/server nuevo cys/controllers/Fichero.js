'use strict';

var utils = require('../utils/writer.js');
var Fichero = require('../service/FicheroService');

module.exports.ficherosGET = function ficherosGET (req, res, next) {
  Fichero.ficherosGET()
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.ficherosIdFicheroDELETE = function ficherosIdFicheroDELETE (req, res, next, idFichero) {
  Fichero.ficherosIdFicheroDELETE(idFichero)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.ficherosIdFicheroGET = function ficherosIdFicheroGET (req, res, next, idFichero) {
  Fichero.ficherosIdFicheroGET(idFichero)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.ficherosIdFicheroPUT = function ficherosIdFicheroPUT (req, res, next, body, idFichero) {
  Fichero.ficherosIdFicheroPUT(body, idFichero)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.ficherosPOST = function ficherosPOST (req, res, next, body) {
  console.log("entra al controlador de ficherosPOST");
  Fichero.ficherosPOST(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};
