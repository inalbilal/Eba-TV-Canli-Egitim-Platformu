<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yenisifre.aspx.cs" Inherits="projeodev.yenisifre" %>

<!DOCTYPE html>
<html>

<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1">
    <title>Eba Canlı Tv - Şifre Sıfırlama</title>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
    <link rel="stylesheet" href="uyelik/style.css">

     <link rel="icon" href="uyelik/ebacanlitv.ico" type="image/x-icon" />

                <style>

        .baslik{

           padding: 50px 0;
          }

         @media only screen and (max-width: 768px) {
           .baslik{

                   padding: 70px;
             }
        }


    </style>
</head>

<body>
<div class="genel">
   <div class="baslik">
       <!--  <h1>Şifre sıfırlama</h1> -->
       <img src="uyelik/ebacanlitv.svg" style="width: 150px; height: 150px;">


    </div>
	
	<asp:Label ID="erroralert" runat="server" Text="hataligiris">
        <div class="alert">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			İşlem başarısız lütfen daha sonra tekar deneyiniz.
        </div>
    </asp:Label>


    <asp:Label ID="successalert" runat="server" Text="basarligiris">
        <div class="alert alertsuc">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			Şifreniz başarıyla değiştirildi.
        </div>
    </asp:Label>
	
    <div class="ana form-div">
        <div class="sembol"><i class="fa fa-user" aria-hidden="true"></i></div>
        <div class="form">
            <h2>Şifre sıfırlama</h2>
            <form runat="server">
				<asp:TextBox ID="txtYenisifre" runat="server" class="inputlar"  TextMode="Password" maxlength="25" pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$" title="Şifreniz sadece Alphanumeric karakterlerden oluşmalıdır."  placeholder="Yeni şifre" required></asp:TextBox>
				<asp:TextBox ID="txtSifreyeniden" runat="server" TextMode="Password" maxlength="50" class="inputlar" placeholder="Şifre yeniden" required></asp:TextBox>
			
				<asp:Button ID="btnSifirla" runat="server" Text="Sıfırla" class="button" OnClick="btnSifirla_Click" />
                <script>
                    var sifre = document.getElementById("txtYenisifre")
             , sifre_yeniden = document.getElementById("txtSifreyeniden");

                    function validatePassword() {
                        if (sifre.value != sifre_yeniden.value) {
                            sifre_yeniden.setCustomValidity("Girilen şifreler uyuşmuyor!");
                        } else {
                            sifre_yeniden.setCustomValidity('');
                        }
                    }

                    sifre.onchange = validatePassword;
                    sifre_yeniden.onkeyup = validatePassword;
                </script>
            </form>

        </div>
        <div class="yonlendirme"><a href="giris.aspx">Giriş yap</a></div>
    </div>
</div>


    <script src="uyelik/script.js"></script>

</body>

</html>