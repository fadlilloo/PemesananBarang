
namespace PemesananBarang
{
    partial class FormPemesanan
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
            this.cmbBarang = new System.Windows.Forms.ComboBox();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.numJumlah = new System.Windows.Forms.NumericUpDown();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.txtNamaPemesan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbUpdateStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.dgvPesanan = new System.Windows.Forms.DataGridView();
            this.lblDataPesanan = new System.Windows.Forms.Label();
            this.btnHapusPesanan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesanan)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBarang
            // 
            this.cmbBarang.FormattingEnabled = true;
            this.cmbBarang.Location = new System.Drawing.Point(73, 104);
            this.cmbBarang.Name = "cmbBarang";
            this.cmbBarang.Size = new System.Drawing.Size(182, 21);
            this.cmbBarang.TabIndex = 1;
            this.cmbBarang.SelectedIndexChanged += new System.EventHandler(this.cmbBarang_SelectedIndexChanged);
            // 
            // txtHarga
            // 
            this.txtHarga.Location = new System.Drawing.Point(73, 155);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(182, 20);
            this.txtHarga.TabIndex = 2;
            // 
            // numJumlah
            // 
            this.numJumlah.Location = new System.Drawing.Point(288, 156);
            this.numJumlah.Name = "numJumlah";
            this.numJumlah.Size = new System.Drawing.Size(130, 20);
            this.numJumlah.TabIndex = 3;
            this.numJumlah.ValueChanged += new System.EventHandler(this.numJumlah_ValueChanged);
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(73, 202);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(182, 20);
            this.txtSubtotal.TabIndex = 4;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Location = new System.Drawing.Point(73, 301);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(182, 24);
            this.btnSimpan.TabIndex = 5;
            this.btnSimpan.Text = " SIMPAN PESANAN";
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // txtNamaPemesan
            // 
            this.txtNamaPemesan.Location = new System.Drawing.Point(73, 52);
            this.txtNamaPemesan.Name = "txtNamaPemesan";
            this.txtNamaPemesan.Size = new System.Drawing.Size(182, 20);
            this.txtNamaPemesan.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nama Pemesanan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Harga Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Jumlah Barang";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Subtotal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Status Pesanan";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(73, 250);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(182, 21);
            this.cmbStatus.TabIndex = 15;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnBatal
            // 
            this.btnBatal.Location = new System.Drawing.Point(263, 301);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(155, 24);
            this.btnBatal.TabIndex = 16;
            this.btnBatal.Text = "BATAL / RESET";
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(252, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "FORM PEMESANAN BARANG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Pilih Barang";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(405, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "PILIH BARANG";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(29, 367);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 13);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Ubah Status";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // cmbUpdateStatus
            // 
            this.cmbUpdateStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUpdateStatus.FormattingEnabled = true;
            this.cmbUpdateStatus.Items.AddRange(new object[] {
            "Menunggu",
            "",
            "Diproses",
            "",
            "Selesai"});
            this.cmbUpdateStatus.Location = new System.Drawing.Point(116, 364);
            this.cmbUpdateStatus.Name = "cmbUpdateStatus";
            this.cmbUpdateStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbUpdateStatus.TabIndex = 20;
            this.cmbUpdateStatus.SelectedIndexChanged += new System.EventHandler(this.cmbUpdateStatus_SelectedIndexChanged);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(255, 364);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(168, 23);
            this.btnUpdateStatus.TabIndex = 21;
            this.btnUpdateStatus.Text = "UPDATE STATUS";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // dgvPesanan
            // 
            this.dgvPesanan.AllowUserToAddRows = false;
            this.dgvPesanan.AllowUserToDeleteRows = false;
            this.dgvPesanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesanan.Location = new System.Drawing.Point(452, 104);
            this.dgvPesanan.MultiSelect = false;
            this.dgvPesanan.Name = "dgvPesanan";
            this.dgvPesanan.ReadOnly = true;
            this.dgvPesanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesanan.Size = new System.Drawing.Size(562, 221);
            this.dgvPesanan.TabIndex = 22;
            this.dgvPesanan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPesanan_CellContentClick);
            // 
            // lblDataPesanan
            // 
            this.lblDataPesanan.AutoSize = true;
            this.lblDataPesanan.Location = new System.Drawing.Point(571, 68);
            this.lblDataPesanan.Name = "lblDataPesanan";
            this.lblDataPesanan.Size = new System.Drawing.Size(90, 13);
            this.lblDataPesanan.TabIndex = 23;
            this.lblDataPesanan.Text = "DATA PESANAN";
            // 
            // btnHapusPesanan
            // 
            this.btnHapusPesanan.Location = new System.Drawing.Point(255, 393);
            this.btnHapusPesanan.Name = "btnHapusPesanan";
            this.btnHapusPesanan.Size = new System.Drawing.Size(168, 23);
            this.btnHapusPesanan.TabIndex = 24;
            this.btnHapusPesanan.Text = "HAPUS PESANAN";
            this.btnHapusPesanan.UseVisualStyleBackColor = true;
            this.btnHapusPesanan.Click += new System.EventHandler(this.btnHapusPesanan_Click);
            // 
            // FormPemesanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 543);
            this.Controls.Add(this.btnHapusPesanan);
            this.Controls.Add(this.lblDataPesanan);
            this.Controls.Add(this.dgvPesanan);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.cmbUpdateStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNamaPemesan);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.numJumlah);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.cmbBarang);
            this.Controls.Add(this.label10);
            this.Name = "FormPemesanan";
            this.Text = "FormPemesanan";
            this.Load += new System.EventHandler(this.FormPemesanan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numJumlah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbBarang;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.NumericUpDown numJumlah;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.TextBox txtNamaPemesan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbUpdateStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.DataGridView dgvPesanan;
        private System.Windows.Forms.Label lblDataPesanan;
        private System.Windows.Forms.Button btnHapusPesanan;
    }
}