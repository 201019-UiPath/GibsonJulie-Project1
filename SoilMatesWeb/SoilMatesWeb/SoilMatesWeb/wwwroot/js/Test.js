
function GetAllCustomers() {
    fetch('https://localhost:44334/Customer/get')
        .then(response => response.json())
        .then(result => {
            document.querySelectorAll('#customers tbody tr').forEach(element => element.remove());
            let table = document.querySelector('#customers tbody');
            for (let i = 0; i < result.length; ++i) {
                
                    let row = table.insertRow(table.rows.length);
                    let nameCell = row.insertCell(0);
                    nameCell.innerHTML = result[i].name;

                    let emailCell = row.insertCell(1);
                    emailCell.innerHTML = result[i].email;  
            }
        });
}


function SignUp() {
    let user = {};
    user.name = document.querySelector('#name').value;
    user.email = document.querySelector('#email').value;
    user.password = document.querySelector('#password').value;

    fetch('https://localhost:44334/Customer/add', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    })
        .then(response => response.json())
        .then(data => {
        
        });
}


function Login(userType) {
    let user = {};
    user.email = document.querySelector('#email').value;
    user.password = document.querySelector('#password').value;

    fetch(`https://localhost:44334/${userType}/get/${user.email}`)
        .then(respose => respose.json())
        .then(result => {
            if (user.email == result.email && user.password == result.password) {
                alert('Welcome Back');
            }
            else {
                alert('Something went wrong, redirecting you to main page.')
                location.href = 'https://localhost:44389/Home';
            }
        });
}


function GetAllLocations() {
    fetch(`https://localhost:44334/Location/get/`)
        .then(respose => respose.json())
        .then(result => {
            document.querySelectorAll('#AllLocations tbody tr').forEach(element => element.remove());
            let table = document.querySelector('#AllLocations tbody');
            for (let i = 0; i < result.length; ++i) {

                let row = table.insertRow(table.rows.length);
                let idCell = row.insertCell(0);
                idCell.innerHTML = result[i].locationId;

                let nameCell = row.insertCell(1);
                nameCell.innerHTML = result[i].name;

                let addrCell = row.insertCell(2);
                addrCell.innerHTML = result[i].address;
            }
        })
}

function GetOrders(sort, email) {
    fetch(`https://localhost:44334/Order/get/Customer/${email}/${sort}`)
        .then(respose => respose.json())
        .then(result => {
            document.querySelectorAll('#order tbody tr').forEach(element => element.remove());
            let table = document.querySelector('#order tbody');
            for (let i = 0; i < result.length; ++i) {
                let row = table.insertRow(table.rows.length);
                let idCell = row.insertCell(0);
                idCell.innerHTML = result[i].locationId;

                let addrCell = row.insertCell(1);
                addrCell.innerHTML = result[i].address;

                let timeCell = row.insertCell(2);
                timeCell.innerHTML = result[i].orderTime;

                let priceCell = row.insertCell(3);
                priceCell.innerHTML = '$' + result[i].totalPrice

                for (let j = 0; j < result[i].length; ++j) {
                    let rowInner = table.insertRow(table.rows.length);
                }
            }
        })
}

function GetAllInventory() {
    fetch(`https://localhost:44334/Inventory/get/`)
        .then(respose => respose.json())
        .then(result => {
            document.querySelectorAll('#AllInventory tbody tr').forEach(element => element.remove());
            let table = document.querySelector('#AllInventory tbody');
            for (let i = 0; i < result.length; ++i) {

                let row = table.insertRow(table.rows.length);
                let idCell = row.insertCell(0);
                idCell.innerHTML = result[i].locationForeignId;

                let pidCell = row.insertCell(1);
                pidCell.innerHTML = result[i].productForeingId;

                let nameCell = row.insertCell(2);
                nameCell.innerHTML = result[i].product.name;

                let addrCell = row.insertCell(3);
                addrCell.innerHTML = result[i].quantity;
            }
        })
}




