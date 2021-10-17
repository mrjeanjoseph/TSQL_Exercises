
const pageTitle = 'Project Title goes here!';
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
            }
        }

        this.Count(this.countries.length);
        return this.el.innerHTML = data;
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

app.FetchAll();
