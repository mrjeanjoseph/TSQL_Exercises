
const colors = ["green", "red", "rgba(133, 122, 200)", "#f15025"];

const btn = document.querySelector("#btn");
const color = document.querySelector(".color")

function getRandomNumber() {
    randomNum = Math.floor(Math.random() * colors.length);
    return randomNum;
}
btn.addEventListener("click", function () {
    // var getBody = document.body;
    // console.log(getBody)
    const randomNumber = getRandomNumber();
    // console.log(randomNumber)
    document.body.style.backgroundColor = colors[randomNumber];
    color.textContent = colors[randomNumber];
});