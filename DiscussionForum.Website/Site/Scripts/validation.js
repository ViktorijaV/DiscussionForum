function encodeHtml(value) {
    return $('<div/>').text(value).html();
}

function decodeHtml(value) {
    return $('<div/>').html(value).text();
}

function validateReportTopic() {
    if ($("[name$='listReportTopic']:checked").length == 0 && $("[id$='txtOther']").val() == "") {
        $("[id$='errorReportTopic']").show();
        $("[id$='errorReportTopic']").text("Please enter some reason why you want to report this topic.");
        return false;
    }

    if ($("[id$='txtOther']").val().length > 300) {
        $("[id$='errorReportTopic']").show();
        $("[id$='errorReportTopic']").text("The reason should be less than 300 charachters.");
        return false;
    }

    $("[id$='errorReportTopic']").text("");
    $("[id$='errorReportTopic']").hide();
    closeReportTopicModal();
    $("[id$='btnReportTopic']").trigger('click');
    openMessageModal("You have reported this topic. Admins are going to look into it and decide whether to delete it.");
}

function validateReportComment() {
    if ($("[name$='listReportComment']:checked").length == 0 && $("[id$='txtOtherReason']").val() == "") {
        $("[id$='errorReportComment']").show();
        $("[id$='errorReportComment']").text("Please enter some reason why you want to report this comment.");
        return false;
    }

    if ($("[id$='txtOtherReason']").val().length > 300) {
        $("[id$='errorReportComment']").show();
        $("[id$='errorReportComment']").text("The reason should be less than 300 charachters.");
        return false;
    }

    $("[id$='errorReportComment']").text("");
    $("[id$='errorReportComment']").hide();
    closeReportCommentModal();
    $("[id$='btnReportComment']").trigger('click');
    openMessageModal("You have reported this comment. Admins are going to look into it and decide whether to delete it.");
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
    $("[id$='txtContent']").val("");

    $("[id$='error']").text("");
    $("[id$='error']").hide();
    $("[id$='btnCreateComment']").trigger('click');
}

function validateEditComment() {

    if ($("[id$='txtContent']").val() == "") {
        $("[id$='editError']").show();
        $("[id$='editError']").text("Comment text is required. Please enter text.");
        return false;
    }
    $("[id$='txtContent']").val(encodeHtml($("[id$='txtComment']").val()));

    if ($("[id$='txtContent']").val().length > 5000) {
        $("[id$='editError']").show();
        $("[id$='editError']").text("Comment text is too long. Please enter smaller text.");
        return false;
    }

    tinymce.activeEditor.remove();
    $("[id$='txtContent']").val(encodeHtml($("[id$='txtContent']").val()));

    $("[id$='editError']").text("");
    $("[id$='editError']").hide();
    closeEditCommentModal();
    $("[id$='btnEditComment']").trigger('click');
}

function validateCreateTopic() {

    if ($("[id$='txtTitle']").val() == "") {
        $("[id$='error']").show();
        $("[id$='error']").text("Title is required. Please enter title.");
        return false;
    }

    if ($("[id$='txtTitle']").val().length > 50) {
        $("[id$='error']").show();
        $("[id$='error']").text("Title is too long. Please enter title that is smaller than 50 characters.");
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

function validateEditTopic() {

    if ($("[id$='txtEditTitle']").val() == "") {
        $("[id$='editTopicError']").show();
        $("[id$='editTopicError']").text("Name is required. Please enter name.");
        return false;
    }

    if ($("[id$='txtEditTitle']").val().length > 50) {
        $("[id$='editTopicError']").show();
        $("[id$='editTopicError']").text("Name is too long. Please enter name that is smaller than 50 characters.");
        return false;
    }

    if ($("[id$='txtEditDesc']").val() == "") {
        $("[id$='editTopicError']").show();
        $("[id$='editTopicError']").text("Description is required. Please enter description.");
        return false;
    }

    $("[id$='txtEditDesc']").val(encodeHtml($("[id$='txtEditDesc']").val()));

    if ($("[id$='txtEditDesc']").val().length > 5000) {
        $("[id$='editTopicError']").show();
        $("[id$='editTopicError']").text("Description is too long. Please enter smaller description.");
        return false;
    }

    tinymce.activeEditor.remove();
    $("[id$='txtEditDesc']").val(encodeHtml($("[id$='txtEditDesc']").val()));

    $("[id$='editTopicError']").text("");
    $("[id$='editTopicError']").hide();
    $("[id$='btnEditTopic']").trigger('click');
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

function validateChangeUserProperties() {

    if ($("[id$='txtFullName']").val() == "") {
        $("[id$='error']").show();
        $("[id$='error']").text("FullName is required. Please enter FullName");
        return false;
    }
    else if ($("[id$='txtFullName']").val().match(/([A-Za-z -]+){6,20}/) == null) {
        $("[id$='error']").show();
        $("[id$='error']").text("FullName must be at least 6 characters long and can consist of alphabetic characters, ‘-’ and whitespace only (no numbers or special characters are allowed)");
        return false;
    }

    if ($("[id$='txtBio']").val().length > 300) {
        $("[id$='error']").show();
        $("[id$='error']").text("Bio must be less than 300 chars.");
        return false;
    }

    $("[id$='error']").text("");
    $("[id$='error']").hide();
    event.preventDefault();
    $("[id$='btnSave']").trigger('click');
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

