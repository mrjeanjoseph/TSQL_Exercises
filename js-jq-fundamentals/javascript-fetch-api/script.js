//Old ways of doing things
// fetch("https://dog.ceo/api/breeds/list/all")
//     .then(function (response) {
//         return response.json();
//     })
//     .then(function (data) {
//         console.log(data)
//     });

let timer, deletefirstPhotoDelay;

async function start() {
    try {
        const response = await fetch("https://dog.ceo/api/breeds/list/all");
        const data = await response.json();
        createBreedList(data.message);
        // console.log(data)
    } catch (e) {
        let errMess = `<p style='color: red;'>There was an error.
                                                We are working on fixing the problem.
                                                Please try again later</p>`;
        setTimeout(function() {
            document.getElementById("slideshow").innerHTML = errMess;
            //alert(errMess);
        }, 5000);
    }
}

start();

function createBreedList(breedList) {
    document.getElementById("breed").innerHTML = `
    <select onchange="loadByBreed(this.value)">
        <option>Choose a dog breed</option>
        ${Object.keys(breedList).map(function (breed) {
        return `<option>${breed}</option>`
    }).join("")}
    </select>
    `
}

async function loadByBreed(breed) {
    if (breed != "Choose a dog breed") {
        const response = await fetch(`https://dog.ceo/api/breed/${breed}/images`);
        const data = await response.json();
        // console.log(data);
        createSlideshow(data.message);
    }
}

function createSlideshow(images) {
    clearInterval(timer);
    clearTimeout(deletefirstPhotoDelay);
    let currentPosition = 0;
    // console.log(images)
    if (images.length > 1) {
        document.getElementById("slideshow").innerHTML = `
        <div class="slide" style="background-image: url('${images[0]}')"></div>
        <div class="slide" style="background-image: url('${images[1]}')"></div>        
        `
        currentPosition += 2;
        if (images.length == 2) currentPosition = 0;
        timer = setInterval(nextSlide, 3000);
    } else {
        document.getElementById("slideshow").innerHTML = `
        <div class="slide" style="background-image: url('${images[0]}')"></div>
        <div class="slide"></div>        
        `
    }


    function nextSlide() {
        document.getElementById("slideshow").insertAdjacentHTML("beforeend", `
        <div class="slide" style="background-image: url('${images[currentPosition]}')"></div>`)
        deletefirstPhotoDelay = setTimeout(function () {
            document.querySelector(".slide").remove();
        }, 1000);
        if (currentPosition + 1 >= images.length) {
            currentPosition = 0;
        } else {
            currentPosition++;
        }
    }
}