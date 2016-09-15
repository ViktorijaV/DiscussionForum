function encodeHtml(value) {
    return $('<div/>').text(value).html();
}

function decodeHtml(value) {
    return $('<div/>').html(value).text();
}

function validateCreateComment() {

    if ($("[id$='txtComment']").val() == "") {
        $("[id$='error']").show();
        $("[id$='error']").text("Comment text is required. Please enter text.");
        return false;
    }
    $("[id$='txtComment']").val(encodeHtml($("[id$='txtComment']").val()));

    if ($("[id$='txtComment']").val().length > 5000) {
        $("[id$='error']").show();
        $("[id$='error']").text("Comment text is too long. Please enter smaller text.");
        return false;
    }

    tinymce.activeEditor.remove();
    $("[id$='txtComment']").val(encodeHtml($("[id$='txtComment']").val()));

    $("[id$='error']").text("");
    $("[id$='error']").hide();
    $("[id$='btnCreateComment']").trigger('click');
}

function validateCreateTopic() {

    if ($("[id$='txtTitle']").val() == "") {
        $("[id$='error']").show();
        $("[id$='error']").text("Name is required. Please enter name.");
        return false;
    }

    if ($("[id$='txtTitle']").val().length > 50) {
        $("[id$='error']").show();
        $("[id$='error']").text("Name is too long. Please enter name that is smaller than 50 characters.");
        return false;
    }

    if ($("[id$='txtDescription']").val() == "") {
        $("[id$='error']").show();
        $("[id$='error']").text("Description is required. Please enter description.");
        return false;
    }

    $("[id$='txtDescription']").val(encodeHtml($("[id$='txtDescription']").val()));

    if ($("[id$='txtDescription']").val().length > 5000) {
        $("[id$='error']").show();
        $("[id$='error']").text("Description is too long. Please enter smaller description.");
        return false;
    }

    tinymce.activeEditor.remove();
    $("[id$='txtDescription']").val(encodeHtml($("[id$='txtDescription']").val()));
    
    $("[id$='error']").text("");
    $("[id$='error']").hide();
    $("[id$='btnSubmit']").trigger('click');
}

function validateCreateCategory() {
    if ($("[id$='txtName']").val() == "") {
        $("[id$='error']").show();
        $("[id$='error']").text("Name is required. Please enter name.");
        return false;
    }

    if ($("[id$='txtColor']").val() == "") {
        $("[id$='error']").show();
        $("[id$='error']").text("Color is required. Please select color.");
        return false;
    }

    $("[id$='error']").text("");
    $("[id$='error']").hide();
    $("[id$='btnSubmit']").trigger('click');
}

function logout() {
    $('#btnLogOut').trigger('click');
}

function validateLogin() {
    if ($("#txtEmail").val() == "") {
        $("#error").show();
        $("#error").text("Email is required. Please enter email");
        return false;
    }
    else if ($("#txtEmail").val().match(/^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/) == null) {
        $("#error").show();
        $("#error").text("Email is not valid!");
        return false;
    }

    if ($("#txtPassword").val() == "") {
        $("#error").show();
        $("#error").text("Password is required. Please enter password");
        return false;
    }

    $("#error").text("");
    $("#error").hide();
    $('#btnLoginServer').trigger('click');
}

function validateRegister() {

    if ($("#txtEmail").val() == "") {
        $("#error").show();
        $("#error").text("Email is required. Please enter email");
        return false;
    }
    else if ($("#txtEmail").val().match(/^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/) == null) {
        $("#error").show();
        $("#error").text("Email is not valid!");
        return false;
    }

    if ($("#txtPassword").val() == "") {
        $("#error").show();
        $("#error").text("Password is required. Please enter password");
        return false;
    }
    else if ($("#txtPassword").val().match(/((?=.*\w)(?=.*[!#$%&'()*+,-./:;<=>?@[\]^_`{|}~]).{6,16})/) == null) {
        $("#error").show();
        $("#error").text("Password must be 6 characters long, also must have one alphanumeric character and one special character");
        return false;
    }
    else if ($("#txtPassword").val() != $("#txtRepeatPassword").val()) {
        $("#error").show();
        $("#error").text("Passwords doesn't match. Please reenter passwords");
        return false;
    }

    if ($("#txtFullName").val() == "") {
        $("#error").show();
        $("#error").text("FullName is required. Please enter FullName");
        return false;
    }
    else if ($("#txtFullName").val().match(/([A-Za-z -]+){6,20}/) == null) {
        $("#error").show();
        $("#error").text("FullName must be at least 6 characters long and can consist of alphabetic characters, ‘-’ and whitespace only (no numbers or special characters are allowed)");
        return false;
    }

    if ($("#txtBirthday").val() == "") {
        $("#error").show();
        $("#error").text("Please select your birthday!");
        return false;
    }

    $("#error").text("");
    $("#error").hide();
    $('#btnRegister').trigger('click');
}
