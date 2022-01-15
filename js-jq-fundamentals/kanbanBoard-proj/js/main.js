// import KanbanAPI from "./api/KanbanAPI.js";


// console.log(KanbanAPI.insertItem(2, "I am new"));

// console.log(KanbanAPI.getItems(1));

// KanbanAPI.updateItem(962271);
// KanbanAPI.deleteItem(962271);

// KanbanAPI.updateItem(962271, {
//     columnId: 1,
//     position: 0,
//     content: "I've changed again"
// });


import Kanban from "./view/Kanban.js";
new Kanban(document.querySelector(".kanban"));