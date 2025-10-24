using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist2.odev
{
    internal class OgrenciDersYonetimi
    {
        public OgrenciHeadNode OgrenciListesiBas { get; set; }
        public DersHeadNode DersListesiBas { get; set; }

        public OgrenciDersYonetimi()
        {
            OgrenciListesiBas = null;
            DersListesiBas = null;
        }

        // Yardımcı Metotlar (Aramalar)

        // Öğrenci HeadNode'u bulma
        public OgrenciHeadNode OgrenciBul(int ogrenciNo)
        {
            var current = OgrenciListesiBas;
            while (current != null)
            {
                if (current.OgrenciNo == ogrenciNo) return current;
                current = current.SonrakiOgrenciHead;
            }
            return null;
        }

        // Ders HeadNode'u bulma
        public DersHeadNode DersBul(string dersKodu)
        {
            var current = DersListesiBas;
            while (current != null)
            {
                if (current.DersKodu == dersKodu) return current;
                current = current.SonrakiDersHead;
            }
            return null;
        }

        // DersNode'u (Öğrenci ve Dersin Kesişimini) bulma
        public DersNode DersNodeBul(int ogrenciNo, string dersKodu)
        {
            var ogrenciHead = OgrenciBul(ogrenciNo);
            if (ogrenciHead == null) return null;

            var currentDers = ogrenciHead.IlkDers;
            while (currentDers != null)
            {
                if (currentDers.DersKodu == dersKodu)
                {
                    return currentDers;
                }
                currentDers = currentDers.SonrakiDers;
            }
            return null;
        }

        // HeadNode'u ekleme metotları
        // ... (Yeni Öğrenci veya Yeni Ders başlığı ekleme mantığı buraya gelir)

        // Ana Ekleme İşlemi (1 ve 2. maddelerin temelini oluşturur)
        public bool DersEkle(int ogrenciNo, string dersKodu, string harfOrtalamasi)
        {
            // 1. Yeni DersNode'u oluştur
            var yeniNode = new DersNode(ogrenciNo, dersKodu, harfOrtalamasi);

            // 2. Öğrenci Listesi (OgrenciHeadNode) tarafındaki bağlantıları kur
            //    a. OgrenciHeadNode'u bul veya oluştur
            var ogrenciHead = OgrenciBul(ogrenciNo);
            if (ogrenciHead == null)
            {
                // Yeni Öğrenciyse, listeye ekle
                ogrenciHead = new OgrenciHeadNode(ogrenciNo);
                ogrenciHead.SonrakiOgrenciHead = OgrenciListesiBas;
                OgrenciListesiBas = ogrenciHead;
            }
            //    b. DersNode'u öğrencinin ders listesinin başına ekle (en basit yöntem)
            yeniNode.SonrakiDers = ogrenciHead.IlkDers;
            ogrenciHead.IlkDers = yeniNode;

            // 3. Ders Listesi (DersHeadNode) tarafındaki bağlantıları kur
            //    a. DersHeadNode'u bul veya oluştur
            var dersHead = DersBul(dersKodu);
            if (dersHead == null)
            {
                // Yeni Derse, listeye ekle
                dersHead = new DersHeadNode(dersKodu);
                dersHead.SonrakiDersHead = DersListesiBas;
                DersListesiBas = dersHead;
            }
            //    b. DersNode'u dersin öğrenci listesinin başına ekle (en basit yöntem)
            yeniNode.SonrakiOgrenci = dersHead.IlkOgrenci;
            dersHead.IlkOgrenci = yeniNode;

            return true;
        }

        public List<DersNode> DerstekiOgrencileriSiraliListele(string dersKodu)
        {
            var dersHead = DersBul(dersKodu);
            if (dersHead == null) return new List<DersNode>();

            var liste = new List<DersNode>();
            var current = dersHead.IlkOgrenci;
            while (current != null)
            {
                liste.Add(current);
                current = current.SonrakiOgrenci;
            }

            // Öğrenci numarasına göre sırala (List<T>'nin Sort metodunu kullanmak en kolayıdır)
            liste.Sort((a, b) => a.OgrenciNo.CompareTo(b.OgrenciNo));

            return liste;
        }

        public List<DersNode> OgrenciDersleriniKodaGoreSiraliListele(int ogrenciNo)
        {
            var ogrenciHead = OgrenciBul(ogrenciNo);
            if (ogrenciHead == null) return new List<DersNode>();

            var liste = new List<DersNode>();
            var current = ogrenciHead.IlkDers;
            while (current != null)
            {
                liste.Add(current);
                current = current.SonrakiDers;
            }

            // Ders koduna göre sırala
            liste.Sort((a, b) => a.DersKodu.CompareTo(b.DersKodu));

            return liste;
        }

        public bool DersSil(int ogrenciNo, string dersKodu)
        {
            // 1. ÖĞRENCİ LİSTESİNDE SİLME İŞLEMİ (SonrakiDers zinciri)
            var ogrenciHead = OgrenciBul(ogrenciNo);
            if (ogrenciHead == null) return false; // Öğrenci yok

            DersNode currentOgr = ogrenciHead.IlkDers;
            DersNode prevOgr = null;

            // Öğrencinin ders listesinde dolaş
            while (currentOgr != null)
            {
                if (currentOgr.DersKodu == dersKodu)
                {
                    // Silinecek DersNode bulundu!

                    if (prevOgr == null)
                    {
                        // Silinecek Node listenin başıysa
                        ogrenciHead.IlkDers = currentOgr.SonrakiDers;
                    }
                    else
                    {
                        // Silinecek Node listenin ortası veya sonundaysa
                        prevOgr.SonrakiDers = currentOgr.SonrakiDers;
                    }

                    // Artık Ders Listesi (DersHeadNode) kısmında silme işlemine geçebiliriz.
                    // Bu, 'currentOgr' değişkeninin referansını kullanarak yapılacak.
                    goto SilmeDersZinciri;
                }

                prevOgr = currentOgr;
                currentOgr = currentOgr.SonrakiDers;
            }

            // Buraya geldiyse, öğrencinin böyle bir dersi yok demektir.
            return false;

        // 2. DERS LİSTESİNDE SİLME İŞLEMİ (SonrakiOgrenci zinciri)
        SilmeDersZinciri:

            var dersHead = DersBul(dersKodu);
            if (dersHead == null) return false; // Normalde buraya düşmemesi gerekir

            DersNode currentDers = dersHead.IlkOgrenci;
            DersNode prevDers = null;

            // Dersin öğrenci listesinde dolaş
            while (currentDers != null)
            {
                // currentOgr değişkeni (yukarıda bulunan node) ile karşılaştırarak bul
                if (currentDers.OgrenciNo == ogrenciNo)
                {
                    // Silinecek DersNode bulundu! (currentDers ile currentOgr aynı nesnedir)

                    if (prevDers == null)
                    {
                        // Silinecek Node listenin başıysa
                        dersHead.IlkOgrenci = currentDers.SonrakiOgrenci;
                    }
                    else
                    {
                        // Silinecek Node listenin ortası veya sonundaysa
                        prevDers.SonrakiOgrenci = currentDers.SonrakiOgrenci;
                    }

                    // Silme işlemi her iki zincirden de başarıyla tamamlandı.
                    return true;
                }

                prevDers = currentDers;
                currentDers = currentDers.SonrakiOgrenci;
            }

            // Her iki zincirden de silinememesi teorik olarak imkansızdır, 
            // ancak programlama hatasına karşı false dönebiliriz.
            return false;
        }
    }
}
