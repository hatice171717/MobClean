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
    public partial class Yüzeyler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void verilerigoster()
        {

            DataTable dtYuzeyler = DbContext.DbClass.TabloOlustur(30, "");
            if (dtYuzeyler.Rows.Count > 0)
            {
                tools.GridDoldur(GrdYuzeyler, dtYuzeyler);
            }

        }
        void temizle()
        {
            txtYuzeyAdi.Text = "";
            txtAcıklama.Text = "";

        }

        private void erisim(bool durum)
        {
            txtYuzeyAdi.Enabled = durum;
            txtAcıklama.Enabled = durum;
            ddlZemin.Enabled = durum;
            ddlTekstil.Enabled = durum;
            ddlAntika.Enabled = durum;
            FileUploadResim.Enabled = durum;
        }
        private void yansıt(int rowindex)
        {


            lbltableId.Text = GrdYuzeyler.Rows[rowindex].Cells[0].Text.ToString();
            txtYuzeyAdi.Text = GrdYuzeyler.Rows[rowindex].Cells[1].Text.ToString();
            //ddlZemin.Text =GrdYuzeyler.Rows[rowindex].Cells[2].Text.ToString();
            //ddlTekstil.Text = GrdYuzeyler.Rows[rowindex].Cells[3].Text.ToString();
            //ddlAntika.Text = GrdYuzeyler.Rows[rowindex].Cells[4].Text.ToString();
            txtAcıklama.Text =GrdYuzeyler.Rows[rowindex].Cells[5].Text.ToString();
            //FileUploadResim.FileName= GrdYuzeyler.Rows[rowindex].Cells[6].Text.ToString();
        }

        protected void GrdYuzeyler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string secilen = e.CommandName.ToString();
            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            //burada kaldım
            switch (secilen)
            {
                case "YENİ":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Yeni Yüzey Giriniz...";
                    BtnSave.Text = "Kaydet";
                    erisim(true);

                    break;
                case "GÜNCELLE":
                    MultiView1.ActiveViewIndex = 1;
                    erisim(true);
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Yüzeyi Güncelleyiniz...";
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
                    string[] Par = { "@YuzeyAdi", "@SertZemin", "@Tekstil", "@Antika", "@Aciklama", "@ResimYol" };
                    string[] Val = { txtYuzeyAdi.Text, ddlZemin.SelectedValue, ddlTekstil.SelectedValue, ddlAntika.SelectedValue, txtAcıklama.Text, FileUploadResim.FileName };
                    sonuc = DbClass.CRUD(Val, Par, 130, "");
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
                    string kosul = "YuzeyId=" + lbltableId.Text;
                    string[] ParU = { "@YuzeyAdi", "@SertZemin", "@Tekstil", "@Antika", "@Aciklama", "@ResimYol" };
                    string[] ValU = { txtYuzeyAdi.Text, ddlZemin.SelectedValue, ddlTekstil.SelectedValue, ddlAntika.SelectedValue, txtAcıklama.Text, FileUploadResim.FileName };
                    sonuc = DbClass.CRUD(ValU, ParU, 330, kosul);

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
                    string kosulD = "YuzeyId=" + lbltableId.Text;
                    string[] ParD = { "@YuzeyAdi", "@SertZemin", "@Tekstil", "@Antika", "@Aciklama", "@ResimYol" };
                    string[] ValD = { txtYuzeyAdi.Text, ddlZemin.SelectedValue, ddlTekstil.SelectedValue, ddlAntika.SelectedValue, txtAcıklama.Text, FileUploadResim.FileName };
                    sonuc = DbClass.CRUD(ValD, ParD, 930, kosulD);
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