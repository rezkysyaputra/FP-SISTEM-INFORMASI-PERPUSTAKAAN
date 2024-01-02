using MySql.Data.MySqlClient;
using Perpustakaan.Model.Context;
using Perpustakaan.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perpustakaan.Model.Repository
{
    internal class LaporanRepository
    {
        // deklarsi objek connection
        private MySqlConnection _conn;

        // constructor
        public LaporanRepository(MyDatabaseContext context)
        {
            // inisialisasi objek connection
            _conn = context.GetConnection();
        }

        public List<Laporan> ReadAll()
        {
            // membuat objek collection untuk menampung objek buku
            List<Laporan> list = new List<Laporan>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select nama_anggota, kode_anggota, judul_buku, kode_buku, tanggal_pinjam, tanggal_kembali from laporan";

                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Laporan lp = new Laporan();
                            lp.nama_angggota = dtr["nama_anggota"].ToString();
                            lp.kode_anggota = dtr["kode_anggota"].ToString();
                            lp.judul_buku = dtr["judul_buku"].ToString();
                            lp.kode_buku = dtr["kode_buku"].ToString();
                            lp.tanggal_pinjam = dtr["tanggal_pinjam"].ToString();
                            lp.tanggal_kembali = dtr["tanggal_kembali"].ToString();

                            // tambahkan objek buku ke dalam collection
                            list.Add(lp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }

            return list;
        }

        public int Delete(Laporan bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from laporan
                           where kode_buku = @kode_buku limit 1";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode_buku", bk.kode_buku);
                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result;
        }

        // Method untuk menampilkan data mahasiwa berdasarkan pencarian nama
        public List<Laporan> ReadByNama(string nama_anggota)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Laporan> list = new List<Laporan>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select nama_anggota, kode_anggota, judul_buku, kode_buku, tanggal_pinjam, tanggal_kembali from laporan
                               where nama_anggota like @nama_anggota
                               order by nama_anggota";

                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@nama_anggota", "%" + nama_anggota + "%");

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Laporan lp = new Laporan();
                            lp.nama_angggota = dtr["nama_anggota"].ToString();
                            lp.kode_anggota = dtr["kode_anggota"].ToString();
                            lp.judul_buku = dtr["judul_buku"].ToString();
                            lp.kode_buku = dtr["kode_buku"].ToString();
                            lp.tanggal_pinjam = dtr["tanggal_pinjam"].ToString();
                            lp.tanggal_kembali = dtr["tanggal_kembali"].ToString();

                            // tambahkan objek buku ke dalam collection
                            list.Add(lp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }

            return list;
        }
    }
}
