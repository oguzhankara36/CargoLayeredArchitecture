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
    public partial class ARACSAYFA : Form
    {
        public ARACSAYFA()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Araçlar.listele();
        }
        public void verigoster()
        {
            dataGridView1.DataSource = Araçlar.listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arac ekle = new Arac();
            ekle.aractur = txttur.Text;
            ekle.aracsofor = txtsöfor.Text;
            ekle.arackapasite = int.Parse(txtkapasite.Text);
            if (!Araçlar.ekle(ekle))
            {
                MessageBox.Show("ekleme işlemi başarısız"); 
            }
            else
            {
                MessageBox.Show("ekleme işlemi başarılı");
            }
            verigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Arac sil = new Arac();
            sil.aracno = int.Parse(textBox1.Text);
            if (!Araçlar.sil(sil))
            {
                MessageBox.Show("silme işlemi başarısız");
            }
            else
            {
                MessageBox.Show("silme işlemi başarılı");
            }
            verigoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arac bul = new Arac();
            bul.aractur = txttur.Text;
            dataGridView1.DataSource= Araçlar.bul(bul);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Arac guncelle = new Arac();
            guncelle.aracno =int.Parse( textBox1.Text);
            guncelle.aractur = txttur.Text;
            guncelle.aracsofor = txtsöfor.Text;
            guncelle.arackapasite = int.Parse(txtkapasite.Text);
            if (!Araçlar.guncelle(guncelle))
            {
                MessageBox.Show("güncelleme işlemi başarısız");
            }
            else
            {
                MessageBox.Show("güncelleme işlemi başarılı");
            }
            verigoster();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["aracno"].Value.ToString();
            txtkapasite.Text = satir.Cells["arackapasite"].Value.ToString();
            txtsöfor.Text = satir.Cells["aracsofor"].Value.ToString();
            txttur.Text = satir.Cells["aractur"].Value.ToString();
        }
    }
}
