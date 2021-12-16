const express = require("express");
const app = express();
const port = 999;
const path = require("path");
const bodyParser = require("body-parser");
const { check, validationResult } = require("express-validator");

let urlencoded = bodyParser.urlencoded({ extended: false });

app.use(bodyParser.json());
app.use(urlencoded);
app.use(express.static(__dirname + '/public'));

app.get("/", (request, response) => {
    response.sendFile(path.join(__dirname + '/index.html'));
});

app.post("/formData", [
    check('name')
    .not().isEmpty()
    //Resume at 32:09 on the video
], (request, response) => {
    const errors = validationResult(request);

    if(!errors.isEmpty()){
        return response.status(422).json({
            errors: errors.array()
        });
    }
    response.status(202).json({
        success: 'Ok!'
    })
})

app.listen(port, () => console.log("server listening on port 999"))