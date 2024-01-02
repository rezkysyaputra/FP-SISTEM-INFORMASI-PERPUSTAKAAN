using Perpustakaan.Model.Context;
using Perpustakaan.Model.Entity;
using Perpustakaan.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan.Controller
{
    internal class PeminjamanController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private PeminjamanRepository _repository;

        public List<Peminjaman> ReadAll()
        {
            // membuat objek collection
            List<Peminjaman> list = new List<Peminjaman>();

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new PeminjamanRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }
            return list;
        }

        public int Create(Peminjaman bk)
        {
            int result = 0;

            if (string.IsNullOrEmpty(bk.kode_buku))
            {
                MessageBox.Show("Kode Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.kode_anggota))
            {
                MessageBox.Show("Kode Anggota harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.tanggal_pinjam))
            {
                MessageBox.Show("Tanggal pinjam harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek class repository
                _repository = new PeminjamanRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Pinjam berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Pinjam gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Peminjaman bk)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new PeminjamanRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Pinjam berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Pinjam gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Kembali(Peminjaman bk)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new PeminjamanRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Kembali(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Buku berhasil Dikembalikkan!", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Buku gagal Dikembalikkan!!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }
    }
}
