// import KanbanAPI from "./api/KanbanAPI.js";

import Kanban from "./view/Kanban.js";

// console.log(KanbanAPI.getItems(1));
// console.log(KanbanAPI.insertItem(2, "new Item added"));

// KanbanAPI.deleteItem(15686);

new Kanban(document.querySelector(".kanban"));