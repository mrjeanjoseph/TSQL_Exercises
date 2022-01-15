
var db = openDatabase("itemDB", "1.0", "itemDB", 65535);

function DisplayConfirmation(errMessage, customError){
    var messageElement = `<label style="color:red;">${errMessage}</label>`;
    var errorMessage = $("#quantity").append(messageElement);
    return errorMessage;
}

function createTable() {
    $("#create").click(function () {
        db.transaction(function (transaction) {
            var sql = "CREATE TABLE items " +
                "(id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                "item VARCHAR(100) NOT NULL," +
                "quantity INT(5) NOT NULL)";
            transaction.executeSql(sql, undefined, function () {
                alert("Table created Successfully");
                //DisplayConfirmation("Table created Successfully","");
                $("input #quantity").text("Text");
            }, function () {
                alert("An error occurred while create table");
            })
        });
    });
}

function deleteTableData() {
    $("#remove").click(function () {
        if (!confirm("Are you sure to delete this table?", "")) return;;
        db.transaction(function (transaction) {
            var sql = "DROP TABLE items";
            transaction.executeSql(sql, undefined, function () {
                alert("Table deleted successfully.");
            }, function (transaction, error) {
                alert("An error occurred while deleting table\n" + error.message);
            })
        });
    });
}

function insertDataIntoTable() {
    $("#insert").click(function () {
        var item = $("#item").val();
        var qty = $("#quantity").val();
        db.transaction(function (transaction) {
            var sql = "INSERT INTO items(item,quantity)" +
                "VALUES(?,?)";
            transaction.executeSql(sql, [item, qty], function () {
                alert(`Items: ${item} added successfully`);
            }, function (transaction, error) {
                alert("Error adding items\n" + error.message);
            });
        });
    });
}

function fetchDataFromDB() {
    $("#list").click(function () {
        $("#table-data").children().remove();
        db.transaction(function (transaction) {
            var sql = "SELECT * FROM items ORDER BY id";
            transaction.executeSql(sql, undefined, function (transaction, result) {
                if (result.rows.length) {
                    for (let data = 0; data < result.rows.length; data++) {
                        let row = result.rows.item(data);
                        let item = row.item;
                        let id = row.id;
                        let qty = row.quantity;
                        $("#table-data").append(`
                            <tr>
                                <td>${id}</td>
                                <td>${item}</td>
                                <td>${qty}</td>
                            </tr>
                        `);
                    }

                } else {
                    $("#table-data").append(`
                        <tr>
                            <td colspan="3" align="center">Fetched records returns no data</td>
                        </tr>
                    `);
                }
            }, function (transaction, error) {
                alert("An error getting data", error.message);
            });
        });
    });
}

$(document).ready(function () {
    createTable();
    deleteTableData();
    insertDataIntoTable();
    fetchDataFromDB();
});