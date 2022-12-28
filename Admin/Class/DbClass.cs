using Admin.Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Admin.DbContext
{
    public class DbClass
    {
        public static SqlConnection Baglan()
        {
            SqlConnection Kopru = new SqlConnection(ConfigurationManager.ConnectionStrings["CleanSysConnectionString"].ConnectionString);
            //SqlConnection Kopru = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CleanSys;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            return Kopru;
        }
        public static DataTable TabloOlustur(int sorguNo, string Sart)
        {
            string sorgu = Sorgu.sorgular(sorguNo);
            sorgu += " " + Sart;
            SqlConnection Anahtar = NewMethod();
            DataTable P_Liste = new DataTable();
            SqlCommand Komut = new SqlCommand();
            Komut.CommandType = CommandType.Text;
            Komut.CommandText = sorgu;
            Komut.Connection = Anahtar;
            Anahtar.Open();
            SqlDataAdapter Adap = new SqlDataAdapter(Komut);
            Komut.ExecuteNonQuery();
            Adap.Fill(P_Liste);
            Anahtar.Close();
            return P_Liste;
        }

        private static SqlConnection NewMethod()
        {
            return Baglan();
        }

        public static string CRUD(string[] Values, string[] Paraetres, int Query, string Whr)
        {
            string query = Sorgu.sorgular(Query);
            if (Whr != "")
            {
                 query += " Where " + Whr;
            }

            string Sonuc = "";

            SqlConnection con = Baglan();

            SqlCommand cmd = new SqlCommand(query, con);
            if (Paraetres.Length > 0)
            {
                for (int i = 0; i < Paraetres.Length; i++)
                {
                    cmd.Parameters.AddWithValue(Paraetres[i].ToString(), Values[i].ToString());
                }
            }


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Sonuc = "1";
            }
            catch (SqlException e)
            {

                Sonuc = "Error Generated. Details: " + e.ToString();

            }
            finally
            {
                con.Close();

            }
            return Sonuc;
        }

    }
}