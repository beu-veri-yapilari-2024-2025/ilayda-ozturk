using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist2.odev
{
    internal class DersNode
    {
        public int OgrenciNo { get; set; }
        public string DersKodu { get; set; }
        public string HarfOrtalamasi { get; set; }

        // Bağlantılar (İstenen Yapı)
        public DersNode SonrakiDers { get; set; } // Aynı öğrencinin diğer dersi
        public DersNode SonrakiOgrenci { get; set; } // Aynı dersteki bir sonraki öğrenci

        public DersNode(int ogrenciNo, string dersKodu, string harfOrtalamasi)
        {
            OgrenciNo = ogrenciNo;
            DersKodu = dersKodu;
            HarfOrtalamasi = harfOrtalamasi;
            SonrakiDers = null;
            SonrakiOgrenci = null;
        }
    }
}
