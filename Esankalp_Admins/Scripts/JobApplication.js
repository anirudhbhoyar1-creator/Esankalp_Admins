$(document).ready(function () {

    GetJobApplicationList();

});
var SaveJobApplication = function () {

    var model = {

        CandidateName: $("#txtCandidateName").val(),

        Email: $("#txtEmail").val(),

        Mobile: $("#txtMobile").val(),

        PositionAppliedFor: $("#txtPosition").val(),

        Status: $("#ddlStatus").val(),

        InterviewDate: $("#txtInterviewDate").val()
    };

    $.ajax({

        url: "/JobApplication/SaveJobApplication",

        type: "POST",

        data: JSON.stringify(model),

        contentType: "application/json;charset=utf-8",

        dataType: "json",

        success: function (response) {

            alert(response.Message);

            GetJobApplicationList();
        },

        error: function (xhr) {

            alert(xhr.responseText);
        }
    });
};
var GetJobApplicationList = function () {

    $.ajax({

        url: "/JobApplication/GetJobApplicationList",

        type: "GET",

        dataType: "json",

        success: function (response) {

            var html = "";

            $("#tblJobApplication").empty();

            $.each(response.model, function (i, item) {

                html += "<tr>";

                html += "<td>" + item.Id + "</td>";

                html += "<td>" + item.CandidateName + "</td>";

                html += "<td>" + item.Email + "</td>";

                html += "<td>" + item.Mobile + "</td>";

                html += "<td>" + item.PositionAppliedFor + "</td>";

                html += "<td>" + item.Status + "</td>";

                html += "<td>" +
                    (item.InterviewDate == null
                        ? ''
                        : item.InterviewDate.substring(0, 10))
                    + "</td>";

                html += "</tr>";
            });

            $("#tblJobApplication").append(html);
        }
    });
};