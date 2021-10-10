
const pageTitle = 'Project Title goes here!';
document.getElementById("title").innerHTML = pageTitle;


function productsAdd(){
    if($("#productTable tbody").length == 0) {
        $("#productTable").append("<tbody></body>");
    }

    
}