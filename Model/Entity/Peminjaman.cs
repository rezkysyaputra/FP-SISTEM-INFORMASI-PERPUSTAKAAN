using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perpustakaan.Model.Entity
{
    public class Peminjaman
    {
        public string kode_anggota { get; set; }
        public string kode_buku { get; set; }
        public string tanggal_pinjam { get; set; }
    }
}
