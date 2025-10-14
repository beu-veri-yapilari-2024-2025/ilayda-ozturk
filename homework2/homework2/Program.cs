using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dizideki elemanların toplamı

            int[] sayilar = { 5, 8, 12, 15, 25, 39, 46, 50, 67, 89, 93 };
            int toplam = 0;

            foreach (int sayi in sayilar)
            {
                toplam += sayi;

            }

            Console.WriteLine("Sayıların toplamı:" + toplam);
            Console.ReadLine();

            //notasyonu O(n)'dir. çünkü dizide her eleman 1 defa gelir.
        }
    }
}
