$(function () {
    $("#btnSignUp").on("click", function (e) {
        e.preventDefault();
        $("label.error").text("").hide();

        var form = $("#signUpForm");
        form.validate();
        if (form.valid()) {
            $(this).prop('disabled', true);
            $(this).addClass("loading");

            $.ajax({
                url: "/account/Signup",
                method: "POST",
                data: form.serialize(),
                dataType: "json"
            }).done(function (data, status) {
                if (data.url) {
                    window.location.href = data.url;
                }
                else {
                    if (data.success) {
                        $.get("/account/SignUpConfirmation", function (data) {
                            window.scrollTo(0, 0);
                            $('#container').html(data);
                        });
                    } else {
                        var html = "<ul class=\"ulErrors\">";
                        $("#btnSignUp").removeClass("loading");
                        $("#btnSignUp").removeAttr("disabled");
                        data.errors.forEach(element => {
                            html += "<li>" + element + "</li>";
                        });
                        html += "</ul>";
                        $("#result").html(html);
                        $("#result").css("color", "red");
                    }
                }
            });
        }
        return false;
    });
});
