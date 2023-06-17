using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace formAES
{
    class ClientRequests
    {
        public static int Registration(string ip, int port, string login, string password)
        {
            try
            {
                TcpClient client = new TcpClient();
                NetworkStream stream;

                // если не успели подключиться за 1 секунду
                if (!client.ConnectAsync(IPAddress.Parse(ip), port).Wait(1000))
                {
                    return -2;
                }

                stream = client.GetStream();

                byte[] buff_login = Encoding.UTF8.GetBytes(login);
                byte[] hashPassword;

                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputPassword = Encoding.ASCII.GetBytes(password);
                    hashPassword = md5.ComputeHash(inputPassword);
                }

                byte size_login = Convert.ToByte(login.Length);
                byte size_hashPassword = 16;

                int message_size = size_login + size_hashPassword + 3;

                byte[] message = new byte[message_size];

                message[0] = 0x01;
                message[1] = size_login;

                int i = 2;
                for (; i < size_login + 2; i++)
                {
                    message[i] = buff_login[i - 2];
                }

                message[i] = size_hashPassword;
                i++;

                for (int j = 0; j < size_hashPassword; j++)
                {
                    message[i + j] = hashPassword[j];
                }

                // если не получилось отправить за 1 секунду
                if (!stream.WriteAsync(message, 0, message_size).Wait(1000))
                {
                    return -4;
                }

                // получаем сообзение от сервера
                //bool isGood = Convert.ToBoolean(stream.ReadByteAsync());

                byte[] buff = new byte[1];

                if (!stream.ReadAsync(buff, 0, 1).Wait(1000))
                {
                    return -3;
                }

                return buff[0];
            }
            catch
            {
                return -5;
            }
        }

        public static int Authentication(string ip, int port, string login, string password, out TcpClient tcpClient)
        {

            tcpClient = new TcpClient();
            NetworkStream stream;
            try
            {
                // если не успели подключиться за 1 секунду
                if (!tcpClient.ConnectAsync(IPAddress.Parse(ip), port).Wait(1000))
                {
                    return -2;
                }

                stream = tcpClient.GetStream();

                byte[] buff_login = Encoding.UTF8.GetBytes(login);
                byte[] hashPassword;

                using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                {
                    byte[] inputPassword = Encoding.ASCII.GetBytes(password);
                    hashPassword = md5.ComputeHash(inputPassword);
                }

                byte size_login = Convert.ToByte(login.Length);
                byte size_hashPassword = 16;

                int message_size = size_login + size_hashPassword + 3;

                byte[] message = new byte[message_size];

                message[0] = 0x02; // код аутентификации
                message[1] = size_login;

                int i = 2;
                for (; i < size_login + 2; i++)
                {
                    message[i] = buff_login[i - 2];
                }

                message[i] = size_hashPassword;
                i++;

                for (int j = 0; j < size_hashPassword; j++)
                {
                    message[i + j] = hashPassword[j];
                }

                // если не получилось отправить за 1 секунду
                if (!stream.WriteAsync(message, 0, message_size).Wait(1000))
                {
                    return -4;
                }

                byte[] buff = new byte[1];

                if (!stream.ReadAsync(buff, 0, 1).Wait(1000))
                {
                    return -3;
                }

                return buff[0];
            }
            catch
            {
                return -5;
            }
        }

        public static int CheckForConnection(NetworkStream stream, string user_login)
        {
            try
            {
                byte[] buff = new byte[user_login.Length + 2];

                byte[] buff_login = Encoding.UTF8.GetBytes(user_login);

                buff[0] = 0x03; // 3 операция - проверка на то, что пользователь в сети
                buff[1] = Convert.ToByte(user_login.Length);
                for (int i = 0; i < buff_login.Length; i++)
                {
                    buff[i + 2] = buff_login[i];
                }

                if (!stream.WriteAsync(buff, 0, buff.Length).Wait(1000))
                {
                    return -4;
                }

                return 0;
            }
            catch
            {
                return -5;
            }
        }

        private static byte[] ToBytes(UInt32 number)
        {
            byte[] buff = new byte[4];

            buff[0] = Convert.ToByte(number >> 24);
            buff[1] = Convert.ToByte((number << 8) >> 24);
            buff[2] = Convert.ToByte((number << 16) >> 24);
            buff[3] = Convert.ToByte((number << 24) >> 24);

            return buff;
        }

        public static int SendItImagesResponse(NetworkStream stream, UInt32 count, UInt32 size, string user_login)
        {
            try
            {
                byte[] buff = new byte[9 + 1 + user_login.Length];
                byte[] buff_user_login = Encoding.UTF8.GetBytes(user_login);
                byte[] buff_count = ToBytes(count);
                byte[] buff_size = ToBytes(size);

                buff[0] = 0x04; // код вопроса "отправлять ли"
                for (int i = 0; i < 4; i++)
                {
                    buff[1 + i] = buff_count[i];
                    buff[5 + i] = buff_size[i];
                }

                buff[9] = Convert.ToByte(user_login.Length);

                for(int i = 0; i < user_login.Length; i++)
                {
                    buff[10 + i] = buff_user_login[i];
                }

                if (!stream.WriteAsync(buff, 0, buff.Length).Wait(1000))
                {
                    return -4;
                }

                return 0;
            }
            catch
            {
                return -5;
            }
        }

        public static int SendItImagesRequest(NetworkStream stream, bool isYes)
        {
            try
            {
                byte[] buff = new byte[2];
                
                buff[0] = 0x05;
                if (isYes)
                {
                    buff[1] = 1;
                }
                else
                {
                    buff[1] = 0;
                }

                stream.Write(buff, 0, 2);

                return 0;
            }
            catch
            {
                return -5;
            }
        }

        public static int SendItKeysResponse(NetworkStream stream, UInt32 count, string user_login)
        {
            try
            {
                byte[] buff = new byte[5 + 1 + user_login.Length];
                byte[] buff_user_login = Encoding.UTF8.GetBytes(user_login);
                byte[] buff_count = ToBytes(count);
                

                buff[0] = 0x07; // код вопроса "отправлять ли ключ"
                for (int i = 0; i < 4; i++)
                {
                    buff[1 + i] = buff_count[i];
                }

                buff[5] = Convert.ToByte(user_login.Length);

                for (int i = 0; i < user_login.Length; i++)
                {
                    buff[6 + i] = buff_user_login[i];
                }

                if (!stream.WriteAsync(buff, 0, buff.Length).Wait(1000))
                {
                    return -4;
                }

                return 0;
            }
            catch
            {
                return -5;
            }
        }
    }
}
