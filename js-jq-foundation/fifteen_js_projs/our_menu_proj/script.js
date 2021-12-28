const menu = [
    {
        id: 1,
        title: "Heart Healthy Salad",
        category: "breakfast",
        price: 14.99,
        img: "https://images.pexels.com/photos/1414651/pexels-photo-1414651.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
        desc: "Spicy jalapeno bacon ipsum dolor amet ham hock pork loin strip steak, cupim filet mignon capicola brisket beef flank spare ribs",
    },
    {
        id: 2,
        title: "Bacon Salad",
        category: "dinner",
        price: 14.99,
        img: "https://images.pexels.com/photos/1653877/pexels-photo-1653877.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
        desc: "Spicy jalapeno bacon ipsum dolor amet ham hock pork loin strip steak, cupim filet mignon capicola brisket beef flank spare ribs",
    },
    {
        id: 3,
        title: "diner double",
        category: "lunch",
        price: 14.99,
        img: "https://images.pexels.com/photos/1437267/pexels-photo-1437267.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
        desc: "Spicy jalapeno bacon ipsum dolor amet ham hock pork loin strip steak, cupim filet mignon capicola brisket beef flank spare ribs",
    },
    {
        id: 4,
        title: "Heart Healthy Salad",
        category: "breakfast",
        price: 14.99,
        img: "https://images.pexels.com/photos/1640777/pexels-photo-1640777.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
        desc: "Spicy jalapeno bacon ipsum dolor amet ham hock pork loin strip steak, cupim filet mignon capicola brisket beef flank spare ribs",
    },
    {
        id: 5,
        title: "Bacon Salad",
        category: "dinner",
        price: 14.99,
        img: "https://images.pexels.com/photos/1095550/pexels-photo-1095550.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
        desc: "Spicy jalapeno bacon ipsum dolor amet ham hock pork loin strip steak, cupim filet mignon capicola brisket beef flank spare ribs",
    },
    {
        id: 6,
        title: "diner double",
        category: "lunch",
        price: 14.99,
        img: "https://images.pexels.com/photos/326279/pexels-photo-326279.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
        desc: "Spicy jalapeno bacon ipsum dolor amet ham hock pork loin strip steak, cupim filet mignon capicola brisket beef flank spare ribs",
    },
    {
        id: 7,
        title: "Milkshake",
        category: "dessert",
        price: 74.99,
        img: "https://images.pexels.com/photos/3727250/pexels-photo-3727250.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
        desc: "Spicy jalapeno bacon ipsum dolor amet ham hock pork loin strip steak, cupim filet mignon capicola brisket beef flank spare ribs",
    },
];

const sectionCenter = document.querySelector(".section-center");
const container = document.querySelector(".btn-container");

//Load items
window.addEventListener("DOMContentLoaded", () => {
    displayMenuItems(menu);
    displayMenuBtns();
});
function displayMenuItems(menuItems) {
    let displayMenu = menuItems.map((item) => {
        // console.log(item);
        return `
        <article class="menu-item">
            <img class="photo"src="${item.img}" alt="${item.title}">            
            <div class="item-info">
            <header>
                <h4>${item.title}</h4>
                <h4 class="price">$${item.price}</h4>
            </header>
            <p>${item.desc}</p>
            </div>
        </article>`;
    });

    displayMenu = displayMenu.join('');
    sectionCenter.innerHTML = displayMenu;
    // console.log(displayMenu);
}

function displayMenuBtns(){
    const categories = menu.reduce(function (values, item) {
        //return values;
        if (!values.includes(item.category)) {
            values.push(item.category)
        }
        return values;
    },
        ['all']
    );
    // console.log(categories);
    const categoryBtns = categories.map(function (category) {
        return `<button class="filter-btn" type="button" data-id="${category}">${category}</button>`;
    }).join("");
    console.log(categoryBtns);

    container.innerHTML = categoryBtns;
    const filterBtns = container.querySelectorAll(".filter-btn");
    filterItems(filterBtns);
    
}
//filter items
function filterItems(filterBtns){
    filterBtns.forEach((btn) => {
        btn.addEventListener("click", (e) => {
            const category = e.currentTarget.dataset.id;
            const menuCategory = menu.filter((menuItem) => {
                // console.log(menuItem.category)
                if (menuItem.category === category) {
                    return menuItem
                }
            });
            // console.log(menuCategory);
            if (category === "all") {
                displayMenuItems(menu);
            } else {
                displayMenuItems(menuCategory);
            }
        });
    });
}