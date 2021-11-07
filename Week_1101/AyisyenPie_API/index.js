let express = require('express');
let app = express();
let pieRepo = require('./repos/pieRepo');

//use express Router Object
let router = express.Router();
//Creating an array of items to be passed in
//let pies = pieRepo.get();


router.get('/', function (req, res, next) {
    //Here I return the array of object
    pieRepo.get(function (data) {
        res.status(200).json({
            //wrapping the status message inside a json envelop
            "status": 200,
            "statusText": "OK",
            "message": "Tout Gato yo valab.",
            "data": data
        });
    }, function (err) {
        next(err);
    });
});

app.use('/api/', router);

var server = app.listen(5000, function () {
    console.log('Node server is running on http://localhost:5000...,');
});