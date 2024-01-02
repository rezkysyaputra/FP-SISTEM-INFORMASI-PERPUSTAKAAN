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
    public partial class FrmPeminjaman : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Peminjaman bk);

        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;

        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;

        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek mahasiswa
        private Peminjaman bk;

        // deklarasi objek collection untuk menampung objek mahasiswa
        private List<Peminjaman> listOfPeminjaman = new List<Peminjaman>();

        // deklarasi objek controller
        private PeminjamanController controller;
        public FrmPeminjaman()
        {
            InitializeComponent();
            // membuat objek controller
            controller = new PeminjamanController();

            InisialisasiListView();
            LoadDataBuku();
        }

               // atur kolom listview
        private void InisialisasiListView()
        {
            lvwPeminjaman.View = System.Windows.Forms.View.Details;
            lvwPeminjaman.FullRowSelect = true;
            lvwPeminjaman.GridLines = true;

            lvwPeminjaman.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvwPeminjaman.Columns.Add("Kode Buku", 150, HorizontalAlignment.Center);
            lvwPeminjaman.Columns.Add("Kode Anggota", 150, HorizontalAlignment.Center);
            lvwPeminjaman.Columns.Add("Tanggal Pinjam", 200, HorizontalAlignment.Center);
        }

        // method untuk menampilkan semua data mahasiswa
        private void LoadDataBuku()
        {
            // kosongkan listview
            lvwPeminjaman.Items.Clear();

            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfPeminjaman = controller.ReadAll();

            // ekstrak objek mhs dari collection
            foreach (var bk in listOfPeminjaman)
            {
                var noUrut = lvwPeminjaman.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bk.kode_buku);
                item.SubItems.Add(bk.kode_anggota);
                item.SubItems.Add(bk.tanggal_pinjam);
                // tampilkan data mhs ke listview
                lvwPeminjaman.Items.Add(item);
            }
        }

        private void FrmPeminjaman_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Peminjaman bk)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfPeminjaman.Add(bk);

            int noUrut = lvwPeminjaman.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(bk.kode_buku);
            item.SubItems.Add(bk.kode_anggota);
            item.SubItems.Add(bk.tanggal_pinjam);

            lvwPeminjaman.Items.Add(item);

            // Memanggil event OnCreate
            OnCreate?.Invoke(bk);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek buku
            if (isNewData)
            {
                bk = new Peminjaman();
            }

            // Pastikan objek buku tidak bernilai null sebelum mengakses propertinya
            if (bk != null)
            {
                // set nilai property objek buku yang diambil dari TextBox
                bk.kode_buku = txtBuku.Text;
                bk.kode_anggota = txtAnggota.Text;
                bk.tanggal_pinjam = txtPinjam.Text;

                int result = 0;

                if (isNewData) // tambah data baru, panggil method Create
                {
                    // panggil operasi CRUD
                    result = controller.Create(bk);

                    if (result > 0) // tambah data berhasil
                    {
                        OnCreateEventHandler(bk); // panggil event OnCreate

                        // reset form input, utk persiapan input data berikutnya
                        txtBuku.Clear();
                        txtAnggota.Clear();
                        txtPinjam.Refresh();

                        txtBuku.Focus();
                    }
                }
          /*      else // edit data, panggil method Update
                {
                    // panggil operasi CRUD
                    result = controller.Update(bk);

                    if (result > 0)
                    {
                        OnUpdateEventHandler(bk); // panggil event OnUpdate
                        this.Close();
                    }
                }*/
            }
            else
            {
                MessageBox.Show("Objek buku bernilai null.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBuku.Clear();
            txtAnggota.Clear();
            txtPinjam.Refresh();

            txtBuku.Focus();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwPeminjaman.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Pinjam ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Peminjaman bk = listOfPeminjaman[lvwPeminjaman.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(bk);
                    if (result > 0) LoadDataBuku();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data Pinjam belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            if (lvwPeminjaman.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Pinjam ingin dikembalikan?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Peminjaman bk = listOfPeminjaman[lvwPeminjaman.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Kembali(bk);
                    if (result > 0) LoadDataBuku();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data Pinjam belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
