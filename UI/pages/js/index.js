const token = sessionStorage.getItem('accessToken');
if(token == null){
var link = window.location.href.split('/');
link[link.length-1] =  "../login.html";
window.location.href = link.toString().replace(/,/g,'/')
}

const defaultBackGroundColor = 'rgba(231,125,38,0.8)';
const defaultBorderColor = 'rgba(0,0,0,0.8)';

const ctxplasmanVeAktifMusteri = document.getElementById('plasmanVeAktifMusteri').getContext('2d');
const ctxislemHacmi = document.getElementById('islemHacmi').getContext('2d');;
const ctxgelirKar = document.getElementById('gelirKar').getContext('2d');;
const ctxyeniIslem = document.getElementById('yeniIslem').getContext('2d');;
const ctxriskKonsantrasyonu = document.getElementById('riskKonsantrasyonu').getContext('2d');;
const ctxspread = document.getElementById('spread').getContext('2d');;

let response = new Object(); 
let plasman =  new Array() ;
let ortalamaPlasman = [] ;
let islemhacimleri = [];
let aylikortalamasatis = [];
let musteri = [];
let yeniIslemMusteriTutari= []
let yeniMusteriAdedi=[];
let gelirKar = [];


let toplam=[];
let ankara=[];
let konya=[];
let trakya=[];
let kobi=[];
let ticari=[];

let bool1 = false;
let bool2 = false;
let bool3 = false;
let bool4 = false;
let bool5 = false;
let bool6 = false;


const data = fetch(aktifUrl+'/api/Raporlar/PazarlamaPerformans?yil=2023',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        islemhacimleri.push(element.islemHacmi);
        aylikortalamasatis.push(element.islemKatkiliOran)
        plasman.push(element.plasman);
        ortalamaPlasman.push(element.ortalamaPlasman);
        musteri.push(element.plasmanMusteriAdedi);
        yeniIslemMusteriTutari.push(element.yeniIslemMusteriTutari);
        yeniMusteriAdedi.push(element.yeniIslemMusteriAdedi); 
        gelirKar.push(element.gelir)
      });
      chartTanımla();
});


const data1 =  fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil=2023&secim=1',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        toplam.push(element.risk);
      });
      bool1=true;
      kontrol()
});
const data2 =  fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil=2023&secim=2',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        ankara.push(element.risk);
      });
      bool2=true;
      kontrol()
});
const data3 =  fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil=2023&secim=3',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        konya.push(element.risk);
      });
      bool3=true;
      kontrol()
});
const data4 =  fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil=2023&secim=4',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        trakya.push(element.risk);
      });
      bool4=true;
      kontrol()
});
const data5 =  fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil=2023&secim=5',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        kobi.push(element.risk);
      });
      bool5=true;
      kontrol()
});
const data6 =  fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil=2023&secim=6',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
  datas.forEach(element => {
        ticari.push(element.risk);
      });
      bool6=true;
      kontrol()
});


