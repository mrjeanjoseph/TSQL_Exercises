const auth = "563492ad6f91700001000001d943ea2b17ff43c7ba6c640715cabe4b";
const next = document.querySelector(".next");
const input = document.querySelector("input");
const searchButton = document.querySelector(".searchButton");

let pagenr = 1;
let search = false;
let query = "";

input.addEventListener("input", (e) => {
    e.preventDefault();
    query = e.target.value
});

async function CuratedPhotos(pagenr){
    const data = await fetch(`https://api.pexels.com/v1/curated?per_page=${pagenr}`,{
        method: 'GET',
        headers: {
            accept: 'application/json',
            Authorization: auth,
        },
    });
    const result = await data.json();
    console.log(result);
}

CuratedPhotos(pagenr);