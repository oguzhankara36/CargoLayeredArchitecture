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
    public partial class SEVKIYATSAYFA : Form
    {
        public SEVKIYATSAYFA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sevk ekle = new Sevk();
            ekle.sevkiyatadi = txtsevkadi.Text;
            ekle.sevkulasimnoktasi = txtsevkulasim.Text;
            ekle.sevkalisnoktasi = txtsevkalıs.Text;
            ekle.mesafe = int.Parse(txtmesafe.Text);
            ekle.mesafetutar = decimal.Parse(txtmesafetutar.Text);
            ekle.aracno = int.Parse(txtarano.Text);
            if (!Sevkiyatlar.ekle(ekle))
            {
                MessageBox.Show("ekleme işlemi başarısız");
            }
            else
            {
                MessageBox.Show("ekleme işlemi başarılı");
            }
            goster();
        }
        public void goster()
        {
            dataGridView1.DataSource = Sevkiyatlar.listele();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Sevkiyatlar.listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sevk sil = new Sevk();
            sil.sevkiyatno = int.Parse(txtsevkno.Text);
            if (!Sevkiyatlar.sil(sil))
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
            Sevk ara = new Sevk();
            ara.sevkiyatadi = txtsevkadi.Text;
            dataGridView1.DataSource = Sevkiyatlar.bul(ara);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sevk guncelle = new Sevk();
            guncelle.sevkiyatadi = txtsevkadi.Text;
            guncelle.sevkulasimnoktasi = txtsevkulasim.Text;
            guncelle.sevkalisnoktasi = txtsevkalıs.Text;
            guncelle.mesafe = int.Parse(txtmesafe.Text);
            guncelle.mesafetutar = decimal.Parse(txtmesafetutar.Text);
            guncelle.aracno = int.Parse(txtarano.Text);
            if (!Sevkiyatlar.guncelle(guncelle))
            {
                MessageBox.Show("ekleme işlemi başarısız");
            }
            else
            {
                MessageBox.Show("ekleme işlemi başarılı");
            }
            goster();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtarano.Text = satir.Cells["aracno"].Value.ToString();
            txtmesafe.Text = satir.Cells["mesafe"].Value.ToString();
            txtmesafetutar.Text = satir.Cells["mesafetutar"].Value.ToString();
            txtsevkadi.Text = satir.Cells["sevkiyatadi"].Value.ToString();
            txtsevkalıs.Text = satir.Cells["sevkalisnoktasi"].Value.ToString();
            txtsevkulasim.Text = satir.Cells["sevkulasimnoktasi"].Value.ToString();
            txtsevkno.Text = satir.Cells["sevkiyatno"].Value.ToString();
        }

        private void SEVKIYATSAYFA_Load(object sender, EventArgs e)
        {
            txtarano.ValueMember = "aracno";
            txtarano.DataSource = Sevkiyatlar.doldur();
        }
    }
}
