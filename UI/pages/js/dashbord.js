const token = sessionStorage.getItem('accessToken');
if(token == null){
var link = window.location.href.split('/');
link[link.length-1] =  "../login.html";
window.location.href = link.toString().replace(/,/g,'/')
}


let ToplamBordroTutari = [];
let IslemAdedi = [];
let IslemAdediGercelesen = [];
let OnayDurum = [];

const gelenGunluk = document.getElementById('GelenIslemAdediGunluk');
const gelenGunlukGerceklesen = document.getElementById('GelenIslemAdediGunlukGerceklesen');
const gelenAylik = document.getElementById('GelenIslemAdediAylik');
const gelenAylikGerceklesen = document.getElementById('GelenIslemAdediAylikGerceklesen');
const gelenYillik = document.getElementById('GelenIslemAdediYillik');
const gelenYillikGerceklesen = document.getElementById('GelenIslemAdediYillikGerceklesen');

const toplamGunluk = document.getElementById('ToplamBordroTutariGunluk');
const toplamAylik = document.getElementById('ToplamBordroTutariAylik');
const toplamYillik = document.getElementById('ToplamBordroTutariYillik');

const onaylananGunluk = document.getElementById('OnaylananIslemGunluk');
const onaylanmayanGunluk = document.getElementById('OnaylanmayanIslemGunluk');
const onaylananAylik = document.getElementById('OnaylananIslemAylik');
const onaylanmayanAylik = document.getElementById('OnaylanmayanIslemAylik');
const onaylananYillik = document.getElementById('OnaylananIslemYillik');
const onaylanmayanYillik = document.getElementById('OnaylanmayanIslemYillik');

const yeniMusteriAdedii = document.getElementById('yeniMusteriAdedi');
const yeniMusteriAdediKumule = document.getElementById('yeniMusteriAdediKumule');

const ziyaretTablosu =document.getElementById("ZiyaretTablosu");
const ziyaretTablosuToplam =document.getElementById("ToplamZiyaretAdedi");


  let hedefPlasman = [];
  let hedefGelir = [];
  let hedefIslemHacmi = [];
  let hedefYeniIslemHacmi = [];

  let hedefAciklama = [];
  let hedefDegerler = [];

  const data1 = fetch(aktifUrl+'/api/Raporlar/PazarlamaPerformans?yil=2023',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        hedefPlasman.push(element.plasman);
        hedefGelir.push(element.gelir);
        hedefIslemHacmi.push(element.islemHacmi);
        hedefYeniIslemHacmi.push(element.yeniIslemMusteriTutari);
      });
      HedefHeader()
      HedefFooter()
});
  const data9 = fetch(aktifUrl+'/api/Raporlar/HedefData',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
    datas.forEach(element => {
        hedefDegerler.push(element.hedef);
        });
        console.log(hedefDegerler)
        
  });

  function HedefHeader() {
  var listeRef = document.getElementById('HedefHeader');
    //insert Row
    listeRef.innerHTML += 
    "<div class='progress-group'>Plasman"+
      "<span class='float-right'><b>"+hedefPlasman[hedefPlasman.length-1].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</b>/"+hedefDegerler[0].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+ "</span>"+
      "<div class='progress progress-sm'>"+
        "<div class='progress-bar bg-primary' style='width: " +Math.round(hedefPlasman[hedefPlasman.length-1]*100/hedefDegerler[0]) +"%'></div>"+
      "</div>"+
    "</div>"+
    "<div class='progress-group'>Gelir"+
      "<span class='float-right'><b>"+hedefGelir[hedefGelir.length-1].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</b>/"+hedefDegerler[1].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+ "</span>"+
      "<div class='progress progress-sm'>"+
        "<div class='progress-bar bg-warning' style='width: " +Math.round(hedefGelir[hedefGelir.length-1]*100/hedefDegerler[1]) +"%'></div>"+
      "</div>"+
    "</div>"+
    "<div class='progress-group'>İşlem Hacmi"+
      "<span class='float-right'><b>"+hedefIslemHacmi[hedefIslemHacmi.length-1].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</b>/"+hedefDegerler[2].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+ "</span>"+
      "<div class='progress progress-sm'>"+
        "<div class='progress-bar bg-success' style='width: " +Math.round(hedefIslemHacmi[hedefIslemHacmi.length-1]*100/hedefDegerler[2]) +"%'></div>"+
      "</div>"+
    "</div>"+
    "<div class='progress-group'>Yeni İşlem Hacmi"+
      "<span class='float-right'><b>"+hedefYeniIslemHacmi[hedefYeniIslemHacmi.length-1].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</b>/"+hedefDegerler[3].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+ "</span>"+
      "<div class='progress progress-sm'>"+
        "<div class='progress-bar bg-danger' style='width: " +Math.round(hedefYeniIslemHacmi[hedefYeniIslemHacmi.length-1]*100/hedefDegerler[3]) +"%'></div>"+
      "</div>"+
    "</div>"
    ;

}

