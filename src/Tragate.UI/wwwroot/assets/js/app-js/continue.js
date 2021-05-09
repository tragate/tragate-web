
$(function () {
    $('.userTypeCard .i-checks').click(function () {
        $('.userTypeCard .i-checks').removeClass('active');
        $(this).addClass('active');
    })
    $("#btnContinue").on("click", function (e) {
        e.preventDefault();
        var choice = parseInt($('input[name=choice]:checked').val());
        var personId = $("#personId").val();

        switch (choice) {
            case 1:
                window.location.href = "/";
                break;
            case 2:
                // $.get("/company/register", 
                //     function (data) {
                //         $('#container').html(data);
                // });
                // window.location.href = "/company/register";
                window.location.replace("/company/register")
                break;
            case 3:
                window.location.href = "/User";
                break;
            default:
                return false;
        }
        
    });
});
