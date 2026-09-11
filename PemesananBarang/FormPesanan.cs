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

            cmbUpdateStatus.Items.Clear();
            cmbUpdateStatus.Items.Add("Menunggu");////
            cmbUpdateStatus.Items.Add("Diproses");
            cmbUpdateStatus.Items.Add("Selesai");
            cmbUpdateStatus.Items.Add("Dibatalkan");

            cmbUpdateStatus.SelectedIndex = 0;

            // LANGSUNG TAMPILKAN DATA PESANAN
            LoadPesanan();
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
            try
            {
                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT
                    p.id_pesanan AS 'ID Pesanan',
                    p.nama_pemesan AS 'Nama Pemesan',
                    b.nama_barang AS 'Nama Barang',
                    d.jumlah AS 'Jumlah',
                    d.harga AS 'Harga',
                    d.subtotal AS 'Subtotal',
                    p.status AS 'Status'
                FROM pesanan p
                INNER JOIN detail_pesanan d
                    ON p.id_pesanan = d.id_pesanan
                INNER JOIN barang b
                    ON d.id_barang = b.id_barang
                ORDER BY p.id_pesanan ASC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd);

                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        // Tampilkan data ke DGV
                        dgvPesanan.DataSource = dt;
                    }
                }

                // Sembunyikan ID Pesanan
                if (dgvPesanan.Columns.Contains("ID Pesanan"))
                {
                    dgvPesanan.Columns["ID Pesanan"].Visible = false;
                }

                // Hapus kolom No lama
                if (dgvPesanan.Columns.Contains("No"))
                {
                    dgvPesanan.Columns.Remove("No");
                }

                // Buat kolom No
                DataGridViewTextBoxColumn kolomNo =
                    new DataGridViewTextBoxColumn();

                kolomNo.Name = "No";
                kolomNo.HeaderText = "No";
                kolomNo.ReadOnly = true;

                dgvPesanan.Columns.Insert(0, kolomNo);

                // Isi nomor 1, 2, 3, dst.
                for (int i = 0; i < dgvPesanan.Rows.Count; i++)
                {
                    dgvPesanan.Rows[i].Cells["No"].Value = i + 1;
                }

                // ==========================================
                // ATUR AGAR KOLOM TERLIHAT
                // ==========================================

                dgvPesanan.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgvPesanan.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.None;

                dgvPesanan.RowTemplate.Height = 30;

                dgvPesanan.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvPesanan.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleLeft;

                // Kolom tertentu rata tengah
                if (dgvPesanan.Columns.Contains("No"))
                {
                    dgvPesanan.Columns["No"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvPesanan.Columns.Contains("Jumlah"))
                {
                    dgvPesanan.Columns["Jumlah"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvPesanan.Columns.Contains("Status"))
                {
                    dgvPesanan.Columns["Status"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }

                // Format harga
                if (dgvPesanan.Columns.Contains("Harga"))
                {
                    dgvPesanan.Columns["Harga"]
                        .DefaultCellStyle.Format = "N0";
                }

                // Format subtotal
                if (dgvPesanan.Columns.Contains("Subtotal"))
                {
                    dgvPesanan.Columns["Subtotal"]
                        .DefaultCellStyle.Format = "N0";
                }

                // Pastikan DGV bisa memilih baris
                dgvPesanan.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvPesanan.MultiSelect = false;
                dgvPesanan.ReadOnly = true;
                dgvPesanan.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan data pesanan:\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
            try
            {
                string keyword = txtCari.Text.Trim();

                using (MySqlConnection conn = Koneksi.GetConnection())
                {
                    conn.Open();

                    string query = @"
                SELECT
                    p.id_pesanan AS 'ID Pesanan',
                    p.nama_pemesan AS 'Nama Pemesan',
                    b.nama_barang AS 'Nama Barang',
                    d.jumlah AS 'Jumlah',
                    d.harga AS 'Harga',
                    d.subtotal AS 'Subtotal',
                    p.status AS 'Status'
                FROM pesanan p
                INNER JOIN detail_pesanan d
                    ON p.id_pesanan = d.id_pesanan
                INNER JOIN barang b
                    ON d.id_barang = b.id_barang
                WHERE
                    p.nama_pemesan LIKE @keyword
                    OR b.nama_barang LIKE @keyword
                    OR p.status LIKE @keyword
                ORDER BY p.id_pesanan ASC";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@keyword",
                            "%" + keyword + "%");

                        MySqlDataAdapter adapter =
                            new MySqlDataAdapter(cmd);

                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dgvPesanan.DataSource = dt;
                    }
                }

                // Sembunyikan ID Pesanan
                if (dgvPesanan.Columns.Contains("ID Pesanan"))
                {
                    dgvPesanan.Columns["ID Pesanan"].Visible = false;
                }

                // Hapus No yang lama
                if (dgvPesanan.Columns.Contains("No"))
                {
                    dgvPesanan.Columns.Remove("No");
                }

                // Tambahkan kolom No
                DataGridViewTextBoxColumn kolomNo =
                    new DataGridViewTextBoxColumn();

                kolomNo.Name = "No";
                kolomNo.HeaderText = "No";
                kolomNo.ReadOnly = true;
                kolomNo.Width = 50;

                dgvPesanan.Columns.Insert(0, kolomNo);

                // Nomor urut mulai dari 1
                for (int i = 0; i < dgvPesanan.Rows.Count; i++)
                {
                    dgvPesanan.Rows[i].Cells["No"].Value = i + 1;
                }

                // Format harga
                if (dgvPesanan.Columns.Contains("Harga"))
                {
                    dgvPesanan.Columns["Harga"]
                        .DefaultCellStyle.Format = "N0";
                }

                // Format subtotal
                if (dgvPesanan.Columns.Contains("Subtotal"))
                {
                    dgvPesanan.Columns["Subtotal"]
                        .DefaultCellStyle.Format = "N0";
                }

                // Jika tidak ada hasil
                if (dgvPesanan.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Data pesanan tidak ditemukan.",
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari data pesanan.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        private void btnCari_Click_2(object sender, EventArgs e)
        {

        }

        private void dgvPesanan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCari_Click_3(object sender, EventArgs e)
        {
            CariPesanan();
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateStatus_Click_1(
             object sender,
             EventArgs e
         )
        {
            // Cek apakah ada pesanan yang dipilih
            if (dgvPesanan.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Silakan pilih pesanan yang ingin diubah.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Cek status
            if (cmbUpdateStatus.SelectedItem == null)
            {
                MessageBox.Show(
                    "Silakan pilih status terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                // Ambil ID Pesanan dari baris yang dipilih
                int idPesanan = Convert.ToInt32(
                    dgvPesanan.SelectedRows[0]
                    .Cells["ID Pesanan"].Value);

                string statusBaru =
                    cmbUpdateStatus.SelectedItem.ToString();

                using (MySqlConnection conn =
                    Koneksi.GetConnection())
                {
                    conn.Open();

                    string query = @"
                UPDATE pesanan
                SET status = @status
                WHERE id_pesanan = @id_pesanan";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@status",
                            statusBaru);

                        cmd.Parameters.AddWithValue(
                            "@id_pesanan",
                            idPesanan);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Status pesanan berhasil diperbarui.",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Tampilkan data terbaru
                LoadPesanan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mengubah status pesanan.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnHapusPesanan_Click(object sender, EventArgs e)
        {
            {
                // Cek apakah ada data yang dipilih
                if (dgvPesanan.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Silakan pilih pesanan yang ingin dihapus.",
                        "Peringatan",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                try
                {
                    int idPesanan = Convert.ToInt32(
                        dgvPesanan.SelectedRows[0]
                        .Cells["ID Pesanan"].Value);

                    string namaPemesan =
                        dgvPesanan.SelectedRows[0]
                        .Cells["Nama Pemesan"].Value.ToString();

                    DialogResult konfirmasi = MessageBox.Show(
                        "Apakah kamu yakin ingin menghapus pesanan:\n\n" +
                        "Nama Pemesan : " + namaPemesan,
                        "Konfirmasi Hapus",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (konfirmasi != DialogResult.Yes)
                    {
                        return;
                    }

                    using (MySqlConnection conn =
                        Koneksi.GetConnection())
                    {
                        conn.Open();

                        MySqlTransaction transaksi =
                            conn.BeginTransaction();

                        try
                        {
                            // =================================================
                            // 1. Ambil barang dan jumlah pesanan
                            // =================================================

                            string queryDetail = @"
                    SELECT id_barang, jumlah
                    FROM detail_pesanan
                    WHERE id_pesanan = @id_pesanan";

                            DataTable detail = new DataTable();

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    queryDetail,
                                    conn,
                                    transaksi))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id_pesanan",
                                    idPesanan);

                                MySqlDataAdapter adapter =
                                    new MySqlDataAdapter(cmd);

                                adapter.Fill(detail);
                            }

                            // =================================================
                            // 2. Kembalikan stok barang
                            // =================================================

                            foreach (DataRow row in detail.Rows)
                            {
                                int idBarang =
                                    Convert.ToInt32(row["id_barang"]);

                                int jumlah =
                                    Convert.ToInt32(row["jumlah"]);

                                string queryStok = @"
                        UPDATE barang
                        SET stok = stok + @jumlah
                        WHERE id_barang = @id_barang";

                                using (MySqlCommand cmd =
                                    new MySqlCommand(
                                        queryStok,
                                        conn,
                                        transaksi))
                                {
                                    cmd.Parameters.AddWithValue(
                                        "@jumlah",
                                        jumlah);

                                    cmd.Parameters.AddWithValue(
                                        "@id_barang",
                                        idBarang);

                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // =================================================
                            // 3. Hapus detail pesanan
                            // =================================================

                            string queryHapusDetail = @"
                    DELETE FROM detail_pesanan
                    WHERE id_pesanan = @id_pesanan";

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    queryHapusDetail,
                                    conn,
                                    transaksi))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id_pesanan",
                                    idPesanan);

                                cmd.ExecuteNonQuery();
                            }

                            // =================================================
                            // 4. Hapus data pesanan
                            // =================================================

                            string queryHapusPesanan = @"
                    DELETE FROM pesanan
                    WHERE id_pesanan = @id_pesanan";

                            using (MySqlCommand cmd =
                                new MySqlCommand(
                                    queryHapusPesanan,
                                    conn,
                                    transaksi))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id_pesanan",
                                    idPesanan);

                                cmd.ExecuteNonQuery();
                            }

                            // =================================================
                            // 5. Simpan transaksi
                            // =================================================

                            transaksi.Commit();

                            MessageBox.Show(
                                "Pesanan berhasil dihapus.",
                                "Berhasil",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            // Refresh DGV
                            LoadPesanan();
                        }
                        catch
                        {
                            transaksi.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Gagal menghapus pesanan.\n\n" +
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnTampilkan_Click(object sender, EventArgs e)
        {

            txtCari.Clear();
            LoadPesanan();

        }
    }
}