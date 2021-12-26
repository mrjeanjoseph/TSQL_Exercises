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

async function getAllPhotos(pagenr) {
    const data = await fetch(`https://api.pexels.com/v1/curated?per_page=15&page=${pagenr}`, {
        method: 'GET',
        headers: {
            accept: 'application/json',
            Authorization: auth,
        },
    });
    const result = await data.json();
    // console.log(result);
    result.photos.forEach((photo) => {
        const pic = document.createElement("div");
        pic.innerHTML = `
            <img src=${photo.src.large}>
                <p>Photo: ${photo.photographer}</p>
                <a href=${photo.src.large}>Download</a>`;
        document.querySelector(".gallery").appendChild(pic);
    });

}
async function searchPhoto(pagenr) {
    const data = await fetch(`https://api.pexels.com/v1/search?query=${query}&per_page=15&page=${pagenr}`, {
        method: 'GET',
        headers: {
            accept: 'application/json',
            Authorization: auth,
        },
    });
    const result = await data.json();
    // console.log(result);
    result.photos.forEach((photo) => {
        const pic = document.createElement("div");
        pic.innerHTML = `
            <img src=${photo.src.large}>
                <p>Photo: ${photo.photographer}</p>
                <a href=${photo.src.large}>Download</a>`;
        document.querySelector(".gallery").appendChild(pic);
    });

}

searchButton.addEventListener("click", () => {
    if (input.value === "") return;
    clear();
    search = true;
    searchPhoto(query, pagenr);
});

function clear() {
    input.value = "";
    document.querySelector(".gallery").innerHTML = "";
    pagenr = 1;
}

next.addEventListener("click", () => {
    if (!search) {
        pagenr++;
        getAllPhotos(pagenr);
    } else {
        if (query.value === "") return;
        pagenr++;
        searchPhoto(pagenr);
    }
})

getAllPhotos(pagenr);