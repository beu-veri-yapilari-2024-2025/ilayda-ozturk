using System;
using System.Collections.Generic;
using System.Linq;

// Öğrenci Bilgilerini Tutan Sınıf (Class)
public class Ogrenci
{
    public string Ad { get; set; }
    public string Soyad { get; set; }
    public int Numara { get; set; }

    // Yapıcı Metod (Constructor)
    public Ogrenci(string ad, string soyad, int numara)
    {
        Ad = ad;
        Soyad = soyad;
        Numara = numara;
    }

    public void BilgileriGoster()
    {
        Console.WriteLine($"  Numara: {Numara}, Ad: {Ad}, Soyad: {Soyad}");
    }
}

//  Bağlı Listenin Düğümü (Node) Sınıfı
public class Node
{
    public Ogrenci Ogrenci { get; set; } // Veri kısmı
    public Node Next { get; set; }      // Sonraki düğümü gösteren referans

    // Yapıcı Metod (Constructor)
    public Node(Ogrenci ogrenci)
    {
        Ogrenci = ogrenci;
        Next = null;
    }
}

//  Bağlı Liste Sınıfı
public class OgrenciLinkedList
{
    private Node head; // Listenin başını gösteren referans

    // Yapıcı Metod (Constructor)
    public OgrenciLinkedList()
    {
        head = null;
    }

