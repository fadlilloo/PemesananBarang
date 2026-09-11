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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = Koneksi.GetConnection();

            try
            {
                connection.Open();

                string query =
                    "SELECT id_user, username, password, nama, role " +
                    "FROM users " +
                    "WHERE username = @username " +
                    "AND password = @password";

                MySqlCommand command =
                    new MySqlCommand(query, connection);

                command.Parameters.AddWithValue(
                    "@username",
                    txtUsername.Text
                );

                command.Parameters.AddWithValue(
                    "@password",
                    txtPassword.Text
                );

                MySqlDataReader reader =
                    command.ExecuteReader();

                if (reader.Read())
                {
                    int idUser =
                        Convert.ToInt32(reader["id_user"]);

                    string nama =
                        reader["nama"].ToString();

                    string role =
                        reader["role"].ToString();

                    MessageBox.Show(
                        "Login Berhasil"
                    );

                    this.Hide();

                    FormDashboard dashboard =
                        new FormDashboard(
                            idUser,
                            nama,
                            role
                        );

                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show(
                        "Username atau Password Salah"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message
                );
            }
            finally
            {
                connection.Close();
            }
        }
    }
}