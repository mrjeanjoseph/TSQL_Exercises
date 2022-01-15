function create_CSV_table(employee_data) {
    var table_data = '<table class="table table-bordered table-striped">';
    for(let count = 0; count < employee_data.length; count++){
        var cell_data = employee_data[count].split(',');

        table_data+='<tr>';
        for(var index = 0; index < cell_data.length; index++){
            if(count === 0){
                table_data+= `<th> ${cell_data[index]} </th>`;
            } else {                        
                table_data+= `<td> ${cell_data[index]} </td>`;
            }
        }
        table_data+= '</tr>';
    }
    table_data+= '</table>';
    return table_data;
}

$(document).ready(() => {
    $.ajax({
        url: "ncvendorinactive.csv",
        dataType: "text",
        success: function(data){
            // console.log(data);
            var employee_data = data.replace(/"/g,"");
            employee_data = employee_data.split(/\r?\n|\r/);
            var table_data = create_CSV_table(employee_data);
            $('#employee_table').html(table_data)
        }
    })
})