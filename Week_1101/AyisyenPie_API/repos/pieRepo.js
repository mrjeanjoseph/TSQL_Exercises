let fs = require('fs');

const FILE_NAME = './assets/piesData.json';

let pieRepo = {
    get: function(resolve, reject) {
        fs.readFile(FILE_NAME, function(err, data) {
            if(err) {
                reject(err);
            }
            else{
                resolve(JSON.parse(data));
            }
        });
    },

    //Getting a single piece of pie data
    getById: function (id, resolve, reject) {
        fs.readFile(FILE_NAME, function(err, data){
            if(err){
                reject(err)
            } else {
                let aSinglePie = JSON.parse(data).find(pie => pie.id == id);
                resolve(aSinglePie);
            }
        });
    },

    //Getting a single piece of pie data by id and/or name
    search: function(searchObject, resolve, reject){
        fs.readFile(FILE_NAME, function(err, data) {
            if(err) {
                reject(err);
            } else {
                let pies = JSON.parse(data);
                //Perfom the search now
                if(searchObject){
                    //This is an example of search object
                    /* 
                    let searchObject = {
                        "id": 1,
                        "name": 'A'
                    };
                    */
                   searchPie = pies.filter(
                       onePie =>(searchObject.id ? onePie.id == searchObject.id: true) &&
                       (searchObject.name ? onePie.name.toLowerCase().indexOf(searchObject.name.toLowerCase()) >= 0 : true));                       
                }
                resolve(searchPie);
            }
        });
    }
};

module.exports = pieRepo;