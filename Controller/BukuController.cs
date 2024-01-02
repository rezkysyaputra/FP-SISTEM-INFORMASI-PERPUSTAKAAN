using Perpustakaan.Model.Context;
using Perpustakaan.Model.Entity;
using Perpustakaan.Model.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan.Controller
{
    public class BukuController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private BukuRepository _repository;

        public List<Buku> ReadAll()
        {
            // membuat objek collection
            List<Buku> list = new List<Buku>();

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new BukuRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }

            return list;
        }

        public int Create(Buku bk)
        {
            int result = 0;

            if (string.IsNullOrEmpty(bk.kode_buku))
            {
                MessageBox.Show("Kode Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.judul_buku))
            {
                MessageBox.Show("Judul buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.penulis_buku))
            {
                MessageBox.Show("Penulis Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.penerbit_buku))
            {
                MessageBox.Show("Penerbit Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.tahun_terbit))
            {
                MessageBox.Show("Tahun terbit Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.stok))
            {
                MessageBox.Show("Stok Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }


            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek class repository
                _repository = new BukuRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Buku berhasil disimpan !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Buku gagal disimpan !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Update(Buku bk)
        {
            int result = 0;

            if (string.IsNullOrEmpty(bk.kode_buku))
            {
                MessageBox.Show("Kode Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.judul_buku))
            {
                MessageBox.Show("Judul buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.penulis_buku))
            {
                MessageBox.Show("Penulis Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.penerbit_buku))
            {
                MessageBox.Show("Penerbit Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.tahun_terbit))
            {
                MessageBox.Show("Tahun terbit Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(bk.stok))
            {
                MessageBox.Show("Stok Buku harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil diupdate !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal diupdate !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public int Delete(Buku bk)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new BukuRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Data buku berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Buku gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public List<Buku> ReadByJudul(string judul_buku)
        {
            // membuat objek collection
            List<Buku> list = new List<Buku>();

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new BukuRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByJudul(judul_buku);
            }

            return list;
        }

    }
}
