import productdb, { bulkcreate, getData, createEle } from './module.js'


let db = productdb("Productdb", {
    products: `++id, name, seller, price`
});

//input tags
const userid = document.getElementById("userid");
const prodname = document.getElementById("prodname");
const seller = document.getElementById("seller");
const price = document.getElementById("price");

//buttons
const btncreate = document.getElementById("btn-create")
const btnread = document.getElementById("btn-read")
const btnupdate = document.getElementById("btn-update")
const btndelete = document.getElementById("btn-delete")

//insert value using create buttons
btncreate.onclick = (even) => {

    let flag = bulkcreate(db.products, {
        name: prodname.value,
        seller: seller.value,
        price: price.value
    })
    // console.log(flag);

    // prodname.value = "",
    // seller.value = "",
    // price.value = ""

    prodname.value = seller.value = price.value = "";
    getData(db.products, (data) => {
        // console.log(data.id);
        userid.value = data.id + 1 || 1;
    });
}

//create event on btn read button
btnread.onclick = table;

function table() {
    const tbody = document.getElementById("tbody")
    //This option would create too many lines of codes
    //const tbody = document.getElementById("tbody")
    //let td = document.createElement("td");
    //console.log(td)
    //tbody.appendChild(td);
    //console.log(tbody)

    //Testing if the code works
    //const tbody = document.getElementById("tbody")
    // createEle("td",tbody,(td) => {
    //     console.log(td);
    //     console.log(tbody);
    // })

    getData(db.products, (data) => {
        if (data) {
            createEle("tr", tbody, tr => {
                for (const value in data) {
                    createEle("td", tr, td => {
                        td.textContent = data.price === data[value] ? `$${data[value]}` : data[value];
                    })
                }
                //Adding the edit icon
                createEle("td", tr, td => {
                    createEle("i", td, i => {
                        i.className += "fas fa-edit btnedit";
                    })
                })
                //Adding the delete icon
                createEle("td", tr, td => {
                    createEle("i", td, i => {
                        i.className += "fas fa-trash-alt btndelete";
                    })
                })
            })
        }
    })

}