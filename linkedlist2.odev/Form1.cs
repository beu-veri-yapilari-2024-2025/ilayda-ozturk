using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linkedlist2.odev
{
    public partial class Form1 : Form

    {
        private OgrenciDersYonetimi yonetim = new OgrenciDersYonetimi();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtOgrenciNo.Text, out int ogrenciNo) &&
        !string.IsNullOrEmpty(txtDersKodu.Text) &&
        !string.IsNullOrEmpty(txtHarfNotu.Text))
            {
                // 1 ve 2: Bir öğrenciye yeni bir ders / Bir derse yeni bir öğrenci ekleme
                bool basarili = yonetim.DersEkle(
                    ogrenciNo,
                    txtDersKodu.Text.ToUpper(),
                    txtHarfNotu.Text.ToUpper());

                if (basarili)
                {
                    MessageBox.Show("Ders kaydı başarıyla eklendi.", "Başarılı");
                    // Listeyi yenileme veya temizleme işlemleri
                }
                else
                {
                    MessageBox.Show("Ekleme sırasında bir hata oluştu.", "Hata");
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doğru doldurun.", "Uyarı");
            }
        }

        private void btnOgrenciyeGoreListele_Click(object sender, EventArgs e)
        {
            string dersKodu = txtDersKodu.Text.ToUpper();

            if (string.IsNullOrEmpty(dersKodu))
            {
                MessageBox.Show("Lütfen listelenecek dersin kodunu girin.", "Uyarı");
                return;
            }

            // YÖNETİM NESNESİ KULLANILIYOR:
            var siraliListe = yonetim.DerstekiOgrencileriSiraliListele(dersKodu);

            lstSonuclar.Items.Clear();
            if (siraliListe.Count == 0)
            {
                lstSonuclar.Items.Add($"{dersKodu} dersine kayıtlı öğrenci bulunamadı.");
                return;
            }

            lstSonuclar.Items.Add($"--- {dersKodu} Dersi Öğrencileri (No'ya Göre Sıralı) ---");
            foreach (var node in siraliListe)
            {
                // ListBox'a sonucu ekle
                lstSonuclar.Items.Add($"No: {node.OgrenciNo,-5} | Not: {node.HarfOrtalamasi}");
            }
        }

        private void btnDerseGoreListele_Click(object sender, EventArgs e)
        {
            string dersKodu = txtListeleDersKodu.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(dersKodu))
            {
                MessageBox.Show("Lütfen listelenecek ders kodunu girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Yönetim sınıfından sıralı veriyi al
            var siraliListe = yonetim.DerstekiOgrencileriSiraliListele(dersKodu);

            // 2. ListBox'ı temizle ve başlık ekle
            lstSonuclar.Items.Clear();
            lstSonuclar.Items.Add($"--- {dersKodu} DERSİ ÖĞRENCİ LİSTESİ (No'ya Göre Sıralı) ---");
            lstSonuclar.Items.Add("---------------------------------------------------------");

            if (siraliListe.Count == 0)
            {
                lstSonuclar.Items.Add("Bu derse kayıtlı öğrenci bulunamadı veya ders kodu hatalı.");
                return;
            }

            // 3. Veriyi ListBox'a aktar
            foreach (var node in siraliListe)
            {
                // Öğrenci No, Ders Kodu ve Notu formatlı bir şekilde ekle
                string satir = $"Öğr. No: {node.OgrenciNo,-6} | Harf Notu: {node.HarfOrtalamasi}";
                lstSonuclar.Items.Add(satir);
            }
        }

        private void btnDersSil_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtOgrenciNo.Text, out int ogrenciNo))
            {
                MessageBox.Show("Lütfen geçerli bir Öğrenci Numarası girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dersKodu = txtDersKodu.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(dersKodu))
            {
                MessageBox.Show("Lütfen silinecek Ders Kodunu girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıdan onay al
            DialogResult result = MessageBox.Show(
                $"{ogrenciNo} numaralı öğrencinin {dersKodu} dersini silmek istediğinize emin misiniz?",
                "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Yönetim sınıfındaki silme metodunu çağır
                bool basarili = yonetim.DersSil(ogrenciNo, dersKodu);

                if (basarili)
                {
                    MessageBox.Show("Ders kaydı başarıyla silindi.", "Başarılı");
                    // Giriş alanlarını temizle
                    txtOgrenciNo.Clear();
                    txtDersKodu.Clear();
                    txtHarfNotu.Clear();
                }
                else
                {
                    MessageBox.Show("Silinecek kayıt bulunamadı (Öğrenci veya ders kodu hatalı).", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
