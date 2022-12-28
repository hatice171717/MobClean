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
    public partial class Bolumler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }
        private void verilerigoster()
        {
            DataTable dtBolumler = DbClass.TabloOlustur(4, "");
            if (dtBolumler.Rows.Count > 0)
            {
                tools.GridDoldur(GrdBolumler, dtBolumler);
            }
        }
        private void temizle()
        {
            txtBolumAdi.Text = "";
            
        }
        protected void GrdBolumler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            string secilen = e.CommandName.ToString();
            switch (secilen)
            {
                case "YENİ":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Yeni Bölüm  Giriniz...";
                    BtnSave.Text = "Kaydet";
                    txtBolumAdi.Enabled = true;
                    DropDownListBolumTip.Enabled = true;

                    break;
                case "GÜNCELLE":
                    MultiView1.ActiveViewIndex = 1;
                    txtBolumAdi.Enabled = true;
                    DropDownListBolumTip.Enabled = true;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Bölüm  Güncelleyiniz...";
                    BtnSave.Text = "Güncelle";


                    txtBolumAdi.Text = GrdBolumler.Rows[rowindex].Cells[1].Text.ToString();
                    DropDownListBolumTip.SelectedValue = GrdBolumler.Rows[rowindex].Cells[2].Text.ToString();
                    lbltableId.Text = GrdBolumler.Rows[rowindex].Cells[0].Text.ToString();

                    break;
                case "SİL":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Aşağıdaki Bilgiler Silinecektir...";
                    BtnSave.Text = "Sil";
                    txtBolumAdi.Enabled = false;
                    DropDownListBolumTip.Enabled = false;

                    txtBolumAdi.Text = GrdBolumler.Rows[rowindex].Cells[1].Text.ToString();
                    DropDownListBolumTip.SelectedValue = GrdBolumler.Rows[rowindex].Cells[2].Text.ToString();
                    lbltableId.Text = GrdBolumler.Rows[rowindex].Cells[0].Text.ToString();

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
                    string[] Par = { "@BolumAdi", "@BolumTipId" };
                    string[] Val = { txtBolumAdi.Text, DropDownListBolumTip.SelectedValue };
                    sonuc = DbClass.CRUD(Val, Par, 104, "");
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
                    string kosul = "BolumId=" + lbltableId.Text;
                    string[] ParU = { "@BolumAdi", "@BolumTipId" };
                    string[] ValU = { txtBolumAdi.Text, DropDownListBolumTip.SelectedValue };
                    sonuc = DbClass.CRUD(ValU, ParU, 304, kosul);

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
                    string kosulD = "BolumId=" + lbltableId.Text;
                    string[] ParD = { "@BolumAdi", "@BolumTipId" };
                    string[] ValD = { txtBolumAdi.Text, DropDownListBolumTip.SelectedValue };
                    sonuc = DbClass.CRUD(ValD, ParD, 904, kosulD);
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