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
    public class Sevkiyatlar
    {
        public static DataTable listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("sevkiyatlistele", datalar.Baglanti);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool sil(Sevk sil)
        {
            SqlCommand komut = new SqlCommand("sevkiyatsil", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("sevkiyatno", sil.sevkiyatno);

            return datalar.ExecuteNonQuery(komut);
        }
        public static bool ekle(Sevk ekle)
        {
            SqlCommand komut = new SqlCommand("sevkiyatekle", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("sevkiyatadi", ekle.sevkiyatadi);
            komut.Parameters.AddWithValue("sevkalisnoktasi", ekle.sevkalisnoktasi);
            komut.Parameters.AddWithValue("sevkulasimnoktasi", ekle.sevkulasimnoktasi);
            komut.Parameters.AddWithValue("mesafe", ekle.mesafe);
            komut.Parameters.AddWithValue("mesafetutar", ekle.mesafetutar);
            komut.Parameters.AddWithValue("aracno", ekle.aracno);
            return datalar.ExecuteNonQuery(komut);
        }
        public static bool guncelle(Sevk guncelle)
        {
            SqlCommand komut = new SqlCommand("sevkiyatguncelle", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("sevkiyatno", guncelle.sevkiyatno);
            komut.Parameters.AddWithValue("sevkiyatadi", guncelle.sevkiyatadi);
            komut.Parameters.AddWithValue("sevkalisnoktasi", guncelle.sevkalisnoktasi);
            komut.Parameters.AddWithValue("sevkulasimnoktasi", guncelle.sevkulasimnoktasi);
            komut.Parameters.AddWithValue("mesafe", guncelle.mesafe);
            komut.Parameters.AddWithValue("mesafetutar", guncelle.mesafetutar);
            komut.Parameters.AddWithValue("aracno", guncelle.aracno);
            return datalar.ExecuteNonQuery(komut);
        }
        public static DataTable bul(Sevk bul)
        {
            SqlCommand komut = new SqlCommand("sevkiyatbul", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("sevkiyatadi", bul.sevkiyatadi);
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
            SqlDataAdapter goster = new SqlDataAdapter("select aracno from araclar", datalar.Baglanti);
            goster.Fill(doldur);
            return doldur;
        }
    }
}
