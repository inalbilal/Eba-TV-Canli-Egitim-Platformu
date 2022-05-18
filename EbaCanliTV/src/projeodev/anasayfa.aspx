<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="anasayfa.aspx.cs" Inherits="projeodev.anasayfa" %>

<!DOCTYPE html>

<html>
    <head>
        <title>Eba Canlı Tv - Anasayfa</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
        <link rel="stylesheet" href="canlitv/stil.css">
        <script src="canlitv/hls.min.js" type="application/javascript"></script>
        <script src="canlitv/ayar.js" type="application/javascript"></script>
         <link rel="icon" href="uyelik/ebacanlitv.ico" type="image/x-icon" />


    </head>

    <body onload="chatYukle();">


                <div id="not-div">
            <div id="not-div-ust">Notlarım</div>
            <div class="form-div">
                <textarea id="notarea" class="txtArea"></textarea>
                <button type="submit" id="kaydetbtn" class="btnKaydet">Kaydet</button>

            </div>

        </div>
      
        <div class="ana">
            <div class="sol">
                <video class="canlivideo" controls autoplay="true" width="100%" height="100%"></video>
                <asp:Label ID="lblSinif" style="display:none" runat="server" ></asp:Label>
                <asp:Label ID="siniflbl" style="display:none"  runat="server"></asp:Label>
                <script src="canlitv/ayar.js" type="application/javascript"></script>
                <script>
                    var url = document.getElementById('lblSinif');
                    ((source) => {
                        if (typeof Hls == "undefined") return console.error("HLS Not Found");
                        if (!document.querySelector("video")) return;
                        var hls = new Hls();
                        hls.loadSource(source);
                        hls.attachMedia(document.querySelector("video"));
                    })(url.textContent);
                </script>
            </div>
            <div class="sag">
                <section class="chat">
                    <header class="menu">
                        <div class="kullanıcı">
                          <i class="fas fa-user-alt"></i> <span id="kadi">
                              <asp:Label ID="lblKullanici" runat="server" Text=""></asp:Label></span>
                        </div>
                        
                        
                        <div style="display: none;" id="menuLinkler">
                            <a href="#quiz" onclick="notFunction();">Not</a>
                            <a href="sikayet.aspx">Şikayet</a>
                            <a href="cikis.aspx" class="cikis">Çıkış</a>
                            
                           
                          </div>
                         <script>
                            function notFunction() {
                                var x = document.getElementById("not-div");
                              if (x.style.display === "block") {
                                x.style.display = "none";
                              } else {
                                  let isMobile = window.matchMedia("only screen and (max-width: 760px)").matches;

                                  if (isMobile) {
                                      x.style.top = "60%";
                                      x.style.left = "50%";
                                      x.style.transform = "translate(-50%, -50%)";
                                  }
                        


                                x.style.display = "block";
                              }
                            }
                            </script>
                        <div class="menu-ikon" ref="javascript:void(0);" onclick="menuFunction()">
                          <span><i class="fas fa-bars"></i></span>
                        </div>
                        <script>
                            function menuFunction() {
                              var x = document.getElementById("menuLinkler");
                              if (x.style.display === "block") {
                                x.style.display = "none";
                              } else {
                                x.style.display = "block";
                              }
                            }
                            </script>
                      </header>
        
                
                    <main id="mesajlar" class="mesajlar">
                
                    
                    </main>
                
                    <div class="inputlar">
                      <input type="text" class="mesaj-input" id="mesaj-input-id" maxlength="35" placeholder="Mesajınızı giriniz">
                      <button type="submit" id="btnMsj" class="gonder-input" onclick="mesajGonder();">Gönder</button>
                    </div>

                    <script>
                      var input = document.getElementById("mesaj-input-id");
                      input.addEventListener("keyup", function (event) {
                          if (event.keyCode === 13) {
                              event.preventDefault();
                              document.getElementById("btnMsj").click();
                          }
                      });
                  </script>
                </section>
    
            </div>


        </div>
         
        <script src='https://use.fontawesome.com/releases/v5.0.13/js/all.js'></script>
        <script src="https://www.gstatic.com/firebasejs/5.8.3/firebase.js"></script>
        <script src="https://www.gstatic.com/firebasejs/5.8.2/firebase-database.js"></script>
        <script>
    
            var firebaseConfig = {
                apiKey: "AIzaSyAaI2RvfGGobkUZJtznJ4vIVmSE2GSCq5c",
                authDomain: "sohbet-1b050.firebaseapp.com",
                databaseURL: "https://sohbet-1b050.firebaseio.com",
                projectId: "sohbet-1b050",
                storageBucket: "sohbet-1b050.appspot.com",
                messagingSenderId: "768882356227",
                appId: "1:768882356227:web:caa3ec7f1f3b792df2de36"
            };
    
            firebase.initializeApp(firebaseConfig);
        </script>
    
    
        <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
            integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
            crossorigin="anonymous"></script>
    </body>


        
</html>