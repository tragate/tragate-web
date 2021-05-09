$(function () {
    $("#btnSend").on("click", function (e) {
        e.preventDefault();
        var form = $("#forgotForm");
        form.validate();
        if (form.valid()) {
            $(this).prop('disabled', true);
            $(this).addClass("loading");
            $.post("/account/ForgotPassword", form.serialize(), function (data, status) {
                

                $("#result").empty();
                if (data.url) {
                    window.location.href = data.url;
                } else {
                    if (data.success) {
                        $(".ibox-content").empty();
                        $.get("/account/forgot-password-confirmation", function (data) {
                            $(".ibox-content").html(data);
                        });
                    } else {
                        var html = "<ul class=\"ulErrors\">";
                        $("#btnSend").removeAttr("disabled");
                        $('#btnSend').removeClass("loading");
                        data.errors.forEach(element => {
                            html += "<li>" + element + "</li>";
                        });
                        html += "</ul>"
                        $("#result").html(html);
                        $("#result").css("color", "red");
                    }
                }
            });
        }
        return false;
    });
});