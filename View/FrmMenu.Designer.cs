namespace Perpustakaan
{
    partial class FrmMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuAnggota = new System.Windows.Forms.Button();
            this.menuPeminjaman = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.mnuBuku = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(784, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU";
            // 
            // menuAnggota
            // 
            this.menuAnggota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuAnggota.BackColor = System.Drawing.Color.DarkTurquoise;
            this.menuAnggota.Font = new System.Drawing.Font("New Athletic M54", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuAnggota.ForeColor = System.Drawing.Color.White;
            this.menuAnggota.Location = new System.Drawing.Point(595, 316);
            this.menuAnggota.Name = "menuAnggota";
            this.menuAnggota.Size = new System.Drawing.Size(557, 71);
            this.menuAnggota.TabIndex = 2;
            this.menuAnggota.Text = "ANGGOTA";
            this.menuAnggota.UseVisualStyleBackColor = false;
            this.menuAnggota.Click += new System.EventHandler(this.menuAnggota_Click);
            // 
            // menuPeminjaman
            // 
            this.menuPeminjaman.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuPeminjaman.BackColor = System.Drawing.Color.Orange;
            this.menuPeminjaman.Font = new System.Drawing.Font("New Athletic M54", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuPeminjaman.ForeColor = System.Drawing.Color.White;
            this.menuPeminjaman.Location = new System.Drawing.Point(595, 393);
            this.menuPeminjaman.Name = "menuPeminjaman";
            this.menuPeminjaman.Size = new System.Drawing.Size(557, 71);
            this.menuPeminjaman.TabIndex = 3;
            this.menuPeminjaman.Text = "TRANSAKSI";
            this.menuPeminjaman.UseVisualStyleBackColor = false;
            this.menuPeminjaman.Click += new System.EventHandler(this.menuPeminjaman_Click);
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.Tomato;
            this.button5.Font = new System.Drawing.Font("New Athletic M54", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(595, 625);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(557, 71);
            this.button5.TabIndex = 5;
            this.button5.Text = "KELUAR";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // mnuBuku
            // 
            this.mnuBuku.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mnuBuku.BackColor = System.Drawing.Color.LimeGreen;
            this.mnuBuku.Font = new System.Drawing.Font("New Athletic M54", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBuku.ForeColor = System.Drawing.Color.White;
            this.mnuBuku.Location = new System.Drawing.Point(595, 239);
            this.mnuBuku.Name = "mnuBuku";
            this.mnuBuku.Size = new System.Drawing.Size(557, 71);
            this.mnuBuku.TabIndex = 6;
            this.mnuBuku.Text = "BUKU";
            this.mnuBuku.UseVisualStyleBackColor = false;
            this.mnuBuku.Click += new System.EventHandler(this.menu_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLaporan.BackColor = System.Drawing.Color.DimGray;
            this.btnLaporan.Font = new System.Drawing.Font("New Athletic M54", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporan.ForeColor = System.Drawing.Color.White;
            this.btnLaporan.Location = new System.Drawing.Point(595, 470);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(557, 71);
            this.btnLaporan.TabIndex = 7;
            this.btnLaporan.Text = "LAPORAN";
            this.btnLaporan.UseVisualStyleBackColor = false;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1853, 919);
            this.Controls.Add(this.btnLaporan);
            this.Controls.Add(this.mnuBuku);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.menuPeminjaman);
            this.Controls.Add(this.menuAnggota);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Lime;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button menuBuku;
        private System.Windows.Forms.Button menuAnggota;
        private System.Windows.Forms.Button menuPeminjaman;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button mnuBuku;
        private System.Windows.Forms.Button btnLaporan;
    }
}