using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace testServerTCP
{
    class ClientRequests
    {
        private static string to16Base(byte[] buff)
        {
            string s = "";
            for (int i = 0; i < buff.Length; i++)
            {
                s += Convert.ToChar((buff[i] % 16) + '0');
                s += Convert.ToChar((buff[i] / 16) + '0');
            }

            return s;
        }

        public static int RegistrationUser(NetworkStream stream, NpgsqlConnection db)
        {
            NpgsqlCommand comm = db.CreateCommand();

            try
            {
                byte login_size = Convert.ToByte(stream.ReadByte()); // читаем логин
                byte[] login_buff = new byte[login_size];
                stream.Read(login_buff, 0, login_size);

                byte hashPassword_size = Convert.ToByte(stream.ReadByte()); // читаем пароль
                byte[] hashPassword_buff = new byte[hashPassword_size];
                stream.Read(hashPassword_buff, 0, hashPassword_size);

                string login = Encoding.UTF8.GetString(login_buff); // преобразуем в строки для запроса
                string pass = to16Base(hashPassword_buff);

                comm.CommandText = $"INSERT INTO users(login, password) VALUES('{login}', '{pass}');";

                comm.ExecuteNonQuery();

                return 1; // дошли до конца - добавить удалось
            }
            catch(PostgresException)
            {
                return 0; // не удалось добавить строк
            }
            catch(Exception)
            {
                return -5; // ошибка неопределённого рода
            }
        }

        public static int AuthenticationUser(NetworkStream stream, NpgsqlConnection db, out int id, out string login)
        {
            NpgsqlCommand comm = db.CreateCommand();

            try
            {
                byte login_size = Convert.ToByte(stream.ReadByte()); // читаем логин
                byte[] login_buff = new byte[login_size];
                stream.Read(login_buff, 0, login_size);

                byte hashPassword_size = Convert.ToByte(stream.ReadByte()); // читаем пароль
                byte[] hashPassword_buff = new byte[hashPassword_size];
                stream.Read(hashPassword_buff, 0, hashPassword_size);

                login = Encoding.UTF8.GetString(login_buff); // преобразуем в строки для запроса
                string pass = to16Base(hashPassword_buff);

                comm.CommandText = $"SELECT id FROM users WHERE login = '{login}' AND password = '{pass}';";

                NpgsqlDataReader reader = comm.ExecuteReader();

                if (reader.Read()) // если есть результат
                {
                    id = int.Parse(reader[0].ToString());
                }
                else
                    id = -1;

                reader.Close();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                id = -1; // не получилось прочитать
                login = "";
            }

            if(id == -1)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
