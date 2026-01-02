using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VirusScanerSim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Masaüstü yolunu bul
                string yol = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string[] dosyalar = Directory.GetFiles(yol);

                listBox1.Items.Clear();
                listBox1.Items.Add("Sistem Taraması Başlatıldı...");

                progressBar1.Maximum = dosyalar.Length;
                progressBar1.Value = 0;

                foreach (string dosya in dosyalar)
                {
                    string dosyaAdi = Path.GetFileName(dosya);
                    listBox1.Items.Add("İnceleniyor: " + dosyaAdi);

                    // Simülasyon: Riskli uzantı kontrolü
                    if (dosyaAdi.ToLower().EndsWith(".exe") || dosyaAdi.ToLower().EndsWith(".bat"))
                    {
                        listBox1.Items.Add("⚠️ RİSKLİ DOSYA: " + dosyaAdi);
                    }

                    progressBar1.Value++;
                    Application.DoEvents(); // Donmayı engeller
                }

                listBox1.Items.Add("--- Tarama Başarıyla Tamamlandı ---");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}