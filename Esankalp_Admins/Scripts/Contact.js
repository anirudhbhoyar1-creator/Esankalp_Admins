function DetailContact(Id) {
    $.ajax({
        url: "/ContactList/DetailContact?Id=" + Id,
        type: "GET",
        dataType: "json",

        success: function (data) {
            $("#dId").text(data.Id);
            $("#dName").text(data.fullname);
            $("#dEmail").text(data.email);
            $("#dMobile").text(data.mob);
            $("#dMessage").text(data.msg);

            $("#detailModal").modal("show");
        }
    });
}