import KanbanAPI from "./api/KanbanAPI.js";

// console.log(KanbanAPI.getItems(1));
// console.log(KanbanAPI.insertItem(2, "new Item added"));

KanbanAPI.updateItem(41676, {
    columId:1,
    position: 0
});