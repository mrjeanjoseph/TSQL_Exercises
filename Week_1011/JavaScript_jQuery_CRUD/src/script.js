
function productsAdd() {
    if ($("#productTable tbody").length == 0) {
        $("#productTable").append("<tbody></tbody");
    }

    $("#productTable tbody").append("<tr>" +
        "<td>My JavaScript Project</td>" +
        "<td>10/13/2021</td>" +
        "<td>wwww.javascriptprojs.com</td>" +
        "</td>");

    $("#productTable tbody").append("<tr>" +
        "<td>My Second JavaScript Project</td>" +
        "<td>10/19/2021</td>" +
        "<td>wwww.javascriptprojs.com</td>" +
        "</td>");
}

function productUpdate() {
    if ($("#productName").val() != null && $("#productName").val() != '') {
        if($("#updateButton").text() == "Update") {
            productUpdateInTable();
        } else {
            productAddToTable();
        }
        
        formClear();    
        $("#productName").focus();

        //productAddToTable();
       // productBuildTableRow();

    }
}

function productAddToTable() {
    // First check if a <tbody> tag exists, add one if not
    if ($("#productTable tbody").length == 0) {
        $("#productTable").append("<tbody></tbody>");
    }

    // Append product to the table
    $("#productTable tbody").append(
        "<tr>" +
        "<td>" + $("#productName").val() + "</td>" +
        "<td>" + $("#introDate").val() + "</td>" +
        "<td>" + $("#url").val() + "</td>" +
        "<td>" +
        "<button type='button' onclick='productDelete(this);'" +                
                " class='btn btn-default'>" +
        "<span class='glyphicon glyphicon-remove' />" +
        "</button>" +
        "</td>" +
        "</tr>");
}


function productBuildTableRow() {
    if ($("#productTable tbody").length == 0) {
        $("#productTable").append("<tbody></tbody>");
    }

    var ret = "<tr>" +
        "<td>" +
        "<button type='button' onclick='productDisplay(this);' class='btn btn-default'>" +
        "<span class='glyphicon glyphicon-edit' />" +
        "x</button>" +
        "</td>" +
        "<td>" + $("#productName").val() + "</td>" +
        "<td>" + $("#introDate").val() + "</td>" +
        "<td>" + $("#url").val() + "</td>" +
        "<td>" +
        "<button type='button' onclick='productDelete(this);' class='btn btn-default'>" +
        "<span class='glyphicon glyphicon-remove' />" +
        "</button>" +
        "</td>" +
        "</tr>"

    return ret;
}

var _row = null;
function productDisplay(ctl){
    _row = $(ctl).parents("tr");
    var cols = _row.children("td");

    $("#productName").val($(cols[1]).text());
    $("#introDate").val($(cols[2]).text());
    $("#url").val($(cols[3]).text());

    $("#updateButton").text("Update");
}


function productUpdateInTable() {
    $(_row).after(productBuildTableRow());

    $(_row).remove();

    formClear();

    $("#updateButton").text("Add");
}


function productDelete(ctl) {
    $(ctl).parents("tr").remove();
}

function formClear() {
    $("#productName").val("");
    $("#introDate").val("");
    $("#url").val("");
}



