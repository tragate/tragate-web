var categoryId = 0;
$(function () {
    GetData(undefined, -1, -1);
    $(document).on('click', ".list-box ul li", function () {
        $(this).closest("ul").find("li").removeClass("active");
        var categoryParentId = $(this).closest(".list-box").data("id");
        var exist = -1;
        if ($("div[data-parent=" + categoryParentId + "]")[0]) {
            exist = categoryParentId;
        }

        var loader = "<i id=\"loader\" class=\"fa fa-spinner fa-spin\" style=\"font-size:20px;float: right;margin-top: 4px;\"></i>";

        $(this).append(loader);
        $(this).addClass("active");
        categoryId = $(this).attr("id");
        GetData(categoryId, exist, categoryParentId);
    });
});

var parentNumber = -1;

function GetData(categoryId, exist, parentNumber) {
    var url = "/category/get-categories";
    if (categoryId != undefined) {
        url += "?parentId=" + categoryId;
    }

    $.ajax({
        url: url,
        method: "GET",
        dataType: "json"
    }).done(function (data, status) {
        data = data.data;
        if (data.length > 0) {
            var html = "";
            if (exist == -1 || $("div[data-parent=" + exist + "]").hasClass("finish")) {
                $(".finish").remove();
                html += "<div class=\"list-box\"  data-parent=\"" + parentNumber++ + "\" data-id=\"" + parentNumber + "\">";
                html += "<ul>";
                $.each(data, function (i) {
                    html += "<li id=\"" + data[i].id + "\">" + data[i].value + "</li>";
                });
                html += "</ul>";
                html += "</div>";

                $(".x-scrollable").css("width", $(".x-scrollable").width() + 250);
                $("#setProductCategory").find(".x-scrollable").append(html);
                $("#loader").remove();
            }
            else {
                // buranın child varsa sil
                html += "<ul>";
                $.each(data, function (i) {
                    html += "<li id=\"" + data[i].id + "\">" + data[i].value + "</li>";
                });
                html += "</ul>";

                $("div[data-parent=" + exist + "]").html(html);
                $.each($("div.list-box"), function (i) {
                    if ($(this).attr("data-parent") > Number(exist)) {
                        $(this).remove();
                    }
                });
                $("#loader").remove();
            }
        }
        else {
            $("#loader").remove();
            var html = "";

            if (exist != -1) {
                $.each($("div.list-box"), function (i) {
                    if ($(this).attr("data-parent") >= Number(exist)) {
                        $(this).remove();
                    }
                });
            }
            html += "<div class=\"list-box finish\"  data-parent=\"" + parentNumber++ + "\" data-id=\"" + parentNumber + "\">";
            html += "<i class=\"fa fa-check\" style=\"font-size:32px;margin:0 auto; color:green;\"></i>";
            html += "<p>Category choose completed</p>";
            html += "<p id=\"next\"><button onclick='SaveCategory();' class=\"btn btn-success\">Save Category</button></p>";
            html += "</div>";
            $(".x-scrollable").css("width", $(".x-scrollable").width() + 250);
            $("#setProductCategory").find(".x-scrollable").append(html);
            var leftPos = $("#setProductCategory").find(".x-scrollable").scrollLeft();
            $("#setProductCategory").animate({ scrollLeft: 320 }, 800);

        }
    });
}

function SaveCategory() {
    var companyId = $("#companyId").val();
    var productId = $("#productId").val();

    $.ajax({
        type: 'POST',
        url: '/companyadmin/EditCategory',
        data: {
            'CompanyId': companyId,
            'ProductId': productId,
            'CategoryId': categoryId
        }
    }).done(function (response) {
        if (response.success) {
            window.location.href = '/companyadmin/product-edit/' + companyId + '/' + productId;
        }
        else {
            toastr["info"](response.message);
        }
    });
}