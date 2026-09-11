using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PemesananBarang
{
    public partial class FormLaporan : Form
    {
        public FormLaporan()
        {
            InitializeComponent();

            AturDataGridView();
        }

        // =====================================================
        // ATUR DATAGRIDVIEW
        // =====================================================
        private void AturDataGridView()
        {




            dgvLaporan.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvLaporan.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvLaporan.MultiSelect = false;

            dgvLaporan.ReadOnly = true;

            dgvLaporan.AllowUserToAddRows = false;

            dgvLaporan.AllowUserToDeleteRows = false;

            dgvLaporan.AllowUserToResizeRows = false;

            dgvLaporan.RowHeadersVisible = false;

            dgvLaporan.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvLaporan.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvLaporan.RowTemplate.Height = 30;

            dgvLaporan.AutoGenerateColumns = true;
        }

        // =====================================================
        // SAAT FORM LAPORAN DIBUKA
        // =====================================================
        private void FormLaporan_Load(object sender, EventArgs e)
        {
            dtpTanggalAwal.Value = DateTime.Today;

            dtpTanggalAkhir.Value = DateTime.Today;

            dgvLaporan.DataSource = null;
        }

        // =====================================================
        // TANGGAL AWAL BERUBAH
        // =====================================================
        private void dtpTanggalAwal_ValueChanged_1(
            object sender,
            EventArgs e)
        {
            if (dtpTanggalAwal.Value.Date >
                dtpTanggalAkhir.Value.Date)
            {
                dtpTanggalAkhir.Value =
                    dtpTanggalAwal.Value;
            }
        }

        // =====================================================
        // TANGGAL AKHIR BERUBAH
        // =====================================================
        private void dtpTanggalAkhir_ValueChanged(
            object sender,
            EventArgs e)
        {
            if (dtpTanggalAkhir.Value.Date <
                dtpTanggalAwal.Value.Date)
            {
                MessageBox.Show(
                    "Tanggal akhir tidak boleh lebih kecil dari tanggal awal.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                dtpTanggalAkhir.Value =
                    dtpTanggalAwal.Value;
            }
        }

        // =====================================================
        // TOMBOL TAMPILKAN LAPORAN
        // =====================================================
        private void btnTampilkan_Click_1(
    object sender,
    EventArgs e)
        {
            DateTime tanggalAwal =
                dtpTanggalAwal.Value.Date;

            DateTime tanggalAkhir =
                dtpTanggalAkhir.Value.Date;

            // =============================================
            // VALIDASI TANGGAL
            // =============================================
            if (tanggalAkhir < tanggalAwal)
            {
                MessageBox.Show(
                    "Tanggal akhir tidak boleh lebih kecil dari tanggal awal.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MySqlConnection connection = null;

            try
            {
                // =============================================
                // KONEKSI DATABASE
                // =============================================
                connection = Koneksi.GetConnection();
                connection.Open();

                // =============================================
                // QUERY LAPORAN
                // TIDAK MENAMPILKAN ID PESANAN
                // =============================================
                string query = @"
            SELECT
                p.tanggal_pesanan AS 'Tanggal Pesanan',
                p.nama_pemesan AS 'Nama Pemesan',
                b.nama_barang AS 'Nama Barang',
                dp.jumlah AS 'Jumlah',
                dp.harga AS 'Harga',
                dp.subtotal AS 'Subtotal',
                p.total_harga AS 'Total Harga',
                p.status AS 'Status'
            FROM pesanan p
            INNER JOIN detail_pesanan dp
                ON p.id_pesanan = dp.id_pesanan
            INNER JOIN barang b
                ON dp.id_barang = b.id_barang
            WHERE p.tanggal_pesanan >= @tanggalAwal
              AND p.tanggal_pesanan < DATE_ADD(
                    @tanggalAkhir,
                    INTERVAL 1 DAY
              )
            ORDER BY
                p.tanggal_pesanan ASC,
                p.id_pesanan ASC
        ";

                MySqlCommand command =
                    new MySqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@tanggalAwal",
                    tanggalAwal
                );

                command.Parameters.AddWithValue(
                    "@tanggalAkhir",
                    tanggalAkhir
                );

                // =============================================
                // AMBIL DATA
                // =============================================
                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(command);

                DataTable table =
                    new DataTable();

                adapter.Fill(table);

                // =============================================
                // TAMPILKAN DATA KE DGV
                // =============================================
                dgvLaporan.DataSource = null;
                dgvLaporan.Columns.Clear();

                dgvLaporan.DataSource = table;

                // =============================================
                // TAMBAHKAN KOLOM NO
                // =============================================
                if (dgvLaporan.Columns.Contains("No"))
                {
                    dgvLaporan.Columns.Remove("No");
                }

                DataGridViewTextBoxColumn kolomNo =
                    new DataGridViewTextBoxColumn();

                kolomNo.Name = "No";
                kolomNo.HeaderText = "No";
                kolomNo.ReadOnly = true;

                dgvLaporan.Columns.Insert(0, kolomNo);

                // =============================================
                // ISI NOMOR URUT 1, 2, 3, ...
                // =============================================
                for (int i = 0; i < dgvLaporan.Rows.Count; i++)
                {
                    if (!dgvLaporan.Rows[i].IsNewRow)
                    {
                        dgvLaporan.Rows[i].Cells["No"].Value =
                            i + 1;
                    }
                }

                // =============================================
                // FORMAT DATAGRIDVIEW
                // =============================================
                dgvLaporan.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvLaporan.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvLaporan.MultiSelect = false;

                dgvLaporan.ReadOnly = true;

                dgvLaporan.AllowUserToAddRows = false;

                dgvLaporan.AllowUserToDeleteRows = false;

                dgvLaporan.AllowUserToResizeRows = false;

                dgvLaporan.RowHeadersVisible = false;

                dgvLaporan.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvLaporan.RowTemplate.Height = 30;

                // =============================================
                // LEBAR KOLOM
                // =============================================
                if (dgvLaporan.Columns.Contains("No"))
                {
                    dgvLaporan.Columns["No"].FillWeight = 40;
                }

                if (dgvLaporan.Columns.Contains("Tanggal Pesanan"))
                {
                    dgvLaporan.Columns["Tanggal Pesanan"].FillWeight = 100;
                }

                if (dgvLaporan.Columns.Contains("Nama Pemesan"))
                {
                    dgvLaporan.Columns["Nama Pemesan"].FillWeight = 120;
                }

                if (dgvLaporan.Columns.Contains("Nama Barang"))
                {
                    dgvLaporan.Columns["Nama Barang"].FillWeight = 130;
                }

                if (dgvLaporan.Columns.Contains("Jumlah"))
                {
                    dgvLaporan.Columns["Jumlah"].FillWeight = 60;
                }

                if (dgvLaporan.Columns.Contains("Harga"))
                {
                    dgvLaporan.Columns["Harga"].FillWeight = 100;
                }

                if (dgvLaporan.Columns.Contains("Subtotal"))
                {
                    dgvLaporan.Columns["Subtotal"].FillWeight = 110;
                }

                if (dgvLaporan.Columns.Contains("Total Harga"))
                {
                    dgvLaporan.Columns["Total Harga"].FillWeight = 110;
                }

                if (dgvLaporan.Columns.Contains("Status"))
                {
                    dgvLaporan.Columns["Status"].FillWeight = 90;
                }

                // =============================================
                // FORMAT NOMOR
                // =============================================
                if (dgvLaporan.Columns.Contains("No"))
                {
                    dgvLaporan.Columns["No"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }

                // =============================================
                // FORMAT TANGGAL
                // =============================================
                if (dgvLaporan.Columns.Contains("Tanggal Pesanan"))
                {
                    dgvLaporan.Columns["Tanggal Pesanan"]
                        .DefaultCellStyle.Format =
                        "dd/MM/yyyy";
                }

                // =============================================
                // FORMAT UANG
                // =============================================
                if (dgvLaporan.Columns.Contains("Harga"))
                {
                    dgvLaporan.Columns["Harga"]
                        .DefaultCellStyle.Format =
                        "N0";
                }

                if (dgvLaporan.Columns.Contains("Subtotal"))
                {
                    dgvLaporan.Columns["Subtotal"]
                        .DefaultCellStyle.Format =
                        "N0";
                }

                if (dgvLaporan.Columns.Contains("Total Harga"))
                {
                    dgvLaporan.Columns["Total Harga"]
                        .DefaultCellStyle.Format =
                        "N0";
                }

                // =============================================
                // BERSIHKAN SELECTION
                // =============================================
                dgvLaporan.ClearSelection();

                // =============================================
                // PESAN JIKA DATA KOSONG
                // =============================================
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Tidak ada data pemesanan pada periode " +
                        tanggalAwal.ToString("dd/MM/yyyy") +
                        " sampai " +
                        tanggalAkhir.ToString("dd/MM/yyyy") +
                        ".",
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Laporan berhasil ditampilkan.\n\n" +
                        "Jumlah data: " +
                        table.Rows.Count,
                        "Laporan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan laporan.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        // =====================================================
        // TOMBOL KEMBALI
        // =====================================================
        private void btnKembali_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }

        private void btnKembali_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLaporan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}