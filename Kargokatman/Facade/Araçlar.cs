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
    public class Araçlar
    {

        public static DataTable listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("araclistele", datalar.Baglanti);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool sil(Arac sil)
        {
            SqlCommand komut = new SqlCommand("aracsil", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("aracno", sil.aracno);

            return datalar.ExecuteNonQuery(komut);
        }
        public static bool ekle(Arac ekle)
        {
            SqlCommand komut = new SqlCommand("aracekle", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("aractur", ekle.aractur);
            komut.Parameters.AddWithValue("arackapasite", ekle.arackapasite);
            komut.Parameters.AddWithValue("aracsofor", ekle.aracsofor);
            return datalar.ExecuteNonQuery(komut);
        }
        public static bool guncelle(Arac guncelle)
        {
            SqlCommand komut = new SqlCommand("aracguncelle", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("aracno", guncelle.aracno);
            komut.Parameters.AddWithValue("aractur", guncelle.aractur);
            komut.Parameters.AddWithValue("arackapasite", guncelle.arackapasite);
            komut.Parameters.AddWithValue("aracsofor", guncelle.aracsofor);
            return datalar.ExecuteNonQuery(komut);
        }
        public static DataTable bul(Arac bul)
        {
            SqlCommand komut = new SqlCommand("aracbul", datalar.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("aractur", bul.aractur);
            datalar.ExecuteNonQuery(komut);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }
      
    }
}
