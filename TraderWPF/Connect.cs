using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace TraderWPF
{
    internal class Connect
    {

        public MySqlConnection _connection;


        private string _host;
        private string _db;
        private string _user;
        private string _password;

        private string _connectionstring;

        public Connect()
        {
            _host = "localhost";
            _db = "trader";
            _user = "root";
            _password = "";

            _connectionstring = $"SERVER=(_host);DATABASE=(_db);UID=(_user);PASSWORD=(_password);SslMode=None";

            _connection = new MySqlConnection(_connectionstring);
        }

    }
}
