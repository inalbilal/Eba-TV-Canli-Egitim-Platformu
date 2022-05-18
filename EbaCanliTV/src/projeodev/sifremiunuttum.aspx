<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sifremiunuttum.aspx.cs" Inherits="projeodev.sifremiunuttum" %>

<!DOCTYPE html>
<html>

<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1">
    <title>Eba Canlı Tv - Şifremi Unuttum</title>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
    <link rel="stylesheet" href="uyelik/style.css">

     <link rel="icon" href="uyelik/ebacanlitv.ico" type="image/x-icon" />

                <style>

        .baslik{

           padding: 70px 0;
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
        <!-- <h1>Şifremi unuttum</h1> -->
       <img src="uyelik/ebacanlitv.svg" style="width: 150px; height: 150px;">
    </div>
	
	<asp:Label ID="erroralert" runat="server" Text="Label">
        <div class="alert">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			Sisteme kayıtlı kullanıcı bulunamıyor veya aktif bir sıfırlama işleminiz bulunuyor.
        </div>
    </asp:Label>

    	<asp:Label ID="alerterororcath" runat="server" Text="Label">
        <div class="alert">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			Sistemsel bir sorun oluştu lütfen daha sonra tekrar deneyiniz.
        </div>
    </asp:Label>

    <asp:Label ID="successalert" runat="server" Text="Label">
        <div class="alert alertsuc">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			Şifre sıfırlama linki mail adresinize gönderildi.
        </div>
    </asp:Label>
	
    <div class="ana form-div">
        <div class="sembol"><i class="fa fa-user" aria-hidden="true"></i></div>
        <div class="form">
            <h2>Şifre unuttum</h2>
            <form id="form1" runat="server">
				<asp:TextBox ID="txtSifirlamaMail" runat="server" TextMode="Email" class="inputlar" placeholder="E-Posta" required></asp:TextBox>
				
				<asp:Button ID="btnSifirla" runat="server" Text="Gönder" class="button" OnClick="btnSifirla_Click" />

            </form>
        </div>
        <div class="yonlendirme">Hesabın yok mu? <a href="kayit.aspx">Kayıt ol</a></div>
    </div>
</div>


    <script src="uyelik/script.js"></script>

</body>

</html>