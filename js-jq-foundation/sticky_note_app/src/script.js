const notesContainer = document.getElementById("app");
const addNoteButton = notesContainer.querySelector(".add-note")

function getNotes() {
    const locallyStoredNotes = localStorage.getItem("stickynotes-notes") || "[]";
    return JSON.parse(locallyStoredNotes);

}

function saveNotes(notes) {
    localStorage.setItem("stickynotes-notes", JSON.stringify(notes));

}

function createNoteElement(id, content) {
    const element = document.createElement("textarea");
    element.classList.add("note");
    element.value = content;
    element.placeholder = "Empty Sticky Note";

    element.addEventListener("change", () => {
        
    })
    return element;
}

function addNotes() {

}

function updateNote(id, newContent) {

}

function deleteNote(id, element) {

}