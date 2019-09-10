//Get Customer Form
$("#createButton").click(function () {
    $.ajax({
        url: "Customer/Create",
        method: "get"
    })
        .done(function (response) {
            debugger;
            $("#contentModal").html(response);
        });
});

//Post Customer Form
//$("#saveButton").click(function () {
//    $.ajax({
//        url: "Customer/Create",
//        method: "post",
//        data: $("#createForm").serialize()
//    }).done(function (response) {
//        debugger;
//        $("#listArea").html(response);
//    });
//});