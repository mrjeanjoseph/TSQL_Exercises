import KanbanAPI from "../api/KanbanAPI.js";

export default class DropZone {
    static createDropZone() {
        const range = document.createRange();

        range.selectNode(document.body);

        const dropZone = range.createContextualFragment(`
            <div class="kanban__dropzone"></div>
        `).children[0];

        dropZone.addEventListener("dragover", e => {
            e.preventDefault();
            dropZone.classList.add("kanban__dropzone--active");
        });

        dropZone.addEventListener("dragleave", () => {
            dropZone.classList.remove("kanban__dropzone--active");
        });

        dropZone.addEventListener("drop", e => {
            e.preventDefault();
            dropZone.classList.remove("kanban__dropzone--active");

            const columnElement = dropZone.closest(".kanban__column");
            const columnId = Number(columnElement.dataset.id);
            // console.log(columnElement, columnId);

            const dropZonesInColumn = Array.from(columnElement.querySelectorAll(".kanban__dropzone"));
            // console.log(dropZonesInColumn);
            
            const droppedIndex = dropZonesInColumn.indexOf(dropZone)
            // console.log(droppedIndex);

            const itemId = Number(e.dataTransfer.getData("text/plain"));
            // console.log(itemId);

            const droppedItemElement = document.querySelector(`[data-id="${itemId}"]`);
            // console.log(droppedItemElement);

            const insertAfter = dropZone.parentElement.classList.contains("kanban__item") ? dropZone.parentElement : dropZone;
            // console.log(insertAfter);

            if(droppedItemElement.contains(dropZone)) {
                return;
            }

            insertAfter.after = (droppedItemElement);
            KanbanAPI.updateItem(itemId, {
                columnId,
                position: droppedIndex
            });
        });

        return dropZone;
    }
}