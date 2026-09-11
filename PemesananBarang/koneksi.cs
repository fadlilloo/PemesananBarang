using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PemesananBarang
{
    class Koneksi
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString =
                "server=localhost;" +
                "database=db_pemesanan_barang;" +
                "uid=root;" +
                "pwd=;";

            MySqlConnection connection =
                new MySqlConnection(connectionString);

            return connection;
        }
    }
}