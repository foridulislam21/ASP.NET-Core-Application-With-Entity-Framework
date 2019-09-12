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
    $(".deleteButton").click(function () {
        var result = confirm("Are you sure!");
        debugger;
        if (result === true) {
            $.ajax({
                url: "Customer/Delete",
                method: "POST",
                data: {
                    id: $(this).attr("data-id")
                }
            }).done(function (response) {
                debugger;
                $("#listArea").html(response);
            });
        }
    });
});