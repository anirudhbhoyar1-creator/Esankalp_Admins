$(document).ready(function () {
    GetIncomeList();  
});
function SaveIncome() {
    var model =
    {
        ClientName: $("#txtClient").val(),
        Amount: $("#txtAmount").val(),
        IncomeDate: $("#txtDate").val(),
        Category: $("#txtCategory").val(),
        Notes: $("#txtNotes").val()
    };

    $.ajax({
        url: "/Income/SaveIncome",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (response) {
            alert(response.Message);

            GetIncomeList(); }
    });
}
function GetIncomeList() {
    $.ajax({
        url: "/Income/GetIncomeList",
        type: "GET",
        dataType: "json",

        success: function (response) {
            var html = "";

            $("#tblIncome tbody").empty();

            $.each(response.model, function (index, item) {
                html += "<tr>";

                html += "<td>" + item.Id + "</td>";

                html += "<td>" + item.ClientName + "</td>";

                html += "<td>" + item.Category + "</td>";

                html += "<td>" +
                    item.IncomeDate +
                    "</td>";

                html += "<td>₹ " +
                    item.Amount +
                    "</td>";

                html += "</tr>";
            });

            $("#tblIncome tbody").append(html);
        }
    });
}
