using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace Admin.Class
{
    public class tools
    {
        public static void DDDoldur(System.Web.UI.WebControls.DropDownList DD, DataTable Dt, string ValueField, string TextField)
        {

            DD.DataSource = Dt;
            DD.DataValueField = ValueField;
            DD.DataTextField = TextField;
            DD.DataBind();
            DD.Items.Insert(0, new ListItem("Seçiniz ...", "0"));
        }
        public static void GridDoldur(System.Web.UI.WebControls.GridView Grd, DataTable Dt)
        {

            Grd.DataSource = Dt;
            Grd.DataBind();

        }
        /// <summary>
        /// Bu metot Excel'den Sql'e veri aktarmaya yaramaktadır.
        /// </summary>
        /// <param name="excelSource">C:\\Ogrenciler.xls gibi dosyanın olduğu path belirtilmelidir.</param>
        /// <param name="excelSorgusu">Select id,ogrenciAdi From ExcelOgrenciler gibi sorgunuzu yazınız.</param>
        /// <param name="sqlTabloAdi">Sql'deki tablo adınızı yazınız</param>
        /// <param name="ConnectionString">MS-SQL için bağlantı cümleciğiniz</param>
        /// <param name="Parametre">Yollayacağınız parametreleri "ExcelKolonAdı","SqlKolonAdı" şeklinde virgül koyarak dilediğiniz kadar ekleyebilirsiniz</param>
        public static void ExceldenSQLeVeriAktar(string excelSource, string excelSorgusu, string sqlTabloAdi, SqlConnection ConnectionString, params object[] Parametre)
        {
            using (OleDbConnection conExcel = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data source=" + excelSource + "; Extended Properties=Excel 12.0"))
            {
                OleDbCommand cmdExdcel = new OleDbCommand("Select  * From [Sayfa1$]", conExcel);
                conExcel.Open();
                OleDbDataReader drExcel = cmdExdcel.ExecuteReader();

                SqlConnection conSql = ConnectionString;
                SqlBulkCopy sbc = new SqlBulkCopy(conSql);
                sbc.DestinationTableName = sqlTabloAdi;

                if (Parametre != null)
                {
                    for (int i = 0; i < Parametre.Length; i = i + 2)
                    {
                        sbc.ColumnMappings.Add(Parametre[i].ToString(), Parametre[i + 1].ToString());
                    }
                }

                conSql.Open();
                sbc.WriteToServer(drExcel);
                cmdExdcel.Parameters.Clear();
            }
        }
        public static Bitmap resim_boyulandir(Stream resim, int genislik, int yukseklik)
        {
            Bitmap orjinalresim = new Bitmap(resim);
            int yenigenislik = orjinalresim.Width;
            int yeniyukseklik = orjinalresim.Height;
            double enboyorani = Convert.ToDouble(orjinalresim.Width) / Convert.ToDouble(orjinalresim.Height);

            if (enboyorani <= 1 && orjinalresim.Width > genislik)
            {
                yenigenislik = genislik;
                yeniyukseklik = Convert.ToInt32(Math.Round(yenigenislik / enboyorani));
            }
            else if (enboyorani > 1 && orjinalresim.Height > yukseklik)
            {
                yeniyukseklik = yukseklik;
                yenigenislik = Convert.ToInt32(Math.Round(yeniyukseklik * enboyorani));
            }
            return new Bitmap(orjinalresim, yenigenislik, yeniyukseklik);
        }

    }
}