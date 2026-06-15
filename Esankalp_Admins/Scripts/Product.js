var SaveProduct = function () {

    var model = {

        ProductName: $("#txtProductName").val(),
        Category: $("#ddlCategory").val(),
        Price: $("#txtPrice").val(),
        Status: $("#ddlStatus").val(),
        Description: $("#txtDescription").val()

    };

    $.ajax({

        url: "/AddProduct/SaveProduct",
        method: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (response) {

            alert(response.Message);

            location.reload();
        }
    });
}