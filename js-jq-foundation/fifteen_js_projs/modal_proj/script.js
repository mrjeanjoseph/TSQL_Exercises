
var modalBtn = document.querySelector(".modal-btn");
var modal = document.querySelector(".modal-overlay");
var closeBtn = document.querySelector(".close-btn");

modalBtn.addEventListener("click", () => {
    modal.classList.add("open-modal");
});


closeBtn.addEventListener("click", () => {
    modal.classList.remove("open-modal");
});