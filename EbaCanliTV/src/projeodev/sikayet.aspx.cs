using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace projeodev
{
    public partial class sikayet : System.Web.UI.Page
    {
        
        object kullaniciadi;

        private void kullanicilar() //burada kullanıcının select-option dan şikayet etmek istediği kullanıcıyı seçmesini sağlıyorum
        {
            kullaniciadi = Session["Kullanici_Adi"];
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
            conn.Open();

            MySqlCommand cmdUsers = new MySqlCommand("SELECT * From canliebatvtable Where User_Name NOT IN (@User_Name)", conn);
            cmdUsers.Parameters.AddWithValue("@User_Name", kullaniciadi.ToString());


            var kullanici_bilgiler = cmdUsers.ExecuteReader();
            while (kullanici_bilgiler.Read())
            {
                txtSikayetusr.Items.Add(kullanici_bilgiler["User_Name"].ToString());

            }
            conn.Close();
        }//***************************************************

        protected void Page_Load(object sender, EventArgs e)
        {

            kullaniciadi = Session["Kullanici_Adi"];

            if (kullaniciadi == null) //burada da kullanıcının aktif bir girişi var mı diye kontrol ediyorum varsa anasafyaya yönelndiriyorum
            {
                Response.Redirect("/giris.aspx");
            } //****************************************


            if (!Page.IsPostBack) //burada ise sayfada şikayet işlemi yapılırsa select-optiondaki kullanıcıların tekrar etmememsi için ilk hali gibi görünmesini sağlamak

            {

                kullanicilar();


            }//****************************************************

            successalert.Visible = false;
            erroralert.Visible = false;

            areaNeden.Attributes.Add("maxlength", "250"); //şikayet nedeni textareasına maxlength ekliyorum


        }

        protected void btnSikayetet_Click(object sender, EventArgs e)
        {
            try //şikayetin veritabanına işlenmesini yapıyoruz
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server = localhost; user id = root; password =; database = canliebatvdb; pooling = false;";
                conn.Open();

                MySqlCommand cmdSikayet = new MySqlCommand("Insert into sikayettable (User_Name, Sikayetci_User_Name, Sikayet_Neden) values (@User_Name, @Sikayetci_User_Name, @Sikayet_Neden)", conn);

                cmdSikayet.Parameters.AddWithValue("@User_Name", txtSikayetusr.SelectedValue);
                cmdSikayet.Parameters.AddWithValue("@Sikayetci_User_Name", kullaniciadi.ToString());
                cmdSikayet.Parameters.AddWithValue("@Sikayet_Neden", areaNeden.Text);


                cmdSikayet.ExecuteNonQuery();
                conn.Close();

                areaNeden.Text = "";
                successalert.Visible = true;
            }
            catch
            {
                erroralert.Visible = true;
            }
            
            

        }
    }
}