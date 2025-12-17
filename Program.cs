class Node
{
    public int Value;       // Düğümün taşıdığı sayısal değer
    public Node Left, Right; // Sol ve Sağ alt düğümlere giden bağlantılar (pointerlar)
    public int Height;      // Düğümün yüksekliği (Denge hesabı için kritik önem taşır)

    public Node(int value)
    {
        Value = value;
        Left = Right = null; // Yeni düğümün çocukları henüz yoktur
        Height = 1;          // Yeni eklenen düğümün yüksekliği başlangıçta 1'dir
    }
}

class AVLTree
{
    private Node root; // Ağacın başlangıç noktası (Kök düğüm)

    public AVLTree()
    {
        root = null; // Ağaç ilk başta boştur
    }

    // --- EKLEME İŞLEMİ (INSERT) ---
    // Kullanıcının çağırdığı ana ekleme metodu
    public void Insert(int value)
    {
        root = InsertRec(root, value);
    }

    // Özyinelemeli (Recursive) olarak asıl eklemeyi yapan metot
    private Node InsertRec(Node node, int value)
    {
        // 1. ADIM: Standart BST (Binary Search Tree) Ekleme İşlemi
        if (node == null)
            return new Node(value); // Ağaç boşsa veya yaprağa ulaşıldıysa yeni düğümü oluştur

        if (value < node.Value)
            node.Left = InsertRec(node.Left, value); // Değer küçükse sola git
        else if (value > node.Value)
            node.Right = InsertRec(node.Right, value); // Değer büyükse sağa git
        else
            return node; // Aynı değerler ağaca eklenmez (Duplicate yasak)

        // 2. ADIM: Yükseklik Güncelleme
        // Ekleme yapılan yoldaki her düğümün yüksekliğini güncelliyoruz.
        node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

        // 3. ADIM: Denge Kontrolü (Balance Factor)
        // Sol ve Sağ yükseklik farkına bakılır.
        int balance = GetBalance(node);

        // 4. ADIM: Denge Bozulmuşsa Rotasyon (Döndürme) İşlemleri

        // Durum 1: Sol taraf çok ağır ve eklenen değer solun solunda (Left-Left Case) -> Sağ Rotasyon
        if (balance > 1 && value < node.Left.Value)
            return RightRotate(node);

        // Durum 2: Sağ taraf çok ağır ve eklenen değer sağın sağında (Right-Right Case) -> Sol Rotasyon
        if (balance < -1 && value > node.Right.Value)
            return LeftRotate(node);

        // Durum 3: Sol taraf ağır ama eklenen değer solun sağında (Left-Right Case) -> Önce Sol, Sonra Sağ Rotasyon
        if (balance > 1 && value > node.Left.Value)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Durum 4: Sağ taraf ağır ama eklenen değer sağın solunda (Right-Left Case) -> Önce Sağ, Sonra Sol Rotasyon
        if (balance < -1 && value < node.Right.Value)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        // Denge bozulmadıysa düğümü olduğu gibi döndür
        return node;
    }

    // --- ROTASYON METOTLARI ---

    // Sağ Rotasyon (Right Rotate): Sol taraf ağırlaştığında kullanılır
    private Node RightRotate(Node y)
    {
        Node x = y.Left;
        Node T2 = x.Right;

        // Döndürme işlemi (Pointerları değiştirme)
        x.Right = y;
        y.Left = T2;

        // Yükseklikleri güncelle (Önce alt seviye olan y, sonra üst seviye olan x)
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

        return x; // Yeni kök x olur
    }

    // Sol Rotasyon (Left Rotate): Sağ taraf ağırlaştığında kullanılır
    private Node LeftRotate(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;

        // Döndürme işlemi
        y.Left = x;
        x.Right = T2;

        // Yükseklikleri güncelle
        x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

        return y; // Yeni kök y olur
    }

    // Yardımcı Metot: Bir düğümün yüksekliğini güvenli şekilde alır (Null kontrolü yapar)
    private int GetHeight(Node node)
    {
        return node == null ? 0 : node.Height;
    }

    // Yardımcı Metot: Denge Faktörünü hesaplar (Sol Yükseklik - Sağ Yükseklik)
    private int GetBalance(Node node)
    {
        return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
    }

    // --- ARAMA İŞLEMİ (SEARCH) ---
    public bool Search(int value)
    {
        return SearchRec(root, value);
    }

    private bool SearchRec(Node node, int value)
    {
        if (node == null)
            return false; // Ağaç bitti, değer bulunamadı

        if (value < node.Value)
            return SearchRec(node.Left, value); // Aranan değer küçükse sola bak
        else if (value > node.Value)
            return SearchRec(node.Right, value); // Aranan değer büyükse sağa bak
        else
            return true; // Değer bulundu
    }

    // --- SİLME İŞLEMİ (DELETE) ---
    public void Delete(int value)
    {
        root = DeleteRec(root, value);
    }

