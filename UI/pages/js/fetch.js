const getApiDomain = (path) => {
    if (path === "auth")
    {
        if (window.location.hostname === "localhost" || window.location.hostname === "127.0.0.1") 
            return "https:" + "//" + "localhost:7277";
        else  
            return "https:" + "//" + "auth.ekofactoring.com";
    }
    else
    {
        if (window.location.hostname === "localhost" || window.location.hostname === "127.0.0.1") 
            return "https:" + "//" + "localhost:7105";
        else  
            return "https:" + "//" + "siriusapi.ekofactoring.com";
    }
}

if (window.location.pathname === "/login.html")
    var path = "auth";

const aktifUrl = getApiDomain(path);

console.warn("aktif url : " + aktifUrl)