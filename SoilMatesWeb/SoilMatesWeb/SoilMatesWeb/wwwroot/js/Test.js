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

                    let descriptionCell = row.insertCell(1);
                    descriptionCell.innerHTML = result[i].email;  
            }
        });
}

function Login() {
    let user = {};
    user.email = document.querySelector('#email').value;
    user.password = document.querySelector('#password').value;

    fetch(`https://localhost:44334/Customer/get/${user.email}`)
        .then(respose => respose.json())
        .then(result => {
            if (user.email == result.email && user.password == result.password) {
                alert('success');
            }
            else {
                alert('unsucessful')
                location.href = 'https://localhost:44389/Home';
            }
        })
}
