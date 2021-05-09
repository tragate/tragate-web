$(function () {
    $("#btnSave").on("click", function (e) {
        e.preventDefault();
        var form = $("#resetForm");
        form.validate();
        if (form.valid()) {
            $(this).prop('disabled', true);
            $(this).text("Saving");

            $.post("/account/ResetPassword", form.serialize(), function (data, status) {
                $(this).removeAttr("disabled");
                $(this).text("Save");
                $("#result").empty();
                if (data.success) {
                    $(".ibox-content").empty();
                    $.get("/account/reset", function (data) {
                        $(".ibox-content").html(data);
                    });
                } else {
                    $("#result").css("color", "red");
                    $("#result").text(data.message);
                }
            });
        }
        return false;
    });
});