function HedefFooter(){
  var plasman = parseInt(Math.floor(((Math.floor(hedefPlasman[hedefPlasman.length-1])-Math.floor(hedefPlasman[hedefPlasman.length-2]))/Math.floor(hedefPlasman[hedefPlasman.length-2]))*100)); 
  let gelir =  Math.floor(((Math.floor(hedefGelir[hedefGelir.length-1])-Math.floor(hedefGelir[hedefGelir.length-2]))/Math.floor(hedefGelir[hedefGelir.length-2]))*100)

  let islemhacmi =  Math.floor(((Math.floor(hedefIslemHacmi[hedefIslemHacmi.length-1])-Math.floor(hedefIslemHacmi[hedefIslemHacmi.length-2]))/Math.floor(hedefIslemHacmi[hedefIslemHacmi.length-2]))*100)

  let yenislemhacmi =  Math.floor(((Math.floor(hedefYeniIslemHacmi[hedefYeniIslemHacmi.length-1])-Math.floor(hedefYeniIslemHacmi[hedefYeniIslemHacmi.length-2]))/Math.floor(hedefYeniIslemHacmi[hedefYeniIslemHacmi.length-2]))*100)

  var listeRef = document.getElementById('HedefFooter');
    //insert Row
    listeRef.innerHTML += 
    "<div class='col-sm-3 col-6'>"+
      "<div class='description-block border-right'>"+
        degerKontrol(plasman)
        +plasman+"%</span>"+
        "<h5 class='description-header'>"+(Math.floor(hedefPlasman[hedefPlasman.length-1])-
          Math.floor(hedefPlasman[hedefPlasman.length-2])).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</h5>"+
        "<span class='description-text'>Plasman</span>"+
      "</div>"+
    "</div>"+
    "<div class='col-sm-3 col-6'>"+
      "<div class='description-block border-right'>"+
        degerKontrol(gelir)
        +gelir+"%</span>"+
        "<h5 class='description-header'>"+(Math.floor(hedefGelir[hedefGelir.length-1])-
          Math.floor(hedefGelir[hedefGelir.length-2])).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</h5>"+
        "<span class='description-text'>Gelir</span>"+
      "</div>"+
    "</div>"+
    "<div class='col-sm-3 col-6'>"+
      "<div class='description-block border-right'>"+
        degerKontrol(islemhacmi)
        +islemhacmi+"%</span>"+
        "<h5 class='description-header'>"+(Math.floor(hedefIslemHacmi[hedefIslemHacmi.length-1])-
          Math.floor(hedefIslemHacmi[hedefIslemHacmi.length-2])).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</h5>"+
        "<span class='description-text'>İşlem Hacmi</span>"+
      "</div>"+
    "</div>"+
    "<div class='col-sm-3 col-6'>"+
      "<div class='description-block border-right'>"+
        degerKontrol(yenislemhacmi)
        +plasman+"%</span>"+
        "<h5 class='description-header'>"+(Math.floor(hedefYeniIslemHacmi[hedefYeniIslemHacmi.length-1])-
          Math.floor(hedefYeniIslemHacmi[hedefYeniIslemHacmi.length-2])).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</h5>"+
        "<span class='description-text'>Yeni İşlem Hacmi</span>"+
      "</div>"+
    "</div>";
}

function degerKontrol(deger){
  let addText ;
  if (deger == 0) {
          addText="<span class='description-percentage text-warning'><i class='fas fa-caret-left'></i>"
        }
        else if(deger < 0){
          addText="<span class='description-percentage text-danger'><i class='fas fa-caret-down'></i>"
        }
        else if(deger > 0){
          addText="<span class='description-percentage text-success'><i class='fas fa-caret-up'></i>"
        }
        return addText;
}


