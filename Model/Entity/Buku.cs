using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perpustakaan.Model.Entity
{
    public class Buku
    {
        public string kode_buku { get; set; }
        public string judul_buku { get; set; }
        public string penulis_buku { get; set; }
        public string penerbit_buku { get; set; }
        public string tahun_terbit { get; set; }
        public string stok { get; set; }
    }
}
