
function RemoveCompanyAdmin(id) {
    $.ajax({
        type: 'POST',
        url: '/companyadmin/delete',
        data: {
            'id': id
        }
    }).done(function (response) {
        if (response !== null) {
            if (response.success) {
                toastr.success(response.message);
                setTimeout(function () {
                    location.reload();
                }, 1000);
            }
            else {
                toastr.error(response.errors[0]);
            }
        }
        else {
            toastr.error('İşleminiz gerçekleşmedi');
        }
    });
}