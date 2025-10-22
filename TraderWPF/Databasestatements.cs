using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TraderWPF
{
    internal class Databasestatements
    {

        Connect conn = new Connect();

        public object AddNewUser(object user)
        {
            try
            {
                conn._connection.Open();
                var NewUser = user.GetType().GetProperties();

                string salt = generateSalt();
                string hashedPassword = ComputeHmacSha256(NewUser[2].GetValue(user).ToString(), salt);

                string sql = "INSERT INTO `users`(`UserName`, `FullName`, `Password`, `Salt`, `Email`) VALUES (@username, @fullname, @password, @salt, @email)";

                MySqlCommand cmd = new MySqlCommand(sql, conn._connection);

                var newUser = user.GetType().GetProperties();

                cmd.Parameters.AddWithValue("@usernme", newUser[0].GetValue(user));
                cmd.Parameters.AddWithValue("@fullname", newUser[1].GetValue(user));
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@email", newUser[4].GetValue(user));

                cmd.ExecuteNonQuery();

                conn._connection.Close();

                return new { message = "Sikeres hozzáadás" };
            }
            catch (Exception ex)
            {

                return new { message = ex.Message };
            }

          

        }

        public object LogInUser(object user)
        {

            conn._connection.Open();

            string sql = "SELECT * FROM users WHERE UserName = @username AND Password = @password";

            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);

            var logUser = user.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@username", logUser[0].GetValue(user));
            cmd.Parameters.AddWithValue("@password", logUser[1].GetValue(user));

            MySqlDataReader reader = cmd.ExecuteReader();

            object isRegisted = reader.Read() ? new { message = "Regisztrált" } : new { message = "Nem regisztrált" };
            ;

            conn._connection.Close();

            return isRegisted;
        }

        public DataView UserList()
        {

            conn._connection.Open();

            string sql = "SELECT * FROM users";

            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            conn._connection.Close();

            return dt.DefaultView;

        }

        public string generateSalt()
        {
            byte[] salt = new byte[16];

            using (var rnd = RandomNumberGenerator.Create())
            {

                rnd.GetBytes(salt);

            }

            return Convert.ToBase64String(salt);

        }

        public string ComputeHmacSha256(string password, string salt)
        {

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {

                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);

            }

        }

    }
}
