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

    //Handler for GET METHOD - Getting a single piece of pie data by id/name
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
    },

    //Handler for POST METHOD - Posting a single piece of pie data
    insert: function(newData, resolve, reject){
        fs.readFile(FILE_NAME, function(err, data) {
            if(err){
                reject(err);
            } else {
                let pies = JSON.parse(data);
                pies.push(newData);
                fs.writeFile(FILE_NAME, JSON.stringify(pies), function(err){
                    if(err){
                        reject(err);
                    }else{
                        resolve(newData);
                    }
                });
            }
        });
    },

    //Handler for Update Method - Partially updating pie data
    update: function(newData, id, resolve, reject){
        fs.readFile(FILE_NAME, function(err, data) {
            if(err){
                reject(err);
            } else {
                let pies = JSON.parse(data);
                let pie = pies.find(p => p.id == id);
                if(pie) {
                    Object.assign(pie, newData);
                    fs.writeFile(FILE_NAME, JSON.stringify(pies), function(err){
                        if(err){
                            reject(err);
                        } else {
                            resolve(newData);
                        }
                    });
                }
            }
        });
    },

    //Handler for the delete function. will delete a single file
    delete: function(id, resolve, reject) {
        fs.readFile(FILE_NAME, function(err, data){
            if(err){
                reject(err);
            } else {
                let pies = JSON.parse(data);
                let index = pies.findIndex(p => p.id == id );
                if(index != -1) {
                    pies.splice(index, 1);
                    fs.writeFile(FILE_NAME, JSON.stringify(pies), function(err) {
                        if(err){
                            reject(err);
                        } else {
                            resolve(index);
                        }
                    });
                }
            }
        });
    }
};

module.exports = pieRepo;