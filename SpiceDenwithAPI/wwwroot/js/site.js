// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:44327/api/Menu/GetMenu',
        type: 'GET',
        success: function (data1) {
            var html = '';
            for (var index = 0; index < data1.length; index++) {
                console.log(data1[index]);
                html += ('<option value="' + data1[index].menuID + '">' + data1[index].cusine + '</option>');
            }
            $('#menuList').append(html);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
    });


    $('#menuList').change(function () {
        var menuselected = $('#menuList').val();
        //alert(menuselected);
        $.ajax({
            url: 'https://localhost:44327/api/Menu/GetChoice',
            type: 'GET',
            success: function (data1) {
                var html = '<option value=" ">' + "Select" + '</option>';
                for (var index = 0; index < data1.length; index++) {
                    console.log(data1[index]);
                    html += ('<option value="' + data1[index].choiceID + '">' + data1[index].category + '</option>');
                }
                $('#choiceList').html(html);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });

    });
    $('#choiceList').change(function () {
        var choiceList = $('#choiceList').val();
        //alert(choiceList);
        var menuselected = $('#menuList').val();
        $.ajax({
            url: 'https://localhost:44327/api/Menu/GetMenuCard?Mid=' + menuselected + '&Cid=' + choiceList,

            type: 'GET',
            success: function (data1) {
                var html = '';
                for (var index = 0; index < data1.length; index++) {
                    console.log(data1[index]);
                    html += ('<tr>' +
                        '<td>' + data1[index].dishId + '</td>' +
                        '<td>' + data1[index].dishName + '</td>' +
                        '<td>' + data1[index].price + '</td>' +
                        '</tr>');
                }
                $('#tbody').html(html);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });
    });
    //post call
    //javascript obj(onclick function of submit button)-extract data, pass the object in data.
    $('#btnSubmit').click(function () {

        var dishname = $('#dname').val();
        var dishprice = $('#dprice').val();
        var menuid = $('input:radio[name=cusine]:checked').val();
        var choiceid = $('input:radio[name=choice]:checked').val();
       
        var formdata = {
            DishId:0,
            DishName: dishname,
            Price: dishprice,
            MenuID: menuid,
            ChoiceID: choiceid,
        };
        console.log(formdata);
        $.ajax({

            url: 'https://localhost:44327/api/Menu/AddDish',
            type: 'POST',
           /* contentType: 'application/json',*/
            /*data: '{"dishId":0, "dishName": string,"price":0;,"menuID":0,"choiceID":0   }',*/
            data: formdata, //data=attribute
            success: function (response) { // response from api, not the attribute
                
                console.log(response);
              

            },

            error: function (XMLHttpRequest, textStatus, errorThrown) {
                console.log(XMLHttpRequest);
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);

            }
        });

    });
});



    function showDiv() {
        document.getElementById('addDish').style.display = "block";
    }


    