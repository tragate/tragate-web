$(function () {
    var productData = $('.type-page').data();
    $("#files").kendoUpload({
        async: {
            autoUpload: false,
            saveUrl: "/companyadmin/image-upload/" + productData.uuid + "/" + productData.id,
            allowmultiple: true
        },
        validation: {
            maxFileSize: 7000000,
            allowedExtensions: [".gif", ".jpg", ".png", ".jpeg"]
        },
        success: function (result) {
            if (result.response.success) {
                toastr['success'](result.response.message);
                GetProductImages(productData.productid);
                $("#btnComplete").show();
            } else {
                toastr['error'](result.response.errors.join('<br/>'));
            }
        },
        error: function (result) {
            toastr['error']("Fatal error");
        },
        select: function (e) {
            addPreview(e.files, $("#imageList"));
        },
        clear: function (e) {
            $(".img-container").each(function (item) {
                if ($(this).data("productid") == undefined)
                    $(this).fadeOut();
            });
        }

    });

    if (productData.mode == 1) {
        GetProductImages(productData.productid);
    }

});

function addPreview(files, wrapper) {

    if (files.length > 0) {
        $.each(files, function () {
            var reader = new FileReader();
            var raw = this.rawFile;
            reader.onloadend = function () {
                var preview = '<div class="img-container">';
                preview += '<i class="fa fa-close"></i>';
                preview += '<img class="image-preview" src="' + this.result + '"/>';
                preview += '</div>';
                wrapper.append(preview);
            };
            reader.readAsDataURL(raw);
        });
        $("#result").text('');

    }
}

function GetProductImages(productId) {
    $.ajax({
        url: "/companyadmin/get-product-images/" + productId,
        method: "POST",
        dataType: "json"
    }).done(function (data, status) {
        if (data != null) {
            $("#imageList").html('');
            var preview = '';
            $.each(data, function () {
                preview += '<div class="img-container" data-productId="' + this.id + '">';
                preview += '<i class="fa fa-close" onclick="DeleteImage(' + this.id + ',this)"></i>';
                preview += '<i class="fa fa-star" onclick="SetShowCase(' + this.id + ',' + productId + ',this)"></i>';
                preview += '<img class="image-preview" src="' + this.path + '"/>';
                preview += '</div>';
            });
            $("#imageList").html(preview);

        }
        else {
            toastr['error'](data.errors[0]);
        }
    });
}

function DeleteImage(id, that) {
    $(that).parent('.img-container').hide();
    $.ajax({
        url: "/companyadmin/delete-product-images/" + id,
        method: "POST",
        dataType: "json"
    }).done(function (data, status) {
        if (data.success) {
            $(that).parent('.img-container').remove();
            toastr['success'](data.message);
        } else {
            toastr['error'](data.errors[0]);
            $(that).parent('.img-container').show();
        }
    });
}

function SetShowCase(id, productId, that) {
    $.ajax({
        url: "/companyadmin/product-update-list-image/",
        type: "POST",
        dataType: "json",
        data: {
            'imageId': id,
            'productId': productId
        }
    }).done(function (data, status) {
        if (data.success) {
            $('#imageList .img-container .fa-star').removeClass('active');
            $(that).addClass('active');
            toastr['success'](data.message);
        } else {
            toastr['error'](data.errors[0]);
        }
    });
}