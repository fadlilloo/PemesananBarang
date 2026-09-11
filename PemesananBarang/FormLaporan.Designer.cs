
namespace PemesananBarang
{
    partial class FormLaporan
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
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblTanggalAwal = new System.Windows.Forms.Label();
            this.dtpTanggalAwal = new System.Windows.Forms.DateTimePicker();
            this.lblSampai = new System.Windows.Forms.Label();
            this.lblTanggalAkhir = new System.Windows.Forms.Label();
            this.dtpTanggalAkhir = new System.Windows.Forms.DateTimePicker();
            this.btnTampilkan = new System.Windows.Forms.Button();
            this.btnKembali = new System.Windows.Forms.Button();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Location = new System.Drawing.Point(282, 74);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(134, 13);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "LAPORAN PEMESANAN  ";
            // 
            // lblTanggalAwal
            // 
            this.lblTanggalAwal.AutoSize = true;
            this.lblTanggalAwal.Location = new System.Drawing.Point(92, 123);
            this.lblTanggalAwal.Name = "lblTanggalAwal";
            this.lblTanggalAwal.Size = new System.Drawing.Size(72, 13);
            this.lblTanggalAwal.TabIndex = 1;
            this.lblTanggalAwal.Text = "Tanggal Awal";
            // 
            // dtpTanggalAwal
            // 
            this.dtpTanggalAwal.Location = new System.Drawing.Point(61, 155);
            this.dtpTanggalAwal.Name = "dtpTanggalAwal";
            this.dtpTanggalAwal.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalAwal.TabIndex = 9;
            this.dtpTanggalAwal.ValueChanged += new System.EventHandler(this.dtpTanggalAwal_ValueChanged_1);
            // 
            // lblSampai
            // 
            this.lblSampai.AutoSize = true;
            this.lblSampai.Location = new System.Drawing.Point(333, 123);
            this.lblSampai.Name = "lblSampai";
            this.lblSampai.Size = new System.Drawing.Size(23, 13);
            this.lblSampai.TabIndex = 3;
            this.lblSampai.Text = "s/d";
            // 
            // lblTanggalAkhir
            // 
            this.lblTanggalAkhir.AutoSize = true;
            this.lblTanggalAkhir.Location = new System.Drawing.Point(453, 123);
            this.lblTanggalAkhir.Name = "lblTanggalAkhir";
            this.lblTanggalAkhir.Size = new System.Drawing.Size(73, 13);
            this.lblTanggalAkhir.TabIndex = 4;
            this.lblTanggalAkhir.Text = "Tanggal Akhir";
            // 
            // dtpTanggalAkhir
            // 
            this.dtpTanggalAkhir.Location = new System.Drawing.Point(415, 155);
            this.dtpTanggalAkhir.Name = "dtpTanggalAkhir";
            this.dtpTanggalAkhir.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggalAkhir.TabIndex = 5;
            this.dtpTanggalAkhir.ValueChanged += new System.EventHandler(this.dtpTanggalAkhir_ValueChanged);
            // 
            // btnTampilkan
            // 
            this.btnTampilkan.Location = new System.Drawing.Point(261, 219);
            this.btnTampilkan.Name = "btnTampilkan";
            this.btnTampilkan.Size = new System.Drawing.Size(155, 23);
            this.btnTampilkan.TabIndex = 6;
            this.btnTampilkan.Text = "TAMPILKAN LAPORAN";
            this.btnTampilkan.UseVisualStyleBackColor = true;
            this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click_1);
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(261, 429);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(155, 23);
            this.btnKembali.TabIndex = 8;
            this.btnKembali.Text = "KEMBALI";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click_1);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(0, 275);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.Size = new System.Drawing.Size(788, 130);
            this.dgvLaporan.TabIndex = 10;
            this.dgvLaporan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaporan_CellContentClick);
            // 
            // FormLaporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.btnTampilkan);
            this.Controls.Add(this.dtpTanggalAkhir);
            this.Controls.Add(this.lblTanggalAkhir);
            this.Controls.Add(this.lblSampai);
            this.Controls.Add(this.dtpTanggalAwal);
            this.Controls.Add(this.lblTanggalAwal);
            this.Controls.Add(this.lblJudul);
            this.Name = "FormLaporan";
            this.Text = "FormLaporan";
            this.Load += new System.EventHandler(this.FormLaporan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblTanggalAwal;
        private System.Windows.Forms.DateTimePicker dtpTanggalAwal;
        private System.Windows.Forms.Label lblSampai;
        private System.Windows.Forms.Label lblTanggalAkhir;
        private System.Windows.Forms.DateTimePicker dtpTanggalAkhir;
        private System.Windows.Forms.Button btnTampilkan;
        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.DataGridView dgvLaporan;
    }
}