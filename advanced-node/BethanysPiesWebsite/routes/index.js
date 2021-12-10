var express = require('express');
var router = express.Router();
const apiHelper = require('../helpers/apiHelper');

/* GET home page. */
router.get('/', function (req, res, next){
  //res.render('index', { title: "Ayisien's Pie Shop" }); // The default one to be replaced

  apiHelper.callAPI('http://localhost:5000/api/')
    .then(response => {
      console.log(response);
      res.render('index', {
        title: "Ayisien's Pie Shop",
        data: response.data
      });
    }).catch(error => {
      res.send(error)
    });
});

module.exports = router;