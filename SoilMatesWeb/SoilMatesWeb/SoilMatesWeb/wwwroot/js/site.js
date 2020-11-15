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


function getAllProducts() {
    let url ="https://localhost:44334/Product/get"
    const response = fetch(url, {
        method: 'GET', // *GET, POST, PUT, DELETE, etc.
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    console.log(response.json()); // parses JSON response into native JavaScript objects
}

function addProduct() {
    alert('Here');

    
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



