using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace projeodev
{
    public partial class adminpanel : System.Web.UI.Page
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



        private void kullanicilar()
        {
            //kullanıcı verilerini çektim
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
            conn.Open();

            MySqlCommand cmdTablo = new MySqlCommand("Select * from canliebatvtable", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmdTablo);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            tblKullanicilar.DataSource = ds;
            tblKullanicilar.DataBind();
            conn.Close();

            //Şikayet tablosuna verileri çektim
            conn.Open();
            MySqlCommand cmdSikayet = new MySqlCommand("Select * from sikayettable", conn);
            MySqlDataAdapter adpSikayet = new MySqlDataAdapter(cmdSikayet);
            DataSet dsSikayet = new DataSet();
            adpSikayet.Fill(dsSikayet);
            tblSikayet.DataSource = dsSikayet;
            tblSikayet.DataBind();
            conn.Close();



        }
        protected void Page_Load(object sender, EventArgs e)
        {
            object kullanici = Session["adminKullaniciAdi"];

            if (kullanici == null)
            {
                Response.Redirect("/admingiris.aspx");
            }
            
            if (!IsPostBack)
            {
                kullanicilar();
            }
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
            conn.Open();

            int id = (Convert.ToInt32(((Label)tblKullanicilar.Rows[e.RowIndex].FindControl("Label1")).Text));
            MySqlCommand cmd = new MySqlCommand("Delete From canliebatvtable where id='" + id + "'",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            kullanicilar();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            tblKullanicilar.EditIndex = e.NewEditIndex;
            kullanicilar();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
            con.Open();

            int id = (Convert.ToInt32(((Label)tblKullanicilar.Rows[e.RowIndex].FindControl("Label1")).Text));

            string Banned = ((TextBox)tblKullanicilar.Rows[e.RowIndex].FindControl("TextBox1")).Text;
            string User_Name = ((TextBox)tblKullanicilar.Rows[e.RowIndex].FindControl("TextBox2")).Text;
            //string Password = ((TextBox)tblKullanicilar.Rows[e.RowIndex].FindControl("TextBox3")).Text;
            string Email = ((TextBox)tblKullanicilar.Rows[e.RowIndex].FindControl("TextBox4")).Text; 
            string Sinif = ((TextBox)tblKullanicilar.Rows[e.RowIndex].FindControl("TextBox5")).Text;
            string Reset_ID = ((TextBox)tblKullanicilar.Rows[e.RowIndex].FindControl("TextBox6")).Text;
            string Olay_ID = ((TextBox)tblKullanicilar.Rows[e.RowIndex].FindControl("TextBox7")).Text; 
            string Kayit_Tarih = ((TextBox)tblKullanicilar.Rows[e.RowIndex].FindControl("TextBox8")).Text;




            MySqlCommand cmdUpdate = new MySqlCommand("UPDATE canliebatvtable SET User_Name=@User_Name, Email=@Email,Sinif=@Sinif, Banned=@Banned, Reset_ID=@Reset_ID, Olay_ID=@Olay_ID, Kayit_Tarih=@Kayit_Tarih  WHERE id=@id", con);
            cmdUpdate.Parameters.AddWithValue("@id", id.ToString());

            cmdUpdate.Parameters.AddWithValue("@Banned", Banned);
            cmdUpdate.Parameters.AddWithValue("@User_Name", User_Name);
            //cmdUpdate.Parameters.AddWithValue("@Password", MD5Olustur(Password));
            cmdUpdate.Parameters.AddWithValue("@Email", Email);
            cmdUpdate.Parameters.AddWithValue("@Sinif", Sinif);
            cmdUpdate.Parameters.AddWithValue("@Reset_ID", Reset_ID);
            cmdUpdate.Parameters.AddWithValue("@Olay_ID", Olay_ID);
            cmdUpdate.Parameters.AddWithValue("@Kayit_Tarih", Kayit_Tarih);




            cmdUpdate.ExecuteNonQuery();
            con.Close();
            tblKullanicilar.EditIndex = -1;
            kullanicilar();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            tblKullanicilar.EditIndex = -1;
            kullanicilar();
        }

        protected void tblSikayet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}