$(document).ready(function () {
    $('#load_data').click(function () {
        $.ajax({
            url: "employee.csv",
            dataType: "text",
            success: function (data) {
                let employee_data = data.split(/\r?\n|r/);
                let table_data = `
                <table class="table table-bordered table-striped">
                `;
                for (let count = 0; count < employee_data.length; count++) {
                    let cell_data = employee_data[count].split(",");
                    cell_data += 'tr';
                    for (let cell_count = 0; cell_count < cell_data.length; cell_count++) {
                        if (count === 0) {
                            table_data += `<th>${cell_data[cell_data.length]}</th>`;
                        } else {
                            table_data += `<td>${cell_data[cell_data.length]}</td>`;
                        }
                    }
                    table_data += '</tr>';
                }
                table_data +='</table>';
                $('#employee_table').html(table_data);
            }
        })
    })
})