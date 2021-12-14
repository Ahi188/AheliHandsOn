array=[100000,100,1,2.54,30.48,91.44,160934.4,185200,0.1];
array2=["KM","M","CM","INCH","FT","YD","MI","NM","MM"];
function convert()
{
  var a =Number(document.getElementById("unit1").value);
  var b =Number(document.getElementById("unit2").value);
  var c =document.getElementById("input").value;
  var d =(array[a]/array[b])*c;
  document.getElementById("output2").value=d+" "+array2[b];
}
