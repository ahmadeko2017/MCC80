// $(document).ready(function () {
//     let table = new DataTable('#myTable', {
//         ajax: {
//             url: "https://swapi.dev/api/people/",
//             dataSrc: "results",
//             dataType: "JSON"
//         },
//         columns: [
//             { data: "name" },
//             { data: "name" },
//             {
//                 data: 'height',
//                 render: function (data, type, row) {
//                     return data+" Cm";
//                 }
//             },
//             {
//                 data: '',
//                 render: function (data, type, row) {
//                     return `<button onclick="detailSW('${row.url}')" data-bs-toggle="modal" data-bs-target="#modalSW" class="btn btn-primary">Detail</button>`;
//                 }
//             }
//         ]
//     });
// });

async function login() {
    const loginData = {
        email: "john.doe@example.com",
        password: "@Doe1234",
    };

    const endpoint = "https://localhost:7156/api/accounts/login";

    try {
        const response = await fetch(endpoint, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(loginData),
        });

        if (response.ok) {
            const responseData = await response.json();

            // Store the data in an object
            return {
                code: responseData.code,
                status: responseData.status,
                message: responseData.message,
                data: responseData.data,
            };
        } else {
            console.log("Login failed with status:", response.status);
            return null;
        }
    } catch (error) {
        console.error("Error during login:", error);
        return null;
    }
}

// Usage:
login()
    .then((loginResponse) => {
        if (loginResponse) {
            console.log("Login successful!");
            console.log("Token:", loginResponse.data.token);
            // getEmployeeDetails(loginResponse.data.token)
            getDataTables(loginResponse.data.token);
            let result =  loginResponse.data.token;
        } else {
            console.log(loginResponse);
            console.log("Login failed!");
        }
    })
    .catch((error) => {
        console.error("Error during login:", error);
    });

async function getEmployeeDetails(token) {
    const endpoint = "https://localhost:7156/api/employees/detail";

    try {
        const response = await fetch(endpoint, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                // Include the Authorization header with the token
                Authorization: `Bearer ${token}`,
            },
        });

        if (response.ok) {
            const responseData = await response.json();
            return responseData;
        } else {
            console.log(
                "Failed to get employee details with status:",
                response.status,
            );
            return null;
        }
    } catch (error) {
        console.error("Error getting employee details:", error);
        return null;
    }
}
function getDataTables(token) {
    // let i = 0;
    // Define the DataTable initialization options outside of the document.ready function
    const dataTableOptions = {
        ajax: {
            url: "https://localhost:7156/api/employees/detail",
            dataSrc: "data", // Use "data" instead of "results" to access the array directly
            dataType: "JSON",
            headers: {
                "Content-Type": "application/json",
                // Include the Authorization header with the token
                Authorization: `Bearer ${token}`,
            },
        },
        columns: [
            {
                data: "id",
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                    // return i++;
                },
            },
            { data: "nik" },
            { data: "fullName" },
            {
                data: "birthDate",
                render: function (data, type, row) {
                    // Parse the date string to a JavaScript Date object
                    const dateObj = new Date(data);

                    // Format the date as "DD/MM/YYYY"
                    return dateObj.toLocaleDateString("en-GB");
                },
            },
            {
                data: "gender",
                render: function (data, type, row) {
                    return data ? "perempuan" : "laki-laki";
                },
            },
            { 
                data: '',
                render: function (data, type) {
                return ``
                }
            }
            
            // {
            //     data: "hiringDate",
            //     render: function (data, type, row) {
            //         // Parse the date string to a JavaScript Date object
            //         const dateObj = new Date(data);
            //
            //         // Format the date as "DD/MM/YYYY"
            //         return dateObj.toLocaleDateString("en-GB");
            //     },
            // },
            // { data: "email" },
            // { data: "phoneNumber" },
            // { data: "major" },
            // { data: "degree" },
            // { data: "gpa" },
            // { data: "universityName" },
        ],
    };

    // Initialize DataTable inside the document.ready function
    $(document).ready(function () {
        let table = $("#myTable").DataTable(dataTableOptions);
    });
}


async function register(data) {
    const endpoint = "https://localhost:7156/api/accounts/register";

    try {
        const response = await fetch(endpoint, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data),
        });

        if (response.ok) {
            // Parse the response body as JSON data
            const responseData = await response.json();

            // Use the parsed JSON data as needed
            console.log("Registration Success:", responseData);

            // You can display an alert or perform other actions here
            appendAlert(`Registration Success - ${responseData}`, 'success');
            setTimeout(() => {
                window.location.href = "https://localhost:7097/DataTable";
            }, 3000); // Delay of 2000 milliseconds (2 seconds)
        } else {
            console.log("Registration failed with status:", response.status);
            // Display an alert or perform actions for failed registration
            appendAlert('Registration Failed', 'danger');
            setTimeout(() => {
                window.location.href = "https://localhost:7097/DataTable";
            }, 3000); // Delay of 2000 milliseconds (2 seconds)
        }
    } catch (error) {
        console.error("Error during login:", error);
        // Display an alert or perform actions for error during registration
        appendAlert('Registration Failed', 'danger');
    }
}

document.getElementById('sendMessageBtn').addEventListener('click', function () {
    // Get the form values
    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    const birthDate = document.getElementById('birthDate').value;
    const gender = document.getElementById('gender').value;
    const hiringDate = document.getElementById('hiringDate').value;
    const email = document.getElementById('email').value;
    const phoneNumber = document.getElementById('phoneNumber').value;
    const major = document.getElementById('major').value;
    const degree = document.getElementById('degree').value;
    const gpa = parseFloat(document.getElementById('gpa').value);
    const universityCode = document.getElementById('universityCode').value;
    const universityName = document.getElementById('universityName').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;

    // Construct the data object to be sent to the API
    const data = {
        "firstName": firstName,
        "lastName": lastName,
        "birthDate": birthDate,
        "gender": parseInt(gender),
        "hiringDate": hiringDate,
        "email": email,
        "phoneNumber": phoneNumber,
        "major": major,
        "degree": degree,
        "gpa": gpa,
        "universityCode": universityCode,
        "universityName": universityName,
        "password": password,
        "confirmPassword": confirmPassword
    };

    // Call the register function with the data
    register(data)
        .then(result => {
            if (result.ok){
                console.log(result.json())
            }
        })
        .catch(error => {
            console.error("Error during registration:", error);
            // Handle errors here, if any occurred during the registration process.
        });
});

const alertPlaceholder = document.getElementById('liveAlertPlaceholder')
const appendAlert = (message, type) => {
    const wrapper = document.createElement('div')
    wrapper.innerHTML = [
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
        '</div>'
    ].join('')

    alertPlaceholder.append(wrapper)
}

function closeModal(id) {
    // Get the modal element
    const modalElement = document.getElementById(id);
    // Hide the modal using the Bootstrap's 'hide' method
    const modal = new bootstrap.Modal(modalElement);
    modal.hide();
}
