// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function putInventory() {
    let item = {};
    item.location = document.querySelector('#locationId').value;
    item.product = document.querySelector('#productId').value;
    item.quantity = document.querySelector('#quantity').value;

    let url = `https://localhost:44334/Inventory/put/${item.product}/${item.location}/${item.quantity}`
    data = {}

    const response = fetch(url, {
        method: 'PUT', // *GET, POST, PUT, DELETE, etc.
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    console.log(response.json()); // parses JSON response into native JavaScript objects
}


async function fetchAllProducts() {
    let url ="https://localhost:44334/Product/get"
    try {
        const response = await fetch(url, {
            method: 'GET',
            credentials: 'same-origin'
        });
        const exam = await response.json();
        return exam;
    } catch (error) {
        //alert(error);
    }
}

async function getAllProducts(){
    const products = await fetchAllProducts();
   // console.log(products);
    document.querySelectorAll('#AllProductsUpdate tbody tr').forEach(element => element.remove());
    let table = document.querySelector('#AllProductsUpdate tbody');
    for (let i = 0; i < products.length; ++i) {

        let row = table.insertRow(table.rows.length);
        let idCell = row.insertCell(0);
        idCell.innerHTML = products[i].productId;

        let nameCell = row.insertCell(1);
        nameCell.innerHTML = products[i].name;

        let priceCell = row.insertCell(2);
        priceCell.innerHTML = products[i].price;

        let descCell = row.insertCell(3);
        descCell.innerHTML = products[i].description;

    }

}

function addProduct() {

    let name = document.querySelector('#productName').value;
    let description = document.querySelector('#productDescription').value;
    let price = document.querySelector('#price').value;

    let url =`https://localhost:44334/Product/add/${name}/${price}/${description}`
    const response = fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        headers: {
            'Content-Type': 'application/json'
        },
        //body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    console.log(response.json()); // parses JSON response into native JavaScript objects

}

async function addToInventory(productId, locationId, quantity) {

    let url = `https://localhost:44334/Inventory/add/${productId}/${locationId}/${quantity}`
    try {
        await fetch(url, {
            method: 'POST',
        });
    } catch (error) {
        //alert(error);
    }
}

async function postInventoryItem() {
    let InventoryLocationId = document.querySelector('#InventoryLocation').value;
    let ProductInventoryId = document.querySelector('#ProductInventoryId').value;
    let InventoryQuantity = document.querySelector('#InventoryQuantity').value;
    await addToInventory(ProductInventoryId, InventoryLocationId, InventoryQuantity)
}



