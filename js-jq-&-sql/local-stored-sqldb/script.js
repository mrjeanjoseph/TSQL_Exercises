
var db = openDatabase("itemDB", "1.0", "itemDB", 65535);

$(document).ready(function () {

    $("#create").click(function () {
        db.transaction(function (transaction) {
            var sql = "CREATE TABLE items " +
                "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                "item VARCHAR(100) NOT NULL," +
                "quantity INT(5) NOT NULL)";
            transaction.executeSql(sql, undefined, function () {
                alert("Table is created Successfully");
            }, function () {
                alert("Data is created Successfully");
            })
        })
    })

    $("#remove").click(function () {
        if (!confirm("Are you sure to delete this table?", "")) return;;
        db.transaction(function (transaction) {
            var sql = "DELETE TABLE items";
            transaction.executeSql(sql, undefined, function () {

            })
        })
    })
})