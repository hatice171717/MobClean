using Admin.Class;
using Admin.DbContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin.View
{
    public partial class BolumTipleri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }
        private void temizle()
        {
            txtBolumTipAdi.Text = "";
            txtBolumTipRiskOrani.Text = "";
        }

        private void verilerigoster()
        {
            DataTable dtBolumTipleri = DbClass.TabloOlustur(5, "");
            if (dtBolumTipleri.Rows.Count > 0)
            {
                tools.GridDoldur(GrdBolumTipleri, dtBolumTipleri);
            }
        }

        protected void GrdBolumTipleri_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            string secilen = e.CommandName.ToString();
            switch (secilen)
            {
                case "YENİ":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Yeni Bölüm Tipi Giriniz...";
                    BtnSave.Text = "Kaydet";
                    txtBolumTipAdi.Enabled = true;
                    txtBolumTipRiskOrani.Enabled = true;

                    break;
                case "GÜNCELLE":
                    MultiView1.ActiveViewIndex = 1;
                    txtBolumTipAdi.Enabled = true;
                    txtBolumTipRiskOrani.Enabled = true;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Bölüm Tipini Güncelleyiniz...";
                    BtnSave.Text = "Güncelle";


                    txtBolumTipAdi.Text = GrdBolumTipleri.Rows[rowindex].Cells[1].Text.ToString();
                    txtBolumTipRiskOrani.Text = GrdBolumTipleri.Rows[rowindex].Cells[2].Text.ToString();
                    lbltableId.Text = GrdBolumTipleri.Rows[rowindex].Cells[0].Text.ToString();

                    break;
                case "SİL":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Aşağıdaki Bilgiler Silinecektir...";
                    BtnSave.Text = "Sil";
                    txtBolumTipAdi.Enabled = false;
                    txtBolumTipRiskOrani.Enabled = false;
                    txtBolumTipAdi.Text = GrdBolumTipleri.Rows[rowindex].Cells[1].Text.ToString();
                    txtBolumTipRiskOrani.Text = GrdBolumTipleri.Rows[rowindex].Cells[2].Text.ToString();
                    lbltableId.Text = GrdBolumTipleri.Rows[rowindex].Cells[0].Text.ToString();

                    break;

            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string sonuc = "";
            int ErrosCodes = -1;

            switch (BtnSave.Text)
            {
                case "Kaydet":
                    string[] Par = { "@BolumTipiAdi", "@BolumRiskOrani" };
                    string[] Val = { txtBolumTipAdi.Text, txtBolumTipRiskOrani.Text };
                    sonuc = DbClass.CRUD(Val, Par, 105, "");
                    try
                    {
                        ErrosCodes = Convert.ToInt32(sonuc);
                        hata_mesaj.allert(ErrosCodes);
                        verilerigoster();
                        MultiView1.ActiveViewIndex = 0;
                    }
                    catch (Exception)
                    {
                        hata_mesaj.allert_Mess(sonuc);
                    }
                    temizle();
                    break;


                case "Güncelle":
                    string kosul = "BolumTipId=" + lbltableId.Text;
                    string[] ParU = { "@BolumTipiAdi", "@BolumRiskOrani" };
                    string[] ValU = { txtBolumTipAdi.Text, txtBolumTipRiskOrani.Text };
                    sonuc = DbClass.CRUD(ValU, ParU, 305, kosul);

                    try
                    {
                        ErrosCodes = Convert.ToInt32(sonuc);
                        hata_mesaj.allert(ErrosCodes);
                        verilerigoster();
                        MultiView1.ActiveViewIndex = 0;
                    }
                    catch (Exception)
                    {
                        hata_mesaj.allert_Mess(sonuc);
                    }
                    temizle();
                    break;
                case "Sil":
                    string kosulD = "BolumTipId=" + lbltableId.Text;
                    string[] ParD = { "@BolumTipiAdi", "@BolumRiskOrani" };
                    string[] ValD = { txtBolumTipAdi.Text, txtBolumTipRiskOrani.Text };
                    sonuc = DbClass.CRUD(ValD, ParD, 905, kosulD);
                    try
                    {
                        ErrosCodes = Convert.ToInt32(sonuc);
                        hata_mesaj.allert(ErrosCodes);
                        verilerigoster();
                        MultiView1.ActiveViewIndex = 0;
                    }
                    catch (Exception)
                    {
                        hata_mesaj.allert_Mess(sonuc);
                    }
                    temizle();
                    break;


            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            temizle();
        }
    }
}