using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedlist2.odev
{
    internal class OgrenciHeadNode
    {
        public int OgrenciNo { get; set; }
        public DersNode IlkDers { get; set; } // Bu öğrencinin ilk DersNode'u
        public OgrenciHeadNode SonrakiOgrenciHead { get; set; } // Bir sonraki öğrenci başlığı

        public OgrenciHeadNode(int ogrenciNo)
        {
            OgrenciNo = ogrenciNo;
            IlkDers = null;
            SonrakiOgrenciHead = null;
        }
    }
}
