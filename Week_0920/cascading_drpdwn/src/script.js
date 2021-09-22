

var subjectObject = {
    "Front-end": {
        "HTML": ["Links", "Images", "Tables", "Lists"],
        "CSS": ["Borders", "Margins", "Backgrounds", "Float"],
        "Bootstrap": ["class", "cards", "Tables", "forms"],
        "JavaScript": ["Variables", "Functions", "Conditions", "Operators"]
    },
    "Back-end": {
        "C-Sharp": ["Methods", "Classes", "Linq", "Variables"],
        "SQL": ["UPDATE", "DELETE", "INSERT", "INTO"],
        "Web API": ["Endpoint", "URL", "API KEY", "WEB URL"],
        "Azure": ["Server", "API", "Connection", "Hosting"]
    }
}

window.onload = function() {
    var subjectSel = document.getElementById("subject");
    var topicSel = document.getElementById("topic");
    var chapterSel = document.getElementById("chapter");

    for(var x in subjectObject) {
        subjectSel.options[subjectSel.options.length] = new Option(x, x);
    }
    
    subjectSel.onchange = function() {
        chapterSel.length = 1;
        topicSel.length = 1;
        for(var y in subjectObject[this.value]) {
            topicSel.options[topicSel.options.length] = new Option(y, y);
        }
    }
    topicSel.onchange = function() {
        chapterSel.length =1;
        var z = subjectObject[subjectSel.value][this.value];
        for(var i=0; i<z.length; i++) {
            chapterSel.options[chapterSel.options.length] = new Option(z[i], z[i]);
        }
    }
}