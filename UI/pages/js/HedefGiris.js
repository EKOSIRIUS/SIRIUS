
const token = sessionStorage.getItem('accessToken');
if(token == null){
var link = window.location.href.split('/');
link[link.length-1] =  "../login.html";
window.location.href = link.toString().replace(/,/g,'/')
}

let hedefDegerler = []
const data1 = fetch(aktifUrl+'/api/Raporlar/HedefData',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
    datas.forEach(element => {
        hedefDegerler.push(element.hedef);
        });
        hedefDeger()
  });

  function hedefDeger() {
  var tableRef = document.getElementById('plasmanD');
  tableRef.value = hedefDegerler[0];

  var tableRef = document.getElementById('gelirD');
  tableRef.value = hedefDegerler[1];

  var tableRef = document.getElementById('islemhacmiD');
  tableRef.value = hedefDegerler[2];

  var tableRef = document.getElementById('yeniislemhacmiD');
  tableRef.value = hedefDegerler[3];
}

function hedefDegerGuncelleme() {
  var plasman=document.getElementById("plasmanD");
  var gelir=document.getElementById("gelirD");
  var islemhacmi=document.getElementById("islemhacmiD");
  var yenislemhacmi=document.getElementById("yeniislemhacmiD");

  var data = {id:"1",hedef:plasman.value};
  var data2 = {id:"2",hedef:gelir.value};
  var data3 = {id:"3",hedef:islemhacmi.value};
  var data4 = {id:"4",hedef:yenislemhacmi.value};
  $.ajax({
    type: "POST",
    url: aktifUrl+'/api/Raporlar/HedefDataGuncelleme',
    data: JSON.stringify(data),
    contentType: "application/json",
    success:(data,status,xhr) => {
      var x = document.getElementById("snackbar");
      x.className = "show";
      setTimeout(function(){ x.className = x.className.replace("show", ""); }, 3000);
      }
  })
  $.ajax({
    type: "POST",
    url: aktifUrl+'/api/Raporlar/HedefDataGuncelleme/',
    data: JSON.stringify(data2),
    contentType: "application/json",
    success:(data,status,xhr) => {
      var x = document.getElementById("snackbar");
      x.className = "show";
      setTimeout(function(){ x.className = x.className.replace("show", ""); }, 3000);
      }
  })

  $.ajax({
    type: "POST",
    url: aktifUrl+'/api/Raporlar/HedefDataGuncelleme/',
    data: JSON.stringify(data3),
    contentType: "application/json",
    success:(data,status,xhr) => {
      var x = document.getElementById("snackbar");
      x.className = "show";
      setTimeout(function(){ x.className = x.className.replace("show", ""); }, 3000);
      }
  })

  $.ajax({
    type: "POST",
    url: aktifUrl+'/api/Raporlar/HedefDataGuncelleme/',
    data: JSON.stringify(data4),
    contentType: "application/json",
    success:(data,status,xhr) => {
      var x = document.getElementById("snackbar");
      x.className = "show";
      setTimeout(function(){ x.className = x.className.replace("show", ""); }, 3000);
      }
  })
  
}

