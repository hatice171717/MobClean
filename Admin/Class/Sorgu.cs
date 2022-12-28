using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Class
{
    public class Sorgu
    {
        public static string sorgular(int SorguNo)
        {
            // Her tablo için Case açacağız..
            // 000 - 100 case Select cümlesi olacak
            // 101 - 300 arasında Insert
            // 301 - 500 arası Update
            // 500 - 900 Raporlama işlemleri
            // 900 - 999 arası Delete
            string sorgu = "";
            switch (SorguNo)
            {
                // İlk 100 case SELECT......FROM için yazılacak
                case 1:
                    sorgu = " SELECT  [BinaTipId],[BinaTipAdi],[TipRiskOrani]  FROM [CleanSys].[dbo].[BinaTipleri] ";
                    break;
                case 2:
                    sorgu = " SELECT [BirimId],[BirimAdi],[AktifPasif] FROM[dbo].[Birimler] ";
                    break;
                case 3:
                    sorgu = "SELECT [BDId],[PBId],[DonanimId],[DMiktar],[BirimId],[YuzeyId],[YMiktar]FROM[dbo].[BolumDonanimlari]";
                    break;
                case 4:
                    sorgu = "SELECT [BolumId],[BolumAdi],[BolumTipId]FROM[dbo].[Bolumler]";
                    break;
                case 5:
                    sorgu = "SELECT [BolumTipId],[BolumTipiAdi],[BolumRiskOrani] FROM[dbo].[BolumTipleri]";
                    break;
                case 6:
                    sorgu = "SELECT [DonanimId],[DonanimAdi],[DonanimResim] FROM[dbo].[Donanimlar]";
                    break;
                case 7:
                    sorgu = "SELECT [FiyatListesiId],[MakineId],[KimyasalId],[MeslekId],[miktar],[BirimId],[Tutar],[ListeGecerlilikTarihi],[Aktif] FROM[dbo].[FiyatListesi]";
                    break;
                case 8:
                    sorgu = "SELECT [IlceId],[IlceAdi],[IlId] FROM[dbo].[Ilceler]";
                    break;
                case 9:
                    sorgu = "SELECT [IlId],[IlAdi] FROM[dbo].[Iller]";
                    break;
                case 10:
                    sorgu = "SELECT [Kimyasalld],[KimyasalAdi],[Ph],[UreticiId] FROM[dbo].[Kimyasallar]";
                    break;
                case 11:
                    sorgu = "SELECT [MakineId],[MakineAdi],[Aktif],[AlimTarihi],[AmortismanSuresi] FROM [dbo].[Makineler]";
                    break;
                case 12:
                    sorgu = "SELECT [MalzemeId],[MalzemeAdi],[UreticiId] ,[BirimId] FROM[dbo].[Malzemeler]";
                    break;
                case 13:
                    sorgu = "SELECT [MeslekId],[MeslekAdi],[Yeterlilik] FROM[dbo].[Meslekler]";
                    break;
                case 14:
                    sorgu = "SELECT [MusteriHarketId],[MusteriId],[IslemTipi],[Tutar] FROM[dbo].[MusteriHareketleri]";
                    break;
                case 15:
                    sorgu = "SELECT MusteriId,MusteriAdi,MusteriAdresi,MusteriVergiDairesi,MusteriVergiNo,MusteriYetkiliAdi,MusteriYetkiliTelefon,MusteriYetkiliDahili,MusteriWebAdresi,MusteriMersisNo,MusteriTehlikeSinifi,MusteriEPosta,AboneBaşlama,AboneBitis,Aktif,MaksimumProjeSayisi,KullanilanProjeSayisi,Aciklama FROM Musteriler ";
                    break;
                case 16:
                    sorgu = "SELECT [PersonelId],[MusteriId],[PersonelAdi],[PersonelSoyadi],[PersonelTc],[MeslekId],[PersonelTelefon],[PersonelMail],[PersonelCinsiyet],[PersonelEgitim],[PersonelMedeni],[PersonelCocuk],[PersonelDogumTarihi],[PersonelAciklama],[IseBaslamaTarihi],[IstenAyrilmaTarihi],[Alerji],[AlerjiDetay],[Sifre] FROM[dbo].[Personel]";
                    break;
                case 17:
                    sorgu = "SELECT [BinaId] ,[ProjeId] ,[BinaAdi],[BinaAdresi],[BinaIl] ,[BinaIlce] ,[BinaTipId] ,[BinaPersonelId]  FROM[dbo].[ProjeBinalari]";
                    break;
                case 18:
                    sorgu = "SELECT [PBId],[ProjeId],[PBolumID],[PBolumMiktar],[BirimId] FROM[dbo].[ProjeBolumleri]";
                    break;
                case 19:
                    sorgu = "SELECT [PKontrolId] ,[ProjeId],[BolumId] ,[PersonelId] ,[BaslamaZamani] ,[BitisZamani] FROM[dbo].[ProjeBolumTamamlama]";
                    break;
                case 20:
                    sorgu = "SELECT [PDonanimId] ,[PKontrolId] ,[DonanimId],[TamamlamaZamani] ,[BaslamaZamani] FROM[dbo].[ProjeDonanimTamamlama]";
                    break;
                case 21:
                    sorgu = "SELECT [PKimyasalId] ,[ProjeId],[KimyasalId],[Miktar] ,[BirimId] FROM[dbo].[ProjeKimyasallari]";
                    break;
                case 22:
                    sorgu = "SELECT [ProjeId] ,[ProjeAdi],[MusteriId],[ProjeFirmaUnvani],[ProjeAdresi],[ProjeVergiDairesi],[ProjeVergiNo],[ProjeIl],[ProjeIlce],[ProjeIk] ,[ProjeYetkiliAdi],[ProjeYetkiliTel],[ProjeYetkiliMail],[ProjeTehlikeSinifi],[Aciklama] FROM[dbo].[Projeler]";
                    break;
                case 23:
                    sorgu = "SELECT [PMakineId],[ProjeId],[MakineId],[BaslamaTarihi],[BitisTarihi]FROM[dbo].[ProjeMakineleri]";
                    break;
                case 24:
                    sorgu = "SELECT [PMalzemeId],[ProjeId],[MalzemeId],[Miktar],[BirimId] FROM[dbo].[ProjeMalzemeleri]";
                    break;
                case 25:
                    sorgu = "SELECT [ProjeIkId] ,[ProjeId],[PersonelId],[BaslamaTarihi],[AyrılmaTarihi] FROM[dbo].[ProjePersonelleri]";
                    break;
                case 26:
                    sorgu = "SELECT [TeklifId] ,[ProjeId] ,[YuzeyId] ,[DonanimId] ,[MalzemeId] ,[KimyasalId] ,[MakineId] ,[Miktar],[BirimId] FROM[dbo].[ProjeTeklifleri]";
                    break;
                case 27:
                    sorgu = "SELECT [StokHareketId],[MalzemeId],[HareketTarihi],[AlimMiktari] ,[KullanimMiktari] ,[ProjeId] ,[UreticiId] ,[BirimId] FROM[dbo].[StokHareketleri]";
                    break;
                case 28:
                    sorgu = "SELECT [UreticiHareketId],[UreticiId],[HareketTarihi],[IslemTipi],[MalzemeId] ,[MakineId] ,[KimyasalId],[Miktar] ,[BirimId] ,[Tutar] FROM[dbo].[UreticiHareketleri]";
                    break;
                case 29:
                    sorgu = "SELECT [UreticiId],[UreticiAdi],[UreticiAdresi],[UreticiVergiDairesi],[UreticiVergiNo],[UreticiYetkiliAdi],[UreticiYetkiliTelefon],[UreticiYetkiliDahili],[UreticiWebAdresi],[UreticiMersisNo],[UreticiTehlikeSinifi] FROM[dbo].[Ureticiler]";
                    break;
                case 30:
                    sorgu = "SELECT [YuzeyId],[YuzeyAdi],SertZemin, Tekstil, Antika, Aciklama,ResimYol FROM[dbo].[Yuzeyler]";
                    break;
                case 31:
                    sorgu = "SELECT [YStandartId] ,[YId] ,[KimyasalId] ,[MakineId] ,[YMalzemeId] ,[StandartDeger] ,[BirimId]FROM[dbo].[YuzeyStandartlari]";
                    break;




                // 101 - 300  case arasında İNSERT İNTO.....VALUES için yazılacak
                case 101:
                    sorgu = "INSERT INTO [dbo].[BinaTipleri] ([BinaTipAdi] ,[TipRiskOrani]) VALUES (@BinaTipAdi, @TipRiskOrani) ";
                    break;
                case 102:
                    sorgu = "INSERT INTO [dbo].[Birimler] ([BirimAdi],[AktifPasif])  VALUES  (@BirimAdi, @AktifPasif)";
                    break;
                
                case 103:
                    sorgu = "INSERT INTO [dbo].[BolumDonanimlari]([PBId],[DonanimId],[DMiktar],[BirimId],[YuzeyId],[YMiktar]) VALUES (@PBId, @DonanimId, @DMiktar, @BirimId, @YuzeyId,@YMiktar,)";
                    break;
                case 104:
                    sorgu = "INSERT INTO [dbo].[Bolumler] ([BolumAdi],[BolumTipId]) VALUES (@BolumAdi, @BolumTipId)";
                    break;
                case 105:
                    sorgu = "INSERT INTO [dbo].[BolumTipleri] ([BolumTipiAdi],[BolumRiskOrani]) VALUES(@BolumTipiAdi,@BolumRiskOrani)";
                    break;
                case 106:
                    sorgu = "INSERT INTO [dbo].[Donanimlar] ([DonanimAdi],[DonanimResim]) VALUES(@DonanimAdi, @DonanimResim)";
                    break;
                case 107:
                    sorgu = "INSERT INTO [dbo].[FiyatListesi]([MalzemeId],[MakineId],[KimyasalId],[MeslekId],[miktar],[BirimId],[Tutar],[ListeGecerlilikTarihi],[Aktif])  VALUES (@MalzemeId, @MakineId, @KimyasalId, @MeslekId, @miktar, @BirimId, @Tutar, @ListeGecerlilikTarihi, @Aktif)";
                    break;
                case 108:
                    sorgu = "INSERT INTO [dbo].[Ilceler] ([IlceAdi] ,[IlId])  VALUES (@IlceAdi, @IlId)";
                    break;
                case 109:
                    sorgu = "INSERT INTO [dbo].[Iller] ([IlAdi]) VALUES (@IlAdi, )";
                    break;
                case 110:
                    sorgu = "INSERT INTO [dbo].[Kimyasallar] ([KimyasalAdi],[Ph] ,[UreticiId]) VALUES (@KimyasalAdi , @Ph, @UreticiId)";
                    break;
                case 111:
                    sorgu = "INSERT INTO [dbo].[Makineler]([MakineAdi],[Aktif],[AlimTarihi],[AmortismanSuresi]) VALUES (@MakineAdi , @Aktif, @AlimTarihi , @AmortismanSuresi)";
                    break;
                case 112:
                    sorgu = "INSERT INTO [dbo].[Malzemeler] ([MalzemeAdi],[UreticiId],[BirimId]) VALUES (@MalzemeAdi, @UreticiId, @BirimId)";
                    break;
                case 113:
                    sorgu = "INSERT INTO [dbo].[Meslekler] ([MeslekAdi],[Yeterlilik]) VALUES (@MeslekAdi, @Yeterlilik)";
                    break;
                case 114:
                    sorgu = "INSERT INTO [dbo].[MusteriHareketleri]([MusteriId],[IslemTipi],[Tutar]) VALUES  (@MusteriId , @IslemTipi, @Tutar)";
                    break;
                case 115:
                    sorgu = "INSERT INTO [dbo].[Musteriler](MusteriAdi,MusteriAdresi,MusteriVergiDairesi,MusteriVergiNo,MusteriYetkiliAdi,MusteriYetkiliTelefon,MusteriYetkiliDahili,MusteriWebAdresi,MusteriMersisNo,MusteriTehlikeSinifi,MusteriEPosta,AboneBaşlama,AboneBitis,Aktif,MaksimumProjeSayisi,KullanilanProjeSayisi,Aciklama) VALUES (@MusteriAdi,@MusteriAdresi,@MusteriVergiDairesi,@MusteriVergiNo,@MusteriYetkiliAdi,@MusteriYetkiliTelefon,@MusteriYetkiliDahili,@MusteriWebAdresi,@MusteriMersisNo,@MusteriTehlikeSinifi,@MusteriEPosta,@AboneBaşlama,@AboneBitis,@Aktif,@MaksimumProjeSayisi,@KullanilanProjeSayisi,@Aciklama)";
                    break;
                case 116:
                    sorgu = "INSERT INTO [dbo].[Projeler]([ProjeAdi],[MusteriId],[ProjeFirmaUnvani],[ProjeAdresi],[ProjeVergiDairesi],[ProjeVergiNo],[ProjeIl],[ProjeIlce] ,[ProjeIk] ,[ProjeYetkiliAdi],[ProjeYetkiliTel],[ProjeYetkiliMail],[ProjeTehlikeSinifi],[Aciklama]) VALUES (@ProjeAdi , @MusteriId , @ProjeFirmaUnvani, @ProjeAdresi, @ProjeVergiDairesi, @ProjeVergiNo , @ProjeIl , @ProjeIlce , @ProjeIk , @ProjeYetkiliAdi, @ProjeYetkiliTel, @ProjeYetkiliMail , @ProjeTehlikeSinifi, @Aciklama)";
                    break;
                case 117:
                    sorgu = "INSERT INTO [dbo].[ProjeBinalari] ([ProjeId],[BinaAdi],[BinaAdresi],[BinaIl],[BinaIlce],[BinaTipId],[BinaPersonelId])  VALUES (@ProjeId           , @BinaAdi, @BinaAdresi, @BinaIl, @BinaIlce, @BinaTipId , @BinaPersonelId)";
                    break;
                case 118:
                    sorgu = "INSERT INTO [dbo].[ProjeBolumleri] ([PBId],[ProjeId],[PBolumID],[PBolumMiktar] ,[BirimId]) VALUES (@PBId , @ProjeId , @PBolumID, @PBolumMiktar , @BirimId)";
                    break;
                case 119:
                    sorgu = "INSERT INTO [dbo].[ProjeBolumTamamlama] ([ProjeId] ,[BolumId],[PersonelId] ,[BaslamaZamani] ,[BitisZamani]) VALUES (@ProjeId , @BolumId , @PersonelId  , @BaslamaZamani  , @BitisZamani)";
                    break;
                case 120:
                    sorgu = "INSERT INTO [dbo].[ProjeDonanimTamamlama] ([PKontrolId],[DonanimId],[TamamlamaZamani],[BaslamaZamani]) VALUES (@PKontrolId , @DonanimId , @TamamlamaZamani , @BaslamaZamani)";
                    break;
                case 121:
                    sorgu = "INSERT INTO [dbo].[ProjeKimyasallari]([ProjeId],[KimyasalId] ,[Miktar],[BirimId]) VALUES (@ProjeId,@KimyasalId, @Miktar, @BirimId,)";
                    break;
                case 122:
                    sorgu = "INSERT INTO [dbo].[Projeler]([ProjeAdi],[MusteriId],[ProjeFirmaUnvani],[ProjeAdresi],[ProjeVergiDairesi],[ProjeVergiNo],[ProjeIl]  ,[ProjeIlce] ,[ProjeIk] ,[ProjeYetkiliAdi] ,[ProjeYetkiliTel],[ProjeYetkiliMail],[ProjeTehlikeSinifi],[Aciklama]) VALUES (@ProjeAdi, @MusteriId, @ProjeFirmaUnvani, @ProjeAdresi, @ProjeVergiDairesi, @ProjeVergiNo , @ProjeIl , @ProjeIlce, @ProjeIk , @ProjeYetkiliAdi , @ProjeYetkiliTel , @ProjeYetkiliMail, @ProjeTehlikeSinifi , @Aciklama)";
                    break;
                case 123:
                    sorgu = "INSERT INTO [dbo].[ProjeMakineleri]([ProjeId],[MakineId],[BaslamaTarihi],[BitisTarihi]) VALUES (@ProjeId, @MakineId, @BaslamaTarihi , @BitisTarihi)";
                    break;
                case 124:
                    sorgu = "INSERT INTO [dbo].[ProjeMalzemeleri] ([ProjeId] ,[MalzemeId] ,[Miktar] ,[BirimId]) VALUES (@ProjeId , @MalzemeId , @Miktar , @BirimId)";
                    break;
                case 125:
                    sorgu = "INSERT INTO [dbo].[ProjePersonelleri]([ProjeId] ,[PersonelId],[BaslamaTarihi] ,[AyrılmaTarihi]) VALUES (@ProjeId , @PersonelId , @BaslamaTarihi , @AyrılmaTarihi)";
                    break;
                case 126:
                    sorgu = "INSERT INTO [dbo].[ProjeTeklifleri]([TeklifId],[ProjeId],[YuzeyId] ,[DonanimId],[MalzemeId],[KimyasalId] ,[MakineId] ,[Miktar] ,[BirimId]) VALUES (@TeklifId , @ProjeId , @YuzeyId  , @DonanimId  , @MalzemeId , @KimyasalId , @MakineId , @Miktar , @BirimId)"; break;
                case 127:
                    sorgu = "INSERT INTO [dbo].[StokHareketleri] ([MalzemeId] ,[HareketTarihi],[AlimMiktari] ,[KullanimMiktari] ,[ProjeId] ,[UreticiId] ,[BirimId]) VALUES  (@MalzemeId , @HareketTarihi , @AlimMiktari, @KullanimMiktari , @ProjeId, @UreticiId , @BirimId)";
                    break;
                case 128:
                    sorgu = "INSERT INTO [dbo].[UreticiHareketleri] ([UreticiId],[HareketTarihi] ,[IslemTipi] ,[MalzemeId],[MakineId],[KimyasalId] ,[Miktar] ,[BirimId],[Tutar]) VALUES (@UreticiId , @HareketTarihi , @IslemTipi , @MalzemeId, @MakineId, @KimyasalId, @Miktar, @BirimId, @Tutar)";
                    break;
                case 129:
                    sorgu = "INSERT INTO [dbo].[Ureticiler] ([UreticiAdi],[UreticiAdresi] ,[UreticiVergiDairesi],[UreticiVergiNo],[UreticiYetkiliAdi],[UreticiYetkiliTelefon],[UreticiYetkiliDahili],[UreticiWebAdresi],[UreticiMersisNo],[UreticiTehlikeSinifi]) VALUES (@UreticiAdi, @UreticiAdresi, @UreticiVergiDairesi, @UreticiVergiNo, @UreticiYetkiliAdi, @UreticiYetkiliTelefon, @UreticiYetkiliDahili, @UreticiWebAdresi, @UreticiMersisNo, @UreticiTehlikeSinifi)";
                    break;
                case 130:
                    sorgu = "INSERT INTO  Yuzeyler (YuzeyAdi ,SertZemin ,Tekstil ,Antika ,Aciklama ,ResimYol) VALUES (@YuzeyAdi ,@SertZemin ,@Tekstil ,@Antika ,@Aciklama ,@ResimYol)";
                    break;
                case 131:
                    sorgu = "INSERT INTO [dbo].[YuzeyStandartlari] ([YId],[KimyasalId],[MakineId],[YMalzemeId],[StandartDeger],[BirimId])VALUES (@YId, @KimyasalId, @MakineId, @YMalzemeId, @StandartDeger, @BirimId)";
                    break;


                // 301 - 500  case arası UPDATE....SET için yazılacak

                case 301:
                    sorgu = "UPDATE [dbo].[BinaTipleri]   SET[BinaTipAdi] = @BinaTipAdi      ,[TipRiskOrani] = @TipRiskOrani";
                    break;
                case 302:
                    sorgu = "UPDATE[dbo].[Birimler] SET[BirimAdi] = @BirimAdi, [AktifPasif] = @AktifPasif";
                    break;
                case 303:
                    sorgu = "UPDATE [dbo].[BolumDonanimlari] SET [PBId] = @PBId ,[DonanimId] = @DonanimId,[DMiktar] = @DMiktar, [BirimId] = @BirimId,[YuzeyId] = @YuzeyId, [YMiktar] = @YMiktar, ";
                    break;
                case 304:
                    sorgu = "UPDATE [dbo].[Bolumler] SET[BolumAdi] = @BolumAdi,[BolumTipId] = @BolumTipId ";
                    break;
                case 305:
                    sorgu = "UPDATE [dbo].[BolumTipleri] SET[BolumTipiAdi] = @BolumTipiAdi,[BolumRiskOrani] = @BolumRiskOrani";
                    break;
                case 306:
                    sorgu = "UPDATE [dbo].[Donanimlar] SET[DonanimAdi] = @DonanimAdi,[DonanimResim] = @DonanimResim";
                    break;
                case 307:
                    sorgu = "UPDATE [dbo].[FiyatListesi] SET[MalzemeId] = @MalzemeId,[MakineId] = @MakineId ,[KimyasalId] = @KimyasalId ,[MeslekId] = @MeslekId [miktar] = @miktar,[BirimId] = @BirimId, [Tutar] = @Tutar,[ListeGecerlilikTarihi] = @ListeGecerlilikTarihi ,[Aktif] = @Aktif,";
                    break;
                case 308:
                    sorgu = "UPDATE [dbo].[Ilceler] SET[IlceAdi] = @IlceAdi ,[IlId] = @IlId";
                    break;
                case 309:
                    sorgu = "UPDATE [dbo].[Iller] SET[IlAdi] = @IlAdi,";
                    break;
                case 310:
                    sorgu = "UPDATE [dbo].[Kimyasallar] SET[KimyasalAdi] = @KimyasalAdi ,[Ph] = @Ph,[UreticiId] = @UreticiId";
                    break;
                case 311:
                    sorgu = "UPDATE [dbo].[Makineler] SET[MakineAdi] = @MakineAdi,[Aktif] = @Aktif,[AlimTarihi] = @AlimTarihi,[AmortismanSuresi] = @AmortismanSuresi";
                    break;
                case 312:
                    sorgu = "UPDATE [dbo].[Malzemeler] SET[MalzemeAdi] = @MalzemeAdi,[UreticiId] = @UreticiId,[BirimId] = @BirimId, ";
                    break;
                case 313:
                    sorgu = "UPDATE [dbo].[Meslekler] SET[MeslekAdi] = @MeslekAdi,[Yeterlilik] = @Yeterlilik";
                    break;
                case 314:
                    sorgu = "UPDATE [dbo].[MusteriHareketleri] SET[MusteriId] = @MusteriId,[IslemTipi] = @IslemTipi ,[Tutar] = @Tutar, ";
                    break;
                case 315:
                    sorgu = "UPDATE [dbo].[Musteriler] SET[MusteriAdi] = @MusteriAdi,[MusteriAdresi] = @MusteriAdresi,[MusteriVergiDairesi] = @MusteriVergiDairesi,[MusteriVergiNo] = @MusteriVergiNo,[MusteriYetkiliAdi] = @MusteriYetkiliAdi     ,[MusteriYetkiliTelefon] = @MusteriYetkiliTelefon,[MusteriYetkiliDahili] = @MusteriYetkiliDahili,[MusteriWebAdresi] = @MusteriWebAdresi,[MusteriMersisNo] = @MusteriMersisNo ,[MusteriTehlikeSinifi] = @MusteriTehlikeSinifi, MusteriEPosta = @MusteriEPosta, AboneBaşlama = @AboneBaşlama, AboneBitis = @AboneBitis,Aktif = @Aktif, MaksimumProjeSayisi= @MaksimumProjeSayisi, KullanilanProjeSayisi = @KullanilanProjeSayisi, Aciklama = @Aciklama ";
                    break;
                case 316:
                    sorgu = "UPDATE [dbo].[Personel] SET[MusteriId] = @MusteriId ,[PersonelAdi] = @PersonelAdi,[PersonelSoyadi] = @PersonelSoyadi,[PersonelTc] = @PersonelTc ,[MeslekId] = @MeslekId, [PersonelTelefon] = @PersonelTelefon,[PersonelMail] = @PersonelMail,[PersonelCinsiyet] = @PersonelCinsiyet ,[PersonelEgitim] = @PersonelEgitim ,[PersonelMedeni] = @PersonelMedeni,[PersonelCocuk] = @PersonelCocuk,[PersonelDogumTarihi] = @PersonelDogumTarihi,[PersonelAciklama] = @PersonelAciklama,[IseBaslamaTarihi] = @IseBaslamaTarihi ,[IstenAyrilmaTarihi] = @IstenAyrilmaTarihi ,[Alerji] = @Alerji,[AlerjiDetay] = @AlerjiDetay,[Sifre] = @Sifre";
                    break;
                case 317:
                    sorgu = "UPDATE [dbo].[ProjeBinalari] SET[ProjeId] = @ProjeId,[BinaAdi] = @BinaAdi,[BinaAdresi] = @BinaAdresi,[BinaIl] = @BinaIl,[BinaIlce] = @BinaIlce,[BinaTipId] = @BinaTipId,[BinaPersonelId] = @BinaPersonelId";
                    break;
                case 318:
                    sorgu = "UPDATE [dbo].[ProjeBolumleri] SET[PBId] = @PBId,[ProjeId] = @ProjeId,[PBolumID] = @PBolumID,[PBolumMiktar] = @PBolumMiktar,[BirimId] = @BirimId";
                    break;
                case 319:
                    sorgu = "UPDATE [dbo].[ProjeBolumTamamlama] SET[ProjeId] = @ProjeId,[BolumId] = @BolumId,[PersonelId] = @PersonelId,[BaslamaZamani] = @BaslamaZamani,[BitisZamani] = @BitisZamani";
                    break;
                case 320:
                    sorgu = "UPDATE [dbo].[ProjeDonanimTamamlama] SET[PKontrolId] = @PKontrolId,[DonanimId] = @DonanimId,[TamamlamaZamani] = @TamamlamaZamani,[BaslamaZamani] = @BaslamaZamani";
                    break;
                case 321:
                    sorgu = "UPDATE [dbo].[ProjeKimyasallari] SET[ProjeId] = @ProjeId,[KimyasalId] = @KimyasalId,[Miktar] = @Miktar,[BirimId] = @BirimId";
                    break;
                case 322:
                    sorgu = "UPDATE [dbo].[Projeler]SET[ProjeAdi] = @ProjeAdi,[MusteriId] = @MusteriId,[ProjeFirmaUnvani] = @ProjeFirmaUnvani,[ProjeAdresi] = @ProjeAdresi,[ProjeVergiDairesi] = @ProjeVergiDairesi,[ProjeVergiNo] = @ProjeVergiNo,[ProjeIl] = @ProjeIl,[ProjeIlce] = @ProjeIlce,[ProjeIk] = @ProjeIk ,[ProjeYetkiliAdi] = @ProjeYetkiliAdi,[ProjeYetkiliTel] = @ProjeYetkiliTel,[ProjeYetkiliMail] = @ProjeYetkiliMail,[ProjeTehlikeSinifi] = @ProjeTehlikeSinifi,[Aciklama] = @Aciklama";
                    break;
                case 323:
                    sorgu = "UPDATE [dbo].[ProjeMakineleri] SET[ProjeId] = @ProjeId,[MakineId] = @MakineId,[BaslamaTarihi] = @BaslamaTarihi,[BitisTarihi] = @BitisTarihi";
                    break;
                case 324:
                    sorgu = "UPDATE [dbo].[ProjeMalzemeleri] SET[ProjeId] = @ProjeId,[MalzemeId] = @MalzemeId,[Miktar] = @Miktar,[BirimId] = @BirimId";
                    break;
                case 325:
                    sorgu = "UPDATE [dbo].[ProjePersonelleri] SET[ProjeId] = @ProjeId,[PersonelId] = @PersonelId,[BaslamaTarihi] = @BaslamaTarihi,[AyrılmaTarihi] = @AyrılmaTarihi";
                    break;
                case 326:
                    sorgu = "UPDATE [dbo].[ProjeTeklifleri] SET[TeklifId] = @TeklifId,[ProjeId] = @ProjeId,[YuzeyId] = @YuzeyId,[DonanimId] = @DonanimId ,[MalzemeId] = @MalzemeId,[KimyasalId] = @KimyasalId,[MakineId] = @MakineId ,[Miktar] = @Miktar,[BirimId] = @BirimId";
                    break;
                case 327:
                    sorgu = "UPDATE [dbo].[StokHareketleri]SET[MalzemeId] = @MalzemeId,[HareketTarihi] = @HareketTarihi,[AlimMiktari] = @AlimMiktari,[KullanimMiktari] = @KullanimMiktari,[ProjeId] = @ProjeId,[UreticiId] = @UreticiId ,[BirimId] = @BirimId";
                    break;

                case 328:
                    sorgu = "UPDATE [dbo].[UreticiHareketleri] SET[UreticiId] = @UreticiId ,[HareketTarihi] = @HareketTarihi,[IslemTipi] = @IslemTipi,[MalzemeId] = @MalzemeId,[MakineId] = @MakineId ,[KimyasalId] = @KimyasalId,[Miktar] = @Miktar,[BirimId] = @BirimId,[Tutar] = @Tutar, ";
                    break;
                case 329:
                    sorgu = "UPDATE [dbo].[Ureticiler]SET[UreticiAdi] = @UreticiAdi,[UreticiAdresi] = @UreticiAdresi ,[UreticiVergiDairesi] = @UreticiVergiDairesi,[UreticiVergiNo] = @UreticiVergiNo,[UreticiYetkiliAdi] = @UreticiYetkiliAdi,[UreticiYetkiliTelefon] = @UreticiYetkiliTelefon,[UreticiYetkiliDahili] = @UreticiYetkiliDahili,[UreticiWebAdresi] = @UreticiWebAdresi,[UreticiMersisNo] = @UreticiMersisNo,[UreticiTehlikeSinifi] = @UreticiTehlikeSinifi";
                    break;
                case 330:
                    sorgu = "UPDATE [dbo].[Yuzeyler] SET[YuzeyAdi] = @YuzeyAdi ,SertZemin = @SertZemin, Tekstil= @Tekstil, Antika = @Antika, Aciklama = @Aciklama, ResimYol = @ResimYol ";
                    break;
                case 331:
                    sorgu = "UPDATE [dbo].[YuzeyStandartlari] SET[YId] = @YId,[KimyasalId] = @KimyasalId,[MakineId] = @MakineId,[YMalzemeId] = @YMalzemeId,[StandartDeger] = @StandartDeger,[BirimId] = @BirimId";
                    break;

                // 500-599 Ara Sorgular // Drop down list verileri

                case 502:    // Birimler DDlist Sorgusu
                    sorgu = "SELECT [BirimId],[BirimAdi] FROM [CleanSys].[dbo].[Birimler]";
                    break;
                case 504:  // Bolumler  DDList Sorgusu
                    sorgu = "SELECT [BolumId],[BolumAdi],FROM[dbo].[Bolumler]";
                    break;
                case 505:   // BolumTipleri  DDList Sorgusu
                    sorgu = "SELECT BolumTipiId AS ID,BolummTipAdi AS ADI FROM BolumTipleri ";
                    break;
                case 506:     // Donanımlar  DDList Sorgusu
                    sorgu = "SELECT [DonanimId],[DonanimAdi]  FROM[dbo].[Donanimlar]";
                    break;
                case 515:  // Müşteriler DDList Sorgusu
                    sorgu = "SELECT MusteriId AS ID, MusteriAdi AS ADI, Aktif FROM Musteriler ";
                    break;
                case 516:    // Personeller  DDList Sorgusu
                    sorgu = "SELECT PersonelId, MusteriId, PersonelAdi + ' ' + PersonelSoyadi AS ADI FROM Personel";
                    break;
                case 518:   // ProjeBolumleri  DDList Sorgusu
                    sorgu = "SELECT ProjeBolumleri.ProjeBoIumId as ID, Bolumler.BolumAdi as ADI FROM Bolumler INNER JOIN  ProjeBolumleri ON Bolumler.BolumId = ProjeBolumleri.BolumID "; // Joinli sorgu yazılacak
                    break;
                case 529:    // Ureticiler DDList Sorgusu
                    sorgu = "SELECT [UreticiId],[UreticiAdi] FROM [CleanSys].[dbo].[Ureticiler]";
                    break;

                //901 - 999 case arası DELETE için yazılacak
                case 901:
                    sorgu = "Delete  [dbo].[BinaTipleri]  ";
                    break;
                case 902:
                    sorgu = "Delete  [dbo].[Birimler]  ";
                    break;
                case 903:
                    sorgu = "Delete [dbo].[BolumDonanimlari]";
                    break;
                case 904:
                    sorgu = "Delete [dbo].[Bolumler]";
                    break;
                case 905:
                    sorgu = "Delete [dbo].[BolumTipleri]";
                    break;
                case 906:
                    sorgu = "Delete [dbo].[Donanimlar]";
                    break;
                case 907:
                    sorgu = "Delete [dbo].[FiyatListesi]";
                    break;
                case 908:
                    sorgu = "Delete [dbo].[Ilceler]";
                    break;
                case 909:
                    sorgu = "Delete [dbo].[Iller]";
                    break;
                case 910:
                    sorgu = "Delete [dbo].[Kimyasallar]";
                    break;
                case 911:
                    sorgu = "Delete [dbo].[Makineler]";
                    break;
                case 912:
                    sorgu = "Delete [dbo].[Malzemeler]";
                    break;
                case 913:
                    sorgu = "Delete [dbo].[Meslekler]";
                    break;
                case 914:
                    sorgu = "Delete [dbo].[MusteriHareketleri]";
                    break;
                case 915:
                    sorgu = "Delete [dbo].[Musteriler]";
                    break;
                case 916:
                    sorgu = "Delete [dbo].[Personel]";
                    break;
                case 917:
                    sorgu = "Delete [dbo].[ProjeBinalari]";
                    break;
                case 918:
                    sorgu = "Delete [dbo].[ProjeBolumleri]";
                    break;
                case 919:
                    sorgu = "Delete [dbo].[ProjeBolumTamamlama]";
                    break;
                case 920:
                    sorgu = "Delete [dbo].[ProjeDonanimTamamlama]";
                    break;
                case 921:
                    sorgu = "Delete [dbo].[ProjeKimyasallari]";
                    break;
                case 922:
                    sorgu = "Delete [dbo].[Projeler]";
                    break;
                case 923:
                    sorgu = "Delete [dbo].[ProjeMakineleri]";
                    break;
                case 924:
                    sorgu = "Delete [dbo].[ProjeMalzemeleri]";
                    break;
                case 925:
                    sorgu = "Delete [dbo].[ProjePersonelleri]";
                    break;
                case 926:
                    sorgu = "Delete [dbo].[ProjeTeklifleri]";
                    break;
                case 927:
                    sorgu = "DELETE FROM [dbo].[StokHareketleri]";
                    break;
                case 928:
                    sorgu = "DELETE FROM [dbo].[UreticiHareketleri]";
                    break;
                case 929:
                    sorgu = "DELETE FROM [dbo].[Ureticiler]";
                    break;
                case 930:
                    sorgu = "DELETE FROM [dbo].[Yuzeyler]";
                    break;
                case 931:
                    sorgu = "DELETE FROM [dbo].[YuzeyStandartlari]";
                    break;

            }
            return sorgu;

        }
    }
}