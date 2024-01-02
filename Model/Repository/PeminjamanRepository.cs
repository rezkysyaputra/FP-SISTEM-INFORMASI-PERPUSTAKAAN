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
    internal class PeminjamanRepository
    {
        // deklarsi objek connection
        private MySqlConnection _conn;


        // constructor
        public PeminjamanRepository(MyDatabaseContext context)
        {
            // inisialisasi objek connection
            _conn = context.GetConnection();
        }

        public List<Peminjaman> ReadAll()
        {
            // membuat objek collection untuk menampung objek buku
            List<Peminjaman> list = new List<Peminjaman>();

            try
            {
                // deklarasi perintah SQL
                string sql = @"select kode_buku, kode_anggota, tanggal_pinjam from peminjaman";

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
                            Peminjaman peminjaman = new Peminjaman();
                            peminjaman.kode_buku = dtr["kode_buku"].ToString();
                            peminjaman.kode_anggota = dtr["kode_anggota"].ToString();
                            peminjaman.tanggal_pinjam = dtr["tanggal_pinjam"].ToString();

                            // tambahkan objek buku ke dalam collection
                            list.Add(peminjaman);
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

        public int Create(Peminjaman ag)
        {
            int result = 0;

            // Deklarasi perintah SQL untuk menyisipkan data peminjaman
            string sqlInsertPeminjaman = @"INSERT INTO peminjaman (kode_buku, kode_anggota, tanggal_pinjam)
                                   VALUES ((select kode_buku from buku where kode_buku = @kode_buku), 
                                    (select kode_anggota from anggota where kode_anggota = @kode_anggota), @tanggal_pinjam)";

            // Deklarasi perintah SQL untuk mengurangi stok buku
            string sqlUpdateStok = @"UPDATE buku
                             SET stok = stok - 1 
                             WHERE kode_buku = @kode_buku";

            // Membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sqlInsertPeminjaman, _conn))
            {
                // Mendaftarkan parameter untuk data peminjaman dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode_buku", ag.kode_buku);
                cmd.Parameters.AddWithValue("@kode_anggota", ag.kode_anggota);
                cmd.Parameters.AddWithValue("@tanggal_pinjam", ag.tanggal_pinjam);

                try
                {
                    // Jalankan perintah INSERT untuk menyisipkan data peminjaman
                    result = cmd.ExecuteNonQuery();

                    // Jika berhasil menyisipkan data peminjaman, lakukan UPDATE stok buku
                    if (result > 0)
                    {
                        using (MySqlCommand cmdUpdateStok = new MySqlCommand(sqlUpdateStok, _conn))
                        {
                            // Mendaftarkan parameter untuk mengurangi stok buku dan mengeset nilainya
                            cmdUpdateStok.Parameters.AddWithValue("@kode_buku", ag.kode_buku);

                            // Jalankan perintah UPDATE untuk mengurangi stok buku
                            result = cmdUpdateStok.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }

            return result;
        }

        public int Delete(Peminjaman bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from peminjaman
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

        public int Kembali(Peminjaman bk)
        {
            int result = 0;

            // deklarasi perintah SQL
            string sql = @"delete from peminjaman
                           where kode_buku = @kode_buku limit 1";

            string sqlInsertLaporan = @"INSERT INTO laporan (nama_anggota, kode_anggota, judul_buku, kode_buku, tanggal_pinjam, tanggal_kembali)
                            VALUES ((SELECT nama_anggota FROM anggota WHERE kode_anggota = @kode_anggota),
                                    @kode_anggota,
                                    (SELECT judul_buku FROM buku WHERE kode_buku = @kode_buku),
                                    @kode_buku,
                                    @tanggal_pinjam,
                                    DATE_FORMAT(NOW(), '%W, %d %M %Y'))";


            // Deklarasi perintah SQL untuk mengurangi stok buku
            string sqlUpdateStok = @"UPDATE buku 
                             SET stok = stok + 1 
                             WHERE kode_buku = @kode_buku";

            // membuat objek command menggunakan blok using
            using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@kode_buku", bk.kode_buku);
                try
                {
                    // jalankan perintah DELETE dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();

                    // Jika berhasil menyisipkan data peminjaman, lakukan UPDATE stok buku
                    if (result > 0)
                    {
                        using (MySqlCommand cmdUpdateStok = new MySqlCommand(sqlUpdateStok, _conn))
                        {
                            // Mendaftarkan parameter untuk mengurangi stok buku dan mengeset nilainya
                            cmdUpdateStok.Parameters.AddWithValue("@kode_buku", bk.kode_buku);

                            // Jalankan perintah UPDATE untuk mengurangi stok buku
                            result = cmdUpdateStok.ExecuteNonQuery();
                        }
                        using (MySqlCommand cmdInsertLaporan = new MySqlCommand(sqlInsertLaporan, _conn))
                        {
                            // Mendaftarkan parameter untuk data laporan dan mengeset nilainya
                            cmdInsertLaporan.Parameters.AddWithValue("@kode_anggota", bk.kode_anggota);
                            cmdInsertLaporan.Parameters.AddWithValue("@kode_buku", bk.kode_buku);
                            cmdInsertLaporan.Parameters.AddWithValue("@tanggal_pinjam", bk.tanggal_pinjam);

                                // Jalankan perintah INSERT untuk menyisipkan data laporan
                                result = cmdInsertLaporan.ExecuteNonQuery();
                        }

                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Kembali error: {0}", ex.Message);
                }
            }

            return result;
        }
    }
}