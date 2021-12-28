

//Using selectors inside the element
const questions = document.querySelectorAll(".question");

questions.forEach(function(question){
    // console.log(question);
    const btn = question.querySelector(".question-btn");
    // console.log(btn)
    btn.addEventListener("click", () => {
        questions.forEach( (item) => {
            // console.log(item);
            if(item !== question) {
                item.classList.remove("show-text");
            }
        })
        question.classList.toggle("show-text");
    })
});

//traversing the DOM
// const btns = document.querySelectorAll(".question-btn");
// btns.forEach(function (btn) {
//     btn.addEventListener("click", (e) => {
//         console.log(e.currentTarget.parentElement.parentElement)
//         const question = e.currentTarget.parentElement.parentElement;
//         question.classList.toggle("show-text");
//     });
// });