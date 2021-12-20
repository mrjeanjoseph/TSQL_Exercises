
import productdb, { bulkcreate, getData } from "./module.js"

let db = productdb("productDB", {
    products: `++id, name, seller, price`
});

//get id by input tag
const userid = document.getElementById("userid");
const prodname = document.getElementById("prodname");
const seller = document.getElementById("seller");
const price = document.getElementById("price");

// wire up the buttons
const btncreate = document.getElementById("btn-create");
const btnread = document.getElementById("btn-read");
const btnupdate = document.getElementById("btn-update");
const btndelete = document.getElementById("btn-delete");

//insert value using create button
btncreate.onclick = (event) => {
    let flag = bulkcreate(db.products, {
        name: prodname.value,
        seller: seller.vaue,
        price: price.value
    })
    //console.log(flag);

    // The normal way to empty field values
    // prodname.value = "";
    // seller.value = "",
    // price.value = "",

    // The shorter way to empty field values
    prodname.value = seller.value = price.value = "";
    getData(db.products, (data) => {
        //console.log(data.id);
        userid.value = data.id + 1 || 1;
    });
}

//create event on btn read button
btnread.onclick = table;

function table() {
    const tbody = document.createElement("tbody")

    //This is too time consuming
    let td = document.createElement("td");
    console.log(td);
    tbody.appendChild(td);
    console.log(tbody);
}

