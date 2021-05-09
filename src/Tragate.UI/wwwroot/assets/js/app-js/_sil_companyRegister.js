$(document).ready(function () {
    $("#btnCompanyRegister").on("click", function (e) {
        ga('send', {
            hitType: 'event',
            eventCategory: 'Create Company',
            eventAction: 'signup',
            eventLabel: 'Company Register'
        });
        e.preventDefault();

        var form = $("#registerForm");
        form.validate();

        if (form.valid()) {

            $(this).prop('disabled', true);
            $(this).addClass("loading");

            $.ajax({
                url: "/company/register",
                method: "POST",
                data: form.serialize(),
                dataType: "json"
            }).done(function (data, status) {
                if (data.success) {
                    $.get("/company/register-confirmed", function (data) {
                        window.scrollTo(0, 0);
                        $('#container').html(data);
                    });
                } else {
                    var html = "<ul class=\"ulErrors\">";
                    $("#btnRegister").removeClass("loading");
                    $("#btnRegister").removeAttr("disabled");
                    data.errors.forEach(element => {
                        html += "<li>" + element + "</li>";
                    });
                    html += "</ul>"
                    $("#result").html(html);
                    $("#result").css("color", "red");
                }
            });
        }
        return false;
    });
});