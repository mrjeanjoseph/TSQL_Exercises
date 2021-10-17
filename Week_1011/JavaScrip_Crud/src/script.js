
const pageTitle = 'List of countries';
document.getElementById("title").innerHTML = pageTitle;


var app = new function () {
    this.el = document.getElementById('countries');
    this.countries = ['Haiti', 'Chili', 'Equator', 'Nicaragua', 'Guatemala'];
    this.Count = function (data) {
        var el = document.getElementById('counter');
        var name = 'country';

        if (data) {
            if (data > 1) {
                name = 'countries';
            }
            el.innerHTML = data + ' ' + name;
        } else {
            el.innerHTML = 'No ' + name;
        }
    };

    this.FetchAll = function () {
        var data = '';
        if (this.countries.length > 0) {
            for (i = 0; i < this.countries.length; i++) {
                data += '<tr>';
                data += '<td>' + this.countries[i] + '</td';
                data += '</tr>';
                data += '<td><button onclick="app.Edit(' + i + ')">Edit</button></td>';
                data += '<td><button onclick="app.Delete(' + i + ')">Delete</button></td>';
            }
        }
        this.Count(this.countries.length);
        return this.el.innerHTML = data;
    };

    this.Delete = function(item) {
        // Delete the current row
        this.countries.splice(item, 1);
        // Display the new list
        this.FetchAll();
    };

    this.Edit = function (item) {
        var el = document.getElementById('edit-name');
        // Display value in the field
        el.value = this.countries[item];
        // Display fields
        document.getElementById('spoiler').style.display = 'block';
        self = this;

        document.getElementById('saveEdit').onsubmit = function () {
            // Get value
            var country = el.value;
            if (country) {
                // Edit value
                self.countries.splice(item, 1, country.trim());
                // Display a new list
                self.FetchAll();
                CloseInput();
            }
        }
    };

    this.Add = function () {
        el = document.getElementById('add-name');
        //getting the value
        var country = el.value;
        if (country) {
            //add the new value
            this.countries.push(country.trim());
            //reset input value
            this.el.value = '';
            //Display the new list
            this.FetchAll();
        }
    }
};

function CloseInput() {
    document.getElementById('spoiler').style.display = 'none'
}

app.FetchAll();
