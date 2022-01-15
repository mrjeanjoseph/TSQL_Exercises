
$(document).ready(function() {
    $("#app-container").on({
        click: function(){
            $("input").click();
            getdata(getCSVFile);
            console.log("getting the file");
        }
    },"#input");
})

function getData(getCSVFile) {
    fetch("./data.csv").then(response => {
        return response.text();
    }).then(data => {
        //console.log(data) // This gets me the returned text
        let result = data.split(/\r?\n|\r/).map(e => {
            return e.split(",");
        });
        getResult(result);
        // console.log(result); //This gets a the returned array
    })
}

function getResult(result){
    result.forEach(data => {
        let res_data = data.map(data => {
            return `<td>${data}</td>`;
        }).join("");
        let createRows = document.createElement("tr");
        createRows.innerHTML = res_data;
        // document.body.appendChild(createRows);
        if (createRows.innerText !== "") {
            document.querySelector("table").appendChild(createRows);
        }
        // console.log(res_data);
    })
}



//SHOULD BE ABLE TO USE THIS IN THE PROJ
// I DID NOT HAVE TO USE THIRD PARTY LIB