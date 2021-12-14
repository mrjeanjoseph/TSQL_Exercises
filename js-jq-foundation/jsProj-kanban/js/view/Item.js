import DropZone from "./DropZone.js";
import KanbanAPI from "../api/KanbanAPI.js";

export default class Item {
    constructor(id, content) {
        const bottomDropZone = DropZone.createDropZone();

        this.elements = {};
        this.elements.root = Item.CreateRoot();
        this.elements.input = this.elements.root.querySelector(".kanban__item-input");

        this.elements.root.dataset.id = id;
        this.elements.input.textContent = content;
        this.content = content;

        this.elements.root.appendChild(bottomDropZone);

        const onBlur = () => {
            const newContent = this.elements.input.textContent.trim();
            if(newContent == this.content) {
                return;
            }
            this.content = newContent;
            // console.log(this.content);
            
            KanbanAPI.updateItem(id, { content: this.content });
            // console.log(newContent);
        };
        this.elements.input.addEventListener("blur", onBlur);

        //This is to delete content
        this.elements.root.addEventListener("dblclick", () => {
            const check = confirm("Are you sure you want to delete this item");

            if(check) {
                KanbanAPI.deleteItem(id);

                this.elements.input.removeEventListener("blur", onBlur);
                this.elements.root.parentElement.removeChild(this.elements.root);
            }
        });

        this.elements.root.addEventListener("dragstart", e => {
            e.dataTransfer.setData("text/plain", id);
            console.log("content is being dragged");
        });

        //This will prevent the id content added to the drop location
        this.elements.input.addEventListener("drop", e => {
            console.log("content was dropped");
            e.preventDefault();
        });
    }

    static CreateRoot() {
        const range = document.createRange();
        range.selectNode(document.body);

        return range.createContextualFragment(`
            <div class"kanban__item" draggable="true">
                <div class="kanban__item-input" contenteditable></div>
            </div>
        `).children[0];
    }
}