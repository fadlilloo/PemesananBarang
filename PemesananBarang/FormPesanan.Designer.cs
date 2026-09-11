
namespace PemesananBarang
{
    partial class FormPesanan
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
            this.lblCari = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.dgvPesanan = new System.Windows.Forms.DataGridView();
            this.btnKembali = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesanan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Location = new System.Drawing.Point(321, 40);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(90, 13);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "DATA PESANAN";
            this.lblJudul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCari
            // 
            this.lblCari.AutoSize = true;
            this.lblCari.Location = new System.Drawing.Point(134, 92);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(70, 13);
            this.lblCari.TabIndex = 1;
            this.lblCari.Text = "Cari Pesanan";
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(137, 119);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(187, 20);
            this.txtCari.TabIndex = 2;
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(336, 119);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 23);
            this.btnCari.TabIndex = 3;
            this.btnCari.Text = "CARI";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click_1);
            // 
            // dgvPesanan
            // 
            this.dgvPesanan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPesanan.Location = new System.Drawing.Point(0, 212);
            this.dgvPesanan.MultiSelect = false;
            this.dgvPesanan.Name = "dgvPesanan";
            this.dgvPesanan.ReadOnly = true;
            this.dgvPesanan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPesanan.Size = new System.Drawing.Size(804, 150);
            this.dgvPesanan.TabIndex = 4;
            // 
            // btnKembali
            // 
            this.btnKembali.Location = new System.Drawing.Point(430, 119);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(155, 23);
            this.btnKembali.TabIndex = 26;
            this.btnKembali.Text = "KEMBALI";
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // FormPesanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKembali);
            this.Controls.Add(this.dgvPesanan);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.lblCari);
            this.Controls.Add(this.lblJudul);
            this.Name = "FormPesanan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA PESANAN";
            this.Load += new System.EventHandler(this.FormPesanan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPesanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblCari;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.DataGridView dgvPesanan;
        private System.Windows.Forms.Button btnKembali;
    }
}