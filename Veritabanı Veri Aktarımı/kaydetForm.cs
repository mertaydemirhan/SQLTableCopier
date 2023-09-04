using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veritabanı_Veri_Aktarımı
{
    public partial class kaydetForm : Form
    {
        public kaydetForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.KayitliSunucuAdresi = sunucuAdresiBox.Text;
            Properties.Settings.Default.KayitliKullaniciAdi = kullaniciAdiBox.Text;
            Properties.Settings.Default.KayitliSifre = sifreBox.Text;
            
            Properties.Settings.Default.VeritabaniAdiii = veritabaniAdi.Text;


                                

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            MessageBox.Show("Ayarlar kaydedildi. Yazılım yeniden başlatılıyor...", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void kaydetForm_Load(object sender, EventArgs e)
        {
            sunucuAdresiBox.Text = Properties.Settings.Default.KayitliSunucuAdresi;
            kullaniciAdiBox.Text = Properties.Settings.Default.KayitliKullaniciAdi;
            sifreBox.Text = Properties.Settings.Default.KayitliSifre;
            veritabaniAdi.Text = Properties.Settings.Default.VeritabaniAdiii;
        }
    }
}
