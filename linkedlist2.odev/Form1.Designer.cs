namespace linkedlist2.odev
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOgrenciNo = new System.Windows.Forms.TextBox();
            this.txtDersKodu = new System.Windows.Forms.TextBox();
            this.txtHarfNotu = new System.Windows.Forms.TextBox();
            this.btnDersEkle = new System.Windows.Forms.Button();
            this.btnDersSil = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtListeleDersKodu = new System.Windows.Forms.TextBox();
            this.btnDerseGoreListele = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtListeleOgrenciNo = new System.Windows.Forms.TextBox();
            this.btnOgrenciyeGoreListele = new System.Windows.Forms.Button();
            this.lstSonuclar = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 647);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LemonChiffon;
            this.tabPage1.Controls.Add(this.btnDersSil);
            this.tabPage1.Controls.Add(this.btnDersEkle);
            this.tabPage1.Controls.Add(this.txtHarfNotu);
            this.tabPage1.Controls.Add(this.txtDersKodu);
            this.tabPage1.Controls.Add(this.txtOgrenciNo);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 618);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "kayıt yönetimi";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LemonChiffon;
            this.tabPage2.Controls.Add(this.lstSonuclar);
            this.tabPage2.Controls.Add(this.btnOgrenciyeGoreListele);
            this.tabPage2.Controls.Add(this.txtListeleOgrenciNo);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btnDerseGoreListele);
            this.tabPage2.Controls.Add(this.txtListeleDersKodu);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(942, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "listeleme ve sıralama";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "GRUP: GİRİŞ BİLGİLERİ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(33, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Öğrenci no:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(36, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ders kodu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(36, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Harf notu:";
            // 
            // txtOgrenciNo
            // 
            this.txtOgrenciNo.Location = new System.Drawing.Point(147, 105);
            this.txtOgrenciNo.Name = "txtOgrenciNo";
            this.txtOgrenciNo.Size = new System.Drawing.Size(168, 22);
            this.txtOgrenciNo.TabIndex = 4;
            // 
            // txtDersKodu
            // 
            this.txtDersKodu.Location = new System.Drawing.Point(147, 160);
            this.txtDersKodu.Name = "txtDersKodu";
            this.txtDersKodu.Size = new System.Drawing.Size(169, 22);
            this.txtDersKodu.TabIndex = 5;
            // 
            // txtHarfNotu
            // 
            this.txtHarfNotu.Location = new System.Drawing.Point(147, 216);
            this.txtHarfNotu.Name = "txtHarfNotu";
            this.txtHarfNotu.Size = new System.Drawing.Size(169, 22);
            this.txtHarfNotu.TabIndex = 6;
            // 
            // btnDersEkle
            // 
            this.btnDersEkle.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnDersEkle.Location = new System.Drawing.Point(23, 325);
            this.btnDersEkle.Name = "btnDersEkle";
            this.btnDersEkle.Size = new System.Drawing.Size(91, 51);
            this.btnDersEkle.TabIndex = 7;
            this.btnDersEkle.Text = "Ders ekle";
            this.btnDersEkle.UseVisualStyleBackColor = false;
            this.btnDersEkle.Click += new System.EventHandler(this.btnDersEkle_Click);
            // 
            // btnDersSil
            // 
            this.btnDersSil.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnDersSil.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDersSil.Location = new System.Drawing.Point(192, 325);
            this.btnDersSil.Name = "btnDersSil";
            this.btnDersSil.Size = new System.Drawing.Size(89, 51);
            this.btnDersSil.TabIndex = 8;
            this.btnDersSil.Text = "Ders sil";
            this.btnDersSil.UseVisualStyleBackColor = false;
            this.btnDersSil.Click += new System.EventHandler(this.btnDersSil_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label5.Location = new System.Drawing.Point(23, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(471, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "GRUP KUTUSU 1: DERSTEKİ ÖĞRENCİLERİ LİSTELE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label6.Location = new System.Drawing.Point(27, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "ARANACAK DERS KODU:";
            // 
            // txtListeleDersKodu
            // 
            this.txtListeleDersKodu.Location = new System.Drawing.Point(279, 87);
            this.txtListeleDersKodu.Name = "txtListeleDersKodu";
            this.txtListeleDersKodu.Size = new System.Drawing.Size(100, 22);
            this.txtListeleDersKodu.TabIndex = 2;
            // 
            // btnDerseGoreListele
            // 
            this.btnDerseGoreListele.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnDerseGoreListele.Location = new System.Drawing.Point(423, 83);
            this.btnDerseGoreListele.Name = "btnDerseGoreListele";
            this.btnDerseGoreListele.Size = new System.Drawing.Size(84, 30);
            this.btnDerseGoreListele.TabIndex = 3;
            this.btnDerseGoreListele.Text = "tıkla";
            this.btnDerseGoreListele.UseVisualStyleBackColor = false;
            this.btnDerseGoreListele.Click += new System.EventHandler(this.btnDerseGoreListele_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label7.Location = new System.Drawing.Point(27, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(480, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "GRUP KUTUSU 2: ÖĞRENCİNİN DERSLERİNİ LİSTELE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label8.Location = new System.Drawing.Point(31, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "ARANACAK ÖĞRENCİ NO:";
            // 
            // txtListeleOgrenciNo
            // 
            this.txtListeleOgrenciNo.Location = new System.Drawing.Point(293, 207);
            this.txtListeleOgrenciNo.Name = "txtListeleOgrenciNo";
            this.txtListeleOgrenciNo.Size = new System.Drawing.Size(105, 22);
            this.txtListeleOgrenciNo.TabIndex = 6;
            // 
            // btnOgrenciyeGoreListele
            // 
            this.btnOgrenciyeGoreListele.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnOgrenciyeGoreListele.Location = new System.Drawing.Point(423, 205);
            this.btnOgrenciyeGoreListele.Name = "btnOgrenciyeGoreListele";
            this.btnOgrenciyeGoreListele.Size = new System.Drawing.Size(84, 26);
            this.btnOgrenciyeGoreListele.TabIndex = 7;
            this.btnOgrenciyeGoreListele.Text = "tıkla";
            this.btnOgrenciyeGoreListele.UseVisualStyleBackColor = false;
            this.btnOgrenciyeGoreListele.Click += new System.EventHandler(this.btnOgrenciyeGoreListele_Click);
            // 
            // lstSonuclar
            // 
            this.lstSonuclar.FormattingEnabled = true;
            this.lstSonuclar.ItemHeight = 16;
            this.lstSonuclar.Location = new System.Drawing.Point(31, 351);
            this.lstSonuclar.Name = "lstSonuclar";
            this.lstSonuclar.Size = new System.Drawing.Size(520, 196);
            this.lstSonuclar.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 725);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDersSil;
        private System.Windows.Forms.Button btnDersEkle;
        private System.Windows.Forms.TextBox txtHarfNotu;
        private System.Windows.Forms.TextBox txtDersKodu;
        private System.Windows.Forms.TextBox txtOgrenciNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOgrenciyeGoreListele;
        private System.Windows.Forms.TextBox txtListeleOgrenciNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDerseGoreListele;
        private System.Windows.Forms.TextBox txtListeleDersKodu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstSonuclar;
    }
}

