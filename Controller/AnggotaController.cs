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
    internal class AnggotaController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private AnggotaRepository _repository;

        public List<Anggota> ReadAll()
        {
            // membuat objek collection
            List<Anggota> list = new List<Anggota>();

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new AnggotaRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }

            return list;
        }

        public int Create(Anggota ag)
        {
            int result = 0;

            if (string.IsNullOrEmpty(ag.kode_anggota))
            {
                MessageBox.Show("Kode Anggota harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.nama_anggota))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.jk_anggota))
            {
                MessageBox.Show("Jenis Kelamin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.jurusan_anggota))
            {
                MessageBox.Show("Jurusan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.no_telp_anggota))
            {
                MessageBox.Show("Nomor hp harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.alamat_anggota))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }


            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek class repository
                _repository = new AnggotaRepository(context);

                // panggil method Create class repository untuk menambahkan data
                result = _repository.Create(ag);
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

        public int Update(Anggota ag)
        {
            int result = 0;

            if (string.IsNullOrEmpty(ag.kode_anggota))
            {
                MessageBox.Show("Kode Anggota harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.nama_anggota))
            {
                MessageBox.Show("Nama harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.jk_anggota))
            {
                MessageBox.Show("Jenis Kelamin harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.jurusan_anggota))
            {
                MessageBox.Show("Jurusan harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.no_telp_anggota))
            {
                MessageBox.Show("Nomor hp harus diisi !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(ag.alamat_anggota))
            {
                MessageBox.Show("Alamat harus diisi !!!", "Peringatan",
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

        public int Delete(Anggota ag)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new AnggotaRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(ag);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Anggota berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Anggota gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public List<Anggota> ReadByNama(string nama_anggota)
        {
            // membuat objek collection
            List<Anggota> list = new List<Anggota>();

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new AnggotaRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama_anggota);
            }

            return list;
        }
    }
}
