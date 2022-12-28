using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Admin.DbContext;
using Admin.Class;

namespace Admin.View
{
    public partial class BinaTiplerI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void verilerigoster()
        {
            DataTable dtBinaTipleri = DbClass.TabloOlustur(1, "");
            if (dtBinaTipleri.Rows.Count > 0)
            {
                tools.GridDoldur(GrdBinaTipleri, dtBinaTipleri);
            }

        }

        protected void GrdBinaTipleri_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            string secilen = e.CommandName.ToString();
            switch (secilen)
            {
                case "YENİ":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Yeni Bina Adını Giriniz...";
                    BtnSave.Text = "Kaydet";
                    txtBinaTipAdi.Enabled = true;
                    txtTipRiskOrani.Enabled = true;

                    break;
                case "GÜNCELLE":
                    MultiView1.ActiveViewIndex = 1;
                    txtBinaTipAdi.Enabled = true;
                    txtTipRiskOrani.Enabled = true;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Bina Tipini Güncelleyiniz...";
                    BtnSave.Text = "Güncelle";
                    

                    txtBinaTipAdi.Text = GrdBinaTipleri.Rows[rowindex].Cells[1].Text.ToString();
                    txtTipRiskOrani.Text = GrdBinaTipleri.Rows[rowindex].Cells[2].Text.ToString();
                    lbltableId.Text = GrdBinaTipleri.Rows[rowindex].Cells[0].Text.ToString();

                    break;
                case "SİL":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Aşağıdaki Bilgiler Silinecektir...";
                    BtnSave.Text = "Sil";
                    txtBinaTipAdi.Enabled = false;
                    txtTipRiskOrani.Enabled = false;
                    txtBinaTipAdi.Text = GrdBinaTipleri.Rows[rowindex].Cells[1].Text.ToString();
                    txtTipRiskOrani.Text = GrdBinaTipleri.Rows[rowindex].Cells[2].Text.ToString();
                    lbltableId.Text = GrdBinaTipleri.Rows[rowindex].Cells[0].Text.ToString();

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
                    string[] Par = { "@BinaTipAdi", "@TipRiskOrani" };
                    string[] Val = { txtBinaTipAdi.Text, txtTipRiskOrani.Text };
                    sonuc = DbClass.CRUD(Val, Par, 101, "");
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
                    break;

                case "Güncelle":
                    string kosul = "BinaTipId=" + lbltableId.Text;
                    string[] ParU = { "@BinaTipAdi", "@TipRiskOrani" };
                    string[] ValU = { txtBinaTipAdi.Text, txtTipRiskOrani.Text };
                    sonuc = DbClass.CRUD(ValU, ParU, 301, kosul);

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

                    break;
                case "Sil":
                    string kosulD = "BinaTipId=" + lbltableId.Text;
                    string[] ParD = { "@BinaTipAdi", "@TipRiskOrani" };
                    string[] ValD = { txtBinaTipAdi.Text, txtTipRiskOrani.Text };
                    sonuc = DbClass.CRUD(ValD, ParD, 901, kosulD);
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
                    break;


            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            txtBinaTipAdi.Text = "";
            txtTipRiskOrani.Text = "";
        }

      
    }
}