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
    internal class AnggotaRepository
    {
        // deklarsi objek connection
        private MySqlConnection _conn;

        // constructor
        public AnggotaRepository(MyDatabaseContext context)
        {
            // inisialisasi objek connection
            _conn = context.GetConnection();
        }

        public List<Anggota> ReadAll()
        {
            // membuat objek collection untuk menampung objek buku
            List<Anggota> list = new List<Anggota>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kode_anggota, nama_anggota, jk_anggota, jurusan_anggota, no_telp_anggota, alamat_anggota from anggota";

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
                            Anggota anggota = new Anggota();
                            anggota.kode_anggota = dtr["kode_anggota"].ToString();
                            anggota.nama_anggota = dtr["nama_anggota"].ToString();
                            anggota.jk_anggota = dtr["jk_anggota"].ToString();
                            anggota.jurusan_anggota = dtr["jurusan_anggota"].ToString();
                            anggota.no_telp_anggota = dtr["no_telp_anggota"].ToString();
                            anggota.alamat_anggota = dtr["alamat_anggota"].ToString();

                            // tambahkan objek buku ke dalam collection
                            list.Add(anggota);
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

        public int Create(Anggota ag)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into anggota (kode_anggota, nama_anggota, jk_anggota, jurusan_anggota, no_telp_anggota, alamat_anggota)
                           values (@kode_anggota, @nama_anggota, @jk_anggota, @jurusan_anggota, @no_telp_anggota, @alamat_anggota)";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode_anggota", ag.kode_anggota);
                cmd.Parameters.AddWithValue("@nama_anggota", ag.nama_anggota);
                cmd.Parameters.AddWithValue("@jk_anggota", ag.jk_anggota);
                cmd.Parameters.AddWithValue("@jurusan_anggota", ag.jurusan_anggota);
                cmd.Parameters.AddWithValue("@no_telp_anggota", ag.no_telp_anggota);
                cmd.Parameters.AddWithValue("@alamat_anggota", ag.alamat_anggota);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Update(Anggota ag)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update anggota set kode_anggota = @kode_anggota, nama_anggota = @nama_anggota, jk_anggota = @jk_anggota, 
                            jurusan_anggota = @jurusan_anggota, no_telp_anggota = @no_telp_anggota, alamat_anggota = @alamat_anggota
                           where kode_anggota = @kode_anggota";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode_anggota", ag.kode_anggota);
                cmd.Parameters.AddWithValue("@nama_anggota", ag.nama_anggota);
                cmd.Parameters.AddWithValue("@jk_anggota", ag.jk_anggota);
                cmd.Parameters.AddWithValue("@jurusan_anggota", ag.jurusan_anggota);
                cmd.Parameters.AddWithValue("@no_telp_anggota", ag.no_telp_anggota);
                cmd.Parameters.AddWithValue("@alamat_anggota", ag.alamat_anggota);

                try
                {
                    // jalankan perintah UPDATE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Anggota ag)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from anggota
                           where kode_anggota = @kode_anggota";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode_anggota", ag.kode_anggota);
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
        public List<Anggota> ReadByNama(string nama_anggota)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Anggota> list = new List<Anggota>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kode_anggota, nama_anggota, jk_anggota, jurusan_anggota, no_telp_anggota, alamat_anggota
                               from anggota 
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
                            Anggota ag = new Anggota();
                            ag.kode_anggota = dtr["kode_anggota"].ToString();
                            ag.nama_anggota = dtr["nama_anggota"].ToString();
                            ag.jk_anggota = dtr["jk_anggota"].ToString();
                            ag.jurusan_anggota = dtr["jurusan_anggota"].ToString();
                            ag.no_telp_anggota = dtr["no_telp_anggota"].ToString();
                            ag.alamat_anggota = dtr["alamat_anggota"].ToString();

                            // tambahkan objek buku ke dalam collection
                            list.Add(ag);
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
