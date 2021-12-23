import productdb, { bulkcreate, getData, createEle } from './module.js'

// document.addEventListener("DOMContentLoaded", () => {
//     table()
// });

window.onload = () => {
    table()
    getId(userid)
}

function getId(textboxid) {
    getData(db.products, data => {
        textboxid.value = data.id + 1 || 1;
    })
}


let db = productdb("Productdb", {
    products: `++id, name, seller, price`
});

//input tags
const userid = document.getElementById("userid");
const prodname = document.getElementById("prodname");
const seller = document.getElementById("seller");
const price = document.getElementById("price");
// let clearFields = prodname.value = seller.value = price.value = "";

//buttons
const btncreate = document.getElementById("btn-create");
const btnread = document.getElementById("btn-read");
const btnupdate = document.getElementById("btn-update");
const btndelete = document.getElementById("btn-delete");

//not found
const notfound = document.getElementById("notfound")

//insert value using create buttons
btncreate.onclick = (event) => {

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
        userid.value = "";
    });
    table();
    getId(userid)

    let msgadded = document.querySelector(".msgadded");
    getMsg(flag, msgadded)
}

//create event on btn read button
btnread.onclick = table;

btnupdate.onclick = () => {
    const id = parseInt(userid.value || 0);
    if (id) {
        db.products.update(id, {
            name: prodname.value,
            seller: seller.value,
            price: price.value
        }).then((updated) => {
            //let get = updated ? "data updated" : "Could not update data";
            //console.log(get);
            let get = updated ? true : false;
            let msgupdated = document.querySelector(".msgupdated");
            getMsg(get, msgupdated);
            prodname.value = seller.value = price.value = "";
        })
    }

    table();
}

btndelete.onclick = () => {
    db.delete();
    db = productdb("Productdb", {
        products: `++id, name, seller, price`
    });
    db.open();
    table();
    getId(userid);

    let msgdeleted = document.querySelector(".msgdeleted");
    getMsg(true, msgdeleted)
}



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

    while (tbody.hasChildNodes()) {
        tbody.removeChild(tbody.firstChild);
    }

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
                        i.setAttribute(`data-id`, data.id);
                        i.onclick = editbtn;
                    })
                })
                //Adding the delete icon
                createEle("td", tr, td => {
                    createEle("i", td, i => {
                        i.className += "fas fa-trash-alt btndelete";
                        i.onclick = deletebtn;
                    })
                })
            })
        } else {
            notfound.textContent = "No record found in the database"
        }
    })

}

function editbtn(event) {
    // console.log(event.target)
    // console.log(event.target.dataset.id)
    // const id = event.target.dataset.id;
    // console.log(typeof id); // checking what type id is.
    const id = parseInt(event.target.dataset.id); //making this an int
    console.log(typeof id); // checking what type id is.

    //testing getting the data
    db.products.get(id, data => {
        // console.log(data);
        userid.value = data.id || 0;
        prodname.value = data.name || "";
        seller.value = data.seller || "";
        price.value = data.price || "";
    })
}

function deletebtn(event) {
    let id = parseInt(event.target.dataset.id);
    db.products.delete(id);
    table();
}

function getMsg(flag, element) {
    if (flag) {
        element.className += "movedown";

        setTimeout(() => {
            element.classList.forEach(classname => {
                classname == "movedown" ? undefined : element.classList.remove("movedown");
            });
        }, 4000);
    }
}