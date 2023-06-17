using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace testServerTCP
{

    class ServerObject
    {
        TcpListener tcpListener;
        NpgsqlConnection db;
        List<ClientObject> clients;

        public ServerObject()
        {
            tcpListener = new TcpListener(IPAddress.Any, 11555); // сервер для прослушивания
            //clients = new Dictionary<int, ClientObject>();
            clients = new List<ClientObject>(); // все подключения

            string connStr = "Host=localhost;Username=postgres;Password=root;Database=servertcp";
            db = new NpgsqlConnection(connStr);
        }

        public ServerObject(string ip, int port)
        {
            tcpListener = new TcpListener(IPAddress.Parse(ip), port); // сервер для прослушивания
            //clients = new Dictionary<int, ClientObject>();
            clients = new List<ClientObject>(); // все подключения

            string connStr = "Host=localhost;Username=postgres;Password=root;Database=servertcp";
            db = new NpgsqlConnection(connStr);
        }

        protected internal void RemoveConnection(int id)
        {
            ClientObject client;

            client = clients.FirstOrDefault(s => s.Id == id);
            
            if (client == default(ClientObject))
            {
                return;
            }

            client.Close(); // закрываем tcp-соединение
            clients.Remove(client); // убираем из списка клиентов
        }

        // прослушивание входящих подключений
        protected internal async Task ListenAsync()
        {
            try
            {
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");
                db.Open();

                int result = -5;

                while (true)
                {
                    TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                    // получаем поток для чтения данных
                    NetworkStream stream = tcpClient.GetStream();

                    byte operation = Convert.ToByte(stream.ReadByte());

                    if (operation == 1) // если пользователь регестрируется
                    {
                        result = ClientRequests.RegistrationUser(stream, db);
                        Console.WriteLine($"Попытка регистрации: {(result == 1 ? "успех" : "не удалось")}");
                    }
                    else if (operation == 2) // если пользователь пытается войти (аутентификация)
                    {
                        string login;
                        int id;

                        result = ClientRequests.AuthenticationUser(stream, db, out id, out login);

                        if (result == 1)
                        {
                            Console.WriteLine($"Попытка вход (принято): \"{login}\"");

                            ClientObject clientObject = new ClientObject(tcpClient, this, id, login);
                            clients.Add(clientObject);
                            Task.Run(clientObject.HendlerRequestsAsync);
                        }
                        else
                        {
                            Console.WriteLine($"Попытка вход (отказано): \"{login}\"");
                        }
                    }
                    else
                    {
                        continue; // если client прислал непонятно что
                    }

                    byte[] buff = new byte[1] { 0 };

                    if(result == 1) // если запрашиваемая операция прошла успещно
                        buff[0] = 1;

                    stream.Write(buff, 0, 1); // отправляем клиенту ответ
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

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

        // проверяет подключился ли уже пользователь user
        protected internal bool checkForConnection(string user_name)
        {
            var result = clients.FirstOrDefault(s => s.Login == user_name);
            if(result == default(ClientObject))
            {
                return false; // такого ползователя на сервере нет
            }
            else
            {
                return true; // да, нашли такого пользователя
            }
        }

        protected internal bool checkForConnection(string user_name, out ClientObject clientObject)
        {
            var result = clients.FirstOrDefault(s => s.Login == user_name);
            if (result == default(ClientObject))
            {
                clientObject = null;
                return false; // такого ползователя на сервере нет
            }
            else
            {
                clientObject = result; // возвращаем этого клиента
                return true; // да, нашли такого пользователя
            }
        }

        // трансляция сообщения подключенным клиентам
        protected internal async Task BroadcastMessageAsync(string message, string id)
        {
            //foreach (var client in clients)
            //{
            //    if (client.Id != id) // если id клиента не равно id отправителя
            //    {
            //        await client.Writer.WriteLineAsync(message); //передача данных
            //        await client.Writer.FlushAsync();
            //    }
            //}
        }
        // отключение всех клиентов
        protected internal void Disconnect()
        {
            db.Close();
            foreach (var client in clients)
            {
                client.Close(); //отключение клиента
            }
            tcpListener.Stop(); //остановка сервера
        }
    }
}