    // Yardımcı Fonksiyon: Öğrenci Numarasına Göre Arama (Node döndürür)
    private Node Arama(int numara)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Ogrenci.Numara == numara)
            {
                return temp; // Bulundu
            }
            temp = temp.Next;
        }
        return null; // Bulunamadı
    }

    // Yardımcı Fonksiyon: Öğrenci Numarasına Göre Bir Önceki Node'u Arama
    private Node OncekiNodeArama(int numara)
    {
        if (head == null || head.Ogrenci.Numara == numara)
        {
            return null; // Liste boş veya aranan head
        }

        Node current = head;
        while (current.Next != null && current.Next.Ogrenci.Numara != numara)
        {
            current = current.Next;
        }

        return current.Next == null ? null : current; // Bulunursa önceki node'u döndür
    }

    // EKLEME İŞLEMLERİ
    

    //  Başına Ekleme
    public void BasaEkle(Ogrenci yeniOgrenci)
    {
        Node newNode = new Node(yeniOgrenci);
        newNode.Next = head;
        head = newNode;
        Console.WriteLine($"--> Başına eklendi: {yeniOgrenci.Ad}");
    }

    // Sonuna Ekleme
    public void SonaEkle(Ogrenci yeniOgrenci)
    {
        Node newNode = new Node(yeniOgrenci);
        if (head == null)
        {
            head = newNode;
            Console.WriteLine($"--> Listeye ilk eleman olarak eklendi: {yeniOgrenci.Ad}");
            return;
        }

        Node temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
        Console.WriteLine($"--> Sonuna eklendi: {yeniOgrenci.Ad}");
    }

    //  İstenen Değerden (Numaradan) Sonrasına Ekleme
    public void AradanSonrasinaEkle(int hedefNumara, Ogrenci yeniOgrenci)
    {
        Node hedefNode = Arama(hedefNumara);
        if (hedefNode == null)
        {
            Console.WriteLine($"HATA: {hedefNumara} numaralı öğrenci bulunamadı, ekleme yapılamadı.");
            return;
        }

        Node newNode = new Node(yeniOgrenci);
        newNode.Next = hedefNode.Next;
        hedefNode.Next = newNode;
        Console.WriteLine($"--> {hedefNumara} numaralı öğrenciden SONRA eklendi: {yeniOgrenci.Ad}");
    }

    //  İstenen Değerden (Numaradan) Öncesine Ekleme
    public void AradanOncesineEkle(int hedefNumara, Ogrenci yeniOgrenci)
    {
        if (head == null)
        {
            Console.WriteLine($"HATA: Liste boş, {hedefNumara} numaradan önce ekleme yapılamadı.");
            return;
        }

        if (head.Ogrenci.Numara == hedefNumara)
        {
            BasaEkle(yeniOgrenci); // Baş düğümden önce ekle
            return;
        }

        Node oncekiNode = OncekiNodeArama(hedefNumara);

        if (oncekiNode == null)
        {
            Console.WriteLine($"HATA: {hedefNumara} numaralı öğrenci bulunamadı, ekleme yapılamadı.");
        }
        else
        {
            Node newNode = new Node(yeniOgrenci);
            newNode.Next = oncekiNode.Next;
            oncekiNode.Next = newNode;
            Console.WriteLine($"--> {hedefNumara} numaralı öğrenciden ÖNCE eklendi: {yeniOgrenci.Ad}");
        }
    }

   
    // SİLME İŞLEMLERİ
   

    //  Baştan Silme
    public bool BastanSil()
    {
        if (head == null)
        {
            Console.WriteLine("HATA: Liste boş, silme yapılamadı.");
            return false;
        }
        string silinenAd = head.Ogrenci.Ad;
        head = head.Next; // C# garbage collector (çöp toplayıcısı) eski head'i temizleyecektir
        Console.WriteLine($"--> Baştaki öğrenci silindi: {silinenAd}");
        return true;
    }

    //  Sondan Silme
    public bool SondanSil()
    {
        if (head == null)
        {
            Console.WriteLine("HATA: Liste boş, silme yapılamadı.");
            return false;
        }
        if (head.Next == null) // Tek eleman varsa
        {
            string silinenAd = head.Ogrenci.Ad;
            head = null;
            Console.WriteLine($"--> Tek elemanlı listenin sonu silindi: {silinenAd}");
            return true;
        }

        Node temp = head;
        while (temp.Next.Next != null)
        {
            temp = temp.Next;
        }
        string silinenAdSon = temp.Next.Ogrenci.Ad;
        temp.Next = null; // Son düğümün referansını kes
        Console.WriteLine($"--> Sondaki öğrenci silindi: {silinenAdSon}");
        return true;
    }

    //  İstenen Değeri (Numarayı) Silme
    public bool DegerSil(int numara)
    {
        if (head == null) return false;

        if (head.Ogrenci.Numara == numara)
        {
            return BastanSil(); // Baş düğüm silinecekse, BastanSil fonksiyonunu kullan
        }

        Node oncekiNode = OncekiNodeArama(numara);

        if (oncekiNode == null)
        {
            Console.WriteLine($"HATA: {numara} numaralı öğrenci bulunamadı, silme yapılamadı.");
            return false;
        }

        Node silinecekNode = oncekiNode.Next;
        oncekiNode.Next = silinecekNode.Next;
        Console.WriteLine($"--> {numara} numaralı öğrenci silindi: {silinecekNode.Ogrenci.Ad}");

        // Silinecek düğümün referansı kesildiği için, C# çöp toplayıcısı onu temizleyecektir.
        return true;
    }

    // İstenen Değerden (Numaradan) Öncesini Silme
    public bool OncesiniSil(int hedefNumara)
    {
        if (head == null || head.Ogrenci.Numara == hedefNumara)
        {
            Console.WriteLine("HATA: Silinecek önceki eleman yok veya liste boş/hedef ilk eleman.");
            return false;
        }

        // Hedef ikinci düğüm ise, baştaki düğümü sil
        if (head.Next != null && head.Next.Ogrenci.Numara == hedefNumara)
        {
            return BastanSil();
        }

        Node current = head;
        // current.Next.Next aradığımız düğüm (hedef) olmalı.
        // current.Next ise silinecek düğüm (hedef'in önündeki) olmalı.
        while (current.Next != null && current.Next.Next != null && current.Next.Next.Ogrenci.Numara != hedefNumara)
        {
            current = current.Next;
        }

        if (current.Next == null || current.Next.Next == null)
        {
            Console.WriteLine($"HATA: {hedefNumara} numaralı öğrencinin öncesi bulunamadı (ilk 2 elemandan biri değil).");
            return false;
        }

        // Silinecek düğüm: current.Next
        string silinenAd = current.Next.Ogrenci.Ad;
        current.Next = current.Next.Next;
        Console.WriteLine($"--> {hedefNumara} numaralı öğrencinin ÖNCESİ silindi: {silinenAd}");
        return true;
    }

    // İstenen Değerden (Numaradan) Sonrasını Silme
    public bool SonrasiniSil(int hedefNumara)
    {
        Node hedefNode = Arama(hedefNumara);
        if (hedefNode == null)
        {
            Console.WriteLine($"HATA: {hedefNumara} numaralı öğrenci bulunamadı.");
            return false;
        }

        if (hedefNode.Next == null)
        {
            Console.WriteLine($"HATA: {hedefNumara} numaralı öğrenciden sonra silinecek öğrenci yok (Liste sonu).");
            return false;
        }

        Node silinecekNode = hedefNode.Next;
        hedefNode.Next = silinecekNode.Next;
        Console.WriteLine($"--> {hedefNumara} numaralı öğrenciden SONRASI silindi: {silinecekNode.Ogrenci.Ad}");
        return true;
    }

   
    // DİĞER İŞLEMLER
   

    //  Listeleme (Gezinme/Traversal)
    public void Listele()
    {
        if (head == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }
        Node temp = head;
        int sira = 1;
        Console.WriteLine("\n--- OGRENCI LISTESI ---");
        while (temp != null)
        {
            Console.Write($"{sira++}. ");
            temp.Ogrenci.BilgileriGoster();
            temp = temp.Next;
        }
        Console.WriteLine("-----------------------");
    }

    //  Arama (Numaraya göre arama, sonucu yazdırma)
    public void AramaYazdir(int numara)
    {
        Node bulunan = Arama(numara);
        if (bulunan != null)
        {
            Console.Write($"{numara} numaralı öğrenci bulundu: ");
            bulunan.Ogrenci.BilgileriGoster();
        }
        else
        {
            Console.WriteLine($"HATA: {numara} numaralı öğrenci bulunamadı.");
        }
    }

    //  Kullanıcıdan Değer Alarak Ekleme (Menü)
    public void KullanicidanDegerAlarakEkle()
    {
        string ad, soyad;
        int numara;
        int secim;
        int hedefNumara = -1;

        Console.WriteLine("\n--- YENI OGRENCI EKLEME ---");
        Console.Write("Ad: ");
        ad = Console.ReadLine();
        Console.Write("Soyad: ");
        soyad = Console.ReadLine();

        while (true)
        {
            Console.Write("Numara: ");
            if (int.TryParse(Console.ReadLine(), out numara))
                break;
            Console.WriteLine("Geçersiz numara formatı. Lütfen tekrar deneyin.");
        }

        Ogrenci yeniOgrenci = new Ogrenci(ad, soyad, numara);

        Console.WriteLine("\nNereye eklemek istersiniz?");
        Console.WriteLine("1. Listenin basına");
        Console.WriteLine("2. Listenin sonuna");
        Console.WriteLine("3. Başka bir öğrenciden ÖNCE");
        Console.WriteLine("4. Başka bir öğrenciden SONRA");
        Console.Write("Seçiminiz (1-4): ");

        if (int.TryParse(Console.ReadLine(), out secim))
        {
            switch (secim)
            {
                case 1:
                    BasaEkle(yeniOgrenci);
                    break;
                case 2:
                    SonaEkle(yeniOgrenci);
                    break;
                case 3:
                    Console.Write("Hangi öğrenci numarasından ÖNCE eklenecek? ");
                    if (int.TryParse(Console.ReadLine(), out hedefNumara))
                        AradanOncesineEkle(hedefNumara, yeniOgrenci);
                    else
                        Console.WriteLine("Geçersiz numara girişi.");
                    break;
                case 4:
                    Console.Write("Hangi öğrenci numarasından SONRA eklenecek? ");
                    if (int.TryParse(Console.ReadLine(), out hedefNumara))
                        AradanSonrasinaEkle(hedefNumara, yeniOgrenci);
                    else
                        Console.WriteLine("Geçersiz numara girişi.");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim! Ekleme yapılamadı.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Geçersiz seçim formatı! Ekleme yapılamadı.");
        }
    }
}

