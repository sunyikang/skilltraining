
var request = require('request');
request('http://qa-manage.enachina.com/v1/appversion', function (error, response, body) {
    console.log(body)
    return {
        statusCode: response.statusCode,
        body: JSON.stringify({
            message: body
        })
    };
})

console.log("hello world");