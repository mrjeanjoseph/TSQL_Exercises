
$(document).ready(function () {
    $("#upload").on("click", function (e) {
        getUserUploadedCSVFile();
    });
    var result = getTSPostingUserSelection();
    console.log(result);
});

function getTSPostingUserSelection() {
    $("#post_per").on("change", function (e) {
        var postPeriodVal = $("#post_per").children("option:selected").text();
        var tsPeriodVal = $("#ts_per").children("option:selected").text();
        var result = $("#selectedItem").text(`${postPeriodVal} - ${tsPeriodVal}`);
        return result;
    })
}




function getUserUploadedCSVFile() {
    // var fileUpload = document.getElementById("fileUpload");
    var fileUpload = $("#fileUpload");
    var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.csv|.txt)$/;
    if (regex.test(fileUpload.val().toLowerCase())) {
        if (typeof (FileReader) != "undefined") {
            var reader = new FileReader();
            reader.onload = function (e) {
                console.log("file made it to the DOM successfully");
                var myResult = csvJSON(e.target.result);
                console.log(myResult);
                csv_DOM_Table(e);
            }
            reader.readAsText($("#fileUpload")[0].files[0]);
        }
    } else {
        alert("Please upload a valid CSV file.");
    }
}

//var csv is the CSV file with headers
function csvJSON(csv) {
    var lines = csv.split("\n");
    var result = [];
    var headers = lines[0].split("\t");
    for (var i = 1; i < lines.length; i++) {
        var obj = {};
        var currentline = lines[i].split("\t");
        for (var j = 0; j < headers.length; j++) {
            obj[headers[j]] = currentline[j];
        }
        result.push(obj);
    }
    return JSON.parse(JSON.stringify(result));
}

function csv_DOM_Table(e) {
    var table = document.createElement("table");
    var rows = e.target.result.split("\n");
    for (var i = 0; i < rows.length; i++) {
        var row = table.insertRow(-1);
        var cells = rows[i].split(",");
        for (var j = 0; j < cells.length; j++) {
            var cell = row.insertCell(-1);
            cell.innerHTML = cells[j];
        }
    }
    var result = $("#csv-content");
    result.textContent = "";
    result.prepend(table);
}