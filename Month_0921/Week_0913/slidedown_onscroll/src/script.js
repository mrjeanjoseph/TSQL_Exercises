let navbar = document.getElementById("navbar").style;
window.onscroll = function () {
    scrollFunction();
}
navbar.top = "-50px"

// document.getElementById("navbar").style.top = "-50px";

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        navbar.top = "0";
        // document.getElementById("navbar").style.top = "0";
    } else {
        navbar.top = "-50px";
        // document.getElementById("navbar").style.top = "-50px";
    }
}