var SaveApplication = function () {

    var model = {

        FullName: $("#txtName").val(),
        Email: $("#txtEmail").val(),
        Mobile: $("#txtMobile").val(),
        Position: $("#txtPosition").val(),
        DOB: $("#txtDOB").val(),

        Gender: $("#txtddlGender").val(),
        Skills: $("#txtSkills").val(),
        City: $("#txtCity").val(),
        Address: $("#txtAddress").val(),

        Education: $("#txtEducation").val(),
        Experience: $("#txtExperience").val()
    };

    console.log(model);

    $.ajax({

        url: "/ApplicationForm/SaveApplication",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (response) {

            alert(response.Message);

        },
        error: function (xhr) {
            alert("Error: " + xhr.responseText);
        }
    });
}
