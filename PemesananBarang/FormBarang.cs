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
    public partial class FormBarang : Form
    {
        public FormBarang()
        {
            InitializeComponent();
        }

        private void Bersih()
        {
            txtId.Clear();
            txtNama.Clear();
            txtHarga.Clear();
            txtStok.Clear();
            txtKeterangan.Clear();

            txtNama.Focus();
        }

        private void FormBarang_Load(
         object sender,
         EventArgs e
        )

        {
            TampilData();
        }

        private void TampilData()
        {
            MySqlConnection connection =
                Koneksi.GetConnection();

            try
            {
                connection.Open();

                string query =
                    "SELECT * FROM barang";

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(
                        query,
                        connection
                    );

                DataTable table =
                    new DataTable();

                adapter.Fill(table);

                dgvBarang.DataSource =
                    table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnTambah_Click(
        object sender,
        EventArgs e
        )

        {
            MySqlConnection connection =
                Koneksi.GetConnection();

            try
            {
                connection.Open();

                string query =
                    "INSERT INTO barang " +
                    "(nama_barang, harga, stok, keterangan) " +
                    "VALUES " +
                    "(@nama, @harga, @stok, @keterangan)";

                MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection
                    );

                command.Parameters.AddWithValue(
                    "@nama",
                    txtNama.Text
                );

                command.Parameters.AddWithValue(
                    "@harga",
                    txtHarga.Text
                );

                command.Parameters.AddWithValue(
                    "@stok",
                    txtStok.Text
                );

                command.Parameters.AddWithValue(
                    "@keterangan",
                    txtKeterangan.Text
                );

                command.ExecuteNonQuery();

                MessageBox.Show(
                    "Barang berhasil ditambahkan"
                );

                TampilData();
                Bersih();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
            finally
            {
                connection.Close();
            }
        }

        private void dgvBarang_CellClick(
        object sender,
        DataGridViewCellEventArgs e
        )

        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    dgvBarang.Rows[e.RowIndex];

                txtId.Text =
                    row.Cells["id_barang"].Value.ToString();

                txtNama.Text =
                    row.Cells["nama_barang"].Value.ToString();

                txtHarga.Text =
                    row.Cells["harga"].Value.ToString();

                txtStok.Text =
                    row.Cells["stok"].Value.ToString();

                txtKeterangan.Text =
                    row.Cells["keterangan"].Value.ToString();
            }
        }

        private void btnUbah_Click(
        object sender,
        EventArgs e
        )

        {
            MySqlConnection connection =
                Koneksi.GetConnection();

            try
            {
                connection.Open();

                string query =
                    "UPDATE barang SET " +
                    "nama_barang = @nama, " +
                    "harga = @harga, " +
                    "stok = @stok, " +
                    "keterangan = @keterangan " +
                    "WHERE id_barang = @id";

                MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection
                    );

                command.Parameters.AddWithValue(
                    "@id",
                    txtId.Text
                );

                command.Parameters.AddWithValue(
                    "@nama",
                    txtNama.Text
                );

                command.Parameters.AddWithValue(
                    "@harga",
                    txtHarga.Text
                );

                command.Parameters.AddWithValue(
                    "@stok",
                    txtStok.Text
                );

                command.Parameters.AddWithValue(
                    "@keterangan",
                    txtKeterangan.Text
                );

                command.ExecuteNonQuery();

                MessageBox.Show(
                    "Data berhasil diubah"
                );

                TampilData();
                Bersih();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnHapus_Click(
        object sender,
        EventArgs e
        )

        {
            DialogResult result =
                MessageBox.Show(
                    "Apakah Anda yakin ingin menghapus?",
                    "Konfirmasi",
                    MessageBoxButtons.YesNo
                );

            if (result == DialogResult.Yes)
            {
                MySqlConnection connection =
                    Koneksi.GetConnection();

                try
                {
                    connection.Open();

                    string query =
                        "DELETE FROM barang " +
                        "WHERE id_barang = @id";

                    MySqlCommand command =
                        new MySqlCommand(
                            query,
                            connection
                        );

                    command.Parameters.AddWithValue(
                        "@id",
                        txtId.Text
                    );

                    command.ExecuteNonQuery();

                    MessageBox.Show(
                        "Data berhasil dihapus"
                    );

                    TampilData();
                    Bersih();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message
                    );
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnBersih_Click(object sender, EventArgs e)
        {

        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtCari.Text.Trim();

            MySqlConnection connection = Koneksi.GetConnection();

            try
            {
                connection.Open();

                string query =
                    "SELECT " +
                    "id_barang, " +
                    "nama_barang, " +
                    "harga, " +
                    "stok, " +
                    "keterangan " +
                    "FROM barang " +
                    "WHERE " +
                    "CAST(id_barang AS CHAR) LIKE @keyword " +
                    "OR nama_barang LIKE @keyword " +
                    "OR keterangan LIKE @keyword " +
                    "ORDER BY id_barang DESC";

                MySqlCommand command =
                    new MySqlCommand(
                        query,
                        connection
                    );

                command.Parameters.AddWithValue(
                    "@keyword",
                    "%" + keyword + "%"
                );

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(command);

                DataTable table =
                    new DataTable();

                adapter.Fill(table);

                dgvBarang.DataSource = null;
                dgvBarang.DataSource = table;

                dgvBarang.ClearSelection();

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Data barang tidak ditemukan.",
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal mencari data barang.\n\n" +
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

        private void btnTampilkan_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = Koneksi.GetConnection();

            try
            {
                connection.Open();

                string query =
                    "SELECT " +
                    "id_barang, " +
                    "nama_barang, " +
                    "harga, " +
                    "stok, " +
                    "keterangan " +
                    "FROM barang " +
                    "ORDER BY id_barang ASC";

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(query, connection);

                DataTable table = new DataTable();
                adapter.Fill(table);

                dgvBarang.DataSource = null;
                dgvBarang.DataSource = table;

                txtCari.Clear();
                dgvBarang.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal menampilkan semua data barang.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }
    
    