let ziyateAdi = []
let ziyaretAdet = []
const data8 = fetch(aktifUrl+'/api/Raporlar/Ziyaret',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        ziyateAdi.push(element.adi);
        ziyaretAdet.push(element.ziyaret);

      });
      let veri =0;
      for (let index = 0; index < ziyaretAdet.length; index++) {
        veri=veri+ parseInt(ziyaretAdet[index].toString())
      }
      ziyaretTablosuToplam.innerText =veri;
      pazarlamaciZiyaret()
      
      
});


function pazarlamaciZiyaret() {
  var tableRef = document.getElementById('ZiyaretTablosu');
  for (let index = 0; index < ziyateAdi.length; index++){
    //insert Row
      tableRef.innerHTML += 
    "<td>" + ziyateAdi[index]+"</td>" + 
    "<td><span class='badge bg-primary' style='font-size:16px;'>" +ziyaretAdet[index]+"</span></td>";

    

}
}

let yeniMusteriAdedi=[];
const data7 = fetch(aktifUrl+'/api/Raporlar/YeniMusteri',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        yeniMusteriAdedi.push(element.adet);

      });
      let veri =0;
      for (let index = 0; index < yeniMusteriAdedi.length; index++) {
        veri=veri+ parseInt(yeniMusteriAdedi[index].toString())
      }
      yeniMusteriAdediKumule.innerText =veri;
      yeniMusteriAdedii.innerText =yeniMusteriAdedi[yeniMusteriAdedi.length-1];
      
      
});

const data = fetch(aktifUrl+'/api/Raporlar/ToplamBordroTutari',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        ToplamBordroTutari.push(element.toplamBordroTutari);
      });
      toplamGunluk.innerHTML =ToplamBordroTutari[0].toLocaleString(undefined,{ minimumFractionDigits: 2 });
      toplamAylik.innerHTML =ToplamBordroTutari[1].toLocaleString(undefined,{ minimumFractionDigits: 2 });
      toplamYillik.innerHTML =ToplamBordroTutari[2].toLocaleString(undefined,{ minimumFractionDigits:2 });
});

const data2 = fetch(aktifUrl+'/api/Raporlar/IslemAdedi',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        IslemAdedi.push(element.islemAdedi);
        IslemAdediGercelesen.push(element.gerceklesen);
      });
      gelenGunluk.innerText =IslemAdedi[0].toLocaleString(undefined,{ minimumFractionDigits: 0 }).toString();
      gelenGunlukGerceklesen.innerText =IslemAdediGercelesen[0].toLocaleString(undefined,{ minimumFractionDigits: 0 }).toString();
      gelenAylik.innerText =IslemAdedi[1].toLocaleString(undefined,{ minimumFractionDigits: 0 }).toString();
      gelenAylikGerceklesen.innerText =IslemAdediGercelesen[1].toLocaleString(undefined,{ minimumFractionDigits: 0 }).toString();
      gelenYillik.innerText =IslemAdedi[2].toLocaleString(undefined,{ minimumFractionDigits: 0 }).toString();
      gelenYillikGerceklesen.innerText =IslemAdediGercelesen[2].toLocaleString(undefined,{ minimumFractionDigits: 0 }).toString();
      
});

const data3 = fetch(aktifUrl+'/api/Raporlar/OnayDurumuTutari',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
    OnayDurum.push(element.islemBordroTutari);
      });
      onaylananGunluk.innerHTML =parseInt(OnayDurum[0]).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString();
      onaylanmayanGunluk.innerHTML =parseInt(OnayDurum[1]).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString();
      onaylananAylik.innerHTML =parseInt(OnayDurum[2]).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString();
      onaylanmayanAylik.innerHTML =parseInt(OnayDurum[3]).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString();
      onaylananYillik.innerHTML =parseInt(OnayDurum[4]).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString();
      onaylanmayanYillik.innerHTML =parseInt(OnayDurum[5]).toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString();
});     


let IslemNo = [];
let FirmaNo = [];
let FirmaAdi = [];
let TemsilciAdi = [];
let BordroTutar = [];
let Durum = [];

