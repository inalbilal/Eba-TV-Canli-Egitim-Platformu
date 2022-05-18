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
    public partial class yenisifre : System.Web.UI.Page
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


        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            erroralert.Visible = false;
            successalert.Visible = false;
            try
            {
                object sorguobj;
                 id = Request.QueryString["rid"].ToString(); // get ile id yi çekiyorum

                if (id == "") //burada id(get) dolu mu boş mu kontrol ediyorum
                {
                    Response.Redirect("giris.aspx");
                }
                else
                {
                    //burada ise get ile id den gelen id değerinin veritabanında olup olmadığını kontrol ediyorum
                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
                    conn.Open();

                    MySqlCommand cmdSorgu = new MySqlCommand("select * from canliebatvtable where (Reset_ID=@Reset_ID)", conn);


                    cmdSorgu.Parameters.AddWithValue("@Reset_ID", id);

                    sorguobj = cmdSorgu.ExecuteScalar();
                    conn.Close();
                    if (Convert.ToInt32(sorguobj) == 0)
                    {
                        Response.Redirect("giris.aspx");
                    } //***********************************************


                }//******************************************************
 

            }
            catch
            {
                Response.Redirect("giris.aspx");
            }
      
        }
        string olayid;

        protected void btnSifirla_Click(object sender, EventArgs e)
        {
            object sonuc;

            //girilen yeni şifreyi reset id kime ait ise o kişinin şifresini güncelliyorum
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
            conn.Open();

            MySqlCommand cmdUpdate = new MySqlCommand("update canliebatvtable Set  Password =  @Password where Reset_ID = @Reset_ID", conn);
            cmdUpdate.Parameters.AddWithValue("@Password", MD5Olustur(txtYenisifre.Text));
            cmdUpdate.Parameters.AddWithValue("@Reset_ID", id);


            sonuc = cmdUpdate.ExecuteNonQuery();
            conn.Close();
            //*************************************************



            //burada ise olay idmizi silmek için db e işlediğiniz olay id yi çekiyoruz
            conn.Open();
            MySqlCommand cmdReset = new MySqlCommand("SELECT * FROM canliebatvtable WHERE Reset_ID=@Reset_ID", conn);
            cmdReset.Parameters.AddWithValue("@Reset_ID", id.ToString());
            var reader = cmdReset.ExecuteReader();
            while (reader.Read())
            {
                olayid = reader["Olay_ID"].ToString();
               
            }
            conn.Close();
            //*************************************************************************


            if (Convert.ToInt32(sonuc) != 0)
            {
                //şifre başarıyla değiştiği için olayımızı siliyoruz
                conn.Open();
                MySqlCommand cmdOlayidsil = new MySqlCommand("DROP EVENT IF EXISTS "+olayid+"", conn);

                cmdOlayidsil.ExecuteNonQuery();
                conn.Close();
                //***************************************


                //şifre başarıyla değiştiği için db deki reset id ve olay id yi siliyoruz.

                conn.Open();
                MySqlCommand cmdSil = new MySqlCommand("update canliebatvtable Set  Reset_ID = '', Olay_ID = '' where Reset_ID = @Reset_ID", conn);
               
                cmdSil.Parameters.AddWithValue("@Reset_ID", id);
                cmdSil.ExecuteNonQuery();
                conn.Close();

                //*****************************************************************


             


                successalert.Visible = true;
                Response.AddHeader("REFRESH", "5;URL=giris.aspx");


            }
            else
            {
                erroralert.Visible = true;


            }

        }
    }
}