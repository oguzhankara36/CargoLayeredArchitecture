using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Kargokatman.Entity;

namespace Kargokatman.Facade
{
   public class Müşteriler
    {
        public static DataTable listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("musterilistele", datalar.Baglanti);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool sil(Musteri sil)
        {
            SqlCommand komut = new SqlCommand("musterisil", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("musterino", sil.musterino);

            return datalar.ExecuteNonQuery(komut);
        }
        public static bool ekle(Musteri ekle)
        {
            SqlCommand komut = new SqlCommand("musteriekle", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("sevkiyatno", ekle.sevkiyatno);
            komut.Parameters.AddWithValue("musteriadsoyad", ekle.musteriadsoyad);
            komut.Parameters.AddWithValue("adres", ekle.adres);
            komut.Parameters.AddWithValue("telefon", ekle.telefon);
            komut.Parameters.AddWithValue("mail", ekle.mail);
            komut.Parameters.AddWithValue("odemedurum", ekle.odemedurum);
            return datalar.ExecuteNonQuery(komut);
        }
        public static bool guncelle(Musteri guncelle)
        {
            SqlCommand komut = new SqlCommand("aracguncelle", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("musterino", guncelle.musterino);
            komut.Parameters.AddWithValue("sevkiyatno", guncelle.sevkiyatno);
            komut.Parameters.AddWithValue("musteriadsoyad", guncelle.musteriadsoyad);
            komut.Parameters.AddWithValue("adres", guncelle.adres);
            komut.Parameters.AddWithValue("telefon", guncelle.telefon);
            komut.Parameters.AddWithValue("mail", guncelle.mail);
            komut.Parameters.AddWithValue("odemedurum", guncelle.odemedurum);
            return datalar.ExecuteNonQuery(komut);
        }
        public static DataTable bul(Musteri bul)
        {
            SqlCommand komut = new SqlCommand("musteribul", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("musteriadsoyad", bul.musteriadsoyad);
            datalar.ExecuteNonQuery(komut);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable doldur()
        {
            SqlCommand komut = new SqlCommand();
            DataTable doldur = new DataTable();
            SqlDataAdapter goster = new SqlDataAdapter("select sevkiyatno from sevkiyat", datalar.Baglanti);
            goster.Fill(doldur);
            return doldur;
        }
    }
}
