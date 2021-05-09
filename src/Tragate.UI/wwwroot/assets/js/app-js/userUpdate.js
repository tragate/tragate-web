$(document).ready(function () {
    $("#languages").kendoDropDownList({
        optionLabel: "Select",
        dataTextField: "value",
        dataValueField: "id",
        dataSource: {
            transport: {
                read: {
                    url: "",
                    dataType: 'json'
                }
            },
            schema: {
                type: "json",
                data: "data"
            }
        }
    }).data("kendoDropDownList");

    $("#timezones").kendoDropDownList({
        optionLabel: "Select",
        dataTextField: "value",
        dataValueField: "id",
        dataSource: {
            transport: {
                read: {
                    url: "",
                    dataType: 'json'
                }
            },
            schema: {
                type: "json",
                data: "data"
            }
        }
    }).data("kendoDropDownList");
});