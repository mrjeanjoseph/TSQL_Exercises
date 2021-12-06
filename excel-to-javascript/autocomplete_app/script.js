
const search = document.getElementById('search');
const matchList = document.getElementById('match-list');

//search through the data.json file and filter through it.

const searchStates = async searchText => {
    const response = await fetch('data.json');
    const data = await response.json();
    //console.log(data) // This confirms that I am getting the local json data
    //get matches to current text input
    let matches = data.filter(state => {
        const regex = new RegExp(`^${ searchText }`,'gi');
        return state.name.match(regex) || state.abbr.match(regex);
    });
    // console.log(matches) // this confirms that regex is working. Only the first letter of the state or abbr should be filtered.
    
    if(searchText.length === 0 || searchText.length === null || searchText.value === ""){
        //This will reset the searched data back to empty array.
        matches = [];
        matchList.innerHTML = "";
    }
    //console.log(matches); //Confirming clearing the filter works.
    outputHTML(matches); // Printing the result to the DOM
};

const outputHTML = matches => {
    if(matches.length > 0) {
        let html = matches.map(match => `
        <div class="card card-body mb-1">
            <h4>${match.name} (${match.abbr})
                <span class="text-primary">${match.capital}</span>
            </h4>
            <small>Lat: ${match.lat} / Long: ${match.long}</small>
        </div>
        `).join("");        
        //console.log(html);
        matchList.innerHTML = html;
    }
};

search.addEventListener('input', () => searchStates(search.value));