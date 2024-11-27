'use strict';


/**
 * Iniciar sesión para obtener un token JWT
 *
 * body Auth_login_body 
 * returns inline_response_200
 **/
exports.authLoginPOST = function(body) {
  return new Promise(function(resolve, reject) {
    var examples = {};
    examples['application/json'] = {
  "token" : "token"
};
    if (Object.keys(examples).length > 0) {
      resolve(examples[Object.keys(examples)[0]]);
    } else {
      resolve();
    }
  });
}