const data4 = fetch(aktifUrl+'/api/Raporlar/SonIslemler',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
    IslemNo.push(element.islemno);
    FirmaNo.push(element.firmano);
    FirmaAdi.push(element.firmaadi);
    TemsilciAdi.push(element.adi);
    BordroTutar.push(element.bordrotutar);
    Durum.push(element.bipekkod4);
      });
      sonIslemlerDoldur();
});


function sonIslemlerDoldur() {
  var tableRef = document.getElementById('lastProceses').getElementsByTagName('tbody')[0];
  for (let index = 0; index < IslemNo.length; index++){
    //insert Row
    if(Durum[index]== "Onaylanmadı"){
      tableRef.insertRow().innerHTML = 
    "<td><span style='font-size:14px;'>" + IslemNo[index]+"</span></td>" + 
    "<td><span style='font-size:14px;'>" +FirmaNo[index]+"</span></td>"+
    "<td><span style='font-size:14px;'>" +FirmaAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px;'>" +TemsilciAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px; font-weight: bold;'>" +BordroTutar[index].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</span></td>"+
    "<td><span style='font-size:14px;' class='badge badge-danger'>" +Durum[index]+"</span></td>";
    }
    else if(Durum[index]== "Onay Bekliyor"){
      tableRef.insertRow().innerHTML = 
    "<td><span style='font-size:14px;'>" + IslemNo[index]+"</span></td>" + 
    "<td><span style='font-size:14px;'>" +FirmaNo[index]+"</span></td>"+
    "<td><span style='font-size:14px;'>" +FirmaAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px;'>" +TemsilciAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px; font-weight: bold;'>" +BordroTutar[index].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</span></td>"+
    "<td><span style='font-size:14px;' class='badge badge-warning'>" +Durum[index]+"</span></td>";
    }
    else if(Durum[index]== "Onaylandı"){
      tableRef.insertRow().innerHTML = 
    "<td><span style='font-size:14px;'>" + IslemNo[index]+"</span></td>" + 
    "<td><span style='font-size:14px;'>" +FirmaNo[index]+"</span></td>"+
    "<td><span style='font-size:14px;'>" +FirmaAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px;'>" +TemsilciAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px; font-weight: bold;'>" +BordroTutar[index].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</span></td>"+
    "<td><span style='font-size:14px;' class='badge badge-success'>" +Durum[index]+"</span></td>";
    }
    else if(Durum[index]== "Ödeme Yapıldı"){
      tableRef.insertRow().innerHTML = 
    "<td><span style='font-size:14px;'>" + IslemNo[index]+"</span></td>" + 
    "<td><span style='font-size:14px;'>" +FirmaNo[index]+"</span></td>"+
    "<td><span style='font-size:14px;'>" +FirmaAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px;'>" +TemsilciAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px; font-weight: bold;'>" +BordroTutar[index].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</span></td>"+
    "<td><span style='font-size:14px;' class='badge badge-info'>" +Durum[index]+"</span></td>";
    }
    
}
}

let pSube = [];
let pAdi = [];
let pDepartman = [];
let pPlasman= [];
let pIslemHacmi = [];
const data6 = fetch(aktifUrl+'/api/Raporlar/PazarlamaciBilgileri',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
    pSube.push(element.aciklama);
    pAdi.push(element.adi);
    pDepartman.push(element.departman);
    pPlasman.push(element.plasman);
    pIslemHacmi.push(element.islemHacmi);
      });
      pazarlamaciIslemHacmi();
});

function pazarlamaciIslemHacmi() {
  var tableRef = document.getElementById('pazarlamaciBilgileri',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).getElementsByTagName('tbody')[0];
  for (let index = 0; index < pSube.length; index++){
    //insert Row
      tableRef.insertRow().innerHTML = 
    "<td><span style='font-size:14px;'>" + pSube[index]+"</span></td>" + 
    "<td><span style='font-size:14px;'>" +pAdi[index]+"</span></td>"+
    "<td><span style='font-size:14px; font-weight: bold;'>" +pPlasman[index].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</span></td>"
     +"<td><span style='font-size:14px; font-weight: bold;'>" +pIslemHacmi[index].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</span></td>";
    }
}