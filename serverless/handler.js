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
