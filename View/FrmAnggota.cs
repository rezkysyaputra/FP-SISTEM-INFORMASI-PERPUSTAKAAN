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
    public partial class FrmAnggota : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Anggota ag);

        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;

        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;

        // deklarasi field untuk menyimpan status entry data (input baru atau update)
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek mahasiswa
        private Anggota ag;

        // deklarasi objek collection untuk menampung objek mahasiswa
        private List<Anggota> listOfAnggota = new List<Anggota>();

        // deklarasi objek controller
        private AnggotaController controller;
        public FrmAnggota()
        {
            InitializeComponent();
            // membuat objek controller
            controller = new AnggotaController();

            InisialisasiListView();
            LoadDataAnggota();
        }

        // atur kolom listview
        private void InisialisasiListView()
        {
            lvwAnggota.View = System.Windows.Forms.View.Details;
            lvwAnggota.FullRowSelect = true;
            lvwAnggota.GridLines = true;

            lvwAnggota.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvwAnggota.Columns.Add("Kode", 90, HorizontalAlignment.Center);
            lvwAnggota.Columns.Add("Nama", 180, HorizontalAlignment.Center);
            lvwAnggota.Columns.Add("Jenis Kelamin", 90, HorizontalAlignment.Center);
            lvwAnggota.Columns.Add("Jurusan", 150, HorizontalAlignment.Center);
            lvwAnggota.Columns.Add("Telepon", 150, HorizontalAlignment.Center);
            lvwAnggota.Columns.Add("Alamat", 200, HorizontalAlignment.Center);
        }

        // method untuk menampilkan semua data mahasiswa
        private void LoadDataAnggota()
        {
            // kosongkan listview
            lvwAnggota.Items.Clear();

            // panggil method ReadAll dan tampung datanya ke dalam collection
            listOfAnggota = controller.ReadAll();

            // ekstrak objek mhs dari collection
            foreach (var ag in listOfAnggota)
            {
                var noUrut = lvwAnggota.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(ag.kode_anggota);
                item.SubItems.Add(ag.nama_anggota);
                item.SubItems.Add(ag.jk_anggota);
                item.SubItems.Add(ag.jurusan_anggota);
                item.SubItems.Add(ag.no_telp_anggota);
                item.SubItems.Add(ag.alamat_anggota);

                // tampilkan data mhs ke listview
                lvwAnggota.Items.Add(item);
            }
        }

        // method event handler untuk merespon event OnCreate,
        private void OnCreateEventHandler(Anggota ag)
        {
            // tambahkan objek mhs yang baru ke dalam collection
            listOfAnggota.Add(ag);

            int noUrut = lvwAnggota.Items.Count + 1;

            // tampilkan data mhs yg baru ke list view
            ListViewItem item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(ag.kode_anggota);
            item.SubItems.Add(ag.nama_anggota);
            item.SubItems.Add(ag.jk_anggota);
            item.SubItems.Add(ag.jurusan_anggota);
            item.SubItems.Add(ag.no_telp_anggota);
            item.SubItems.Add(ag.alamat_anggota);

            lvwAnggota.Items.Add(item);

            // Memanggil event OnCreate
            OnCreate?.Invoke(ag);
        }

        // method event handler untuk merespon event OnUpdate,
        public void OnUpdateEventHandler(Anggota ag)
        {
            // ambil index data mhs yang edit
            int index = lvwAnggota.SelectedIndices[0];

            // update informasi mhs di listview
            ListViewItem itemRow = lvwAnggota.Items[index];
            itemRow.SubItems[1].Text = ag.kode_anggota;
            itemRow.SubItems[2].Text = ag.nama_anggota;
            itemRow.SubItems[3].Text = ag.jk_anggota;
            itemRow.SubItems[4].Text = ag.jurusan_anggota;
            itemRow.SubItems[5].Text = ag.no_telp_anggota;
            itemRow.SubItems[6].Text = ag.alamat_anggota;

            OnUpdate?.Invoke(ag);
        }

        private void lvwAnggota_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmAnggota_Load(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            // jika data baru, inisialisasi objek buku
            if (isNewData)
            {
                ag = new Anggota();
            }

            // Pastikan objek buku tidak bernilai null sebelum mengakses propertinya
            if (ag != null)
            {
                // set nilai property objek buku yang diambil dari TextBox
                ag.kode_anggota= txtAnggota.Text;
                ag.nama_anggota = txtNama.Text;
                ag.jk_anggota= txtKelamin.Text;
                ag.jurusan_anggota = txtJurusan.Text;
                ag.no_telp_anggota= txtPhone.Text;
                ag.alamat_anggota = txtAlamat.Text;

                int result = 0;

                if (isNewData) // tambah data baru, panggil method Create
                {
                    // panggil operasi CRUD
                    result = controller.Create(ag);

                    if (result > 0) // tambah data berhasil
                    {
                        OnCreateEventHandler(ag); // panggil event OnCreate

                        // reset form input, utk persiapan input data berikutnya
                        txtAnggota.Clear();
                        txtAlamat.Clear();
                        txtJurusan.Clear();
                        txtNama.Clear();
                        txtPhone.Clear();
                        txtNama.Clear();

                        txtAnggota.Focus();
                    }
                }
                else // edit data, panggil method Update
                {
                    // panggil operasi CRUD
                    result = controller.Update(ag);

                    if (result > 0)
                    {
                        OnUpdateEventHandler(ag); // panggil event OnUpdate
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Pastikan ada item yang terpilih
            if (lvwAnggota.SelectedItems.Count > 0)
            {
                // Ambil objek buku yang mau diedit dari collection
                Anggota ag = listOfAnggota[lvwAnggota.SelectedIndices[0]];

                // Pastikan objek buku yang diambil tidak bernilai null
                if (ag != null)
                {
                    txtAnggota.Text = ag.kode_anggota;
                    txtNama.Text = ag.nama_anggota;
                    txtKelamin.Text = ag.jk_anggota;
                    txtJurusan.Text = ag.jurusan_anggota;
                    txtPhone.Text = ag.no_telp_anggota;
                    txtAlamat.Text = ag.alamat_anggota;

                    isNewData = false; // Set status ke edit data
                }
                else
                {
                    MessageBox.Show("Objek Anggota bernilai null.", "Peringatan",
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Pilih satu item terlebih dahulu untuk diedit.", "Peringatan",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAlamat.Clear();
            txtAnggota.Clear();
            txtJurusan.Clear();
            txtKelamin.Clear();
            txtNama.Clear();
            txtPhone.Clear();

            txtAnggota.Focus();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwAnggota.SelectedItems.Count > 0)
            {
                var konfirmasi = MessageBox.Show("Apakah data Anggota ingin dihapus?", "Konfirmasi",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (konfirmasi == DialogResult.Yes)
                {
                    // ambil objek mhs yang mau dihapus dari collection
                    Anggota ag= listOfAnggota[lvwAnggota.SelectedIndices[0]];

                    // panggil operasi CRUD
                    var result = controller.Delete(ag);
                    if (result > 0) LoadDataAnggota();
                }
            }
            else // data belum dipilih
            {
                MessageBox.Show("Data Anggota belum dipilih !!!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // kosongkan listview
            lvwAnggota.Items.Clear();

            // panggil method ReadByNama dan tampung datanya ke dalam collection
            listOfAnggota = controller.ReadByNama(txtSearch.Text);

            // ekstrak objek mhs dari collection
            foreach (var bk in listOfAnggota)
            {
                var noUrut = lvwAnggota.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(bk.kode_anggota);
                item.SubItems.Add(bk.nama_anggota);
                item.SubItems.Add(bk.jk_anggota);
                item.SubItems.Add(bk.jurusan_anggota);
                item.SubItems.Add(bk.no_telp_anggota);
                item.SubItems.Add(bk.alamat_anggota);

                // tampilkan data mhs ke listview
                lvwAnggota.Items.Add(item);
            }
        }
    }
}
