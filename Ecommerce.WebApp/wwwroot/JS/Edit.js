$(document).ready(function () {
    $(".editButton").click(function () {
        debugger;
        $("#createModal").modal("show");
        $.ajax({
            url: "/Customer/Edit",
            method: "GET",
            data: {
                id: $(this).attr("data-id")
            }
        }).done(function (response) {
            $("#contentModal").html(response);
        });
    });
});