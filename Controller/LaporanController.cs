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
    internal class LaporanController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private LaporanRepository _repository;

        public List<Laporan> ReadAll()
        {
            // membuat objek collection
            List<Laporan> list = new List<Laporan>();

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new LaporanRepository(context);

                // panggil method GetAll yang ada di dalam class repository
                list = _repository.ReadAll();
            }

            return list;
        }

        public int Delete(Laporan bk)
        {
            int result = 0;

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new LaporanRepository(context);

                // panggil method Delete class repository untuk menghapus data
                result = _repository.Delete(bk);
            }

            if (result > 0)
            {
                MessageBox.Show("Data Laporan berhasil dihapus !", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data Laporan gagal dihapus !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            return result;
        }

        public List<Laporan> ReadByNama(string nama_anggota)
        {
            // membuat objek collection
            List<Laporan> list = new List<Laporan>();

            // membuat objek context menggunakan blok using
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                // membuat objek dari class repository
                _repository = new LaporanRepository(context);

                // panggil method GetByNama yang ada di dalam class repository
                list = _repository.ReadByNama(nama_anggota);
            }

            return list;
        }

    }
}
