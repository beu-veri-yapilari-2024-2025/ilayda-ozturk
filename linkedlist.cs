class Program
{
    //Node sınıfı her bir düğüm bir veriye ve bir sonraki düğüme işaret eder

    public class Node //düğüm tanımlama
    {
        public int Data; //verimiz
        public Node Next; //sonraki pointerımız

        public Node(int data) //yapıcı method Node'a dönüştürür
        {
            Data = data;
            Next = null;
        }
    }


    //LinkedList sınıfı: kendi bağlantılı liste yapımızı burada oluşturuyoruz

    public class BagliList
    {
        private Node head;
        private Node tail;


        public BagliList()
        {
            head = null;
            tail = null;
        }


        //başa eleman ekleme,

        public void BasaEkle(int value)
        {
            Node newNode = new Node(value); //Node'a dönüşür
            newNode.Next = head;
            head = newNode;
            Console.WriteLine($"{value} Başa Eklendi.");
        }

        //sona eleman ekleme

        public void SonaEkle(int value)
        {
            Node newNode = new Node(value); //Node'a dönüşür
            if (head == null)
            {
                head = newNode;
                Console.WriteLine($"{value} sona Eklendi.");
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            tail = newNode;
            Console.WriteLine($"{value} sona Eklendi.");
        }

        //belirli bir değerin sonrasına eleman ekleme

        public void sonrasinaEkle(int varolanDeger, int yeniDeger)
        {
            Node current = head;

            //listede varolanDeger'i bulana kadar ilerle
            while (current != null && current.Data != varolanDeger)
            {
                current = current.Next;
            }

            // eğer mevcut değer bulunamadıysa, kullanıcıya bilgi ver
            if (current == null)
            {
                Console.WriteLine($"{varolanDeger} bulunamadı, ekleme yapılamadı.");
                return;
            }

            //yeni elemanı mevcut elemandan sonrasına ekle

            Node newNode = new Node(yeniDeger); //Node'a dönüşür
            newNode.Next = current.Next; //Yeni elemanın 'Next' referansını mevcut elemanın 'Next' ine yönlendir
            current.Next = newNode; // mevcut elemanın 'next' referansını yeni düğüme yönlendir
            Console.WriteLine($"{yeniDeger}, {varolanDeger} sonrasına eklendi.");
        }


        //ilk elemanı silme

        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silinecek eleman yok.");
                return;
            }

            head = head.Next;
            Console.WriteLine("İlk eleman silindi.");
        }

        //son elemanı silme

        public void sondanSil()
        {

            if (head == null)
            {
                Console.WriteLine("Liste boş, silinecek eleman yok.");
                return;
            }

            if (head.Next == null)
            {
                head = null;
                Console.WriteLine("Son eleman silindi, liste boş.");
                return;
            }

            Node current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

        }

        //belirli bir elemanı silme

        public void Remove(int value)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silinecek eleman yok.");
                return;
            }

            if (head.Data == value)
            {
                head = head.Next;
                Console.WriteLine($"{value} silindi.");
                return;


            }

            Node current = head;
            Console.WriteLine($"{value} listeden silindi.");
            
            while (current.Next != null && current.Next.Data != value)
            {
                current = current.Next;
            } //ilerlemeyi sağlar

            if (current.Next == null)
            {
                Console.WriteLine($"{value} listede bulunamadı.");  
                return;
            }

            current.Next= current.Next.Next; //silme işlemi
            Console.WriteLine($"{value} listeden silindi.");


        }


        //listeyi yazdırma

        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Node current = head;
            Console.Write("Liste:");
            while (current != null)
            {
                Console.Write(current.Data + " --> ");
                current = current.Next;
            }

            Console.WriteLine();


        }

        //Eleman arama

        public void Ara(int value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data == value)
                {
                    Console.WriteLine($"{value} bulundu.");
                    return;
                }

                current = current.Next;
            }

            Console.WriteLine($"{value} bulunamadı.");

        }
        


        
    }


    static void Main(string[] args)
    {
        BagliList listim= new BagliList();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--LinkedList İşlemleri--");    
            Console.WriteLine("1. Listeyi göster");
            Console.WriteLine("2. Başa eleman ekle");
            Console.WriteLine("3. Sona eleman ekle");
            Console.WriteLine("4. Belirli bir değerin sonrasına eleman ekleme");
            Console.WriteLine("5. İlk elemanı sil");
            Console.WriteLine("6. Son elemanı sil");
            Console.WriteLine("7. Elemanı sil");
            Console.WriteLine("8. Eleman ara");
            Console.WriteLine("9. Çıkış");
            Console.Write("Bir işlem seçin (1-9):");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    listim.Display();
                    break;

                case "2":
                    Console.Write("başa eklenecek değeri girin: "); 
                    int BasaEkleValue = Convert.ToInt32(Console.ReadLine());
                    listim.BasaEkle(BasaEkleValue);
                    break;

                case "3":
                    Console.Write("sona eklenecek değeri girin: ");
                    int DegeriSonaEkle = Convert.ToInt32(Console.ReadLine());
                    listim.SonaEkle(DegeriSonaEkle);
                    break;

                case "4":
                    Console.Write("Sonrasına eklemek istediğiniz değeri girin:");
                    int varolanDeger = Convert.ToInt32(Console.ReadLine());
                    Console.Write("yeni değeri girin:");    
                    int yeniDeger= Convert.ToInt32(Console.ReadLine());
                    listim.sonrasinaEkle(varolanDeger, yeniDeger);
                    break;

                case "5":
                    listim.bastanSil();
                    break;

                case "6":
                    listim.sondanSil();
                    break;

                case "7":
                    Console.Write("silinecek elemanı girin:");
                    int removeValue = Convert.ToInt32(Console.ReadLine());
                    listim.Remove(removeValue);
                    break;

                case "8":
                    Console.Write("aranacak elemanı girin:");   
                    int DegerAra = Convert.ToInt32(Console.ReadLine());
                    listim.Ara(DegerAra);
                    break;

                case "9":
                    running = false;
                    Console.WriteLine("Çıkış yapılıyor...");
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                    break;  







            }
        }
    }
}

