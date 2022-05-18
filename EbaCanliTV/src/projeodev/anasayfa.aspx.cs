using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace projeodev
{
    public partial class anasayfa : System.Web.UI.Page
    {
        string sinif;
        string ban;
        string kullaniciadi;

        protected void Page_Load(object sender, EventArgs e)
        {
            //burada ise kullanıcı gerçekten giriş yapıp mı bu sayfaya gelmiş onu kontrol ediyorum giriş yapıp gelmemişse otomatik giriş sayfasına yönlendiriyorum
            object kullanici = Session["KullaniciAdi"];
            
            if (kullanici == null)
            {
                Response.Redirect("/giris.aspx");
            }
            else //*********************************
            {
        
                
                //burada ise kullanıcının sınıf numarasını ve ban durumunu çekiyorum
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM canliebatvtable WHERE User_Name=@User_Name or Email=@User_Name", conn);
                cmd.Parameters.AddWithValue("@User_Name", kullanici.ToString());
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                  sinif= reader["Sinif"].ToString();
                  ban = reader["Banned"].ToString();
                  kullaniciadi = reader["User_Name"].ToString();

                }
                lblKullanici.Text = kullaniciadi;
               //*******************************

                string ilkokul = "https://tv-e-okul00.medya.trt.com.tr/master_720.m3u8";
                string ortaokul = "https://tv-e-okul01.medya.trt.com.tr/master_720.m3u8";
                string lise = "https://tv-e-okul02.medya.trt.com.tr/master_720.m3u8";

                
                    Session.Add("Kullanici_Adi", kullaniciadi);

                //burada ise db den çektiğim sınıf numarasına göre hangi eba tv nin oynatılmasını kontrol ediyorum


                if ( Convert.ToInt32(sinif)  <= 4)
                {
                    siniflbl.Text = sinif;
                    lblSinif.Text = ilkokul;
                }
                else if (Convert.ToInt32(sinif) <= 8)
                {
                    siniflbl.Text = sinif;
                    lblSinif.Text = ortaokul;
                }
                else
                {
                    siniflbl.Text = sinif;
                    lblSinif.Text = lise;
                }
                //*************************************

                if (Convert.ToInt32(ban) == 1) //sayfayı yenilerse ve ban durumu aktif olursa yani 1 olursa otomatik çıkış yaptırıyorum
                {
                    Response.Redirect("cikis.aspx");
                }
            }


        }

    }
}