using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Media;
using System.Security.Cryptography;
using System.Text;

namespace projeodev
{
    public partial class giris : System.Web.UI.Page
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

            if (kullanici != null)//burada da kullanıcının aktif bir girişi var mı diye kontrol ediyorum varsa anasafyaya yönelndiriyorum
            {
                Response.Redirect("/anasayfa.aspx");
            } //**********************************************
            successalert.Visible = false;
            erroralert.Visible = false;
            banalert.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Timeout = 60;

            object obj;
            // burada giriş sorgusunu yapıyorum
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
            conn.Open();

            MySqlCommand cmdGiris = new MySqlCommand("select count(*) from canliebatvtable where (User_Name=@User_Name or Email=@User_Name ) and (Password=@Password)", conn);


            cmdGiris.Parameters.AddWithValue("@User_Name", txtUsername.Text);
            cmdGiris.Parameters.AddWithValue("@Password", MD5Olustur(txtPassword.Text));

            obj = cmdGiris.ExecuteScalar();
            conn.Close();
            if (Convert.ToInt32(obj) != 0)

            {
                //giriş işlemi başarılı ise kullanıcının ban durumunu kontrol ediyorum eğer banlı ise giriş izni verniyorum
                object banDurumu;
                conn.Open();
                MySqlCommand cmdBan = new MySqlCommand("select count(*) from canliebatvtable where (User_Name=@User_Name or Email=@User_Name ) and (Banned=0)", conn);
                cmdBan.Parameters.AddWithValue("@User_Name", txtUsername.Text);
                banDurumu = cmdBan.ExecuteScalar();

                if (Convert.ToInt32(banDurumu) != 0)

                {
                    
                    successalert.Visible = true;
                    Session.Add("KullaniciAdi", txtUsername.Text);
                    Response.Redirect("/anasayfa.aspx");
                }
                else
                {
                    banalert.Visible = true;

                }//***************************************
                txtUsername.Text = "";
                txtPassword.Text = "";
            }

            else

            {

                erroralert.Visible = true;

            }//****************************************************************************


            
            txtUsername.Text = "";
            txtPassword.Text = "";

        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}