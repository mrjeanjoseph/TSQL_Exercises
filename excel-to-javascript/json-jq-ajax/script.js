function getData(data){
    
    var searchField = $("#search").val();
    var expression =  new RegExp(searchField, "i");
    $.each(data, function (key, value) {
        if (value.name.search(expression) != -1 ||
            value.location.search(expression) != -1) {
            $("#result").append(`
            <li class="list-group-item">
                <img src="${value.image}" height="40" width="40"class="img-thumbnail"/>${value.name} |
                <span class="text-muted">${value.location}</span>                    
            </li>`)
        }
    });
}

$(document).ready(function () {
    $("#search").keyup(function () {
        $("result").html("");
        $.getJSON("data.json", function (data) {
            getData(data);
        })
    })
})