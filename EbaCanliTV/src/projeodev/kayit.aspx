<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kayit.aspx.cs" Inherits="projeodev.kayit" %>

<!DOCTYPE html>
<html>

<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1">
    <title>Eba Canlı Tv - Kayıt</title>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
    <link rel="stylesheet" href="uyelik/style.css">

     <link rel="icon" href="uyelik/ebacanlitv.ico" type="image/x-icon" />

    <style>

        .baslik{

           padding: 6px;
          }

         @media only screen and (max-width: 768px) {
           .baslik{

                   padding: 50px;
             }
        }


    </style>
</head>

<body>
<div class="genel">
    <div class="baslik">
        <!-- <h1>Kayıt Ol</h1> -->

        <img src="uyelik/ebacanlitv.svg" style="width: 150px; height: 150px;">
    </div>
	
	<asp:Label ID="erroralert" runat="server" Text="Label">
        <div class="alert">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			Bu bilgiler ile kayıtlı kullanıcı zaten var.
        </div>
    </asp:Label>

    <asp:Label ID="successalert" runat="server" Text="Label">
        <div class="alert alertsuc">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			Kayıt işlemi başarıyla gerçekleşti.
        </div>
    </asp:Label>
	
    <div class="ana form-div">
        <div class="sembol"><i class="fa fa-user" aria-hidden="true"></i></div>
        <div class="form">
            <h2>Yeni hesap oluştur</h2>
            <form runat="server">
				<asp:TextBox ID="txtUsername" runat="server" class="inputlar" maxlength="20" pattern="[A-Za-z0-9]+" title="Kullanıcı adınız sadece İngiliz alfabesinden ve rakamlardan oluşmalıdır." placeholder="Kullanıcı Adı" required></asp:TextBox>
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="inputlar" maxlength="25" pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$" title="Şifreniz sadece Alphanumeric karakterlerden oluşmalıdır."  placeholder="Şifre" required></asp:TextBox>
				<asp:TextBox ID="txtMail" runat="server" TextMode="Email" class="inputlar" placeholder="E-Posta" required></asp:TextBox>
				<asp:TextBox ID="txtSinif" runat="server" TextMode="Number" class="inputlar" min="1" max="12" placeholder="Sınıf" required></asp:TextBox>
				
				<asp:Button ID="Button1" runat="server" Text="Kayıt ol" class="button" OnClick="Button1_Click" />

            </form>
        </div>
        <div class="yonlendirme">Zaten hesabın var mı? <a href="giris.aspx">Giriş yap</a></div>
    </div>
</div>


    <script src="uyelik/script.js"></script>

</body>

</html>