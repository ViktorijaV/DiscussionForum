$(document).ready(function () {
    //check if js file work: console.log("ready!");
    // try to get user's location (country)
    $.get("http://ipinfo.io", function (response) { // All the info: $("#details").html(JSON.stringify(response, null, 4));
        //ako sakame samo IP-to: $("#ip").html("IP: " + response.ip);
        $("#location").html(response.city + ", " + response.region);
        $("#country").html(response.country);
    }, "jsonp");
});