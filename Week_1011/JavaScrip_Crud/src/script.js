
const pageTitle = 'Project Title goes here!';
document.getElementById("title").innerHTML = pageTitle;


var app = new function () {
    this.el = document.getElementById('countries');
    this.countries = ['Haiti', 'Chili', 'Equator', 'Nicaragua', 'Guatemala'];
    this.Count = function (data) {
        var el = document.getElementById('counter');
        var name = 'country';

        if (data > 1) {
            name = 'countries';
            el.innerHTML = data + '' + name;
        } else {
            this.el.innerHTML = 'No ' + name;
        }
    }

    this.Add = function () {
        alert('add something');
    }

};

this.FetchAll = function () {
    var data = '';
    if (this.countries.length > 0) {
        for (i = 0; i < this.countries.length; i++) {
            data += '<td>';
            data += '<td>' + this.countries[i] + '</td';
            data += '<t/d>';
        }
    }

    this.Count(this.countries.length);
    return this.el.innerHTML = data;
}

app.FetchAll();
