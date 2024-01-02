using Perpustakaan.Controller;
using Perpustakaan.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perpustakaan
{
    public partial class FrmLaporan : Form
    {
        // deklarasi field untuk meyimpan objek mahasiswa
        private Laporan bk;

        // deklarasi objek collection untuk menampung objek mahasiswa
        private List<Laporan> listOfLaporan = new List<Laporan>();

        // deklarasi objek controller
        private LaporanController controller;
        public FrmLaporan()
        {
            InitializeComponent();
            // membuat objek controller
            controller = new LaporanController();

            InisialisasiListView();
            LoadDataLaporan();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwLaporan.View = System.Windows.Forms.View.Details;
            lvwLaporan.FullRowSelect = true;
            lvwLaporan.GridLines = true;

            lvwLaporan.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvwLaporan.Columns.Add("Nama Anggota", 150, HorizontalAlignment.Center);
            lvwLaporan.Columns.Add("Kode Anggota", 90, HorizontalAlignment.Center);
            lvwLaporan.Columns.Add("Judul Buku", 150, HorizontalAlignment.Center);
            lvwLaporan.Columns.Add("Kode Buku", 90, HorizontalAlignment.Center);
            lvwLaporan.Columns.Add("Tanggal Pinjam", 150, HorizontalAlignment.Center);
            lvwLaporan.Columns.Add("Tanggal Kembali", 150, HorizontalAlignment.Center);
        }

        // method untuk menampilkan semua data mahasiswa
        private void LoadDataLaporan()
        {
            // kosongkan listview
            lvwLaporan.Items.Clear();

            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfLaporan = controller.ReadAll();

            // ekstrak objek mhs dari collection
            foreach (var bk in listOfLaporan)
            {
                var noUrut = lvwLaporan.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bk.nama_angggota);
                item.SubItems.Add(bk.kode_anggota);
                item.SubItems.Add(bk.judul_buku);
                item.SubItems.Add(bk.kode_buku);
                item.SubItems.Add(bk.tanggal_pinjam);
                item.SubItems.Add(bk.tanggal_kembali);

                // tampilkan data mhs ke listview
                lvwLaporan.Items.Add(item);
            }
        }

        private void FrmPengembalian_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lvwLaporan.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Laporan ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Laporan bk = listOfLaporan[lvwLaporan.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(bk);
                    if (result > 0) LoadDataLaporan();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data Laporan belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwLaporan.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfLaporan = controller.ReadByNama(txtSearch.Text);

            // ekstrak objek mhs dari collection
            foreach (var bk in listOfLaporan)
            {
                var noUrut = lvwLaporan.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bk.nama_angggota);
                item.SubItems.Add(bk.kode_anggota);
                item.SubItems.Add(bk.judul_buku);
                item.SubItems.Add(bk.kode_buku);
                item.SubItems.Add(bk.tanggal_pinjam);
                item.SubItems.Add(bk.tanggal_kembali);

                // tampilkan data mhs ke listview
                lvwLaporan.Items.Add(item);
            }
        }
    }
}
