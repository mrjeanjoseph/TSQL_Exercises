let express = require('express');
let app = express();
let pieRepo = require('./repos/pieRepo');

//use express Router Object
let router = express.Router();
//Creating an array of items to be passed in
//let pies = pieRepo.get();

app.use(express.json());

//Get all data
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

//Create GET/search?id=name=str to search for pies by 'id' and/or by 'name'
router.get('/search',function(req, res, next) {
    let searchOject = {
        "id":req.query.id,
        "name":req.query.name
    };

    pieRepo.search(searchOject, function(data) {
        res.status(200).json({
            "status":200,
            "statusText":"OK",
            "message":"All pies retrieved.",
            "data":data
        });
    },function(err){
        next(err);
    });
});

//GET/id to return a single pie
router.get('/:id', function(req, res, next) {
    pieRepo.getById(req.params.id, function(data){
        if(data){
            res.status(200).json({
                "status": 200,
                "statusText": "OK",
                "message": "Gato nimewo '" + req.params.id + "' an valab.",
                "data": data
            });
        } else {
            res.status(404).json({
                "status": 404,
                "statusText": "NOT FOUND!",
                "message": "Nimewo Gato '" + req.params.id + "' sa a, pa valab ",
                "error": {
                    "code": "NOT FOUND!",
                    "Message": "Nimewo Gato '" + req.params.id + "' sa a, pa valab "
                }
            });
        }
    }, function(err) {
        next(err);
    });
});

//POST to insert a single pie data
router.post('/', function(req, res, next){
    pieRepo.insert(req.body, function(data){
        res.status(201).json({
            "status": 201,
            "statusText":"Created",
            "message":"New Pie Data added.",
            "data": data
        });
    },function(err){
        next(err);
    });
})

router.put('/:id', function(req, res, next) {
    pieRepo.getById(req.params.id, function(data){
        if(data){
            pieRepo.update(req.body, req.params.id,function(data){
                res.status(200).json({
                    "status":200,
                    "statusText":"OK",
                    "message":"Pie '" + req.params.id + "' updated.",
                    "data": data
                });
            });
        } else {
            res.status(404).json({
                "status": 404,
                "statusText":"Not Found..,",
                "message":"The pie '" + req.params.id + "' could not be found.",
                "error":{
                    "Code":"NOT_FOUND",
                    "message":"The pie '" + req.params.id + "' could not be found."
                }
            });
        }
    }, function(err){
        next(err);
    });
})

//Delete method to delete one item from the list.
router.delete('/:id', function(req, res, next){
    pieRepo.getById(req.params.id, function(data){
        if(data){
            pieRepo.delete(req.params.id, function(data){
                res.status(200).json({
                    "status":200,
                    "statusText":"OK",
                    "message":"Pie '" + req.params.id + "' is now deleted.",
                    "data":"Pie '" + req.params.id + "' is now deleted."
                });
            });
        } else {
            res.status(404).json({
                "status":404,
                "statusText":"NOT FOUND",
                "message":"The pie '" + req.params.id + "' could not be found.",
                "error": {
                    "code":"NOT_FOUND",
                    "message":"Pie id: '" + req.params.id + "' is longer available. "
                }
            });            
        }
    }, function(err){
        next(err);
    });
})

app.use('/api/', router);

var server = app.listen(5000, function () {
    console.log('Node server is running on http://localhost:5000...,');
});