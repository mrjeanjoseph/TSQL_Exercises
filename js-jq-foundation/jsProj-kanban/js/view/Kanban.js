export default class Kanban {
    constructor(root) {
        this.root = root;

        Kanban.columns().forEach(column => {
           //TO DO: Create an instance of column class 
        });
    }

    static columns() {
        return [
            {
                id: 1, title: "Not Started"
            },
            {
                id: 2, title: "In Progress"
            },
            {
                id: 3, title: "Completed"
            }
        ]
    }
}