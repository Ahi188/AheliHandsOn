array=[100000,100,1,2.54,30.48,91.44,160934.4,185200,0.1];
array2=["KM","M","CM","INCH","FT","YD","MI","NM","MM"];
function convert()
{
    var unit1 = Number($('#unit1').val());
    var unit2 = Number($('#unit2').val());
    var c = $("input").val();
    var d = (array[unit1] / array[unit2]) * c;
    $("#output2").val(d + " " + array2[unit2]);
   $("#span").html(d + " " + array2[unit2]);
}
