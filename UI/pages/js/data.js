
 
  const token = sessionStorage.getItem('accessToken');
  if(token == null){
    var link = window.location.href.split('/');
    link[link.length-1] =  "../login.html";
    window.location.href = link.toString().replace(/,/g,'/')
  }

  let firmano = [];
  let adi = [];
  let vergino = [];
  let musterit = [];
  let bakiyesi = [];
  let sehir = [];
  let semt = [];
  let adres = [];

  const data1 = fetch(aktifUrl+'/api/Raporlar/MusteriRiskListesi',{
      method: 'GET',
      headers: {
        'Authorization': `Bearer ${token}`, 
        'Content-Type': 'application/json'
      }
    }).then(response => response.json()).then(function(datas){
      datas.forEach(element => {
            firmano.push(element.firmano);
            adi.push(element.adi);
            vergino.push(element.vergino);
            musterit.push(element.musterit);
            bakiyesi.push(element.bakiyesi);
            sehir.push(element.sehir);
            semt.push(element.semt);
            adres.push(element.adres);
          });
          MusteriRiskDoldur()
    });


    function MusteriRiskDoldur() {
      var tableRef = document.getElementById('musteririsk').getElementsByTagName('tbody')[0];
      for (let index = 0; index < firmano.length; index++){
        //insert Row
          tableRef.insertRow().innerHTML = 
        "<tr><td>" + firmano[index]+"</td>" + 
        "<td>" + adi[index]+"</td>" + 
        "<td>" + vergino[index]+"</td>" + 
        "<td>" + musterit[index]+"</td>" + 
        "<td><span style='font-size:14px; font-weight: bold;'>" +bakiyesi[index].toLocaleString(undefined,{ minimumFractionDigits: 2 }).toString()+"</span></td>"
         +
        "<td>" + sehir[index]+"</td>" + 
        "<td>" + semt[index]+"</td>" + 
        "<td>" + adres[index]+"</td></tr>" ; }

        $(function () {
          $("#musteririsk").DataTable({
            "responsive": true, "lengthChange": false, "autoWidth": false,
            "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
          }).buttons().container().appendTo('#musteririsk_wrapper .col-md-6:eq(0)');
        });
    }


    let mapsehir = [];
    let mapsemt = [];
    let mapadet = [];
    const data2 = fetch(aktifUrl+'/api/Raporlar/MusteriRiskListesiMap?user=Hepsi',{
      method: 'GET',
      headers: {
        'Authorization': `Bearer ${token}`, 
        'Content-Type': 'application/json'
      }
    }).then(response => response.json()).then(function(datas){
      datas.forEach(element => {
          mapsehir.push(element.sehir);
            mapsemt.push(element.semt);
            mapadet.push(element.adet);
          });
          MapListeOlusturucu()
    });

    var maplist ;
    function MapListeOlusturucu(){
      for (let index = 0; index < mapsehir.length; index++) {
        maplist+=mapsemt[index] + " " + mapsehir[index] + "~" + mapadet[index] +";"
      }
    }

    $( document ).ready(function() {


      var myObjects;
        var myMap;
        ymaps.ready(init);

        function init() {
            myMap = new ymaps.Map('map', {
                center: [41.011225, 28.978151],
                zoom: 9
            });
            myObjects = ymaps.geoQuery(myMap.geoObjects);
            AddGeoObject(maplist,'');
        }
        function AddGeoObject(encodingtxt, centerAddress) {
            myMap.geoObjects.removeAll();
            var geoObject;
            if (centerAddress != null && centerAddress != "") {
                geoObject = myObjects.get(0);
                ymaps.geocode(centerAddress, {
                    results: 1
                }).then(function (res) {
                    var firstGeoObject = res.geoObjects.get(0),
                        coords = firstGeoObject.geometry.getCoordinates(),
                        bounds = firstGeoObject.properties.get('boundedBy');
                    firstGeoObject.options.set('preset', 'islands#darkBlueDotIconWithCaption');
                    firstGeoObject.properties.set('iconCaption', "Merkez");
                    if (geoObject != undefined)
                        myMap.geoObjects.splice(0, 1, firstGeoObject);
                    else
                        myMap.geoObjects.add(firstGeoObject);
                });
            }
            if (encodingtxt != null && encodingtxt != "") {
                const myAddresses = encodingtxt.split(';');
                for (var i = 0; i < myAddresses.length; i++) {
                    geoObject = myObjects.get(i + 1);
                    const addressDetail = myAddresses[i].split('~');
                    ymaps.geocode(addressDetail[0], {
                        results: 1
                    }).then(function (res) {
                        var firstGeoObject = res.geoObjects.get(0),
                            coords = firstGeoObject.geometry.getCoordinates(),
                            bounds = firstGeoObject.properties.get('boundedBy');
                            console.log(firstGeoObject);
                        firstGeoObject.options.set('preset', 'islands#redDotIconWithCaption');
                        firstGeoObject.properties.set('iconCaption', addressDetail[1]);
                        if (geoObject != undefined)
                            myMap.geoObjects.splice(i + 1, 1, firstGeoObject);
                        else
                            myMap.geoObjects.add(firstGeoObject);
                    });
                }
            }
            SetupMap();
        }

        function SetupMap() {
            myObjects = ymaps.geoQuery(Map.geoObjects);
            var geoVisibleResult = myObjects.search('options.visible = true');
   
            if (geoVisibleResult.getLength() == 1)
                myMap.setCenter(geoVisibleResult.get(0).geometry.getCoordinates(), 15);
            else
                myMap.setBounds(geoVisibleResult.getBounds());
        }

        function UpdateIcon(index, colorName) {
            myMap.geoObjects.each(function (obj) {
                var indexObj = obj.properties.get('id');
                obj.options.set("iconColor", colorName);
            })
          }

      // AddGeoObject('Fulyalı Sokağı no:No 7 Transmed tıp merkezi~Y-23844;Yanarsu Sk. no:Yanarsu Sokak Basın Sitesi No:5 daire no:26 B BLOK kat:4~Y-23848;Çam Fıstığı Sk. no: 3 daire no:3 kat:2~Y-23849;','')
    });

