
const pageTitle = 'Project Title goes here!';
document.getElementById("title").innerHTML = pageTitle;


function productsAdd(){
    if($("#productTable tbody").length == 0) {
        $("#productTable").append("<tbody></body>");
    }

    $("#productTable tbody").append("<tr>" +
        "<td>JavaScript tutorials</td>" +
        "<td> 6/11/2021</td>" +
        "<td>https://www.w3schools.com/js/default.asp</td>" +
        "</tr>");

        $("#productTable tbody").append("<tr>" +
        "<td>jQuery Tutorials</td>" +
        "<td> 6/11/2021</td>" +
        "<td>https://www.w3schools.com/jquery/default.asp</td>" +
        "</tr>");
}

function productUpdate() {
    if($("#productName").val() != null && $("#productName").val() != '') {
        productAddToTable();
        formClear();
        $("#productName").focus();
    }
}

function productAddToTable() {
    if($("#productTable tbody").length == 0) {
        $("#productTable").append("<tbody></tbody>");
    }

    $("#productTable tbody").append("<tr>" +
    "<td>" + $("#productName").val() + "</td>" +
    "<td>" + $("#introDate").val() + "</td>" +
    "<td>" + $("#url").val() + "</td>" +
    "<td>" + 
    "<button type='button' onclick='productDelete(this);' class='btn btn-secondary'>" +            
    //"<span class='glyphicon glyphicon-remove'/>" +
    "X</button>" +
    "</td>" +
    "</tr>");
}

function formClear() {
    $("#productName").val("");
    $("#introDate").val("");
    $("#url").val("");
}

function productDelete(ctl) {
    $(ctl).parents("tr").remove();
}

$(document).ready(function() {
    //productsAdd();
    productUpdate();
})