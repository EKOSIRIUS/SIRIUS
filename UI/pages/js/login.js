function girisYap() {
  var veri; 
  var email=document.getElementById("email").value;
  var sifre=document.getElementById("sifre").value;
  var data = {email:email,password:sifre};
  $.ajax({
        type: "POST",
        url: aktifUrl+'/api/Auth/CreateToken',
        data: JSON.stringify(data),
        contentType: "application/json",
        success:(data,status,xhr) => {
            if(data.statusCode == 200){
              console.log(data);
              sessionStorage.setItem('accessToken', data.data.accessToken);
              var link = window.location.href.split('/');
              link[link.length-1] = "index.html";
              window.location.href = link.toString().replace(/,/g,'/')
            }
          },
          error: (xhr, status, error) => {
            document.getElementById("hata").innerHTML = 'Kullanıcı Adı Veya Şifre Hatalı'
            console.log(xhr);    // XMLHttpRequest nesnesi
            console.log(status); // HTTP durum kodu
            console.log(error);  // Hata mesajı
          }
      })

}