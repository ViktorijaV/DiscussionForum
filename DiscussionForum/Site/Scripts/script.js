$(document).ready(function () {

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
        $(".nav-pills>li.active").removeClass("active");
        $navpill.addClass("active");
    });
    $("#top").click(function () {
        var $navpill = $(this);
        table.order([4, 'desc']).draw();
        $(".nav-pills>li.active").removeClass("active");
        $navpill.addClass("active");
    });
    $("#most-popular").click(function () {
        var $navpill = $(this);
        table.order([3, 'desc']).draw();
        $(".nav-pills>li.active").removeClass("active");
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