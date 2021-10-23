
const pageTitle = 'Project Title goes here!';
document.getElementById("title").innerHTML = pageTitle;

//$("p").add("div").addClass("widget");
//var pdiv = $("p").add("div");

// $("li").add("h1").add("p").css("background-color", "red");

//$("li").add( document.getElementsByTagName("p")[0]).css("background-color","red");

//$("li").add("<p id='new'> new paragraph </p>").css("background-color","red");

// $("div").add("span").add("section")
//         .css("border","2px solid red")
//         .add("p")
//         .css("background","yellow");


//$( "p" ).clone().add( "<span>Again</span>" ).appendTo( document.body );

//$( "p" ).add( document.getElementsByClassName( "a" )).css( "background","yellow");

// var collection = $( "p" );

// collection = collection.add( document.getElementsByClassName( "a ") );

// collection.css( "background","pink");


// console.log("Hello".charAt(0));

// console.log("Hello".toUpperCase());

// console.log("Hello".toLowerCase());

// console.log("Hello".replace(/e|i/g,"x"));

// console.log("1,2,3".split(","));

// console.log("Hello".length);

// console.log("".length);

// var Title = "Project Two";

// $("<b>" + Title + "</b>").appendTo("body");

$("#clickme").click(function () {
    $("#book").animate({
        opacity: 0.25,
        left: "+=50",
        height: "toggle"
    }, function () {
        console.log("Animation complete!");
    });
});