<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sikayet.aspx.cs" Inherits="projeodev.sikayet" %>

<!DOCTYPE html>
<html>

<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1">
    <title>Eba Canlı Tv - Kullanıcı Şikayeti</title>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Roboto:400,100,300,500,700,900|RobotoDraft:400,100,300,500,700,900'>
    <link rel='stylesheet' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css'>
    <link rel="stylesheet" href="uyelik/style.css">

     <link rel="icon" href="uyelik/ebacanlitv.ico" type="image/x-icon" />

            <style>

        .baslik{

           padding: 20px 0;
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
       <!-- <h1 style=" font-size: 20px;">Kullanıcı şikayeti</h1> -->
       <img src="uyelik/ebacanlitv.svg" style="width: 150px; height: 150px;">
    </div>
	
	<asp:Label ID="erroralert" runat="server" Text="Label">
        <div class="alert">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			Sistemsel bir sorun oluştu.
        </div>
    </asp:Label>


    <asp:Label ID="successalert" runat="server" Text="Label">
        <div class="alert alertsuc">
			<span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
			Şikayetiniz başarıyla yetkili kişilere iletildi.
        </div>
    </asp:Label>
	
    <div class="ana form-div">
        <div class="sembol"><i class="fa fa-user" aria-hidden="true"></i></div>
        <div class="form">
            <h2>Kullanıcı Şikayeti</h2>
            <form id="form1" runat="server">
			    <asp:DropDownList ID="txtSikayetusr" class="inputlar" runat="server"></asp:DropDownList>
				<asp:TextBox ID="areaNeden" runat="server" class="inputlar" TextMode="MultiLine" Rows="6" placeholder="Şikayet nedeni" style="resize: none;"></asp:TextBox>
                <asp:Button ID="btnSikayetet" runat="server" class="button" OnClick="btnSikayetet_Click"  Text="Gönder" />
		    

            </form>
        </div>
        <div class="yonlendirme"><a href="anasayfa.aspx">Anasayfa</a></div>
    </div>
</div>


    <script src="uyelik/script.js"></script>

</body>

</html>
