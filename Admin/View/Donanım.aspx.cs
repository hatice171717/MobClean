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
    public partial class Donanım : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            verilerigoster();

        }

        private void temizle()
        {
            txtDonanimAdi.Text = "";
        }

        protected void GrdDonanim_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            int rowindex = Convert.ToInt32(e.CommandArgument.ToString());
            string secilen = e.CommandName.ToString();
            switch (secilen)
            {
                case "YENİ":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Yeni Donanım Giriniz...";
                    BtnSave.Text = "Kaydet";
                    txtDonanimAdi.Enabled = true;
                    FileUploadResim.Enabled = true;

                    break;
                case "GÜNCELLE":
                    MultiView1.ActiveViewIndex = 1;
                    txtDonanimAdi.Enabled = true;
                    FileUploadResim.Enabled = true;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Bina Tipini Güncelleyiniz...";
                    BtnSave.Text = "Güncelle";


                    txtDonanimAdi.Text = GrdDonanim.Rows[rowindex].Cells[1].Text.ToString();
                    //FileUploadResim.FileName = GrdDonanim.Rows[rowindex].Cells[2].Text.ToString();
                    lbltableId.Text = GrdDonanim.Rows[rowindex].Cells[0].Text.ToString();

                    break;
                case "SİL":
                    MultiView1.ActiveViewIndex = 1;
                    Baslik.Attributes["class"] = "w3-container w3-blue";
                    BtnSave.CssClass = "w3-button w3-blue";
                    LblBas.Text = "Aşağıdaki Bilgiler Silinecektir...";
                    BtnSave.Text = "Sil";
                    txtDonanimAdi.Enabled = false;
                    FileUploadResim.Enabled = false;
                    txtDonanimAdi.Text = GrdDonanim.Rows[rowindex].Cells[1].Text.ToString();
                    //FileUploadResim.FileName = GrdDonanim.Rows[rowindex].Cells[2].Text.ToString();
                    lbltableId.Text = GrdDonanim.Rows[rowindex].Cells[0].Text.ToString();
                    break;

            }
        }
        private void verilerigoster()
        {
            DataTable dtDonanim = DbClass.TabloOlustur(6, "");
            if (dtDonanim.Rows.Count > 0)
            {
                tools.GridDoldur(GrdDonanim, dtDonanim);
            }

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string sonuc = "";
            int ErrosCodes = -1;

            switch (BtnSave.Text)
            {
                case "Kaydet":
                    string[] Par = { "@DonanimAdi", "@DonanimResim" };
                    string[] Val = { txtDonanimAdi.Text, FileUploadResim.FileName };
                    sonuc = DbClass.CRUD(Val, Par, 106, "");
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
                    string kosul = "DonanimId=" + lbltableId.Text;
                    string[] ParU = { "@DonanimAdi", "@DonanimResim" };
                    string[] ValU = { txtDonanimAdi.Text, FileUploadResim.FileName };
                    sonuc = DbClass.CRUD(ValU, ParU, 306, kosul);

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
                    string kosulD = "DonanimId=" + lbltableId.Text;
                    string[] ParD = { "@DonanimAdi", "@DonanimResim" };
                    string[] ValD = { txtDonanimAdi.Text, FileUploadResim.FileName };
                    sonuc = DbClass.CRUD(ValD, ParD, 906, kosulD);
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