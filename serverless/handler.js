'use strict';

module.exports.hello = (event, context, callback) => {

  var thisBody = "hello from handler.js file"
  const response =  {
    statusCode: 200,
    body: JSON.stringify({
      message: thisBody
    }),
  };

  callback(null, response);
};

module.exports.imageResize = (event, context, callback) => {
  return {
    statusCode: 200,
    body: JSON.stringify({
      message: 'resize your image',
    }),
  };

  callback(null, response);
};


  // var request = require('request');
  // var thisStatusCode = "";
  // var thisBody;
  // request('http://qa-manage.enachina.com/v1/appversion', function (error, response, body) {
  //   thisBody = body;
  //   thisStatusCode = response.statusCode;
  //   console.log("sss");
  // })

