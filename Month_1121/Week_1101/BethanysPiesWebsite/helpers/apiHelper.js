
const request = require('request');

let apiHelper = {
    callAPI: function(url){
        return new Promise((resolve, reject) => {
            request(url, {json: true}, (err, res, body) =>{
                if(err){
                    reject(err);
                } else {
                    resolve(body)
                }
            });
        });
    }
}

module.exports = apiHelper;