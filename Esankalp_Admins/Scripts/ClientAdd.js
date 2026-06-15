var SaveClient = function () {

    var model = {

        ClientName: $("#txtClientName").val(),
        CompanyName: $("#txtCompanyName").val(),
        Email: $("#txtEmail").val(),
        Mobile: $("#txtMobile").val(),
        Address: $("#txtAddress").val(),
        ProjectDetails: $("#txtProjectDetails").val()
    };

    $.ajax({

        url: "/ClientAdd/SaveClient",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (response) {

            alert(response.Message);

        },

        error: function (xhr) {

            alert(xhr.responseText);

        }
    });
}