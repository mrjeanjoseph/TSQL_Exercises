const notesContainer = document.getElementById("app");
const addNoteButton = notesContainer.querySelector(".add-note");

getNotes().forEach(note => {
    const noteElement = createNoteElement(note.id, note.content);
    notesContainer.insertBefore(noteElement, addNoteButton);
});

addNoteButton.addEventListener("click", () => addNotes() );

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
        updateNote(id, element.value);
    });

    element.addEventListener("dblclick", () => {
        const doDelete = confirm("Please confirm you want to delete your note!");
        if (doDelete) {
            deleteNote(id, element);
        }
    });
    return element;
}

function addNotes() {
    const newNotes = getNotes();
    const newNoteOjbects = {
        id: Math.floor(Math.random() * 10),
        content: "",
    }

    const noteElement = createNoteElement(newNoteOjbects.id, newNoteOjbects.content);
    notesContainer.insertBefore(noteElement, addNoteButton);

    newNotes.push(newNoteOjbects);
    saveNotes(newNotes);

}

function updateNote(id, newContent) {
    console.log("Updating Note...,");
    console.log(id, newContent);

    const notes = getNotes();
    const targetNote = notes.filter(note => note.id == id)[0];

    targetNote.content = newContent;
    saveNotes(notes);

}

function deleteNote(id, element) {
    console.log("Deleting node...,");
    console.log(id);

    const deleteSelectedNote = getNotes().filter(note => note.id != id);
    saveNotes(deleteSelectedNote);
    notesContainer.removeChild(element);

}