const firstnameEl = document.querySelector('#txtFirstName');
const lastnameEl = document.querySelector('#txtLastName');
const emailEl = document.querySelector('#txtEmail');
const passwordEl = document.querySelector('#txtPassword');
const confirmpasswordEl = document.querySelector('#txtConfirmPassword');
const dobEl = document.querySelector('#txtDOB');
const typeofuserE1 = document.querySelector('#txttype');



const form = document.querySelector('#signup');


const checkFirstName = () => {

    let valid = false;

    const min = 3,
        max = 20;

    const firstname = firstnameEl.value.trim();

    if (!isRequired(firstname)) {
        showError(firstnameEl, 'First Name cannot be blank.');
    } else if (!isBetween(firstname.length, min, max)) {
        showError(firstnameEl, `firstname must be between ${min} and ${max} characters.`)
    } else {
        showSuccess(firstnameEl);
        valid = true;
    }
    return valid;
};

const checkLastName = () => {

    let valid = false;

    const min = 3,
        max = 20;

    const lastname = lastnameEl.value.trim();

    if (!isRequired(lastname)) {
        showError(lastnameEl, 'Last Name cannot be blank.');
    } else if (!isBetween(lastname.length, min, max)) {
        showError(lastnameEl, `lastname must be between ${min} and ${max} characters.`)
    } else {
        showSuccess(lastnameEl);
        valid = true;
    }
    return valid;
};


const checkEmail = () => {
    let valid = false;
    const email = emailEl.value.trim();
    if (!isRequired(email)) {
        showError(emailEl, 'Email cannot be blank.');
    } else if (!isEmailValid(email)) {
        showError(emailEl, 'Email is not valid.')
    } else {
        showSuccess(emailEl);
        valid = true;
    }
    return valid;
};

const checkPassword = () => {
    let valid = false;


    const password = passwordEl.value.trim();

    if (!isRequired(password)) {
        showError(passwordEl, 'Password cannot be blank.');
    } else if (!isPasswordSecure(password)) {
        showError(passwordEl, 'Password must has at least 8 characters that include at least 1 lowercase character, 1 uppercase characters, 1 number, and 1 special character in (!@#$%^&*)');
    } else {
        showSuccess(passwordEl);
        valid = true;
    }

    return valid;
};

const checkConfirmPassword = () => {
    let valid = false;
    // check confirm password
    const confirmpassword = confirmpasswordEl.value.trim();
    const password = passwordEl.value.trim();

    if (!isRequired(confirmpassword)) {
        showError(confirmpasswordEl, 'Please enter the password again');
    } else if (password !== confirmpassword) {
        showError(confirmpasswordEl, 'The password does not match');
    } else {
        showSuccess(confirmpasswordEl);
        valid = true;
    }

    return valid;
};

const isEmailValid = (email) => {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
};

const isPasswordSecure = (password) => {
    const re = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})");
    return re.test(password);
};

const isRequired = value => value === '' ? false : true;
const isBetween = (length, min, max) => length < min || length > max ? false : true;


const showError = (input, message) => {
    // get the form-field element
    const formField = input.parentElement;
    // add the error class
    formField.classList.remove('success');
    formField.classList.add('error');

    // show the error message
    const error = formField.querySelector('small');
    error.textContent = message;
};

const showSuccess = (input) => {
    // get the form-field element
    const formField = input.parentElement;

    // remove the error class
    formField.classList.remove('error');
    formField.classList.add('success');

    // hide the error message
    const error = formField.querySelector('small');
    error.textContent = '';
};

form.addEventListener('input', function (e) {
    switch (e.target.id) {
        case 'txtFirstName':
            checkFirstName();
            break;
        case 'txtLastName':
            checkLastName();
            break;
        case 'txtEmail':
            checkEmail();
            break;
        case 'txtPassword':
            checkPassword();
            break;
        case 'txtConfirmPassword':
            checkConfirmPassword();
            break;
    }
});


form.addEventListener('submit', function (e) {
    e.preventDefault();
    let isFirstNameValid = checkFirstName(),
        isLastNameValid = checkLastName(),
        isEmailValid = checkEmail(),
        isPasswordValid = checkPassword(),
        isConfirmPasswordValid = checkConfirmPassword();



    let isFormValid = isFirstNameValid &&
        isLastNameValid &&
        isEmailValid &&
        isPasswordValid &&
        isConfirmPasswordValid;

    // submit to the server if the form is valid
    if (isFormValid) {
        $.ajax({
            url: 'https://localhost:44377/api/Account/register',
            method: 'POST',
            /*data: model,*/
            data: {
                firstname: $('#txtFirstName').val(),
                lastname: $('#txtLastName').val(),
                email: $('#txtEmail').val(),
                password: $('#txtPassword').val(),
                dob: $('#txtDOB').val(),
                typeofuser: $('#txttype').val()

            },
            //success: function () {
            //    alert("registration Sucessfully!!!")
             
            //},



            success: function () {
                //$('#successModal').modal('show');
                $.ajax({
                    url: 'https://localhost:44377/api/account/Login',
                    method: 'POST',
                    data: {
                        email: $('#txtEmail').val(),
                        password: $('#txtPassword').val()
                    },
                    success: function (res) {
                        window.location.href = res.RedirectUrl;
                    },
                    error: function (jqXHR) {
                        //$('#divErrorText').text(jqXHR.responseText);
                        //$('#divError').show('fade');
                        $("#validation-success").html("<div class='k-messagebox k-messagebox-error'>Wrong Password or Username</div>");
                    }
                });
            },
            error: function (jqXHR) {
                //$('#divErrorText').text(jqXHR.responseText);
                //$('#divError').show('fade');
                $("#validation-success").html("<div class='k-messagebox k-messagebox-error'>Some Internal Error</div>");
            }



        });
      
    }
});

