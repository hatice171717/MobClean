using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arsiv
{
    internal class yardimci
    {

        public static DialogResult Mesaj_Ver(string mess,int Tip)
        

        {
            DialogResult Sonuc = DialogResult.No;
            switch (Tip)
            {
                case 0:
                    Sonuc = MessageBox.Show(mess, "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);                   
                    break;
                case 1:
                     MessageBox.Show(mess);
                    break;
                default:
                    break;
            }
            return Sonuc;



        }
        public static SqlConnection VeritabaniBaglan(string Sunucu,string Veritabani,string Kullanici,string Sifre)
        {
            SqlConnection Kopru = new SqlConnection();
            string KopruString = "Data Source=" + Sunucu+ ";";
            KopruString += "Initial Catalog =" +Veritabani + ";";
            KopruString += "User ID =" + Kullanici + ";";
            KopruString += "Password =" + Sifre;
            Kopru.ConnectionString = KopruString; 
            return Kopru; 
        }
        public static SqlConnection Kopru()
        {
            SqlConnection Kopru = new SqlConnection();
            string KopruString = "Data Source= . ;";
            KopruString += "Initial Catalog = Arsiv;";
            KopruString += "User ID = z38;";
            KopruString += "Password =z3811072010";
            Kopru.ConnectionString = KopruString;
            return Kopru;

        }
        public static DataTable VeriOku(SqlConnection Baglanti, string Sorgu)
        {
            DataTable DtSonuc = new DataTable();
            try
            {
                Baglanti.Open();
               
                SqlCommand Komut = new SqlCommand(Sorgu, Baglanti);
                SqlDataAdapter D_Ap = new SqlDataAdapter(Komut);
                D_Ap.Fill(DtSonuc);
                Baglanti.Close();
                DtSonuc.Dispose();
            }
            catch (Exception Hata )
            {
                Mesaj_Ver(Hata.Message.ToString(),1); 
            }
            

            return DtSonuc;
        }
        public static string Kaydet_Guncelle_Sil(string islev)
        {
            string sonuc = "";
            try
            {
                SqlConnection conn = Kopru();
                SqlCommand komut = new SqlCommand();
                komut.Connection = conn;
                komut.CommandText = islev;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
                sonuc = "İşlem Başarılı";
            }
            catch (Exception hata)
            {

                sonuc = hata.Message;
            }
            return sonuc;
        }
        public static string CRUD(string sorgu, string[] Parametre,string[] Degerler) //create,read,update,delete
        {
            string sonuc = "";
            try
            {
                SqlConnection baglanti = yardimci.Kopru();
                SqlCommand Komut = new SqlCommand();
                Komut.Connection = baglanti;
                Komut.CommandText=sorgu;
                for (int i = 0; i < Parametre.Length; i++)
                {
                    Komut.Parameters.AddWithValue(Parametre[i].ToString(), Degerler[i].ToString());
                }
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                Komut.ExecuteNonQuery();
                baglanti.Close();
                yardimci.Mesaj_Ver("Kayıt Yapıldı", 1);
                sonuc = "1";
            }
            catch (Exception hata)
            {
                sonuc=hata.Message;
                
            }






            return sonuc;
        }
        
    }
}
