using Perpustakaan.Controller;
using Perpustakaan.Model.Context;
using Perpustakaan.Model.Repository;
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
    public partial class FrmBuku : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Buku bk);

        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;

        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;

        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek mahasiswa
        private Buku bk;

        // deklarasi objek collection untuk menampung objek mahasiswa
        private List<Buku> listOfBuku = new List<Buku>();

        // deklarasi objek controller
        private BukuController controller;
        public FrmBuku()
        {
            InitializeComponent();

            // membuat objek controller
            controller = new BukuController();

            InisialisasiListView();
            LoadDataBuku();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwBuku.View = System.Windows.Forms.View.Details;
            lvwBuku.FullRowSelect = true;
            lvwBuku.GridLines = true;

            lvwBuku.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Kode", 90, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Judul", 180, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Penulis", 180, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Penerbit", 180, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Tahun", 100, HorizontalAlignment.Center);
            lvwBuku.Columns.Add("Stok", 90, HorizontalAlignment.Center);
        }

        // method untuk menampilkan semua data mahasiswa
        private void LoadDataBuku()
        {
            // kosongkan listview
            lvwBuku.Items.Clear();

            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfBuku = controller.ReadAll();

            // ekstrak objek mhs dari collection
            foreach (var bk in listOfBuku)
            {
                var noUrut = lvwBuku.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bk.kode_buku);
                item.SubItems.Add(bk.judul_buku);
                item.SubItems.Add(bk.penulis_buku);
                item.SubItems.Add(bk.penerbit_buku);
                item.SubItems.Add(bk.tahun_terbit);
                item.SubItems.Add(bk.stok);

                // tampilkan data mhs ke listview
                lvwBuku.Items.Add(item);
            }
        }

        private void lvwBuku_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmBuku_Load(object sender, EventArgs e)
        {

        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Buku bk)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfBuku.Add(bk);

            int noUrut = lvwBuku.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(bk.kode_buku);
            item.SubItems.Add(bk.judul_buku);
            item.SubItems.Add(bk.penulis_buku);
            item.SubItems.Add(bk.penerbit_buku);
            item.SubItems.Add(bk.tahun_terbit);
            item.SubItems.Add(bk.stok);

            lvwBuku.Items.Add(item);

            // Memanggil event OnCreate
            OnCreate?.Invoke(bk);
        }

        // method event handler untuk merespon event OnUpdate,
        public void OnUpdateEventHandler(Buku bk)
        {
            // ambil index data mhs yang edit
            int index = lvwBuku.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwBuku.Items[index];
            itemRow.SubItems[1].Text = bk.kode_buku;
            itemRow.SubItems[2].Text = bk.judul_buku;
            itemRow.SubItems[3].Text = bk.penulis_buku;
            itemRow.SubItems[4].Text = bk.penerbit_buku;
            itemRow.SubItems[5].Text = bk.tahun_terbit;
            itemRow.SubItems[6].Text = bk.stok;

            OnUpdate?.Invoke(bk);
        }


        private void btnTambah_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek buku
            if (isNewData)
            {
                bk = new Buku();
            }

            // Pastikan objek buku tidak bernilai null sebelum mengakses propertinya
            if (bk != null)
            {
                // set nilai property objek buku yang diambil dari TextBox
                bk.kode_buku = txtBuku.Text;
                bk.judul_buku = txtJudul.Text;
                bk.penulis_buku = txtPenulis.Text;
                bk.penerbit_buku = txtPenerbit.Text;
                bk.tahun_terbit = txtTerbit.Text;
                bk.stok = txtStok.Text;

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
                        txtJudul.Clear();
                        txtPenulis.Clear();
                        txtPenerbit.Clear();
                        txtTerbit.Clear();
                        txtStok.Clear();

                        txtBuku.Focus();
                    }
                }
                else // edit data, panggil method Update
                {
                    // panggil operasi CRUD
                    result = controller.Update(bk);

                    if (result > 0)
                    {
                        OnUpdateEventHandler(bk); // panggil event OnUpdate
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Buku Berhasil di update.", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void HandleCreateEvent(Buku bk)
        {
            // Lakukan sesuatu ketika event OnCreate terjadi
            // Misalnya, tambahkan buku ke koleksi atau lakukan tindakan lain yang diinginkan
            Console.WriteLine($"Buku baru ditambahkan: {bk.judul_buku}");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            // Pastikan ada item yang terpilih
            if (lvwBuku.SelectedItems.Count > 0)
            {
                // Ambil objek buku yang mau diedit dari collection
                Buku bk = listOfBuku[lvwBuku.SelectedIndices[0]];

                // Pastikan objek buku yang diambil tidak bernilai null
                if (bk != null)
                {
                    txtBuku.Text = bk.kode_buku;
                    txtJudul.Text = bk.judul_buku;
                    txtPenulis.Text = bk.penulis_buku;
                    txtPenerbit.Text = bk.penerbit_buku;
                    txtTerbit.Text = bk.tahun_terbit;
                    txtStok.Text = bk.stok;

                    isNewData = false; // Set status ke edit data
                }
                else
                {
                    MessageBox.Show("Objek buku bernilai null.", "Peringatan",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Pilih satu item terlebih dahulu untuk diedit.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmBuku_OnUpdate(Buku bk)
        {
            throw new NotImplementedException();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBuku.Clear();
            txtJudul.Clear();
            txtPenulis.Clear();
            txtPenerbit.Clear();
            txtTerbit.Clear();
            txtStok.Clear();

            txtBuku.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lvwBuku.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Buku ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Buku bk = listOfBuku[lvwBuku.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(bk);
                    if (result > 0) LoadDataBuku();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data buku belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwBuku.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfBuku = controller.ReadByJudul (txtSearch.Text);

            // ekstrak objek mhs dari collection
            foreach (var bk in listOfBuku)
            {
                var noUrut = lvwBuku.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bk.kode_buku);
                item.SubItems.Add(bk.judul_buku);
                item.SubItems.Add(bk.penulis_buku);
                item.SubItems.Add(bk.penerbit_buku);
                item.SubItems.Add(bk.tahun_terbit);
                item.SubItems.Add(bk.stok);

                // tampilkan data mhs ke listview
                lvwBuku.Items.Add(item);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
