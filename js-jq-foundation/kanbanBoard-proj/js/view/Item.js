export default class Item {
    constructor(id, content) {
        this.elements = {};
        this.elements.root = Item.createRoot();
        this.elements.input = this.elements.root.querySelector(".kanban__item-input");

        this.elements.root.dataset.id = id;
        this.elements.input.textContent = content;
        this.content = content;

        const onBlur = () => {
            const newContent = this.elements.input.textContent.trim();

            console.log(this.content);
            console.log(newContent);
        };
        this.elements.input.addEventListener("blur", onBlur);

        if(newContent == this.content){
            return;
        }
        this.content
    }

    static createRoot() {
        const range = document.createRange();
        range.selectNode(document.body);

        return range.createContextualFragment(`
            <div class="kanban__item" draggable="true">
                <div class="kanban__item-input" contenteditable></div>
            </div>`).children[0];
    }
}