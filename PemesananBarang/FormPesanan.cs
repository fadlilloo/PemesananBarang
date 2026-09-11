using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace PemesananBarang
{
    public partial class FormPesanan : Form
    {
        // =====================================
        // CONSTRUCTOR
        // =====================================

        public FormPesanan()
        {
            InitializeComponent();

            AturDataGridView();
        }


        // =====================================
        // PENGATURAN DATAGRIDVIEW
        // =====================================

        private void AturDataGridView()
        {
            dgvPesanan.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvPesanan.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPesanan.MultiSelect =
                false;

            dgvPesanan.ReadOnly =
                true;

            dgvPesanan.AllowUserToAddRows =
                false;

            dgvPesanan.AllowUserToDeleteRows =
                false;

            dgvPesanan.AllowUserToResizeRows =
                false;

            dgvPesanan.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvPesanan.RowTemplate.Height =
                30;
        }


        // =====================================
        // LOAD DATA PESANAN
        // =====================================

        private void LoadPesanan()
        {
            MySqlConnection connection =
                Koneksi.GetConnection();

            try
            {
                connection.Open();

                string query =
                    "SELECT " +
                    "p.id_pesanan AS 'ID Pesanan', " +
                    "u.nama AS 'Nama Pemesan', " +
                    "b.nama_barang AS 'Nama Barang', " +
                    "d.jumlah AS 'Jumlah', " +
                    "d.harga AS 'Harga', " +
                    "d.subtotal AS 'Subtotal', " +
                    "p.status AS 'Status', " +
                    "p.tanggal_pesanan AS 'Tanggal Pesanan' " +

                    "FROM pesanan p " +

                    "INNER JOIN users u " +
                    "ON p.id_user = u.id_user " +

                    "INNER JOIN detail_pesanan d " +
                    "ON p.id_pesanan = d.id_pesanan " +

                    "INNER JOIN barang b " +
                    "ON d.id_barang = b.id_barang " +

                    "ORDER BY p.id_pesanan DESC";


                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(
                        query,
                        connection
                    );


                DataTable table =
                    new DataTable();


                adapter.Fill(table);


                dgvPesanan.DataSource =
                    null;

                dgvPesanan.DataSource =
                    table;


                // Format harga

                if (dgvPesanan.Columns.Contains("Harga"))
                {
                    dgvPesanan.Columns["Harga"]
                        .DefaultCellStyle.Format =
                        "N0";
                }


                // Format subtotal

                if (dgvPesanan.Columns.Contains("Subtotal"))
                {
                    dgvPesanan.Columns["Subtotal"]
                        .DefaultCellStyle.Format =
                        "N0";
                }


                // Format tanggal

                if (dgvPesanan.Columns.Contains("Tanggal Pesanan"))
                {
                    dgvPesanan.Columns["Tanggal Pesanan"]
                        .DefaultCellStyle.Format =
                        "dd-MM-yyyy HH:mm";
                }


                dgvPesanan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengambil data pesanan.\n\n" +
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


        // =====================================
        // FORM LOAD
        // =====================================

        private void FormPesanan_Load(
            object sender,
            EventArgs e
        )
        {
            LoadPesanan();
        }


        // =====================================
        // METHOD CARI PESANAN
        // =====================================

        private void CariPesanan()
        {
            string kataKunci =
                txtCari.Text.Trim();


            // Jika TextBox kosong,
            // tampilkan semua data

            if (string.IsNullOrWhiteSpace(kataKunci))
            {
                LoadPesanan();

                return;
            }


            MySqlConnection connection =
                Koneksi.GetConnection();


            try
            {
                connection.Open();


                string query =
                    "SELECT " +
                    "p.id_pesanan AS 'ID Pesanan', " +
                    "u.nama AS 'Nama Pemesan', " +
                    "b.nama_barang AS 'Nama Barang', " +
                    "d.jumlah AS 'Jumlah', " +
                    "d.harga AS 'Harga', " +
                    "d.subtotal AS 'Subtotal', " +
                    "p.status AS 'Status', " +
                    "p.tanggal_pesanan AS 'Tanggal Pesanan' " +

                    "FROM pesanan p " +

                    "INNER JOIN users u " +
                    "ON p.id_user = u.id_user " +

                    "INNER JOIN detail_pesanan d " +
                    "ON p.id_pesanan = d.id_pesanan " +

                    "INNER JOIN barang b " +
                    "ON d.id_barang = b.id_barang " +

                    "WHERE " +
                    "CAST(p.id_pesanan AS CHAR) LIKE @cari " +
                    "OR u.nama LIKE @cari " +
                    "OR b.nama_barang LIKE @cari " +
                    "OR p.status LIKE @cari " +

                    "ORDER BY p.id_pesanan DESC";


                MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection
                    );


                command.Parameters.AddWithValue(
                    "@cari",
                    "%" + kataKunci + "%"
                );


                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(
                        command
                    );


                DataTable table =
                    new DataTable();


                adapter.Fill(table);


                dgvPesanan.DataSource =
                    null;

                dgvPesanan.DataSource =
                    table;


                // Format harga

                if (dgvPesanan.Columns.Contains("Harga"))
                {
                    dgvPesanan.Columns["Harga"]
                        .DefaultCellStyle.Format =
                        "N0";
                }


                // Format subtotal

                if (dgvPesanan.Columns.Contains("Subtotal"))
                {
                    dgvPesanan.Columns["Subtotal"]
                        .DefaultCellStyle.Format =
                        "N0";
                }


                // Format tanggal

                if (dgvPesanan.Columns.Contains("Tanggal Pesanan"))
                {
                    dgvPesanan.Columns["Tanggal Pesanan"]
                        .DefaultCellStyle.Format =
                        "dd-MM-yyyy HH:mm";
                }


                dgvPesanan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari data pesanan.\n\n" +
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


        // =====================================
        // BUTTON CARI
        // =====================================

        private void btnCari_Click(
            object sender,
            EventArgs e
        )
        {
            CariPesanan();
        }


        // =====================================
        // BUTTON REFRESH
        // =====================================

        private void btnRefresh_Click(
            object sender,
            EventArgs e
        )
        {
            // Bersihkan pencarian

            txtCari.Clear();


            // Muat ulang data pesanan

            LoadPesanan();


            // Hilangkan pilihan DataGridView

            dgvPesanan.ClearSelection();


            MessageBox.Show(
                "Data pesanan berhasil diperbarui.",
                "Refresh",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        // =====================================
        // BUTTON HAPUS PESANAN
        // =====================================

        private void btnHapus_Click(
            object sender,
            EventArgs e
        )
        {
            // =====================================
            // CEK DATA DIPILIH
            // =====================================

            if (dgvPesanan.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Silakan pilih pesanan yang ingin dihapus.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            // =====================================
            // AMBIL ID PESANAN
            // =====================================

            int idPesanan =
                Convert.ToInt32(
                    dgvPesanan
                    .SelectedRows[0]
                    .Cells["ID Pesanan"]
                    .Value
                );


            // =====================================
            // KONFIRMASI
            // =====================================

            DialogResult hasil =
                MessageBox.Show(
                    "Apakah Anda yakin ingin menghapus pesanan ini?\n\n" +
                    "Stok barang akan dikembalikan.",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );


            if (hasil != DialogResult.Yes)
            {
                return;
            }


            MySqlConnection connection =
                Koneksi.GetConnection();


            try
            {
                connection.Open();


                MySqlTransaction transaction =
                    connection.BeginTransaction();


                try
                {
                    // =====================================
                    // AMBIL DATA DETAIL PESANAN
                    // =====================================

                    string queryDetail =
                        "SELECT id_barang, jumlah " +
                        "FROM detail_pesanan " +
                        "WHERE id_pesanan = @id_pesanan";


                    MySqlCommand cmdDetail =
                        new MySqlCommand(
                            queryDetail,
                            connection,
                            transaction
                        );


                    cmdDetail.Parameters.AddWithValue(
                        "@id_pesanan",
                        idPesanan
                    );


                    DataTable tableDetail =
                        new DataTable();


                    using (
                        MySqlDataReader reader =
                        cmdDetail.ExecuteReader()
                    )
                    {
                        tableDetail.Load(reader);
                    }


                    // =====================================
                    // KEMBALIKAN STOK BARANG
                    // =====================================

                    foreach (
                        DataRow row
                        in tableDetail.Rows
                    )
                    {
                        int idBarang =
                            Convert.ToInt32(
                                row["id_barang"]
                            );


                        int jumlah =
                            Convert.ToInt32(
                                row["jumlah"]
                            );


                        string queryStok =
                            "UPDATE barang " +
                            "SET stok = stok + @jumlah " +
                            "WHERE id_barang = @id_barang";


                        MySqlCommand cmdStok =
                            new MySqlCommand(
                                queryStok,
                                connection,
                                transaction
                            );


                        cmdStok.Parameters.AddWithValue(
                            "@jumlah",
                            jumlah
                        );


                        cmdStok.Parameters.AddWithValue(
                            "@id_barang",
                            idBarang
                        );


                        cmdStok.ExecuteNonQuery();
                    }


                    // =====================================
                    // HAPUS DETAIL PESANAN
                    // =====================================

                    string queryHapusDetail =
                        "DELETE FROM detail_pesanan " +
                        "WHERE id_pesanan = @id_pesanan";


                    MySqlCommand cmdHapusDetail =
                        new MySqlCommand(
                            queryHapusDetail,
                            connection,
                            transaction
                        );


                    cmdHapusDetail.Parameters.AddWithValue(
                        "@id_pesanan",
                        idPesanan
                    );


                    cmdHapusDetail.ExecuteNonQuery();


                    // =====================================
                    // HAPUS DATA PESANAN
                    // =====================================

                    string queryHapusPesanan =
                        "DELETE FROM pesanan " +
                        "WHERE id_pesanan = @id_pesanan";


                    MySqlCommand cmdHapusPesanan =
                        new MySqlCommand(
                            queryHapusPesanan,
                            connection,
                            transaction
                        );


                    cmdHapusPesanan.Parameters.AddWithValue(
                        "@id_pesanan",
                        idPesanan
                    );


                    cmdHapusPesanan.ExecuteNonQuery();


                    // =====================================
                    // SIMPAN TRANSAKSI
                    // =====================================

                    transaction.Commit();


                    // =====================================
                    // REFRESH DATA
                    // =====================================

                    LoadPesanan();

                    dgvPesanan.ClearSelection();


                    MessageBox.Show(
                        "Pesanan berhasil dihapus.\n\n" +
                        "Stok barang telah dikembalikan.",
                        "Berhasil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    transaction.Rollback();


                    MessageBox.Show(
                        "Gagal menghapus pesanan.\n\n" +
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Koneksi database gagal.\n\n" +
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

        private void btnCari_Click_1(object sender, EventArgs e)
        {
            MySqlConnection connection =
        Koneksi.GetConnection();

            try
            {
                connection.Open();

                string kataKunci =
                    txtCari.Text.Trim();

                string query =
                    "SELECT " +
                    "p.id_pesanan AS 'ID Pesanan', " +
                    "u.nama AS 'Nama Pemesan', " +
                    "b.nama_barang AS 'Nama Barang', " +
                    "dp.jumlah AS 'Jumlah', " +
                    "dp.harga AS 'Harga', " +
                    "dp.subtotal AS 'Subtotal', " +
                    "p.status AS 'Status' " +

                    "FROM pesanan p " +

                    "INNER JOIN users u " +
                    "ON p.id_user = u.id_user " +

                    "INNER JOIN detail_pesanan dp " +
                    "ON p.id_pesanan = dp.id_pesanan " +

                    "INNER JOIN barang b " +
                    "ON dp.id_barang = b.id_barang " +

                    "WHERE " +
                    "CAST(p.id_pesanan AS CHAR) LIKE @cari " +
                    "OR u.nama LIKE @cari " +
                    "OR b.nama_barang LIKE @cari " +
                    "OR p.status LIKE @cari " +

                    "ORDER BY p.id_pesanan DESC";


                MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection
                    );


                command.Parameters.AddWithValue(
                    "@cari",
                    "%" + kataKunci + "%"
                );


                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(
                        command
                    );


                DataTable table =
                    new DataTable();


                adapter.Fill(table);


                dgvPesanan.DataSource =
                    null;

                dgvPesanan.DataSource =
                    table;


                dgvPesanan.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;


                dgvPesanan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari data pesanan.\n\n" +
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

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {

        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}