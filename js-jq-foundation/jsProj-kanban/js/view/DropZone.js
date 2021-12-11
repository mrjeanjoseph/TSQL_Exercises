export default class DropZone {
    static createDropZone() {
        const range = document.createRange();

        range.selectNode(document.body);

        const dropZone = range.createContextualFragment(`
            <div class"kanban__dropzone"></div>
        `).children[0];
        // We will be doing something here!

        dropZone.addEventListener("dragover", e => {
            e.preventDefault();
            dropZone.classList.add("kanban__dropzone--active");
        });
        dropZone.addEventListener("dragleave", () => {
            dropZone.classList.remove("kanban__dropzone--active");
        });
        
        dropZone.addEventListener("drop", e => {
            e.preventDefault();
            dropZone.classList.add("kanban__dropzone--active");

            const columnElement = dropZone.closest(".kanban__column");
            const columnId = Number(columnElement.dataset.id);

            console.log(columnElement, columnId);
        });

        return dropZone;
    }
}