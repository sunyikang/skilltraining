// index.js

const serverless = require('serverless-http');
const express = require('express')
const app = express()

var requestTime = function (req, res, next) {
  req.requestTime = Date.now()
  next()
}

app.use(requestTime)

app.get('/timestamp', function (req, res) {
  var responseText = 'Hello World!<br>'
  responseText += '<small>Requested at: ' + req.requestTime + '</small>'
  res.send(responseText)
})

app.get('/', function (req, res) {
  var request = require('request');
  request('http://qa-manage.enachina.com/v1/appversion', function (error, response, body) {
    console.log(body)

    var result;
    if(response.statusCode == 200) {
      result = "unit test pass"
    } else {
      result = "unit test failed"
    }
    
    res.send({
      testResult: result,
      statusCode: response.statusCode,
      body: JSON.stringify({
        message: body
      })
    });
  })
})

module.exports.hello = serverless(app);