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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void menu_Click(object sender, EventArgs e)
        {
            //button1_Click
            FrmBuku frmBuku = new FrmBuku();
            frmBuku.OnCreate += HandleCreateEvent;
            frmBuku.OnUpdate += HandleCreateEvent;

            frmBuku.ShowDialog();
        }
        private void HandleCreateEvent(Buku bk)
        {
            // Lakukan sesuatu ketika event OnCreate terjadi
            // Misalnya, tambahkan buku ke koleksi atau lakukan tindakan lain yang diinginkan
            Console.WriteLine($"Buku baru ditambahkan: {bk.judul_buku}");
        }
        private void HandleCreateEventAnggota(Anggota ag)
        {
            // Lakukan sesuatu ketika event OnCreate terjadi
            // Misalnya, tambahkan buku ke koleksi atau lakukan tindakan lain yang diinginkan
            Console.WriteLine($"Buku baru ditambahkan: {ag.nama_anggota}");
        }

        private void HandleCreateEventPeminjaman(Peminjaman ag)
        {
            // Lakukan sesuatu ketika event OnCreate terjadi
            // Misalnya, tambahkan buku ke koleksi atau lakukan tindakan lain yang diinginkan
            Console.WriteLine($"Buku baru ditambahkan: {ag.kode_buku}");
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void menuAnggota_Click(object sender, EventArgs e)
        {
            //button1_Click
            FrmAnggota frmAnggota = new FrmAnggota();
            frmAnggota.OnCreate += HandleCreateEventAnggota;
            frmAnggota.OnUpdate += HandleCreateEventAnggota;

            frmAnggota.ShowDialog();
        }

        private void menuPeminjaman_Click(object sender, EventArgs e)
        {
            FrmPeminjaman frmPeminjaman = new FrmPeminjaman();
            frmPeminjaman.OnCreate += HandleCreateEventPeminjaman;
            frmPeminjaman.OnUpdate += HandleCreateEventPeminjaman;

            frmPeminjaman.ShowDialog();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FrmLaporan frmLaporan = new FrmLaporan();

            frmLaporan.ShowDialog();
        }
    }
}
