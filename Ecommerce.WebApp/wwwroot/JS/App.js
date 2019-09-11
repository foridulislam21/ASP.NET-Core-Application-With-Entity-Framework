$(document).ready(function () {
    //Get Customer Form
    $("#createButton").click(function () {
        $.ajax({
            url: "/Customer/Create",
            method: "GET"
        })
            .done(function (response) {
                debugger;
                $("#contentModal").html(response);
            });
    });
});
//validation using jquery
function validate() {
    var isValid = true;
    if ($("#name").val().trim() === "") {
        $("#name").css("border-color", "red");
        isValid = false;
    } else {
        $("#name").css("border-color", "lightgray");
    }
    if ($("#address").val().trim() === "") {
        $("#address").css("border-color", "red");
        isValid = false;
    } else {
        $("#address").css("border-color", "lightgray");
    }
    if ($("#loyaltyPoints").val().trim() === "") {
        $("#loyaltyPoints").css("border-color", "red");
        isValid = false;
    } else {
        $("#loyaltyPoints").css("border-color", "lightgray");
    }
    return isValid;
}