    private Node DeleteRec(Node root, int value)
    {
        // 1. ADIM: Standart BST Silme İşlemi
        if (root == null)
            return root;

        if (value < root.Value)
            root.Left = DeleteRec(root.Left, value);
        else if (value > root.Value)
            root.Right = DeleteRec(root.Right, value);
        else
        {
            // Silinecek düğüm bulundu

            // Durum A: Tek çocuğu var veya hiç çocuğu yok
            if (root.Left == null || root.Right == null)
            {
                Node temp = root.Left != null ? root.Left : root.Right;

                if (temp == null) // Hiç çocuğu yok
                {
                    temp = root;
                    root = null;
                }
                else // Tek çocuğu var
                    root = temp; // Çocuğu silinen düğümün yerine taşı
            }
            else
            {
                // Durum B: İki çocuğu var
                // Sağ alt ağacın en küçüğünü (In-order Successor) bul
                Node temp = GetMinValueNode(root.Right);

                // O değeri silinecek düğüme kopyala
                root.Value = temp.Value;

                // Sağ taraftan o kopyalanan değeri sil
                root.Right = DeleteRec(root.Right, temp.Value);
            }
        }

        if (root == null)
            return root;

        // 2. ADIM: Yükseklik Güncelleme
        root.Height = Math.Max(GetHeight(root.Left), GetHeight(root.Right)) + 1;

        // 3. ADIM: Denge Kontrolü
        int balance = GetBalance(root);

        // 4. ADIM: Denge Bozuksa Rotasyonlar (Silme sonrası dengeyi tekrar sağla)

        // Sol taraf ağır
        if (balance > 1 && GetBalance(root.Left) >= 0)
            return RightRotate(root);

        // Sol taraf ağır ama solun sağı daha yüklü (Zikzak)
        if (balance > 1 && GetBalance(root.Left) < 0)
        {
            root.Left = LeftRotate(root.Left);
            return RightRotate(root);
        }

        // Sağ taraf ağır
        if (balance < -1 && GetBalance(root.Right) <= 0)
            return LeftRotate(root);

        // Sağ taraf ağır ama sağın solu daha yüklü (Zikzak)
        if (balance < -1 && GetBalance(root.Right) > 0)
        {
            root.Right = RightRotate(root.Right);
            return LeftRotate(root);
        }

        return root;
    }

    // Bir ağaçtaki en küçük değeri bulan yardımcı metot (Silme işleminde kullanılır)
    private Node GetMinValueNode(Node node)
    {
        Node current = node;
        while (current.Left != null)
            current = current.Left; // En sola kadar git

        return current;
    }

    // --- YAZDIRMA (LISTELEME) ---
    public void PrintTree()
    {
        PrintTreeRec(root);
        Console.WriteLine();
    }

    // In-order Traversal (Sol - Kök - Sağ): Küçükten büyüğe sıralı yazdırır
    private void PrintTreeRec(Node node)
    {
        if (node != null)
        {
            PrintTreeRec(node.Left);
            Console.Write(node.Value + " ");
            PrintTreeRec(node.Right);
        }
    }

    // Bu metot dışarıdan tüm ağacı tekrar dengelemek istersek kullanılır (Opsiyonel)
    public void BalanceTree()
    {
        root = BalanceRec(root);
    }

    private Node BalanceRec(Node node)
    {
        if (node == null)
            return null;

        // Alt ağaçları özyinelemeli dengele
        node.Left = BalanceRec(node.Left);
        node.Right = BalanceRec(node.Right);

        // Yükseklik güncelle
        node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;

        // Denge faktörünü kontrol et ve rotasyon yap
        int balance = GetBalance(node);

        if (balance > 1)
        {
            if (GetBalance(node.Left) < 0)
                node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        if (balance < -1)
        {
            if (GetBalance(node.Right) > 0)
                node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }
}

class Program
{
    static void Main(string[] args)
    {
        AVLTree tree = new AVLTree();
        bool continueRunning = true;

        // Kullanıcı menüsü döngüsü
        while (continueRunning)
        {
            Console.Clear(); // Ekranı temizle
            Console.WriteLine("1. Ekleme");
            Console.WriteLine("2. Silme");
            Console.WriteLine("3. Arama");
            Console.WriteLine("4. Listele");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Eklenecek değeri girin: ");
                    int insertValue = int.Parse(Console.ReadLine());
                    tree.Insert(insertValue); // Ağaca ekle
                    Console.WriteLine($"Değer {insertValue} ağaçta eklendi.");
                    tree.PrintTree(); // Güncel hali yazdır
                    break;

                case "2":
                    Console.Write("Silinecek değeri girin: ");
                    int deleteValue = int.Parse(Console.ReadLine());
                    tree.Delete(deleteValue); // Ağaçtan sil
                    Console.WriteLine($"Değer {deleteValue} ağaçtan silindi.");
                    tree.PrintTree();
                    break;

                case "3":
                    Console.Write("Aranacak değeri girin: ");
                    int searchValue = int.Parse(Console.ReadLine());
                    bool found = tree.Search(searchValue); // Ağaçta ara
                    if (found)
                        Console.WriteLine($"Değer {searchValue} ağaçta bulundu.");
                    else
                        Console.WriteLine($"Değer {searchValue} ağaçta bulunamadı.");
                    break;

                case "4":
                    Console.WriteLine("Ağaç: ");
                    tree.PrintTree(); // Sıralı listele
                    break;

                case "5":
                    continueRunning = false; // Döngüyü kır ve çık
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                    break;
            }

            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}