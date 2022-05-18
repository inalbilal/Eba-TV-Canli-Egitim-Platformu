
var sinif = document.getElementById('siniflbl');
function mesajGonder() {
    if(sinif.textContent<=4){
            var mesaj = $('#mesaj-input-id').val();
            var kadi = $('#kadi').text();
            if (kadi != "" && mesaj != "") {
                var tarih = new Date();
                var messageKey = firebase.database().ref("ilkokul/").push().key; //Rastgele bir mesaj keyi gönderir.
                firebase.database().ref("ilkokul/" + messageKey).set({
                    message: mesaj,
                    from: kadi,
                    tarih: tarih.getTime(),
                    saat:  new Date().toLocaleTimeString({ hour: "numeric", minute: "numeric"})
                });
                //Otomatik olarak en alt kısma odakanılır
                $("#mesaj-input-id").val(''); //Mesaj inputunu temizleyelim
            } else {
                alert("Lütfen boş alan bırakmayınız!");
            }
    }else if(sinif.textContent<=8){
        var mesaj = $('#mesaj-input-id').val();
            var kadi = $('#kadi').text();
            if (kadi != "" && mesaj != "") {
                var tarih = new Date();
                var messageKey = firebase.database().ref("ortaokul/").push().key; //Rastgele bir mesaj keyi gönderir.
                firebase.database().ref("ortaokul/" + messageKey).set({
                    message: mesaj,
                    from: kadi,
                    tarih: tarih.getTime(),
                    saat:  new Date().toLocaleTimeString({ hour: "numeric", minute: "numeric"})
                });
                //Otomatik olarak en alt kısma odakanılır
                $("#mesaj-input-id").val(''); //Mesaj inputunu temizleyelim
            } else {
                alert("Lütfen boş alan bırakmayınız!");
            }
    }else{
        var mesaj = $('#mesaj-input-id').val();
            var kadi = $('#kadi').text();
            if (kadi != "" && mesaj != "") {
                var tarih = new Date();
                var messageKey = firebase.database().ref("lise/").push().key; //Rastgele bir mesaj keyi gönderir.
                firebase.database().ref("lise/" + messageKey).set({
                    message: mesaj,
                    from: kadi,
                    tarih: tarih.getTime(),
                    saat:  new Date().toLocaleTimeString({ hour: "numeric", minute: "numeric"})
                });
                //Otomatik olarak en alt kısma odakanılır
                $("#mesaj-input-id").val(''); //Mesaj inputunu temizleyelim
            } else {
                alert("Lütfen boş alan bırakmayınız!");
            }
    }
}



