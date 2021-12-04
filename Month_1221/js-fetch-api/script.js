let timer, deletefirstPhotoDelay;

//Old ways of fetching/consuming API
// fetch("https://dog.ceo/api/breeds/list/all").then(function(response){
//     return response.json();
// }).then(function(data){
//     console.log(data);
// });

async function start() {
    try{
        const response = await fetch("https://dog.ceo/api/breeds/list/all");
        const data = await response.json();
        //console.log(data.message);
        createBreedList(data.message);
    } catch(e) {
        message = "there was a problem getting data from the server API. \n Please try again later."
        setTimeout(function() {
            alert(message);
        }, 5000);
        
    }
}

start();

function createBreedList(breedList) {
    document.getElementById("breed").innerHTML = `
    <select onchange="loadByBreed(this.value)">
        <option>Choose a dog Breed</option>
        ${Object.keys(breedList).map(function (breed) {
        return `<option>${breed}</option>`
    }).join("")}
    </select>
    `;
}

async function loadByBreed(breed) {
    if (breed != "Choose a dog Breed") {
        //alert("You chose a " + breed);
        const response = await fetch(`https://dog.ceo/api/breed/${breed}/images`);
        const data = await response.json();
        //console.log(data)
        createSlideshow(data.message);
    }
}

function createSlideshow(images) {
    let currentPosition = 0;
    clearInterval(timer);
    clearTimeout(deletefirstPhotoDelay)
    if(images.length > 1){
        document.getElementById("slideshow").innerHTML = `
        <div class="slide" style="background-image: url('${images[0]}');"></div>
        <div class="slide" style="background-image: url('${images[1]}');"></div>
        `
        currentPosition += 2;
        if(images.length == 2) currentPosition = 0;
        timer = setInterval(nextSlide, 3000);
    } else {
        document.getElementById("slideshow").innerHTML = `
        <div class="slide" style="background-image: url('${images[0]}');"></div>
        <div class="slide"></div>
        `
    }


    function nextSlide() {
        document.getElementById("slideshow").insertAdjacentHTML("beforeend", `
        <div class="slide" style="background-image: url('${images[currentPosition]}');"></div>`);
        deletefirstPhotoDelay =  setTimeout(function () {
            document.querySelector(".slide").remove();
        }, 1000)
        if (currentPosition + 1 >= images.length) {
            currentPosition = 0;
        } else {
            currentPosition++;
        }
    }
    //console.log(images)
}