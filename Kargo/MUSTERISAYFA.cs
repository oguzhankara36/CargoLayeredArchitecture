using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kargokatman.Entity;
using Kargokatman.Facade;

namespace Kargo
{
    public partial class MUSTERISAYFA : Form
    {
        public MUSTERISAYFA()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Müşteriler.listele();
        }
        public void goster()
        {
            dataGridView1.DataSource = Müşteriler.listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteri ekle = new Musteri();
            ekle.musteriadsoyad = txtmadsoyad.Text;
            ekle.sevkiyatno = int.Parse(txtsno.Text);
            ekle.adres = txtadres.Text;
            ekle.telefon = txttel.Text;
            ekle.mail = txtmail.Text;
            ekle.odemedurum = txtodeme.Text;
            if (!Müşteriler.ekle(ekle))
            {
                MessageBox.Show("ekleme işlemi başarısız");
            }
            else
            {
                MessageBox.Show("ekleme işlemi başarılı");
            }
            goster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Musteri sil = new Musteri();
            sil.musterino = int.Parse(txtmno.Text);
            if (!Müşteriler.sil(sil))
            {
                MessageBox.Show("silme işlemi başarısız");
            }
            else
            {
                MessageBox.Show("silme işlemi başarılı");
            }
            goster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Musteri guncelle = new Musteri();
            guncelle.musterino = int.Parse(txtmno.Text);
            guncelle.musteriadsoyad = txtmadsoyad.Text;
            guncelle.sevkiyatno = int.Parse(txtsno.Text);
            guncelle.adres = txtadres.Text;
            guncelle.telefon = txttel.Text;
            guncelle.mail = txtmail.Text;
            guncelle.odemedurum = txtodeme.Text;
            if (!Müşteriler.guncelle(guncelle))
            {
                MessageBox.Show("güncelleme işlemi başarısız");
            }
            else
            {
                MessageBox.Show("güncelleme işlemi başarılı");
            }
            goster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Musteri bul = new Musteri();
            bul.musteriadsoyad = txtmadsoyad.Text;
            dataGridView1.DataSource = Müşteriler.bul(bul);
        }

        private void MUSTERISAYFA_Load(object sender, EventArgs e)
        {
            txtsno.ValueMember = "sevkiyatno";
            txtsno.DataSource = Müşteriler.doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtsno.Text = satir.Cells["sevkiyatno"].Value.ToString();
            txttel.Text = satir.Cells["telefon"].Value.ToString();
            txtodeme.Text = satir.Cells["odemedurum"].Value.ToString();
            txtmno.Text = satir.Cells["musterino"].Value.ToString();
            txtmail.Text = satir.Cells["mail"].Value.ToString();
            txtmadsoyad.Text = satir.Cells["musteriadsoyad"].Value.ToString();
            txtadres.Text = satir.Cells["adres"].Value.ToString();
        }
    }
}
