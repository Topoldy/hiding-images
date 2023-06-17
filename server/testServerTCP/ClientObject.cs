using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testServerTCP
{
    class ClientObject
    {
        public int Id { get; }
        public string Login { get;  }

        TcpClient client;
        ServerObject server; // объект сервера

        public NetworkStream stream { get; private set; }
        public int status;
        public bool isFree; // свободен поток или нет

        public ClientObject(TcpClient tcpClient, ServerObject serverObject, int id, string login)
        {
            Id = id;
            Login = login;

            client = tcpClient;
            server = serverObject;

            stream = client.GetStream();
            status = -1;
            isFree = true;
        }

        private UInt32 toUInt32(byte[] buff)
        {
            UInt32 number = 0;
            UInt32 tmp;

            tmp = buff[0];
            number = tmp << 24;

            tmp = buff[1];
            number ^= tmp << 16;

            tmp = buff[2];
            number ^= tmp << 8;

            tmp = buff[3];
            number ^= tmp;

            return number;
        }

        public async Task HendlerRequestsAsync()
        {
            try
            {
                while (true)
                {
                    byte operation = Convert.ToByte(stream.ReadByte());

                    Console.WriteLine($"{Login}: {operation}");

                    if (operation == 3) // определяет в сети ли пользователь
                    {
                        int size_user_name = Convert.ToInt32(stream.ReadByte());
                        byte[] buff = new byte[size_user_name];
                        stream.Read(buff, 0, size_user_name);
                        string user_name = Encoding.UTF8.GetString(buff);

                        bool isConnection = server.checkForConnection(user_name);

                        byte[] res = new byte[2];
                        res[0] = 0x03; // код запрашиваемой функции

                        if (isConnection)
                            res[1] = 1; // в сети
                        else
                            res[1] = 0; // не в сети

                        stream.Write(res, 0, 2);

                        Console.WriteLine($"\"{Login}\" узнаёт о \"{user_name}\" {(res[1] == 1 ? "(в сети)" : "(не в сети)")}");
                    }
                    else if (operation == 4)
                    {
                        isFree = false;

                        byte[] buff_count = new byte[4];
                        byte[] buff_size = new byte[4];

                        stream.Read(buff_count, 0, 4);
                        stream.Read(buff_size, 0, 4);

                        UInt32 count = toUInt32(buff_count);
                        UInt32 size = toUInt32(buff_size);

                        UInt32 count_ = count;

                        int size_user_login = Convert.ToInt32(stream.ReadByte());
                        byte[] buff_user_login = new byte[size_user_login];

                        stream.Read(buff_user_login, 0, size_user_login);
                        string user_login = Encoding.UTF8.GetString(buff_user_login);



                        byte[] res = new byte[2];
                        res[0] = 0x4;
                        // ищем такого пользователя среди подключенных
                        ClientObject clientObject2;
                        if (server.checkForConnection(user_login, out clientObject2) && clientObject2.isFree == true) // если пользователь в сети
                        {
                            clientObject2.status = -1;

                            // будем отправлять вопрос второму пользователю
                            byte[] buff = new byte[9 + 1 + Login.Length];

                            buff[0] = 0x05; // код вопроса "примит ли он файл"

                            for (int i = 0; i < 4; i++)
                            {
                                buff[1 + i] = buff_count[i];
                                buff[5 + i] = buff_size[i];
                            }

                            buff[9] = Convert.ToByte(Login.Length); // кладём размер login-а
                            byte[] buff_login = Encoding.UTF8.GetBytes(Login);

                            for (int i = 0; i < Login.Length; i++)
                            {
                                buff[10 + i] = buff_login[i];
                            }

                            clientObject2.stream.Write(buff, 0, buff.Length);

                            //byte[] buff_res_user = new byte[2];

                            //// ждём ответа 10 секунд
                            //if (stream_user.ReadAsync(buff_res_user, 0, 2).Wait(10000))
                            //{
                            //    // если успевает ответить
                            //    // читаем что он ответил

                            //    if (buff_res_user[0] == 0x05) // код ответа
                            //    {
                            //        res[1] = buff_res_user[1];
                            //    }
                            //    else
                            //    {
                            //        Console.WriteLine($"{Login} получил непонятно что, ему отправлен отказ");
                            //    }
                            //}


                            int time_sleep = 10; // 10 ms - время, раз в которое проверять
                            int all_time = 10000; // время, за которое должны  получить ответ
                            int count_iter = all_time / time_sleep;
                            bool isSelected = false;

                            for (int i = 0; i < count_iter; i++)
                            {
                                if (clientObject2.status != -1)
                                {
                                    isSelected = true; // выбор произошёл

                                    res[1] = Convert.ToByte(clientObject2.status); // получаем статус, выбранный пользователем 

                                    clientObject2.status = -1; // делаем прежний статус
                                    break;
                                }
                                Thread.Sleep(time_sleep);
                            }

                            if (!isSelected) // если пользователь за отведённое время не сделал выбор
                            {
                                res[1] = 0; // даём за него отказ
                            }
                        }
                        else
                        {
                            res[1] = 2;
                        }

                        stream.Write(res, 0, 2); // возвращаем отправителю результат

                        bool isGood = true;

                        string str = "";
                        if (res[1] == 0)
                        {
                            str = "отказ";
                        }
                        else if (res[1] == 1)
                        {
                            str = "принято";

                            while (count_ > 0)
                            {
                                count_--;

                                // начинаем отправку файла
                                //byte operation_user = Convert.ToByte(stream.ReadByte());
                                byte size_file_name = Convert.ToByte(stream.ReadByte());
                                byte[] buff_file_name = new byte[size_file_name];
                                stream.Read(buff_file_name, 0, size_file_name);
                                string file_name = Encoding.UTF8.GetString(buff_file_name); // получили имя файла

                                byte[] buff_size_file_bytes = new byte[4];
                                stream.Read(buff_size_file_bytes, 0, 4);
                                UInt32 size_file = toUInt32(buff_size_file_bytes);

                                byte[] file_bytes = new byte[size_file];

                                byte[] buff_res = new byte[2];
                                //buff_res[0] = 0x06; // код перессылки
                                //buff_res[1] = 1; // успешно принял

                                int size_ = file_bytes.Length;
                                int max_size_buff = UInt16.MaxValue + 1;
                                int size_buff = 0;

                                byte[] buff = new byte[max_size_buff];

                                //buff[0] = operation_user;
                                buff[0] = size_file_name;
                                for (int i = 0; i < size_file_name; i++)
                                {
                                    buff[1 + i] = buff_file_name[i];
                                }

                                for (int i = 0; i < 4; i++)
                                {
                                    buff[1 + size_file_name + i] = buff_size_file_bytes[i];
                                }

                                clientObject2.stream.Write(buff, 0, 1 + size_file_name + 4);

                                //stream.Write(buff_res, 0, 2); // рассылаем что можно приступать к следующему ходу
                                //stream_user.Write(buff_res, 0, 2);

                                //int k = 0;

                                int user_status = -1;

                                while (size_ > 0)
                                {
                                    if (size_ >= max_size_buff) // если нужно отправить максимальный буфер
                                    {
                                        size_ -= max_size_buff;
                                        size_buff = max_size_buff;
                                    }
                                    else // если нужно отправить "остатки"
                                    {
                                        size_buff = size_;
                                        size_ = 0;
                                    }

                                    //if (!stream.ReadAsync(file_bytes, k * max_size_buff, size_buff).Wait(1000))

                                    Stopwatch stopWatch = new Stopwatch();
                                    stopWatch.Start();
                                    for (int i = 0; i < 500; i += 2) // ждём 500 мили-секунд
                                    {
                                        Thread.Sleep(2);
                                        if (clientObject2.status != -1)
                                        {
                                            user_status = clientObject2.status;
                                            break;
                                        }
                                    }
                                    clientObject2.status = -1;
                                    if (user_status == -1)
                                    {
                                        isGood = false;
                                        stream.WriteByte(0x00); // уведомляем отпровителя что дела плохи
                                        break;
                                    }
                                    user_status = -1;
                                    stopWatch.Stop();

                                    stream.WriteByte(0x01); // уведомляем отпровителя что всё хорошо

                                    Console.WriteLine($"Отправили ({stopWatch.ElapsedMilliseconds} ms)");

                                    stream.Read(buff, 0, size_buff); // принимаем от отправителя
                                    clientObject2.stream.Write(buff, 0, size_buff); // пересылаем другому
                                    Console.WriteLine("Переслали");
                                }

                                for (int i = 0; i < 1000; i += 10) // ждём 1000 мили-секунд
                                {
                                    Thread.Sleep(10);
                                    if (clientObject2.status != -1)
                                    {
                                        user_status = clientObject2.status;
                                        break;
                                    }
                                }
                                clientObject2.status = -1;
                                if (user_status == -1)
                                {
                                    isGood = false;
                                    stream.WriteByte(0x00); // уведомляем отпровителя что дела плохи
                                    break;
                                }
                                user_status = -1;

                                stream.WriteByte(0x01); // уведомляем отпровителя что всё хорошо
                            }
                        }
                        else if (res[1] == 2)
                        {
                            str = "не в сети";
                        }
                        if (!isGood)
                        {
                            str = $"не дошло {count - count_}";
                        }

                        Console.WriteLine($"\"{Login}\" хотел отправить \"{user_login}\" {count}, {size} сообщение: ({str})");

                        isFree = true;
                    }
                    else if (operation == 5) // ответ на вопрос "хочешь ли ты получить сообщение"
                    {
                        byte isYes = Convert.ToByte(stream.ReadByte());

                        if (isYes == 1)
                        {
                            status = 1;
                        }
                        else
                        {
                            status = 0;
                        }
                    }
                    else if (operation == 6) // сообщение о готовности принимать следующий пакет
                    {
                        byte isReady = Convert.ToByte(stream.ReadByte());

                        if (isReady == 1)
                        {
                            status = 1;
                        }
                        else
                        {
                            status = 0;
                        }
                    }
                    else if (operation == 7)
                    {
                        isFree = false;

                        byte[] buff_count = new byte[4];

                        stream.Read(buff_count, 0, 4);

                        UInt32 count = toUInt32(buff_count);

                        UInt32 count_ = count;

                        int size_user_login = Convert.ToInt32(stream.ReadByte());
                        byte[] buff_user_login = new byte[size_user_login];

                        stream.Read(buff_user_login, 0, size_user_login);
                        string user_login = Encoding.UTF8.GetString(buff_user_login);

                        byte[] res = new byte[2];
                        res[0] = 0x7;

                        // ищем такого пользователя среди подключенных
                        ClientObject clientObject2;
                        if (server.checkForConnection(user_login, out clientObject2) && clientObject2.isFree == true) // если пользователь в сети
                        {
                            clientObject2.status = -1;

                            // будем отправлять вопрос второму пользователю
                            byte[] buff = new byte[5 + 1 + Login.Length];

                            buff[0] = 0x06; // код вопроса "примит ли он файл"

                            for (int i = 0; i < 4; i++)
                            {
                                buff[1 + i] = buff_count[i];
                            }

                            buff[5] = Convert.ToByte(Login.Length); // кладём размер login-а
                            byte[] buff_login = Encoding.UTF8.GetBytes(Login);

                            for (int i = 0; i < Login.Length; i++)
                            {
                                buff[6 + i] = buff_login[i];
                            }

                            clientObject2.stream.Write(buff, 0, buff.Length);

                            int time_sleep = 10; // 10 ms - время, раз в которое проверять
                            int all_time = 10000; // время, за которое должны  получить ответ
                            int count_iter = all_time / time_sleep;
                            bool isSelected = false;

                            for (int i = 0; i < count_iter; i++)
                            {
                                if (clientObject2.status != -1)
                                {
                                    isSelected = true; // выбор произошёл

                                    res[1] = Convert.ToByte(clientObject2.status); // получаем статус, выбранный пользователем 

                                    clientObject2.status = -1; // делаем прежний статус
                                    break;
                                }
                                Thread.Sleep(time_sleep);
                            }

                            if (!isSelected) // если пользователь за отведённое время не сделал выбор
                            {
                                res[1] = 0; // даём за него отказ
                            }
                        }
                        else
                        {
                            res[1] = 2;
                        }

                        stream.Write(res, 0, 2); // возвращаем отправителю результат

                        bool isGood = true;

                        string str = "";
                        if (res[1] == 0)
                        {
                            str = "отказ";
                        }
                        else if (res[1] == 1)
                        {
                            str = "принято";

                            byte[] buff_size = new byte[4];
                            stream.Read(buff_size, 0, 4);

                            UInt32 size = toUInt32(buff_size);
                            byte[] buff = new byte[size];

                            if (!stream.ReadAsync(buff, 0, buff.Length).Wait(1000))
                            {
                                // не успели прочитать
                            }
                            else // если успели прочитать
                            {
                                clientObject2.stream.Write(buff, 0, buff.Length); // отправляем серверу


                                // начинаем отслеживать что там у пользователя
                                int user_status = -1;

                                Stopwatch stopWatch = new Stopwatch();
                                stopWatch.Start();
                                for (int i = 0; i < 500; i += 2) // ждём 500 мили-секунд
                                {
                                    Thread.Sleep(2);
                                    if (clientObject2.status != -1)
                                    {
                                        user_status = clientObject2.status;
                                        break;
                                    }
                                }
                                clientObject2.status = -1;
                                if (user_status == -1)
                                {
                                    isGood = false;
                                    stream.WriteByte(0x00); // уведомляем отпровителя что дела плохи
                                    break;
                                }
                                user_status = -1;
                                stopWatch.Stop();

                                stream.WriteByte(0x01); // уведомляем отпровителя что всё хорошо

                                Console.WriteLine($"Отправили ({stopWatch.ElapsedMilliseconds} ms)");
                            }
                        }
                        else if (res[1] == 2)
                        {
                            str = "не в сети";
                        }
                        if (!isGood)
                        {
                            str = $"не дошло {count - count_}";
                        }

                        Console.WriteLine($"\"{Login}\" хотел отправить \"{user_login}\" {count} шт ключей сообщение: ({str})");

                        isFree = true;
                    }
                }
            }
            catch
            {
                Console.WriteLine($"\"{Login}\" вышел");
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(Id);
            }
        }
        // закрытие подключения
        protected internal void Close()
        {
            stream.Close();
            client.Close();
        }
    }
}
