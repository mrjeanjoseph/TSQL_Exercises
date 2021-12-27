const reviews = [
    {
        id: 1,
        job: "Web Developer",
        img: "https://images.pexels.com/photos/1722198/pexels-photo-1722198.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
        text: "A leading-edge growth year raises a flag over human resource allocation, and mindshare follows through on the issue of the emerging focus. A quality-assured gating factor continues to realize the benefits of the culture change."
    },
    {
        id: 2,
        job: "Chief Executive Officer",
        img: "https://images.pexels.com/photos/2050994/pexels-photo-2050994.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
        text: "The task-driven skill set ensures a core competency. Design-led synergy has the price point. The competitive big picture has the solution."
    },
    {
        id: 3,
        job: "Certify Public Accountant",
        img: "https://images.pexels.com/photos/1729931/pexels-photo-1729931.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
        text: "A soup-to-nuts big win will not have productized opportunities. In order to assure that a lightweight horizontal market works effectively, we must be certain that a state-of-the-art key player helps us in the concepting of price points."
    },
    {
        id: 3,
        job: "Dessert Certify taster",
        img: "https://images.pexels.com/photos/2774292/pexels-photo-2774292.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
        text: "As always, the win-win teams utilize a paper trail. We are pleased to announce that disclosure is not going to have excellence. Surely, we can conclude that new-generation dialogues indicate that the cutting-edge executive advisory boards improve the performance of execution."
    }
];

const img = document.getElementById("person-img");
const author = document.getElementById("author");
const job = document.getElementById("job");
const info = document.getElementById("info");

const prevBtn = document.querySelector(".prev-btn");
const nextBtn = document.querySelector(".next-btn");
const randomBtn = document.querySelector(".random-btn");

let currentItem = 0;
window.addEventListener("DOMContentLoaded", function () {
    showPerson(currentItem);
})

function showPerson(person) {
    const item = reviews[person];
    img.src = item.img;
    author.textContent = item.name;
    job.textContent = item.job;
    info.textContent = item.text;
}

nextBtn.addEventListener("click", function() {
    currentItem ++;

    if(currentItem > reviews.length - 1){
        currentItem = 0;
    }
    showPerson(currentItem);
})

prevBtn.addEventListener("click", function() {
    currentItem --;

    if(currentItem < 0){
        currentItem = reviews.length - 1;
    }
    showPerson(currentItem);
})

randomBtn.addEventListener("click", function(){
    currentItem = Math.floor(Math.random() * reviews.length);
    console.log(currentItem);
    showPerson(currentItem);
})