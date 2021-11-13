

//THIS CODE WORKS - IT ITERATES THROUGH THE LIST OF IMGAGES AT A SPECIFIED INTERVAL
(function () {
    var columnOne = document.getElementById('column1');  // change to match image ID
    var columnTwo = document.getElementById('column2');  // change to match image ID
    var imgDir1 = 'Images/img';               // change to match images folder
    var imgDir2 = 'Images/img';               // change to match images folder
    var delayInSeconds = 1;                             // set number of seconds delay    

    // Yes I made changes below this line
    var numRound = Math.floor(Math.random() * 10);
    var num1 = 0, num2 = numRound;
    
    
    var changeImage = function () {
        columnOne.src = imgDir1 + num1++ + ".jpg";
        columnTwo.src = imgDir2 + num2++ + ".jpg";

        if (num1 == 16) {
            num1 = numRound;
            num2 = 0;
            
        }
    };
   setInterval(changeImage, delayInSeconds * 1000);
})();


