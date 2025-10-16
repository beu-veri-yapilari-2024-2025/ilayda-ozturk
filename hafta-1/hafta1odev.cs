//binary search'in notasyonu 0(logn)'dir.



int[] sayilar = { 5, 8, 12, 15, 25, 39, 46, 50, 67, 89, 93 };

//aranacak sayının girilmesi
Console.WriteLine("Lütfen aranacak sayıyı giriniz:");
int aranansayi= int.Parse(Console.ReadLine());

int sonuc =Array.BinarySearch(sayilar, aranansayi); //binary search metodu kullanıldı.

//ikili arama sonucunu al ve kullan.

if (sonuc >= 0)
{
    Console.WriteLine($"Aradığınız sayı dizide mevcut. Index numarası: {sonuc} 'dir.");
}
else
{
    Console.WriteLine("Aradığınız sayı dizide mecvut değildir.");
}

//aşaıdaki kısım ise linear search metodu ile yapılmıştır.

/*bool bulundu = false;

for (int i=0; i<sayilar.Length; i++) //bu kodun notasyonu O(n) dir.  
{
    if (sayilar[i] == aranansayi)
    {
        Console.WriteLine($"Aradığınız sayı dizide mevcut. Index numarası: {i} 'dir.");
        bulundu = true;
        break;
    }

}
           
if (!bulundu)
{
    Console.WriteLine("Aradığınız sayı dizide mecvut değildir.");
}
*/


Console.ReadLine(); 