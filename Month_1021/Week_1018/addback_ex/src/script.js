
const pageTitle = 'Project Title goes here!';
document.getElementById("title").innerHTML = pageTitle;


$("div.left, div.right").find("div, div > p").addClass("border");

$("div.before-addback").find("p").addClass("background");

$("div.after-addback").find("p").addBack().addClass("background");