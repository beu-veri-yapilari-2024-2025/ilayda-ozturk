using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //matris çarpımı

            int[,] matris1 = new int[2, 3] { { 2, 4, 9 }, { 3, 4, 5 } };
            int[,] matris2 = new int[3, 2] { { 3, 7 }, {4, 8 }, { 5, 9 } };

            int matris1Satir = matris1.GetLength(0); //m=2
            int matris1Sutun = matris1.GetLength(1); //k=3
            int matris2Satir = matris2.GetLength(0); //k=3
            int matris2Sutun = matris2.GetLength(1); //n=2

            int[,] sonuc = new int[matris1Satir, matris2Sutun];

            // notasyon O(n3)'tür.

            for (int i = 0; i < matris1Satir; i++)    // i: sonuç satırları (m). O(n)
            {
                for (int j = 0; j < matris2Sutun; j++)    // j: sonuç sütunları (n). O(n)
                {
                    int toplam = 0;
                    for (int k = 0; k < matris1Sutun; k++)   // k: ortak boyut- mamtris1sütun ile matris2satir da aynı olmalı. O(n)
                    {
                        toplam += matris1[i, k] * matris2[k, j];
                    }

                    sonuc[i, j] = toplam;   // Sonucu C matrisine yaz
                }
            }
            //Sonucu ekrana yazdır
            Console.WriteLine("Sonuç Matrisi: ");
            for (int i = 0; i < matris1Satir; i++)
            {
                for (int j = 0; j < matris2Sutun; j++)
                {
                    Console.Write(sonuc[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadLine();


            Console.ReadLine();

        }
    }
}
