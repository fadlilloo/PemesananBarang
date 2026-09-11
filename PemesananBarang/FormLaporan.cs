using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace PemesananBarang
{
    public partial class FormLaporan : Form
    {
        public FormLaporan()
        {
            InitializeComponent();
        }

        // ==========================================
        // SAAT FORM DIBUKA
        // ==========================================
        private void FormLaporan_Load(object sender, EventArgs e)
        {
            dtpTanggalAwal.Value = DateTime.Today;
            dtpTanggalAkhir.Value = DateTime.Today;

            crystalReportViewer1.ReportSource = null;
        }



        // ==========================================
        // CRYSTAL REPORT VIEWER
        // ==========================================
        private void crystalReportViewer1_Load(
            object sender,
            EventArgs e)
        {
        }

        private void btnTampilkan_Click_1(object sender, EventArgs e)
        {
            DateTime tanggalAwal = dtpTanggalAwal.Value.Date;
            DateTime tanggalAkhir = dtpTanggalAkhir.Value.Date;

            // Validasi tanggal
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
                connection = Koneksi.GetConnection();
                connection.Open();

                // ==========================================
                // QUERY LAPORAN
                // ==========================================
                string query = @"
                    SELECT
                        p.id_pesanan,
                        p.tanggal_pesanan,
                        u.nama AS nama_user,
                        b.nama_barang,
                        dp.jumlah,
                        dp.harga,
                        dp.subtotal,
                        p.total_harga,
                        p.status
                    FROM pesanan p
                    INNER JOIN detail_pesanan dp
                        ON p.id_pesanan = dp.id_pesanan
                    INNER JOIN barang b
                        ON dp.id_barang = b.id_barang
                    INNER JOIN users u
                        ON p.id_user = u.id_user
                    WHERE p.tanggal_pesanan >= @tanggalAwal
                    AND p.tanggal_pesanan < DATE_ADD(@tanggalAkhir, INTERVAL 1 DAY)
                    ORDER BY p.id_pesanan ASC
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

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(command);

                DataTable table = new DataTable();

                adapter.Fill(table);

                // ==========================================
                // CEK DATA
                // ==========================================
                if (table.Rows.Count == 0)
                {
                    crystalReportViewer1.ReportSource = null;

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

                    return;
                }

                // ==========================================
                // TAMPILKAN KE CRYSTAL REPORT
                // ==========================================
                LaporanPenjualan laporan =
                    new LaporanPenjualan();

                laporan.SetDataSource(table);

                crystalReportViewer1.ReportSource = laporan;

                crystalReportViewer1.Refresh();

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

        private void btnKembali_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpTanggalAwal_ValueChanged_1(object sender, EventArgs e)
        {
            if (dtpTanggalAwal.Value.Date > dtpTanggalAkhir.Value.Date)
            {
                dtpTanggalAkhir.Value = dtpTanggalAwal.Value;
            }
        }

        private void dtpTanggalAkhir_ValueChanged_1(object sender, EventArgs e)
        {

            if (dtpTanggalAkhir.Value.Date < dtpTanggalAwal.Value.Date)
            {
                MessageBox.Show(
                    "Tanggal akhir tidak boleh lebih kecil dari tanggal awal.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                dtpTanggalAkhir.Value = dtpTanggalAwal.Value;
            }
        }
    }
}