
const pageTitle = 'Project Title goes here!';
document.getElementById("title").innerHTML = pageTitle;

$("p").add("div").addClass("widget");
var pdiv = $("p").add("div");

// $("li").add("h1").add("p").css("background-color", "red");

//$("li").add( document.getElementsByTagName("p")[0]).css("background-color","red");

//$("li").add("<p id='new'> new paragraph </p>").css("background-color","red");

$("div").css("border","2px solid red")
        .add("p")
        .css("background","yellow");
