using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formAES
{
    public partial class SendForm : Form
    {
        TcpClient tcpClient;
        NetworkStream stream;
        Task task;
        bool isClose;
        string login;
        List<string> path_send_files;

        public SendForm(TcpClient tcpClient, string login)
        {
            InitializeComponent();

            isClose = false;
            this.tcpClient = tcpClient;
            stream = tcpClient.GetStream();

            this.login = login;
            label_login.Text = $"Ваш пользователь: \"{login}\"";

            path_send_files = new List<string>();

            task = Task.Run(getServerResponses); // запускаем в отдельном потоке чтение ответов сервера

            string path = "encrypted images\\";

            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(
                    s =>
                    s.EndsWith(".png") ||
                    s.EndsWith(".bmp") ||
                    s.EndsWith(".tif") ||
                    s.EndsWith(".tiff") ||
                    s.EndsWith(".jpg") ||
                    s.EndsWith(".jpeg"));

                foreach (var file in files)
                {
                    int ii = file.LastIndexOf("\\") + 1;
                    string file_name = file.Substring(ii);
                    string file_path = file.Substring(0, file.Length - file_name.Length);

                    string key_path = textBox_path_keys.Text + file_name + ".key";
                    string isHaveKey = "";
                    if (File.Exists(key_path)) isHaveKey = "+";

                    ListViewItem lvi = new ListViewItem(new string[] { file_name, file_path, isHaveKey });
                    lvi.Tag = file_path;
                    listView1.Items.Add(lvi);
                }

                //textBox_logs.Text += $"\"{path}: найдено {listView1.Items.Count}  изображений\"\r\n";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string path = listView1.SelectedItems[0].Tag as string;
                string file = listView1.SelectedItems[0].Text;

                pictureBox1.Image = new Bitmap(path + file);
            }
        }

        private void button_checkForConnection_MouseClick(object sender, MouseEventArgs e)
        {
            string user_login = textBox_checkForConnection.Text;
            if (user_login == "")
            {
                ToTextBox_logs("Ничего не ввели");
                return;
            }

            int status_request = ClientRequests.CheckForConnection(stream, user_login);

            if(status_request != 0)
            {
                ToTextBox_logs("Сервер не отвечает");
            }

            //if(result == 1)
            //{
            //    label_checkForConnection.Text = "В сети!";
            //}
            //else if(result == 0)
            //{
            //    label_checkForConnection.Text = "Нет такого в сети";
            //}
            //else
            //{
            //    label_checkForConnection.Text = "Сервер не отвечает";
            //}
        }

        private void SendForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isClose = true;
            tcpClient.Close();
            Forms.entryForm.Show();
        }

        private void ToTextBox_logs(string text)
        {
            if (InvokeRequired)
                Invoke((Action<string>)ToTextBox_logs, text);
            else
                textBox_logs.Text += text + "\r\n";
        }

        private byte[] ToBytes(UInt32 number)
        {
            byte[] buff = new byte[4];

            buff[0] = Convert.ToByte(number >> 24);
            buff[1] = Convert.ToByte((number << 8) >> 24);
            buff[2] = Convert.ToByte((number << 16) >> 24);
            buff[3] = Convert.ToByte((number << 24) >> 24);

            return buff;
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

        private async Task getServerResponses()
        {
            while (true)
            {
                try
                {
                    byte operation = Convert.ToByte(stream.ReadByte()); // ждём вызова операций


                    if (operation == 3)
                    {
                        string user_login = textBox_checkForConnection.Text;

                        int status = ClientResponses.CheckForConnection(stream);

                        if (status < 0)
                        {
                            ToTextBox_logs("Ошибка при получение данных");
                        }
                        else if (status == 1)
                        {
                            ToTextBox_logs($"Пользователь \"{user_login}\" в сети");
                        }
                        else
                        {
                            ToTextBox_logs($"Пользователь \"{user_login}\" НЕ в сети");
                        }
                    }
                    else if (operation == 4) // отправление
                    {
                        int status = ClientResponses.SendItImagesResponse(stream);
                        bool isGood = true;
                        byte[] buff_isReady = new byte[1];

                        if (status < 0)
                        {
                            ToTextBox_logs("Ошибка при получение данных");
                        }
                        else if (status == 1)
                        {
                            ToTextBox_logs("Принял запрос");

                            //string file_name = "texture.png";
                            // начинаем отправлять
                            //byte[] file_bytes = File.ReadAllBytes($"encrypted images\\{file_name}");
                            int n;
                            for (n = 0; n < path_send_files.Count; n++)
                            {
                                string file_name = path_send_files[n].Substring(path_send_files[n].LastIndexOf('\\') + 1);
                                byte[] file_bytes = File.ReadAllBytes(path_send_files[n]);

                                byte size_file_name = Convert.ToByte(file_name.Length);
                                byte[] buff_file_name = Encoding.UTF8.GetBytes(file_name);

                                byte[] buff_size_file_bytes = ToBytes(Convert.ToUInt32(file_bytes.Length));

                                byte[] buff_info = new byte[1 + file_name.Length + 4];

                                buff_info[0] = size_file_name; // размер названия картинки
                                for (int i = 0; i < file_name.Length; i++) // передаём название файла
                                {
                                    buff_info[1 + i] = buff_file_name[i];
                                }
                                for (int i = 0; i < 4; i++)// передаём размер файла
                                {
                                    buff_info[1 + size_file_name + i] = buff_size_file_bytes[i];
                                }

                                stream.Write(buff_info, 0, buff_info.Length);

                                byte[] buff_res = new byte[2];

                                //if (!stream.ReadAsync(buff_res, 0, 2).Wait(1000))
                                //{
                                //    ToTextBox_logs("Сервер перестал отсылать");
                                //    continue; // прекращаем отправку
                                //}
                                //else
                                //{
                                //    if (!(buff_res[0] == 0x06 && buff_res[1] == 0))
                                //    {
                                //        ToTextBox_logs("Сервер не то прислал");
                                //        continue;
                                //    }
                                //}

                                int size = file_bytes.Length;
                                int max_size_buff = UInt16.MaxValue + 1;
                                int size_buff = 0;

                                byte[] buff = new byte[max_size_buff];

                                int k = 0;

                                while (size > 0)
                                {
                                    if (size >= max_size_buff) // если нужно отправить максимальный буфер
                                    {
                                        size -= max_size_buff;
                                        size_buff = max_size_buff;
                                    }
                                    else // если нужно отправить "остатки"
                                    {
                                        size_buff = size;
                                        size = 0;
                                    }

                                    for (int i = 0; i < size_buff; i++)
                                    {
                                        buff[i] = file_bytes[max_size_buff * k + i];
                                    }

                                    //for (int i = 0; i < file_bytes.Length; i++) // передаём само изображение
                                    //{
                                    //    buff[2 + size_file_name + 4] = file_bytes[i];
                                    //}

                                    //if (!stream.ReadAsync(buff_res, 0, 2).Wait(1000))
                                    //{
                                    //    ToTextBox_logs("Сервер перестал отсылать");
                                    //    continue; // прекращаем отправку
                                    //}
                                    //else
                                    //{
                                    //    if (!(buff_res[0] == 0x06 && buff_res[1] == 0))
                                    //    {
                                    //        ToTextBox_logs("Сервер не то прислал");
                                    //        continue;
                                    //    }
                                    //}

                                    //Thread.Sleep(500);

                                    if (!stream.ReadAsync(buff_isReady, 0, 1).Wait(500))
                                    {
                                        isGood = false;
                                        break;
                                    }
                                    else if(buff_isReady[0] != 1)
                                    {
                                        isGood = false;
                                        break;
                                    }

                                    stream.Write(buff, 0, size_buff);
                                    k++;
                                }

                                if (!stream.ReadAsync(buff_isReady, 0, 1).Wait(1000))
                                {
                                    isGood = false;
                                    break;
                                }
                                else if (buff_isReady[0] != 1)
                                {
                                    isGood = false;
                                    break;
                                }

                                ToTextBox_logs($"Отправили \"{file_name}\"");
                            }
                            
                            if(isGood)
                            {
                                ToTextBox_logs("Все картинки доставлены");
                            }
                            else
                            {
                                ToTextBox_logs($"Доставлено только {n} из {path_send_files.Count} изображений");
                            }
                        }
                        else
                        {
                            ToTextBox_logs("Пользователь отклонил запрос");
                        }
                    }
                    else if (operation == 5) // получение сообщений
                    {
                        UInt32 count;
                        UInt32 size;
                        string user_login;

                        int status = ClientResponses.SendItImagesRequest(stream, out count, out size, out user_login);

                        if (status != 0)
                        {
                            ToTextBox_logs("Ошибка получения");
                        }
                        else
                        {
                            Stopwatch stopWatch = new Stopwatch();

                            stopWatch.Start();
                            DialogResult dialogResult = MessageBox.Show(
                                $"Пользователь \"{user_login}\"\n" +
                                $"Хочет прислать {count} картинок\n" +
                                $"Общим размером в {size} байт", 
                                "Скачать?", MessageBoxButtons.YesNo);
                            stopWatch.Stop();

                            if (stopWatch.ElapsedMilliseconds < 9000) // 9 секун на ответ
                            {
                                if (dialogResult == DialogResult.Yes)
                                {
                                    if (ClientRequests.SendItImagesRequest(stream, true) != 0)
                                    {
                                        MessageBox.Show("Ошибка 1");
                                    }
                                    else
                                    {
                                        // начинаем принимать файл

                                        while (count > 0)
                                        {
                                            count--;

                                            byte size_file_name = Convert.ToByte(stream.ReadByte());
                                            byte[] buff_file_name = new byte[size_file_name];
                                            stream.Read(buff_file_name, 0, size_file_name);
                                            string file_name = Encoding.UTF8.GetString(buff_file_name); // получили имя файла

                                            byte[] buff_size_file_bytes = new byte[4];
                                            stream.Read(buff_size_file_bytes, 0, 4);
                                            UInt32 size_file = toUInt32(buff_size_file_bytes);

                                            byte[] file_bytes = new byte[size_file];
                                            byte[] buff_res = new byte[2];

                                            int size_ = file_bytes.Length;
                                            int max_size_buff = UInt16.MaxValue + 1;
                                            int size_buff = 0;

                                            byte[] buff_isReady = new byte[2];
                                            buff_isReady[0] = 0x06;
                                            buff_isReady[1] = 1; // состояние 1 - готов

                                            byte[] buff = new byte[max_size_buff];

                                            int k = 0;

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

                                                stream.Write(buff_isReady, 0, buff_isReady.Length); // сообщение о том, что мы готовы

                                                if (!stream.ReadAsync(file_bytes, k * max_size_buff, size_buff).Wait(1000))
                                                {
                                                    ToTextBox_logs("Долго. НЕ дозагрузил");
                                                    break;
                                                }

                                                k++;
                                            }

                                            File.WriteAllBytes(file_name, file_bytes);

                                            stream.Write(buff_isReady, 0, buff_isReady.Length); // сообщение о том, что мы прочитали всё
                                        }
                                    }
                                }
                                else if (dialogResult == DialogResult.No)
                                {
                                    if (ClientRequests.SendItImagesRequest(stream, false) != 0)
                                    {
                                        MessageBox.Show("Ошибка 2");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Вы не успели дать ответ");
                            }

                        }
                    }
                    else if (operation == 6)
                    {

                    }
                }
                catch (Exception ex)
                {
                    if (!isClose)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Вы были отключены от сервера");
                    }
                    return;
                }
            }
        }

        private void button_send_images_MouseClick(object sender, MouseEventArgs e)
        {
            UInt32 count = 0; // количество выбранных картинокв
            UInt32 size = 0; // общий размер изображенийы

            path_send_files.Clear();

            for(int i = 0; i < listView1.Items.Count; i++)
            {
                if(listView1.Items[i].Selected) // если картинку будем отправлять
                {   // записываем все файлы, которые мы хотим отправить
                    string path_send_file = listView1.Items[i].Tag + listView1.Items[i].Text;
                    path_send_files.Add(path_send_file);
                    
                    count++;
                    size += Convert.ToUInt32(new FileInfo(path_send_file).Length);
                }
            }

            string user_login = textBox_checkForConnection.Text;
            if (count == 0 || size == 0 || user_login == "")
            {
                ToTextBox_logs("Ошибка (выберите картинку или введите пользователя)");
                return;
            }

            int status_request = ClientRequests.SendItImagesResponse(stream, count, size, user_login);

            if (status_request != 0)
            {
                ToTextBox_logs("Сервер не отвечает");
            }
        }
    }
}
