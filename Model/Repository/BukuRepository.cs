using MySql.Data.MySqlClient;
using Perpustakaan.Model.Context;
using Perpustakaan.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perpustakaan.Model.Repository
{
    internal class BukuRepository
    {
        // deklarsi objek connection
        private MySqlConnection _conn;

        // constructor
        public BukuRepository(MyDatabaseContext context)
        {
            // inisialisasi objek connection
            _conn = context.GetConnection();
        }

        public List<Buku> ReadAll()
        {
            // membuat objek collection untuk menampung objek buku
            List<Buku> list = new List<Buku>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kode_buku, judul_buku, penulis_buku, penerbit_buku, tahun_penerbit, stok from buku";

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
                            Buku buku = new Buku();
                            buku.kode_buku = dtr["kode_buku"].ToString();
                            buku.judul_buku = dtr["judul_buku"].ToString();
                            buku.penulis_buku = dtr["penulis_buku"].ToString();
                            buku.penerbit_buku = dtr["penerbit_buku"].ToString();
                            buku.tahun_terbit = dtr["tahun_penerbit"].ToString();
                            buku.stok = dtr["stok"].ToString();

                            // tambahkan objek buku ke dalam collection
                            list.Add(buku);
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

        public int Create(Buku bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"insert into buku (kode_buku, judul_buku, penulis_buku, penerbit_buku, tahun_penerbit, stok)
                           values (@kode_buku, @judul_buku, @penulis_buku, @penerbit_buku, @tahun_penerbit, @stok)";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode_buku", bk.kode_buku);
                cmd.Parameters.AddWithValue("@judul_buku", bk.judul_buku);
                cmd.Parameters.AddWithValue("@penulis_buku", bk.penulis_buku);
                cmd.Parameters.AddWithValue("@penerbit_buku", bk.penerbit_buku);
                cmd.Parameters.AddWithValue("@tahun_penerbit", bk.tahun_terbit);
                cmd.Parameters.AddWithValue("@stok", bk.stok);

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

        public int Update(Buku bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"update buku set kode_buku = @kode_buku, judul_buku = @judul_buku, penulis_buku = @penulis_buku, 
                            penerbit_buku = @penerbit_buku, tahun_penerbit = @tahun_penerbit, stok = @stok
                           where kode_buku = @kode_buku";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode_buku", bk.kode_buku);
                cmd.Parameters.AddWithValue("@judul_buku", bk.judul_buku);
                cmd.Parameters.AddWithValue("@penulis_buku", bk.penulis_buku);
                cmd.Parameters.AddWithValue("@penerbit_buku", bk.penerbit_buku);
                cmd.Parameters.AddWithValue("@tahun_penerbit", bk.tahun_terbit);
                cmd.Parameters.AddWithValue("@stok", bk.stok);

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

        public int Delete(Buku bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from buku
                           where kode_buku = @kode_buku";

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
        public List<Buku> ReadByJudul(string judul_buku)
        {
            // membuat objek collection untuk menampung objek mahasiswa
            List<Buku> list = new List<Buku>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kode_buku, judul_buku, penulis_buku, penerbit_buku, tahun_penerbit, stok
                               from buku 
                               where judul_buku like @judul_buku
                               order by judul_buku";

                // membuat objek command menggunakan blok using
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    // mendaftarkan parameter dan mengeset nilainya
                    cmd.Parameters.AddWithValue("@judul_buku", "%" + judul_buku + "%");

                    // membuat objek dtr (data reader) untuk menampung result set (hasil perintah SELECT)
                    using (MySqlDataReader dtr = cmd.ExecuteReader())
                    {
                        // panggil method Read untuk mendapatkan baris dari result set
                        while (dtr.Read())
                        {
                            // proses konversi dari row result set ke object
                            Buku buku = new Buku();
                            buku.kode_buku = dtr["kode_buku"].ToString();
                            buku.judul_buku = dtr["judul_buku"].ToString();
                            buku.penulis_buku = dtr["penulis_buku"].ToString();
                            buku.penerbit_buku = dtr["penerbit_buku"].ToString();
                            buku.tahun_terbit = dtr["tahun_penerbit"].ToString();
                            buku.stok = dtr["stok"].ToString();

                            // tambahkan objek buku ke dalam collection
                            list.Add(buku);
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
