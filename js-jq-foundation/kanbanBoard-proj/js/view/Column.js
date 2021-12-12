import KanbanAPI from "../api/KanbanAPI.js";

export default class Column {
    constructor(id, title) {
        this.elements = {};
        this.elements.root = Column.createRoot();
        this.elements.title = this.elements.root.querySelector(".kanban__column-title");
        this.elements.items = this.elements.root.querySelector(".kanban__column-items");
        this.elements.addItem = this.elements.root.querySelector(".kanban__add-item");

        this.elements.root.dataset.id = id;
        this.elements.title.textContent = title;

        this.elements.addItem.addEventListener("click", () => {
            //DO SOMETHING HERE!
        });

        KanbanAPI.getItems(id).forEach(item => {
            this.renderItem(item);
            console.log(item);
        });
    }

    static createRoot() {
        const range = document.createRange();

        range.selectNode(document.body);

        return range.createContextualFragment(`
        <div class="kanban__column">
            <div class="kanban__column-title"></div>
            <div class="kanban__column-items">
            <button class="kanban__add-item" type="button">+ Add</button>
        </div>
        `).children[0];
    }

    render(data) {

    }
}