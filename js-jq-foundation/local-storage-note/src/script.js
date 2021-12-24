let addBtn = document.getElementById("add-btn");
let addTitle = document.getElementById("note-title");
let addTxt = document.getElementById("note-text");

function localStorageNotes(notes){
    notes = localStorage.getItem("notes");
    if(notes == null){
        notesObj = [];
    } else {
        notesObj = JSON.parse(notes);
    }
    return notes;
}
addBtn.addEventListener("click", (e) => {
    if(addTitle.value == "" || addTxt.value == "") {
        return alert("Please add your notes");
    }

    // let notes = localStorage.getItem("notes");
    // if(notes == null){
    //     notesObj = [];
    // } else {
    //     notesObj = JSON.parse(notes);
    // }
    // let notes
    // localStorageNotes(notes);
    let myObj = {
        title: addTitle.value,
        text: addTxt.value
    }

    notesObj.push(myObj);
    localStorage.setItem("notes", JSON.stringify(notesObj));
    addTitle.value = "";
    addTxt.value = "";

    // showNotes();
})
showNotes();

// Show notes on the page
function showNotes(){
    // let notes = localStorage.getItem("notes");
    // if(notes == null) {
    //     notesObj = [];
    // } else {
    //     notesObj = JSON.parse(notes);
    // }
    let notes
    localStorageNotes(notes);

    let html = "";
    notesObj.forEach(function(element, index) {
        html += `
            <div id="note">
                <p class="note-counter">Note ${ index + 1 }</p>
                <h3 class="note-title">${ element.title }</h3>
                <p class="note-text">${ element.text }</p>
                <button id="${index}" onclick="deleteNote(this.id)" class="note-btn">Delete Note</button>
                <button id="${index}" onclick="editNote(this.id)" class="note-btn edit-btn">Edit Note</button>
            </div>
        `;
    });

    let noteElem = document.getElementById("notes");
    if(notesObj.length !=0) {
        noteElem.innerHTML = html;
    } else {
        noteElem.innerHTML = "No Notes Found! \n Add Notes using the form above";
    }
}

function deleteNote(index) {
    let confirmDelete = confirm("You are about to delete this note forever !!!");
    
    if(confirmDelete == true) {
        // let notes = localStorage.getItem("notes");
        // if(notes == null) {
        //     notesObj = [];
        // } else {
        //     notesObj = JSON.parse(notes);
        // }
        let notes
        localStorageNotes(notes);

        notesObj.splice(index, 1);
        localStorage.setItem("notes", JSON.stringify(notesObj));
        showNotes();
    }
}

//Function to edit the notes

function editNote(index) {

    // let notes = localStorage.getItem("notes");
    let notes
    if(addTitle.value !== "" || addTxt.value !== ""){
        return alert("The form will cleared ")
    }
    // if(notes == null) {
    //     notesObj = [];
    // } else {
    //     notesObj = JSON.parse(notes);
    // }
    localStorageNotes(notes);
    // console.log(notesObj)
    notesObj.findIndex((element, index) => {
        addTitle.value = element.title;
        addTxt.value = element.text;
    })
    notesObj.splice(index, 1);
    localStorage.setItem("notes", JSON.stringify(notesObj));
}