var plasmanaktif;
var islemhacmi;
var yeniislem;
var konsantrasyon;
var spread;
var gelirKarChart;


  function kontrol(){
    if(bool1==true && bool2==true &&bool3==true &&bool4==true &&bool5==true &&bool6==true){
      chartPlasmanDetay();
    }
  }

 function chartTanımla(){

     plasmanaktif = new Chart(ctxplasmanVeAktifMusteri, {
      type: 'bar',
      data: {
      labels  : ['Ocak','Şubat','Mart','Nisan','Mayıs','Haziran','Temmuz','Ağustos','Eylül','Ekim','Kasım','Aralık'],
      datasets: [
        {
          label               : 'Musteri',
          type                : 'line',
          backgroundColor     : 'rgb(231,125,38)',
          pointStyle          : 'circle',
          pointRadius         : 5,
          pointHoverRadius    : 15,
          pointHighlightStroke: 'rgb(231,125,38)',
          tension             : 0,
          order               : 1,
          data                : musteri,
          yAxisID               :"y1"
        },
        {
          label               : 'Plasman',
          type                : 'bar',
          backgroundColor     : 'rgba(231,125,38,0.9)',
          borderColor         : 'rgba(231,125,38,0.8)',
          pointRadius         :  false,
          pointColor          : '#E77D26',
          pointStrokeColor    : 'rgba(231,125,38,1)',
          pointHighlightFill  : '#fff',
          pointHighlightStroke: 'rgba(231,125,38,1)',
          order               : 2,
          data                : plasman,
          yAxisID               :"y"
          
        },
        {
          label               : 'Ortalama Plasman',
          type                : 'bar',
          backgroundColor     : 'rgba(255, 197, 160, 0.9)',
          borderColor         : 'rgba(255, 197, 160, 0.8)',
          pointRadius         : false,
          pointColor          : 'rgba(255, 197, 160, 1)',
          pointStrokeColor    : '#c1c7d1',
          pointHighlightFill  : '#fff',
          pointHighlightStroke: 'rgba(220,220,220,1)',
          order               : 3,
          data                : ortalamaPlasman,
          yAxisID             :"y"
          
        },
      ]
    },
      options: {
        responsive: true,
        color: '#ffffff',
        scales: {
          y1: {
            display: true,
            position: 'right',
            type:"linear",
            
          },
          y:{
            
            display: true,
            position: 'left',
          }
        },
        maintainAspectRatio: false,
        responsive: true,
        plugins: {
            datalabels: { // This code is used to display data values
                anchor: 'center',
                align: 'center',
                formatter: Math.round,
                font: {
                    weight: 'normal',
                    size: 0
                }
            }
          }
      }
  });

     islemhacmi = new Chart(ctxislemHacmi, {
  type: 'bar',
  data: {
    labels  : ['Ocak','Şubat','Mart','Nisan','Mayıs','Haziran','Temmuz','Ağustos','Eylül','Ekim','Kasım','Aralık'],
    datasets: [
      {

        label: 'İşlem Hacmi',
        borderColor: defaultBorderColor,
        backgroundColor: defaultBackGroundColor,
        order :2,
        data: islemhacimleri,
        pointRadius         :  false,
        yAxisID             :"y"
      } ,
      {
        label                 : 'Ortalama Satış Oranı',
          type                : 'line',
          backgroundColor     : 'rgb(231,125,38)',
          pointStyle          : 'circle',
          pointRadius         : 5,
          pointHoverRadius    : 15,
          pointHighlightStroke: 'rgb(231,125,38)',
          tension             : 0,
          order               : 1,
          data                : aylikortalamasatis,
          yAxisID               :"y1"
      }
  ]
  },
  options: {

    color: '#ffffff',
    responsive              : true,
    maintainAspectRatio     : false,
    datasetFill             : false,
    maintainAspectRatio: false,
    responsive: true,
    scales: {
          y1: {
            display: true,
            position: 'right',
            type:"linear",
            
          },
          y:{
            
            display: true,
            position: 'left',
          }
        },
    plugins: {
            datalabels: { // This code is used to display data values
                anchor: 'center',
                align: 'center',
                formatter: Math.round,
                font: {
                    weight: 'normal',
                    size: 0
                }
            }
          }
    
  }
});


gelirKarChart = new Chart(ctxgelirKar, {
  type: 'bar',
  data: {
    labels  : ['Ocak','Şubat','Mart','Nisan','Mayıs','Haziran','Temmuz','Ağustos','Eylül','Ekim','Kasım','Aralık'],
    datasets: [
      {
        label: 'Gelir',
        borderColor: defaultBackGroundColor,
        backgroundColor: defaultBackGroundColor,
        data: gelirKar,
      } 
  ]
  },
  options: {

    color: '#ffffff',
    responsive              : true,
    maintainAspectRatio     : false,
    datasetFill             : false,
    maintainAspectRatio: false,
    responsive: true,
    plugins: {
            datalabels: { // This code is used to display data values
                anchor: 'center',
                align: 'center',
                formatter: Math.round,
                font: {
                    weight: 'normal',
                    size: 0
                }
            }
          }
    
  }
});

     yeniislem = new Chart(ctxyeniIslem, {
  type: 'bar',
  data: {
    labels  : ['Ocak','Şubat','Mart','Nisan','Mayıs','Haziran','Temmuz','Ağustos','Eylül','Ekim','Kasım','Aralık'],
    datasets: [
      {
        label               : 'Risk',
        borderColor         : '#FF6384',
        backgroundColor     : defaultBackGroundColor,
        order               : 2,
        data                : yeniIslemMusteriTutari,
      },
      {
        label               : 'Yeni Müşteri',
        type                : 'bubble',
        backgroundColor     : 'rgba(46,146,173,0.9)',
        pointStyle          : 'rect',
        radius              : 10,
        pointHoverRadius    : 15,
        pointHighlightStroke: 'rgba(231,125,38,1)',
        tension             : 0,
        order               : 1,
        data                : yeniMusteriAdedi,
      }
  ]
  },
  options: {
    color: '#ffffff',
    responsive              : true,
    maintainAspectRatio     : false,
    datasetFill             : false,
    plugins: {
            datalabels: { // This code is used to display data values
                anchor: 'center',
                align: 'center',
                formatter: Math.round,
                font: {
                    weight: 'normal',
                    size: 0
                }
            }
          }
  }
});

     

     spread = new Chart(ctxspread, {
  type: 'line',
  data: {
    labels  : ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran', 'Temmuz',"Ağustos","Eylül","Ekim","Kasım","Aralık"],
    datasets: [
      {
        label: 'Getiri',
        borderColor: 'rgba(51,102,164,0.9)',
        backgroundColor: 'rgba(51,102,164,0.9)',
        fill: false,
        radius: 5,
        pointHoverRadius    : 10,
        tension : 0.5,
        data: [41, 48, 42, 44, 40, 45],
      },
      {
        label: 'Maliyet',
        borderColor: 'rgba(152,47,45,0.9)',
        backgroundColor: 'rgba(152,47,45,0.9)',
        fill: false,
        radius: 5,
        pointHoverRadius    : 10,
        tension : 0.5,
        data: [22, 29, 23, 25, 22, 23],
      },
      {
        label: 'Spread',
        borderColor: 'rgba(142,178,70,0.9)',
        backgroundColor: 'rgba(142,178,70,0.9)',
        fill: false,
        radius: 5,
        pointHoverRadius    : 10,
        tension : 0.5,
        data: [9, 11, 5, 6, 7, 8],
      },
  ]
  },
  options: {
    color: '#ffffff',
    responsive: true,
    maintainAspectRatio     : false,
    datasetFill             : false,
  
    plugins: {
            datalabels: { // This code is used to display data values
                anchor: 'center',
                align: 'center',
                formatter: Math.round,
                font: {
                    weight: 'normal',
                    size: 0
                }
            }
          }
  }
});  
}

   function yildegis(yil) {

    bool1 = false;
    bool2 = false;
    bool3 = false;
    bool4 = false;
    bool5 = false;
    bool6 = false;
    removeCharts();

    islemhacimleri = []
    plasman = []
    ortalamaPlasman = []
    musteri = []
    yeniIslemMusteriTutari = []
    yeniMusteriAdedi = []
    toplam=[]
    ankara=[]
    konya=[]
    trakya=[]
    kobi=[]
    ticari=[]
    
    
    const data = fetch(aktifUrl+'/api/Raporlar/PazarlamaPerformans?yil='+yil,{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
    datas.forEach(element => {
          islemhacimleri.push(element.islemHacmi);
          plasman.push(element.plasman);
          ortalamaPlasman.push(element.ortalamaPlasman);
          musteri.push(element.plasmanMusteriAdedi);
          yeniIslemMusteriTutari.push(element.yeniIslemMusteriTutari);
          yeniMusteriAdedi.push(element.yeniIslemMusteriAdedi);
          gelirKar.push(element.Gelir)
        });
        chartTanımla();
    });



    const data1 =  fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil='+yil+'&secim=1',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
      datas.forEach(element => {
            toplam.push(element.risk);
          });
          bool1=true;
      kontrol()
    });
    const data2 = fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil='+yil+'&secim=2',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
      datas.forEach(element => {
            ankara.push(element.risk);
          });
          bool2=true;
      kontrol()
    });
    const data3 = fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil='+yil+'&secim=3',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
      datas.forEach(element => {
            konya.push(element.risk);
          });
          bool3=true;
      kontrol()
    });
    const data4 = fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil='+yil+'&secim=4',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
      datas.forEach(element => {
            trakya.push(element.risk);
          });
          bool4=true;
      kontrol()
    });
    const data5 = fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil='+yil+'&secim=5',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
      datas.forEach(element => {
            kobi.push(element.risk);
          });
          bool5=true;
      kontrol()
    });
    const data6 = fetch(aktifUrl+'/api/Raporlar/PlasmanDetay?yil='+yil+'&secim=6',{
  method: 'GET',
  headers: {
    'Authorization': `Bearer ${token}`, 
    'Content-Type': 'application/json'
  }
}).then(response => response.json()).then(function(datas){
      datas.forEach(element => {
            ticari.push(element.risk);
          });
          bool6=true;
      kontrol()
    });
    
    
  }

  function removeData(chart) {
    chart.data.datasets.forEach((dataset) => {
        dataset.data=[];
    });
    chart.update();
  }

  function updateData(chart) {
    
    chart.update();
  }

  function removeCharts()
  {
    plasmanaktif.destroy();
    islemhacmi.destroy();
    yeniislem.destroy();
    konsantrasyon.destroy();
    spread.destroy();
    gelirKarChart.destroy();
  }

  function chartPlasmanDetay(){
    konsantrasyon = new Chart(ctxriskKonsantrasyonu, {
  type: 'bar',
  
  data: {
    labels  : ['Ocak','Şubat','Mart','Nisan','Mayıs','Haziran','Temmuz','Ağustos','Eylül','Ekim','Kasım','Aralık'],
    datasets: [
      {
        label: 'Toplam',
        borderColor: '#FF6384',
        backgroundColor: defaultBackGroundColor,
        data: toplam,
      },
      {
        label: 'Ankara',
        borderColor: '#FF6384',
        backgroundColor: 'rgba(142,178,70,0.9)',
        data: ankara,
      },
      {
        label: 'Konya',
        borderColor: '#FF6384',
        backgroundColor: 'rgba(46,146,173,0.9)',
        data: konya,
      },
      {
        label: 'Trakya',
        borderColor: '#FF6384',
        backgroundColor: 'rgba(107,77,142,0.9)',
        data: trakya
      },
      {
        label: 'Kobi',
        borderColor: '#FF6384',
        backgroundColor: 'rgba(51,102,164,0.9)',
        data: kobi,
      },
      {
        label: 'Ticari',
        borderColor: '#FF6384',
        backgroundColor: 'rgba(152,47,45,0.9)',
        data: ticari,
      },
  ]
  },
  options: {
    indexAxis: 'y',
    color: '#ffffff',
    xAxis:{
      fontColor: '#ffffff'
    },
    responsive: true,
    maintainAspectRatio     : false,
    datasetFill             : false,   
    plugins: {
            datalabels: { // This code is used to display data values
                anchor: 'end',
                align: 'end',
                
                font: {
                    weight: 'normal',
                    size: 12
                }
            }
          }
  }

  
});


  }
  
  Chart.defaults.backgroundColor = '#4c4c4c  ';
  Chart.defaults.borderColor = '#4c4c4c  ';
  Chart.defaults.color = '#fff';
  Chart.register(ChartDataLabels);
