function startTimeSofia() {
    var now = new Date(Date.now());
    var formatted = now.getHours() + ":" + now.getMinutes() + ":" + now.getSeconds();
    var formatted1 = now.getDate() + "/" + now.getMonth() + "/" + now.getFullYear();
    document.getElementById('displayMomentSofia').innerHTML = formatted;
    document.getElementById('displayJsDateSofia').innerHTML = formatted1;
    var t = setTimeout(startTimeSofia, 500);
}

startTimeSofia();