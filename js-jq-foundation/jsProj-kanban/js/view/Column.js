export default class Column {
    constructor(id, title){

    }

    static createRoot(){
        const range = document.createRange();

        range.selectNode(document.body);
        return range.createContextualFragment(`
        <div class="kanban__column">
            <div class="kanban__column-title"></div>
            <div class="kanban__column-items"></div>
            <button class="kanban__add-items" type="button">+ Add</button>
        </div>
        `)
    }
}