$(document).ready(function () {
    GetRegistration();
});

function GetRegistration() {

    var name = $("#txtNmae").val();
    var model = { name: Name };

    $.ajax({
        url: "/RegistrationList/GetRegistration",
        type: "GET",
        dataType: "json",

        success: function (response) {

            var html = "";

            $.each(response.data, function (key, item) {

                html += "<tr>";

                html += "<td>" + item.RegId + "</td>";
                html += "<td>" + item.Name + "</td>";
                html += "<td>" + item.MobileNo + "</td>";
                html += "<td>" + item.Email + "</td>";
                html += "<td>" + item.Education + "</td>";
                html += "<td>" + item.Percentage + "</td>";
                html += "<td>" + item.Service + "</td>";
                html += "<td>" + item.Technology + "</td>";
                html += "<td>" + item.Office + "</td>";
                html += "<td>" + item.College + "</td>";
                html += "<td>" + item.Address + "</td>";

                html += "<td>";
                html += "<button class='btn-icon view-btn'><i class='bi bi-eye'></i></button>";
                html += "<button class='btn-icon edit-btn'><i class='bi bi-pencil'></i></button>";
                html += "<button class='btn-icon whatsapp-btn'><i class='bi bi-whatsapp'></i></button>";
                html += "<button class='btn-icon delete-btn'><i class='bi bi-trash'></i></button>";
                html += "</td>";

                html += "</tr>";
            });

            $("#registrationBody").html(html);
        }
    });
}