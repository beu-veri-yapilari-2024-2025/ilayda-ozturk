using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist2.odev
{
    internal class DersHeadNode
    {
        public string DersKodu { get; set; }
        public DersNode IlkOgrenci { get; set; } // Bu derse kayıtlı ilk DersNode
        public DersHeadNode SonrakiDersHead { get; set; } // Bir sonraki ders başlığı

        public DersHeadNode(string dersKodu)
        {
            DersKodu = dersKodu;
            IlkOgrenci = null;
            SonrakiDersHead = null;
        }
    }
}
