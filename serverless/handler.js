'use strict';

module.exports.hello = async (event, context) => {
  // TODO YK P1: invoke an API
  var request = require('request');
  var messages = "hello";
  return {
    statusCode: 200,
    body: JSON.stringify({
      message: messages
    }),
  };

  callback(null, response);
};

module.exports.imageResize = async (event, context) => {
  return {
    statusCode: 200,
    body: JSON.stringify({
      message: 'resize your image',
    }),
  };

  callback(null, response);
};

