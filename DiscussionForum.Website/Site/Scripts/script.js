$(document).ready(function () {

    //preloader
    $(window).load(function () {
        $("#loading").delay(1000).fadeOut(500);
    })

    if ($("#error").text() != "") {
        $("#error").show();
    }

    if ($("[id$='error']").text() != "") {
        $("[id$='error']").show();
    }

    if ($("[id$='editError']").text() != "") {
        $("[id$='editError']").show();
    }

    $(".edit-comment").click(function () {
        var id = $(this).parent().find(".comment-id").val();
        $("[id$='commentID']").val(id);
        $('#editCommentModal').modal('show');
        tinymce.activeEditor.remove();
        $("[id$='txtContent']").val($(this).parent().find(".media-comment").html());
        initializeEditor();
    });

    $(".report-comment").click(function () {
        var id = $(this).parent().find(".comment-id").val();
        $("[id$='commentID']").val(id);
        $('#reportCommentModal').modal('show');
    });


    //Text Editor
    initializeEditor();


    //Add thead to DataTable
    var table = document.getElementById("ContentPlaceHolder1_tableTopics");
    if (table != null) {
        var header = table.createTHead();
        var row = header.insertRow(0);
        var cell = row.insertCell(0);
        cell.innerHTML = "<b>Topic</b>";
        cell.className = "sorter-false";
        var cell = row.insertCell(1);
        cell.innerHTML = "<b>Category</b>";
        cell.className = "sorter-false";
        var cell = row.insertCell(2);
        cell.innerHTML = "<b>Creator</b>";
        cell.className = "sorter-false";
        var cell = row.insertCell(3);
        cell.innerHTML = "<b>Likes</b>";
        cell.className = "sorter-false";
        var cell = row.insertCell(4);
        cell.innerHTML = "<b>Replies</b>";
        cell.className = "sorter-false";
        var cell = row.insertCell(5);
        cell.innerHTML = "<b>Created</b>";
        cell.className = "sorter-false";
        var cell = row.insertCell(6);
        cell.innerHTML = "<b>Activity</b>";
        cell.className = "sorter-false";
        var cell = row.insertCell(7);
        cell.innerHTML = "<b>DateCreated</b>";
        cell.style.display = "none";


        //DataTable
        var table = $("#ContentPlaceHolder1_tableTopics").DataTable({
            bLengthChange: false,
            bInfo: false,
            order: [7, "asc"]
        });


        //Disable events of thead in DataTable
        $('.sorter-false').off();


        //Sort DataTable
        $("#latest").click(function () {
            var $navpill = $(this);
            table.order([7, 'asc']).draw();
            $(".nav-tabs>li.active").removeClass("active");
            $navpill.addClass("active");
        });
        $("#top").click(function () {
            var $navpill = $(this);
            table.order([4, 'desc']).draw();
            $(".nav-tabs>li.active").removeClass("active");
            $navpill.addClass("active");
        });
        $("#most-popular").click(function () {
            var $navpill = $(this);
            table.order([3, 'desc']).draw();
            $(".nav-tabs>li.active").removeClass("active");
            $navpill.addClass("active");
        });


        //Select rows with selected category in DataTable
        $("#ContentPlaceHolder1_ddlCategories").change(function () {
            if ($("#ContentPlaceHolder1_ddlCategories option:selected").val() == 0) {
                table.columns(1).search("").draw();
            }
            else {
                table.columns(1).search($("#ContentPlaceHolder1_ddlCategories option:selected").html()).draw();
            }
        });
    }

});


function initializeEditor() {
    tinymce.init({
        selector: 'textarea',
        height: '250',
        plugins: 'codesample link emoticons paste',
        toolbar1: 'undo redo | styleselect | alignleft aligncenter alignright | bullist numlist ',
        toolbar2: 'bold italic codesample | link | emoticons | forecolor backcolor',
        menubar: false,
        statusbar: false,
        browser_spellcheck: true,
        paste_remove_styles: true,
        paste_as_text: true,
        setup: function (editor) {
            editor.on('change', function () {
                tinymce.triggerSave();
            });
        },
        codesample_languages: [
              { text: 'HTML/XML', value: 'markup' },
              { text: 'JavaScript', value: 'javascript' },
              { text: 'CSS', value: 'css' },
              { text: 'PHP', value: 'php' },
              { text: 'Ruby', value: 'ruby' },
              { text: 'Python', value: 'python' },
              { text: 'Java', value: 'java' },
              { text: 'C', value: 'c' },
              { text: 'C#', value: 'csharp' },
              { text: 'C++', value: 'cpp' },
              { text: 'Other', value: 'txt' }
        ]
    });

}

function openMessageModal(message) {
    $("[id$='messageInModal']").text(message);
    $('#messageModal').modal('show');
}

function closeReportTopicModal() {
    $("[id$='errorReportTopic']").text("");
    $("[id$='errorReportTopic']").hide();
    $('#reportTopicModal').modal('hide');
}

function closeReportCommentModal() {
    $("[id$='errorReportTopic']").text("");
    $("[id$='errorReportTopic']").hide();
    $('#reportCommentModal').modal('hide');
}

function closeEditCommentModal() {
    $("[id$='editError']").text("");
    $("[id$='editError']").hide();
    $('#editCommentModal').modal('hide');
}

function likeComment(button) {
    var id = $(button).parent().find(".comment-id").val();
    $("[id$='commentID']").val(id);
    $("[id$='txtContent']").val("");
    event.preventDefault();
    $("[id$='btnLikeComment']").trigger('click');
}

function unlikeComment(button) {
    var id = $(button).parent().find(".comment-id").val();
    $("[id$='commentID']").val(id);
    $("[id$='txtContent']").val("");
    event.preventDefault();
    $("[id$='btnUnlikeComment']").trigger('click');
}


function pageLoad() {

    initializeEditor();

    if ($("#error").text() != "") {
        $("#error").show();
    }

    if ($("[id$='error']").text() != "") {
        $("[id$='error']").show();
    }

    if ($("[id$='editError']").text() != "") {
        $("[id$='editError']").show();
    }

    $("[id$='txtContent']").val("");

    $(".edit-comment").click(function () {
        var id = $(this).parent().find(".comment-id").val();
        $("[id$='commentID']").val(id);
        $('#editCommentModal').modal('show');
        tinymce.activeEditor.remove();
        $("[id$='txtContent']").val($(this).parent().find(".media-comment").html());
        initializeEditor();
    });

    $(".report-comment").click(function () {
        var id = $(this).parent().find(".comment-id").val();
        $("[id$='commentID']").val(id);
        $('#reportCommentModal').modal('show');
    });
}