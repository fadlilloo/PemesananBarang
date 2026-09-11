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
    public partial class FormPemesanan : Form
    {
        // =========================
        // DATA USER YANG LOGIN
        // =========================

        private int idUser;
        private string namaUser;


        // =========================
        // CONSTRUCTOR
        // =========================

        public FormPemesanan(
            int id,
            string nama
        )
        {
            InitializeComponent();

            idUser = id;
            namaUser = nama;
        }


        // =====================================
        // LOAD DATA PESANAN KE DATAGRIDVIEW
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
                    "p.nama_pemesan AS 'Nama Pemesan', " +
                    "b.nama_barang AS 'Nama Barang', " +
                    "dp.jumlah AS 'Jumlah', " +
                    "dp.harga AS 'Harga', " +
                    "dp.subtotal AS 'Subtotal', " +
                    "p.status AS 'Status' " +

                    "FROM pesanan p " +

                    "INNER JOIN detail_pesanan dp " +
                    "ON p.id_pesanan = dp.id_pesanan " +

                    "INNER JOIN barang b " +
                    "ON dp.id_barang = b.id_barang " +

                    "ORDER BY p.id_pesanan ASC";


                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(
                        query,
                        connection
                    );

                DataTable table =
                    new DataTable();

                adapter.Fill(table);


                // ==============================
                // TAMPILKAN DATA
                // ==============================

                dgvPesanan.DataSource = null;

                dgvPesanan.DataSource = table;


                // ==============================
                // TAMBAHKAN KOLOM NO
                // ==============================

                if (!dgvPesanan.Columns.Contains("No"))
                {
                    DataGridViewTextBoxColumn kolomNo =
                        new DataGridViewTextBoxColumn();

                    kolomNo.Name = "No";
                    kolomNo.HeaderText = "No";
                    kolomNo.ReadOnly = true;

                    dgvPesanan.Columns.Insert(
                        0,
                        kolomNo
                    );
                }


                // ==============================
                // ISI NOMOR 1, 2, 3, DST
                // ==============================

                for (
                    int i = 0;
                    i < dgvPesanan.Rows.Count;
                    i++
                )
                {
                    dgvPesanan.Rows[i]
                        .Cells["No"]
                        .Value = i + 1;
                }


                // ==============================
                // SEMBUNYIKAN ID PESANAN
                // ==============================

                if (
                    dgvPesanan.Columns.Contains(
                        "ID Pesanan"
                    )
                )
                {
                    dgvPesanan.Columns[
                        "ID Pesanan"
                    ].Visible = false;
                }


                // ==============================
                // ATUR DATAGRIDVIEW
                // ==============================

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

                dgvPesanan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data pesanan.\n\n" +
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
        // HITUNG SUBTOTAL
        // =====================================

        private void HitungSubtotal()
        {
            decimal harga = 0;

            int jumlah =
                Convert.ToInt32(
                    numJumlah.Value
                );


            decimal.TryParse(
                txtHarga.Text,
                out harga
            );


            decimal subtotal =
                harga * jumlah;


            txtSubtotal.Text =
                subtotal.ToString();
        }


        // =====================================
        // LOAD DATA BARANG
        // =====================================

        private void LoadBarang()
        {
            MySqlConnection connection =
                Koneksi.GetConnection();

            try
            {
                connection.Open();

                string query =
                    "SELECT * FROM barang " +
                    "WHERE stok > 0 " +
                    "ORDER BY nama_barang ASC";


                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(
                        query,
                        connection
                    );


                DataTable table =
                    new DataTable();


                adapter.Fill(table);


                cmbBarang.DataSource =
                    null;


                cmbBarang.DataSource =
                    table;


                cmbBarang.DisplayMember =
                    "nama_barang";


                cmbBarang.ValueMember =
                    "id_barang";


                cmbBarang.SelectedIndex =
                    -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data barang.\n\n" +
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
        // SAAT FORM DIBUKA
        // =====================================

        private void FormPemesanan_Load(
            object sender,
            EventArgs e
        )
        {
            // Tampilkan nama user
            label10.Text =
                namaUser;


            // Load data barang
            LoadBarang();


            // Load data pesanan ke DataGridView
            LoadPesanan();


            // Bersihkan ComboBox status
            cmbStatus.Items.Clear();

            cmbUpdateStatus.Items.Clear();


            // Status pesanan
            cmbStatus.Items.Add("Menunggu");
            cmbStatus.Items.Add("Diproses");
            cmbStatus.Items.Add("Selesai");


            cmbStatus.SelectedIndex =
                0;


            // Status update
            cmbUpdateStatus.Items.Add("Menunggu");
            cmbUpdateStatus.Items.Add("Diproses");
            cmbUpdateStatus.Items.Add("Selesai");


            cmbUpdateStatus.SelectedIndex =
                -1;


            // Pengaturan jumlah
            numJumlah.Minimum =
                1;

            numJumlah.Value =
                1;


            // Bersihkan harga
            txtHarga.Clear();

            txtSubtotal.Clear();


            // Fokus DataGridView tidak langsung aktif
            dgvPesanan.ClearSelection();
        }


        // =====================================
        // SAAT BARANG DIPILIH
        // =====================================

        private void cmbBarang_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
            if (cmbBarang.SelectedItem == null)
            {
                return;
            }


            DataRowView row =
                cmbBarang.SelectedItem
                as DataRowView;


            if (row == null)
            {
                return;
            }


            // Ambil harga

            decimal harga =
                Convert.ToDecimal(
                    row["harga"]
                );


            txtHarga.Text =
                harga.ToString();


            // Ambil stok

            int stok =
                Convert.ToInt32(
                    row["stok"]
                );


            // Batasi jumlah sesuai stok

            if (stok > 0)
            {
                numJumlah.Minimum =
                    1;

                numJumlah.Maximum =
                    stok;


                if (numJumlah.Value > stok)
                {
                    numJumlah.Value =
                        stok;
                }


                if (numJumlah.Value < 1)
                {
                    numJumlah.Value =
                        1;
                }
            }


            // Hitung subtotal

            HitungSubtotal();
        }


        // =====================================
        // VALIDASI PESANAN
        // =====================================

        private bool ValidasiPesanan()
        {
            if (cmbBarang.SelectedValue == null ||
                cmbBarang.SelectedItem == null)
            {
                MessageBox.Show(
                    "Silakan pilih barang terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cmbBarang.Focus();

                return false;
            }


            if (numJumlah.Value <= 0)
            {
                MessageBox.Show(
                    "Jumlah barang harus lebih dari 0.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                numJumlah.Focus();

                return false;
            }


            if (string.IsNullOrWhiteSpace(
                txtHarga.Text
            ))
            {
                MessageBox.Show(
                    "Harga barang belum tersedia.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }


            decimal harga;

            if (!decimal.TryParse(
                txtHarga.Text,
                out harga
            ))
            {
                MessageBox.Show(
                    "Harga barang tidak valid.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }


            if (numJumlah.Value >
                numJumlah.Maximum)
            {
                MessageBox.Show(
                    "Jumlah pesanan melebihi stok.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }


            return true;
        }


        // =====================================
        // RESET FORM
        // =====================================

        private void ResetFormPemesanan()
        {
            cmbBarang.SelectedIndex =
                -1;


            txtHarga.Clear();

            txtSubtotal.Clear();


            numJumlah.Minimum =
                1;

            numJumlah.Maximum =
                1000;

            numJumlah.Value =
                1;


            cmbStatus.SelectedIndex =
                0;
        }


        // =====================================
        // BUTTON SIMPAN
        // =====================================

        private void btnSimpan_Click(
            object sender,
            EventArgs e
        )
        {
            if (!ValidasiPesanan())
            {
                return;
            }


            int jumlah =
                Convert.ToInt32(
                    numJumlah.Value
                );


            decimal harga;

            if (!decimal.TryParse(
                txtHarga.Text,
                out harga
            ))
            {
                MessageBox.Show(
                    "Harga barang tidak valid.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            int idBarang =
                Convert.ToInt32(
                    cmbBarang.SelectedValue
                );


            decimal subtotal =
                harga * jumlah;


            txtSubtotal.Text =
                subtotal.ToString();


            string status =
                cmbStatus.Text;


            if (string.IsNullOrWhiteSpace(status))
            {
                status =
                    "Menunggu";
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
                    // =================================
                    // CEK STOK TERBARU
                    // =================================

                    string queryStok =
                        "SELECT stok FROM barang " +
                        "WHERE id_barang = @id_barang";


                    MySqlCommand cmdStok =
                        new MySqlCommand(
                            queryStok,
                            connection,
                            transaction
                        );


                    cmdStok.Parameters.AddWithValue(
                        "@id_barang",
                        idBarang
                    );


                    object hasilStok =
                        cmdStok.ExecuteScalar();


                    if (hasilStok == null)
                    {
                        transaction.Rollback();

                        MessageBox.Show(
                            "Barang tidak ditemukan.",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    int stok =
                        Convert.ToInt32(
                            hasilStok
                        );


                    if (jumlah > stok)
                    {
                        transaction.Rollback();

                        MessageBox.Show(
                            "Stok barang tidak mencukupi.\n\n" +
                            "Stok tersedia: " + stok,
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        return;
                    }


                    // =================================
                    // SIMPAN PESANAN
                    // =================================

                    string queryPesanan =
                       "INSERT INTO pesanan " +
    "(id_user, nama_pemesan, tanggal_pesanan, total_harga, status) " +
    "VALUES " +
    "(@id_user, @nama_pemesan, NOW(), @total_harga, @status)";


                    MySqlCommand cmdPesanan =
                        new MySqlCommand(
                            queryPesanan,
                            connection,
                            transaction
                        );


                    cmdPesanan.Parameters.AddWithValue(
                        "@id_user",
                        idUser
                    );


                    cmdPesanan.Parameters.AddWithValue(
                        "@nama_pemesan",
                        txtNamaPemesan.Text.Trim()
                    );


                    cmdPesanan.Parameters.AddWithValue(
                        "@total_harga",
                        subtotal
                    );


                    cmdPesanan.Parameters.AddWithValue(
                        "@status",
                        status
                    );

                    cmdPesanan.ExecuteNonQuery();


                    int idPesanan =
                        Convert.ToInt32(
                            cmdPesanan.LastInsertedId
                        );


                    // =================================
                    // SIMPAN DETAIL PESANAN
                    // =================================

                    string queryDetail =
                        "INSERT INTO detail_pesanan " +
                        "(id_pesanan, id_barang, jumlah, harga, subtotal) " +
                        "VALUES " +
                        "(@id_pesanan, @id_barang, @jumlah, @harga, @subtotal)";


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


                    cmdDetail.Parameters.AddWithValue(
                        "@id_barang",
                        idBarang
                    );


                    cmdDetail.Parameters.AddWithValue(
                        "@jumlah",
                        jumlah
                    );


                    cmdDetail.Parameters.AddWithValue(
                        "@harga",
                        harga
                    );


                    cmdDetail.Parameters.AddWithValue(
                        "@subtotal",
                        subtotal
                    );


                    cmdDetail.ExecuteNonQuery();


                    // =================================
                    // KURANGI STOK
                    // =================================

                    string queryUpdateStok =
                        "UPDATE barang " +
                        "SET stok = stok - @jumlah " +
                        "WHERE id_barang = @id_barang";


                    MySqlCommand cmdUpdateStok =
                        new MySqlCommand(
                            queryUpdateStok,
                            connection,
                            transaction
                        );


                    cmdUpdateStok.Parameters.AddWithValue(
                        "@jumlah",
                        jumlah
                    );


                    cmdUpdateStok.Parameters.AddWithValue(
                        "@id_barang",
                        idBarang
                    );


                    cmdUpdateStok.ExecuteNonQuery();


                    // Simpan semua perubahan

                    transaction.Commit();


                    // Refresh DataGridView

                    LoadPesanan();


                    // Refresh ComboBox Barang

                    LoadBarang();


                    // Reset form

                    ResetFormPemesanan();


                    MessageBox.Show(
                        "Pesanan berhasil disimpan.",
                        "Berhasil",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    MessageBox.Show(
                        "Gagal menyimpan pesanan.\n\n" +
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


        // =====================================
        // BUTTON BATAL
        // =====================================

        private void btnBatal_Click(
            object sender,
            EventArgs e
        )
        {
            DialogResult hasil =
                MessageBox.Show(
                    "Apakah Anda yakin ingin mereset data pesanan?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


            if (hasil == DialogResult.Yes)
            {
                ResetFormPemesanan();
            }
        }


        // =====================================
        // JUMLAH BERUBAH
        // =====================================

        private void numJumlah_ValueChanged(
            object sender,
            EventArgs e
        )
        {
            if (cmbBarang.SelectedItem == null)
            {
                txtSubtotal.Clear();

                return;
            }


            if (numJumlah.Value <= 0)
            {
                txtSubtotal.Clear();

                return;
            }


            HitungSubtotal();
        }


        // =====================================
        // STATUS DIPILIH
        // =====================================

        private void cmbStatus_SelectedIndexChanged(
            object sender,
            EventArgs e
        )
        {
        }


        // =====================================
        // UPDATE STATUS PESANAN
        // =====================================

        private void btnUpdateStatus_Click(
            object sender,
            EventArgs e
        )
        {
            if (dgvPesanan.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Silakan pilih pesanan terlebih dahulu.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            if (cmbUpdateStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Silakan pilih status pesanan.",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }


            int idPesanan =
                Convert.ToInt32(
                    dgvPesanan.SelectedRows[0]
                    .Cells["ID Pesanan"].Value
                );


            string statusBaru =
                cmbUpdateStatus.Text;


            MySqlConnection connection =
                Koneksi.GetConnection();


            try
            {
                connection.Open();


                string query =
                    "UPDATE pesanan " +
                    "SET status = @status " +
                    "WHERE id_pesanan = @id";


                MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection
                    );


                command.Parameters.AddWithValue(
                    "@status",
                    statusBaru
                );


                command.Parameters.AddWithValue(
                    "@id",
                    idPesanan
                );


                command.ExecuteNonQuery();


                LoadPesanan();


                cmbUpdateStatus.SelectedIndex =
                    -1;


                MessageBox.Show(
                    "Status pesanan berhasil diperbarui.",
                    "Berhasil",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memperbarui status.\n\n" +
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
        // HAPUS PESANAN
        // =====================================

        private void btnHapusPesanan_Click(
            object sender,
            EventArgs e
        )
        {
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


            int idPesanan =
                Convert.ToInt32(
                    dgvPesanan.SelectedRows[0]
                    .Cells["ID Pesanan"].Value
                );


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
                    // =================================
                    // AMBIL DETAIL PESANAN
                    // =================================

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


                    // =================================
                    // KEMBALIKAN STOK
                    // =================================

                    foreach (DataRow row
                        in tableDetail.Rows)
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


                    // =================================
                    // HAPUS DETAIL PESANAN
                    // =================================

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


                    // =================================
                    // HAPUS PESANAN
                    // =================================

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


                    // Simpan perubahan

                    transaction.Commit();


                    // Refresh

                    LoadPesanan();

                    LoadBarang();


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


        // =====================================
        // EVENT DATAGRIDVIEW
        // =====================================

        private void dgvPesanan_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e
        )
        {
        }

        private void cmbUpdateStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
    }
}