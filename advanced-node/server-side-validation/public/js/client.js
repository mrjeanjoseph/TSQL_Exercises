let form = document.querySelector('form');

form.onsubmit = sendData;

function sendData(e) {
    e.preventDefault();

    let formData = new FormData(form);

    let params = {
        headers: {
            'content-type':'application/json'
        },
        body: JSON.stringify({
            name:formData.get('name'),
        }),
        method:"POST"
    }

    fetch("http://localhost:999/formData", params)
    .then(response => response.json())
    .then(data => {
        console.log(data);
    })
    .catch(err => console.log(err))
}