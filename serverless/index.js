// index.js

const serverless = require('serverless-http');
const express = require('express')
const app = express()

var requestTime = function (req, res, next) {
  req.requestTime = Date.now()
  next()
}

app.use(requestTime)

app.get('/hello', function (req, res) {
  var responseText = 'Hello World!<br>'
  responseText += '<small>Requested at: ' + req.requestTime + '</small>'
  res.send(responseText)
})

app.get('/', function (req, res) {
  var request = require('request');
  request('http://qa-manage.enachina.com/v1/appversion', function (error, response, body) {
    console.log(body)
    res.send({
      statusCode: response.statusCode,
      body: JSON.stringify({
        message: body
      })
    });
  })
})

module.exports.hello = serverless(app);