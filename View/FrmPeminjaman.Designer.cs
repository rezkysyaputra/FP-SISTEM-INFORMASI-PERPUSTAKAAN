namespace Perpustakaan
{
    partial class FrmPeminjaman
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvwPeminjaman = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuku = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnggota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPinjam = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.txtPinjam = new System.Windows.Forms.DateTimePicker();
            this.btnKembali = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("New Athletic M54", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(118, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(205, 47);
            this.label8.TabIndex = 62;
            this.label8.Text = "TRANSAKSI";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(489, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 20);
            this.label7.TabIndex = 61;
            this.label7.Text = "[ DAFTAR TRANSAKSI ]";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnReset.Location = new System.Drawing.Point(263, 425);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(152, 47);
            this.btnReset.TabIndex = 58;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lvwPeminjaman
            // 
            this.lvwPeminjaman.HideSelection = false;
            this.lvwPeminjaman.Location = new System.Drawing.Point(493, 153);
            this.lvwPeminjaman.Name = "lvwPeminjaman";
            this.lvwPeminjaman.Size = new System.Drawing.Size(874, 565);
            this.lvwPeminjaman.TabIndex = 57;
            this.lvwPeminjaman.UseCompatibleStateImageBehavior = false;
            this.lvwPeminjaman.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Russo One", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(39, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 23);
            this.label3.TabIndex = 49;
            this.label3.Text = "Tanggal Pinjam :";
            // 
            // txtBuku
            // 
            this.txtBuku.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtBuku.Location = new System.Drawing.Point(216, 246);
            this.txtBuku.Name = "txtBuku";
            this.txtBuku.Size = new System.Drawing.Size(236, 30);
            this.txtBuku.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Russo One", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 47;
            this.label2.Text = "Kode Buku :";
            // 
            // txtAnggota
            // 
            this.txtAnggota.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAnggota.Location = new System.Drawing.Point(216, 190);
            this.txtAnggota.Name = "txtAnggota";
            this.txtAnggota.Size = new System.Drawing.Size(236, 30);
            this.txtAnggota.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Russo One", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 23);
            this.label1.TabIndex = 45;
            this.label1.Text = "Kode Anggota :";
            // 
            // btnPinjam
            // 
            this.btnPinjam.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPinjam.Location = new System.Drawing.Point(84, 425);
            this.btnPinjam.Name = "btnPinjam";
            this.btnPinjam.Size = new System.Drawing.Size(152, 47);
            this.btnPinjam.TabIndex = 43;
            this.btnPinjam.Text = "Pinjam";
            this.btnPinjam.UseVisualStyleBackColor = false;
            this.btnPinjam.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Tomato;
            this.btnHapus.Location = new System.Drawing.Point(490, 76);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(156, 53);
            this.btnHapus.TabIndex = 85;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // txtPinjam
            // 
            this.txtPinjam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPinjam.Location = new System.Drawing.Point(216, 302);
            this.txtPinjam.Name = "txtPinjam";
            this.txtPinjam.Size = new System.Drawing.Size(236, 30);
            this.txtPinjam.TabIndex = 63;
            // 
            // btnKembali
            // 
            this.btnKembali.BackColor = System.Drawing.Color.LimeGreen;
            this.btnKembali.Location = new System.Drawing.Point(676, 76);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(156, 53);
            this.btnKembali.TabIndex = 86;
            this.btnKembali.Text = "Kembalikan Buku";
            this.btnKembali.UseVisualStyleBackColor = false;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // FrmPeminjaman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(1384, 746);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.txtPinjam);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lvwPeminjaman);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuku);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAnggota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPinjam);
            this.Name = "FrmPeminjaman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaksi";
            this.Load += new System.EventHandler(this.FrmPeminjaman_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvwPeminjaman;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuku;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnggota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPinjam;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DateTimePicker txtPinjam;
        private System.Windows.Forms.Button btnKembali;
    }
}