// Ana Program (Main metodu bir sınıf içinde olmalıdır)
public class Program
{
    public static void Main(string[] args)
    {
        OgrenciLinkedList list = new OgrenciLinkedList();

        // Başlangıç verileri
        Ogrenci ogr1 = new Ogrenci("İlayda", "Öztürk", 501);
        Ogrenci ogr2 = new Ogrenci("Kenan", "Kaya", 502);
        Ogrenci ogr3 = new Ogrenci("Ayse", "Demir", 503);
        Ogrenci ogr4 = new Ogrenci("Fatma", "Celiko", 504);

        // Listeye Ekleme İşlemleri
        list.SonaEkle(ogr1);    
        list.SonaEkle(ogr3);    
        list.BasaEkle(ogr2);    
        list.AradanSonrasinaEkle(101, ogr4); 

        list.Listele(); // Mevcut listeyi gör

        // Arama İşlemi
        list.AramaYazdir(104);
        list.AramaYazdir(999);

        // Öncesine Ekleme
        Ogrenci ogr5 = new Ogrenci("Zeynep", "Akin", 105);
        list.AradanOncesineEkle(103, ogr5); 
        list.Listele();

        // Silme İşlemleri
        Console.WriteLine("\n--- SILME ISLEMLERI ---");
        list.BastanSil(); 
        list.SondanSil();
        list.DegerSil(104); 
        list.Listele(); 

        // Aradan sonrasini silme
        list.SonrasiniSil(101);
        list.Listele(); 

        // Yeni eleman ekle
        Ogrenci ogr6 = new Ogrenci("Can", "Oz", 106);
        list.SonaEkle(ogr6); 
        Ogrenci ogr7 = new Ogrenci("Deniz", "Ak", 107);
        list.SonaEkle(ogr7); 
        list.Listele();

        // Aradan oncesini silme 
        list.OncesiniSil(106); 
        list.Listele();

        // Kullanıcıdan Değer Alarak Ekleme Fonksiyonunu Çağırma
        list.KullanicidanDegerAlarakEkle();

        list.Listele();

        Console.WriteLine("\nProgram sonlandırmak için bir tuşa basın...");
        Console.ReadKey();
    }
}