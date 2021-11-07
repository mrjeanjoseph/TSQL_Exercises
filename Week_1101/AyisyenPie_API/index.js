let express = require('express');
let app = express();

//use express Router Object
let router = express.Router();

//Creating an array of items to be passed in
let pies = [
    {"id":1,"name":"Confiti Pie"},
    {"id":2,"name":"Gwayav Pie"},
    {"id":3,"name":"Kashiman Pie"},
    {"id":4,"name":"Kowosol Pie"}
];


router.get('/', function(req, res, next) {
    //Here I return the array of object
    res.status(200).send(pies);
});

app.use('/api/', router);

var server = app.listen(5000, function() {
    console.log('Node server is running on http://localhost:5000...,');
});