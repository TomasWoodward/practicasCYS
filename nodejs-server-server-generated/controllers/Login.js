'use strict';

var utils = require('../utils/writer.js');
var Login = require('../service/LoginService');

module.exports.authLoginPOST = function authLoginPOST (req, res, next, body) {
  console.log('Entra al controlador de login');
  Login.authLoginPOST(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};

module.exports.authRegisterPOST = function authRegisterPOST (req, res, next, body) {
  Login.authRegisterPOST(body)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
}