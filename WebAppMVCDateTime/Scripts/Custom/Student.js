$(document).ready(function () {
    
    $.ajax({
        url: '/Demo/GetAllStudentsJson',
        type: 'GET',
        success: function (data) {
            console.log(data);
            var htmlText = '';
            for (var i = 0; i < data.length; i++) {
                var tr = '<tr><td>' + data[i].FirstName + '<tr><td>' + data[i].LastName + '<tr><td>' + data[i].Roll + '<tr><td>' + data[i].MarksSecured + '<tr><td>';
                htmlText += tr;
            }
            $('#tblData').html(htmlText);
        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
    });
});