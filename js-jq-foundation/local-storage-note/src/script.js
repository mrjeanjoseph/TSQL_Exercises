let addBtn = document.getElementById("add-btn");
let addTitle = document.getElementById("note-title");
let addTxt = document.getElementById("note-text");

addBtn.addEventListener("click", (e) => {
    if(addTitle.value == "" || addTxt.value == "") {
        return alert("Please add your notes");
    }

    let notes = localStorage.getItem("notes");
    if(notes == null){
        notesObj = [];
    } else {
        notesObj = JSON.parse(notes);
    }
    let myObj = {
        title: addTitle.value,
        text: addTxt.value
    }

    notesObj.push(myObj);
    localStorage.setItem("notes", JSON.stringify(notesObj));
    addTitle.value = "";
    addTxt.value = "";

    showNotes();
})

// Show notes on the page

function showNotes(){
    let notes = localStorage.getItem("notes");
    if(notes == null) {
        notesObj = [];
    } else {
        notesObj = JSON.parse(notes);
    }

    let html = "";
    notesObj.forEach(function(element, index) {
        html += `
            <div id="note">
                <p class="note-counter">Note 1</p>
                <h3 class="note-title">Hello World</h3>
                <p class="note-text">Some Note text</p>
                <button class="note-btn">Delete Note</button>
                <button class="note-btn edit-btn">Edit Note</button>
            </div>
        `
    })
}