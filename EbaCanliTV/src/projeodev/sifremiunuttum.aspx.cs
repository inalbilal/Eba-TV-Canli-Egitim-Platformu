using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace projeodev
{
    public partial class sifremiunuttum : System.Web.UI.Page
    {
        public static string MD5Olustur(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            object kullanici = Session["KullaniciAdi"];

            if (kullanici != null) //burada da kullanıcının aktif bir girişi var mı diye kontrol ediyorum varsa anasafyaya yönelndiriyorum
            {
                Response.Redirect("/anasayfa.aspx");
            } //*********************

            successalert.Visible = false;
            erroralert.Visible = false;
            alerterororcath.Visible = false;
        }
        string kadi;
        protected void btnSifirla_Click(object sender, EventArgs e)
        {
            object rst;
            //sisteme kayıtlı mail var mı diye kontrol ediyorum ve aktif sıfırlama işlemi var mı diye kontrol ediyoruz
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
            conn.Open();

            MySqlCommand cmdMailSorgu = new MySqlCommand("select count(*) from canliebatvtable where Email=@Email and Reset_ID=''", conn);

            cmdMailSorgu.Parameters.AddWithValue("@Email", txtSifirlamaMail.Text);
            

            rst = cmdMailSorgu.ExecuteScalar();
            conn.Close();
            //***********************************************************************************
            if (Convert.ToInt32(rst) != 0)
            {
                string newPass;
                
                //mail de kullanıcı adını göstermek için kullanıcı adını db den çekiyorum
                conn.Open();

                MySqlCommand cmdKadi = new MySqlCommand("SELECT * FROM canliebatvtable WHERE Email=@Email", conn);
                cmdKadi.Parameters.AddWithValue("@Email", txtSifirlamaMail.Text);
                var readerKadi = cmdKadi.ExecuteReader();
                while (readerKadi.Read())
                {
                    kadi= readerKadi["User_Name"].ToString();

                }
                conn.Close();
                //****************************************


                //reset id yi db e işlediğimiz yer
                Guid guid = Guid.NewGuid();
                string resetID = guid.ToString();

                conn.Open();
                MySqlCommand cmdUpdate = new MySqlCommand("update canliebatvtable Set  Reset_ID =  @Reset_ID where Email = @Email", conn);
                cmdUpdate.Parameters.AddWithValue("@Reset_ID", resetID);
                cmdUpdate.Parameters.AddWithValue("@Email", txtSifirlamaMail.Text);
                cmdUpdate.ExecuteNonQuery();
                conn.Close();
                //*****************************************


                // burada olay oluşturuyorum yani şifre sıfırlama linki 30dk kullanılmazsa otomatik silecek
                conn.Open();
                Guid olayguid = Guid.NewGuid();
                string olayid = olayguid.ToString().Substring(0, 8);
                MySqlCommand cmdOlay = new MySqlCommand("CREATE EVENT olay_"+olayid+ " on schedule at current_timestamp + interval 60 second do update canliebatvtable Set  Reset_ID='', Olay_ID='' where Email = @Email", conn);

                
                cmdOlay.Parameters.AddWithValue("@Email", txtSifirlamaMail.Text);

                cmdOlay.ExecuteNonQuery();
                conn.Close();
                //******************************************************************


                //Burada, olay id yi db e işliyorum silmek içim
                conn.Open();
                MySqlCommand cmdOlayID = new MySqlCommand("update canliebatvtable Set  Olay_ID =  @Olay_ID where Reset_ID = @Reset_ID", conn);
                cmdOlayID.Parameters.AddWithValue("@Reset_ID", resetID);

                cmdOlayID.Parameters.AddWithValue("@Olay_ID","olay_"+olayid);
                cmdOlayID.ExecuteNonQuery();
                conn.Close();
                //***********************************************

                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential("<GMAIL_ADRESİ>", "<GMAIL_ŞİFRESİ>");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.To.Add(txtSifirlamaMail.Text);
                mail.From = new MailAddress("<GMAIL_ADRESİ>", "Şifre Sıfırlama");
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre Sıfırlama";
                mail.Body += "Merhaba <b>" + kadi + "</b>,<br/>Şifre sıfırlama işlemi için bağlantın: <a href='http://localhost:65202/yenisifre.aspx?rid=" + resetID + "' >ŞİFREYİ SIFIRLA</a>";
                try
                {
                    client.Send(mail);


                    successalert.Visible = true;
                    //lblSonuc.Text = "Yeni Şifreniz mail adresinize gönderildi.";
                    Response.AddHeader("REFRESH", "5;URL=giris.aspx");
                }
                catch
                {
                    alerterororcath.Visible = true;
                    //lblSonuc.Text = "Sistemsel bir sorun oluştu lütfen daha sonra tekrar deneyiniz.";
                }

            }
            else
            {
                erroralert.Visible = true;
                //lblSonuc.Text = "Sisteme kayıtlı mail bulunamadı";
            }

        }
    }
}