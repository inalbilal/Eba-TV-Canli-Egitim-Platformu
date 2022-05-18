using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace projeodev
{
    public partial class kayit : System.Web.UI.Page
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
            } //*****************************
            successalert.Visible = false;
            erroralert.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try //kayıt işlemi
            {
                DateTime Tarih = DateTime.Now;

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
                conn.Open();

                MySqlCommand cmdKayit = new MySqlCommand("Insert into canliebatvtable (User_Name, Password, Email, Sinif, Banned, Kayit_Tarih) values (@User_Name, @Password, @Email, @Sinif, 0, @Kayit_Tarih)", conn);

                cmdKayit.Parameters.AddWithValue("@User_Name", txtUsername.Text);
                cmdKayit.Parameters.AddWithValue("@Password", MD5Olustur(txtPassword.Text));
                cmdKayit.Parameters.AddWithValue("@Email", txtMail.Text);
                cmdKayit.Parameters.AddWithValue("@Sinif", txtSinif.Text);
                cmdKayit.Parameters.AddWithValue("@Kayit_Tarih", Tarih);

                cmdKayit.ExecuteNonQuery();
                conn.Close();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtMail.Text = "";
                txtSinif.Text = "";
                successalert.Visible = true;
            }
            catch
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtMail.Text = "";
                txtSinif.Text = "";
                erroralert.Visible = true;

            }

        }
    }
}