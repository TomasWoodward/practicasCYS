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