function chatYukle() {
    if(sinif.textContent<=4){
        var query = firebase.database().ref("ilkokul");
        var kadi = $("#kadi").text();
        query.on('value', function (snapshot) {
            //$("#mesajlar").html("");
            snapshot.forEach(function (childSnapshot) {
                var data = childSnapshot.val();
                if (data.from == kadi) {
                    //Mesaj bizim tarafımızdan gönderilmişse bu alan çalışacak
                    var mesaj = `<div class="mesajkutusu">
                                    <span class="chatad-sol">`+data.from+`</span>
                                    <p>`+data.message+`</p>
                                    <span class="saat-sol">`+data.saat+`</span>
                                </div>`;
                    $("#mesajlar").append(mesaj);
                } else {
                    //Mesaj başkası tarafından gönderilmişse bu alan çalışacak
                    var mesaj = `<div class="mesajkutusu koyu">
                                    <span class="chatad-sol">`+data.from+`</span>
                                    <p>`+data.message+`</p>
                                    <span class="saat-sol">`+data.saat+`</span>
                                </div>`;
           
                    $("#mesajlar").append(mesaj);
                }
                $("#mesajlar").scrollTop($('#mesajlar')[0].scrollHeight - $('#mesajlar')[0].clientHeight);
            });
            
        });
    
    }else if(sinif.textContent<=8){
        var query = firebase.database().ref("ortaokul");
        var kadi = $("#kadi").text();
        query.on('value', function (snapshot) {
            //$("#mesajlar").html("");
            snapshot.forEach(function (childSnapshot) {
                var data = childSnapshot.val();
                if (data.from == kadi) {
                    //Mesaj bizim tarafımızdan gönderilmişse bu alan çalışacak
                    var mesaj = `<div class="mesajkutusu">
                                    <span class="chatad-sol">`+data.from+`</span>
                                    <p>`+data.message+`</p>
                                    <span class="saat-sol">`+data.saat+`</span>
                                </div>`;
                    $("#mesajlar").append(mesaj);
                } else {
                    //Mesaj başkası tarafından gönderilmişse bu alan çalışacak
                    var mesaj = `<div class="mesajkutusu koyu">
                                    <span class="chatad-sol">`+data.from+`</span>
                                    <p>`+data.message+`</p>
                                    <span class="saat-sol">`+data.saat+`</span>
                                </div>`;
           
                    $("#mesajlar").append(mesaj);
                }
                $("#mesajlar").scrollTop($('#mesajlar')[0].scrollHeight - $('#mesajlar')[0].clientHeight);
            });
            
        });
    }else{
        var query = firebase.database().ref("lise");
        var kadi = $("#kadi").text();
        query.on('value', function (snapshot) {
            //$("#mesajlar").html("");
            snapshot.forEach(function (childSnapshot) {
                var data = childSnapshot.val();
                if (data.from == kadi) {
                    //Mesaj bizim tarafımızdan gönderilmişse bu alan çalışacak
                    var mesaj = `<div class="mesajkutusu">
                                    <span class="chatad-sol">`+data.from+`</span>
                                    <p>`+data.message+`</p>
                                    <span class="saat-sol">`+data.saat+`</span>
                                </div>`;
                    $("#mesajlar").append(mesaj);
                } else {
                    //Mesaj başkası tarafından gönderilmişse bu alan çalışacak
                    var mesaj = `<div class="mesajkutusu koyu">
                                    <span class="chatad-sol">`+data.from+`</span>
                                    <p>`+data.message+`</p>
                                    <span class="saat-sol">`+data.saat+`</span>
                                </div>`;
           
                    $("#mesajlar").append(mesaj);
                }
                $("#mesajlar").scrollTop($('#mesajlar')[0].scrollHeight - $('#mesajlar')[0].clientHeight);
            });
            
        });
    }

}








// not div js kodu



function download(filename, text) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(text));
    element.setAttribute('download', filename);

    element.style.display = 'none';
    document.body.appendChild(element);

    element.click();

    document.body.removeChild(element);
}


document.getElementById("kaydetbtn").addEventListener("click", function () {
    
    var text = document.getElementById("notarea").value;
    var filename = "not.txt";

    download(filename, text);
}, false);


dragElement(document.getElementById("not-div"));

function dragElement(elmnt) {
    var pos1 = 0, pos2 = 0, pos3 = 0, pos4 = 0;
    if (document.getElementById("not-div-ust")) {
       
        document.getElementById("not-div-ust").onmousedown = dragMouseDown;
    } else {
      
        elmnt.onmousedown = dragMouseDown;
    }

    function dragMouseDown(e) {
        e = e || window.event;
        e.preventDefault();
        
        pos3 = e.clientX;
        pos4 = e.clientY;
        document.onmouseup = closeDragElement;
        
        document.onmousemove = elementDrag;
    }

    function elementDrag(e) {
        e = e || window.event;
        e.preventDefault();
  
        pos1 = pos3 - e.clientX;
        pos2 = pos4 - e.clientY;
        pos3 = e.clientX;
        pos4 = e.clientY;
        
        elmnt.style.top = (elmnt.offsetTop - pos2) + "px";
        elmnt.style.left = (elmnt.offsetLeft - pos1) + "px";
    }

    function closeDragElement() {
      
        document.onmouseup = null;
        document.onmousemove = null;
    }
}