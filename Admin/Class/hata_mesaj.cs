using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Admin.Class
{
    public class hata_mesaj
    {
        public static void allert(int Kod)
        {
            string Mesaj = HataMesajı(Kod);
            Page pageCurr = HttpContext.Current.Handler as Page;
            if (pageCurr != null)
            {
                ScriptManager.RegisterStartupScript(pageCurr, pageCurr.GetType(), "aKey", "alert('" + Mesaj + "');", true);
            }
        }
        public static void allert_Mess(string Mesaj)
        {

            Page pageCurr = HttpContext.Current.Handler as Page;
            if (pageCurr != null)
            {
                ScriptManager.RegisterStartupScript(pageCurr, pageCurr.GetType(), "aKey", "alert('" + Mesaj + "');", true);
            }
        }

        public static string HataMesajı(int HataKodu)
        {
            string HMesaj = "";
            switch (HataKodu)
            {

                case 1:
                    HMesaj = " İşleminiz Başarı ile gerçekleşmiştir !";
                    break;
                case 2:
                    HMesaj = "İşlem  sırasında teknik hata oldu";
                    break;

            }
            return HMesaj;

        }
    }
}