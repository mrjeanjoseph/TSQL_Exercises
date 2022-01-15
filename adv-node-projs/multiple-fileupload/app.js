const express = require('express');

const fileUpload = require('express-fileUpload');
const { join } = require('path');
const path = require('path');

const app = express();
app.set('view engine', 'ejs');

app.use(fileUpload({
    useTempFiles: true,
    tempFileDir: path.join(__dirname, 'tmp'),
    createParentPath: true,
    limits: { fileSize: 1024 * 1024 * 1024 }
}));

app.get('/', async (req, res, next) => {
    res.render('index');
});

function randomStr(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    return result;
}

//console.log(randomStr(5));

app.post('/single', async (req, res, next) => {
    try {
        const file = req.files.mFile;
        console.log(file);

        //const fileName = new Date().getTime().toString() + path.extname(file.name);
        const fileName = randomStr(5) + path.extname(file.name);

        const savePath = path.join(__dirname, 'public', 'uploads', fileName)
        if (file.truncated) {
           // throw new Error('File ' + fileName + 'size is too big');
            throw new Error('File size is too big');
        }
        if(file.mimetype !== 'image/jpeg') {
            throw new Error('Only jpges are supported')
        }
        await file.mv(savePath);
        //res.redirect('/')
        res.send('FILE UPLOADED');

    } catch (error) {
        console.log(error);
        //res.redirect('/errorpage');
        res.send('Error uploading file');
    }
})

app.post('/multiple', async (req, res, next) => {
    try{
        const files = req.files.mFiles;

        //This wawy will not work because await cannot match the asyn above
        // files.forEach(file => {
        //     const savePath = path.join(__dirname, 'public','uploads', file.name)
        //     await file.mv(savePath)
        // })


        //This way works
        // let promises = [];
        // files.forEach(file => {
        //     const savePath = path.join(__dirname, 'public','uploads', file.name)
        //     promises.push(file.mv(savePath));
        // });

        //This way works too - save as above
        const promises = files.map((file) => {
            const savePath = path.join(__dirname, 'public','uploads', file.name)
            return file.mv(savePath);
        })
        await Promise.all(promises);

        res.redirect('/')

    } catch (error){
        console.log(error);
        res.send('Error uploading file');
    }
})

var port = 1700;
app.listen(port, () => console.log(`listening on ${port}.`));