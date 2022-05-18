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
    public partial class admingiris : System.Web.UI.Page
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
            object kullaniciAdmin = Session["adminKullaniciAdi"];

            if (kullaniciAdmin != null) //burada da admin aktif bir girişi var mı diye kontrol ediyorum varsa anasafyaya yönelndiriyorum
            {
                Response.Redirect("/adminpanel.aspx");
            }  //**********************************************

            successalert.Visible = false;
            erroralert.Visible = false;
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {

            //giriş bilgilerini sorguluyorum doğru ise adminpanel.aspx e yönlendriyorum
            Session.Timeout = 60;

            object obj;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
            conn.Open();

            MySqlCommand cmdAdmingiris = new MySqlCommand("select count(*) from admintable where (User_Name=@User_Name) and (Password=@Password)", conn);

            cmdAdmingiris.Parameters.AddWithValue("@User_Name", txtAdminkadi.Text);
            cmdAdmingiris.Parameters.AddWithValue("@Password", MD5Olustur(txtAdminsifre.Text));

            obj = cmdAdmingiris.ExecuteScalar();

            if (Convert.ToInt32(obj) != 0)

            {

                

                Session.Add("adminKullaniciAdi", txtAdminkadi.Text);
                successalert.Visible = true;
                Response.Redirect("/adminpanel.aspx");

            }

            else

            {
                erroralert.Visible = true;


            }


            conn.Close();
            txtAdminkadi.Text = "";
            txtAdminsifre.Text = "";

            //************************************************************
            
        }
    }
}