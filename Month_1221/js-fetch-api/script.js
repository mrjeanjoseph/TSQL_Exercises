
//This is the old ways of fetching/consuming API
// fetch("https://dog.ceo/api/breeds/list/all").then(function(response){
//     return response.json();
// }).then(function(data){
//     console.log(data);
// });

async function start() {
    const response = await fetch("https://dog.ceo/api/breeds/list/all");
    const data = await response.json();
    //console.log(data.message);
    createBreedList(data.message);
}

start();

function createBreedList(breedList) {
    document.getElementById("breed").innerHTML = `
    <select onchange="loadByBreed(this.value)">
        <option>Choose a dog Breed</option>
        ${Object.keys(breedList).map(function(breed){
            return `<option>${breed}</option>`
        }).join("")}
    </select>
    `;
}

async function loadByBreed(breed){
    if(breed != "Choose a dog Breed"){
        //alert("You chose a " + breed);
        const response = await fetch(`https://dog.ceo/api/breed/${breed}/images`);
        const data = await response.json();
        console.log(data)
    }
}