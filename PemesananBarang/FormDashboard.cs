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


    public partial class FormDashboard : Form
    {
        private int idUser;
        private string namaUser;
        private string roleUser;

        public FormDashboard(
            int id,
            string nama,
            string role
        )
        {
            InitializeComponent();

            idUser = id;
            namaUser = nama;
            roleUser = role;
        }

        private void LoadDashboard()
        {
            // =========================
            // KONEKSI DATABASE
            // =========================

            MySqlConnection connection =
                Koneksi.GetConnection();

            try
            {
                // =========================
                // BUKA KONEKSI
                // =========================

                connection.Open();


                // =========================
                // TOTAL BARANG
                // =========================

                string queryBarang =
                    "SELECT COUNT(*) FROM barang";

                MySqlCommand cmdBarang =
                    new MySqlCommand(
                        queryBarang,
                        connection
                    );

                int totalBarang =
                    Convert.ToInt32(
                        cmdBarang.ExecuteScalar()
                    );

                lblTotalBarang.Text =
                    totalBarang.ToString();


                // =========================
                // TOTAL PESANAN
                // =========================

                string queryPesanan =
                    "SELECT COUNT(*) FROM pesanan";

                MySqlCommand cmdPesanan =
                    new MySqlCommand(
                        queryPesanan,
                        connection
                    );

                int totalPesanan =
                    Convert.ToInt32(
                        cmdPesanan.ExecuteScalar()
                    );

                lblTotalPesanan.Text =
                    totalPesanan.ToString();


                // =========================
                // TOTAL STOK
                // =========================

                string queryStok =
                    "SELECT IFNULL(SUM(stok), 0) FROM barang";

                MySqlCommand cmdStok =
                    new MySqlCommand(
                        queryStok,
                        connection
                    );

                int totalStok =
                    Convert.ToInt32(
                        cmdStok.ExecuteScalar()
                    );

                lblTotalStok.Text =
                    totalStok.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Gagal memuat data dashboard.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // =========================
                // TUTUP KONEKSI
                // =========================

                connection.Close();
            }
        }

        private void FormDashboard_Load(
            object sender,
            EventArgs e
        )
        {
            lblNama.Text =
                "Selamat Datang, " + namaUser;

            LoadDashboard();
        }

        private void btnBarang_Click(
            object sender,
            EventArgs e
        )
        {
            FormBarang barang =
                new FormBarang();

            barang.Show();
        }

        private void btnPemesanan_Click(
            object sender,
            EventArgs e
        )
        {
            FormPemesanan pemesanan =
                new FormPemesanan(
                    idUser,
                    namaUser
                );

            pemesanan.Show();
        }

        private void btnLogout_Click(
            object sender,
            EventArgs e
        )
        {
            this.Hide();

            FormLogin login =
                new FormLogin();

            login.Show();
        }

        private void btnBarang_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBarang_Click_2(object sender, EventArgs e)
        {
            FormBarang barang =
        new FormBarang();

            barang.Show();
        }

        private void btnKelolaBarang_Click(object sender, EventArgs e)
        {
            FormBarang barang =
        new FormBarang();

            barang.Show();
        }

        private void btnPemesanan_Click_1(object sender, EventArgs e)
        {
            FormPemesanan pemesanan =
        new FormPemesanan(
            idUser,
            namaUser
        );

            pemesanan.Show();
        }

        private void btnBuatPesanan_Click(object sender, EventArgs e)
        {
            FormPemesanan pemesanan =
       new FormPemesanan(
           idUser,
           namaUser
       );

            pemesanan.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult hasil =
        MessageBox.Show(
            "Apakah Anda yakin ingin logout?",
            "Konfirmasi Logout",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

            if (hasil == DialogResult.Yes)
            {
                this.Hide();

                FormLogin login =
                    new FormLogin();

                login.Show();
            }
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            DialogResult hasil =
          MessageBox.Show(
              "Apakah Anda yakin ingin logout?",
              "Konfirmasi Logout",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
          );

            if (hasil == DialogResult.Yes)
            {
                this.Hide();

                FormLogin login =
                    new FormLogin();

                login.Show();
            }
        }

        private void btnDataPesanan_Click(object sender, EventArgs e)
        {
            FormPesanan pesanan =
      new FormPesanan();

            pesanan.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporan formLaporan =
       new FormLaporan();

            formLaporan.ShowDialog();
        }

        private void btnLihatPesanan_Click(object sender, EventArgs e)
        {
            FormPesanan FormPesanan =
     new FormPesanan();

            FormPesanan.ShowDialog();
        }
    }
}