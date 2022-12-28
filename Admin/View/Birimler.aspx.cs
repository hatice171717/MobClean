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
    public partial class Birimler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }
        private void temizle()
        {
            txtBirimTipAdi.Text = "";

        }

        private void verilerigoster()
        {
            DataTable dtBirimler = DbContext.DbClass.TabloOlustur(2, "");
            if (dtBirimler.Rows.Count > 0)
            {
                tools.GridDoldur(GrdBirimler, dtBirimler);
            }
        }
        private void erisim(bool durum)
        {
            txtBirimTipAdi.Enabled = durum;
            ddlAktifPasif.Enabled = durum;

        }
        private void yansıt(int rowindex)
        {


            lbltableId.Text = GrdBirimler.Rows[rowindex].Cells[0].Text.ToString();
            txtBirimTipAdi.Text = GrdBirimler.Rows[rowindex].Cells[1].Text.ToString();
            //ddlAktifPasif.SelectedValue = GrdBirimler.Rows[rowindex].Cells[2].Text.ToString();

        }
        protected void GrdBirimler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            string secilen = e.CommandName.ToString();
            switch (secilen)
            {
                case "YENİ":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Yeni Birim Giriniz...";
                    BtnSave.Text = "Kaydet";
                    erisim(true);

                    break;
                case "GÜNCELLE":
                    MultiView1.ActiveViewIndex = 1;
                    erisim(true);
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Birim Güncelleyiniz...";
                    BtnSave.Text = "Güncelle";


                    yansıt(rowindex);

                    break;
                case "SİL":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Aşağıdaki Bilgiler Silinecektir...";
                    BtnSave.Text = "Sil";
                    erisim(false);
                    yansıt(rowindex);
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
                    string[] Par = { "@BirimAdi", "@AktifPasif" };
                    string[] Val = { txtBirimTipAdi.Text, ddlAktifPasif.SelectedValue };
                    sonuc = DbClass.CRUD(Val, Par, 102, "");
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
                    string kosul = "BirimId=" + lbltableId.Text;
                    string[] ParU = { "@BirimAdi", "@AktifPasif" };
                    string[] ValU = { txtBirimTipAdi.Text, ddlAktifPasif.SelectedValue };
                    sonuc = DbClass.CRUD(ValU, ParU, 302, kosul);

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
                    string kosulD = "BirimId=" + lbltableId.Text;
                    string[] ParD = { "@BirimAdi", "@AktifPasif" };
                    string[] ValD = { txtBirimTipAdi.Text, ddlAktifPasif.SelectedValue };
                    sonuc = DbClass.CRUD(ValD, ParD, 902, kosulD);
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