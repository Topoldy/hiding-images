using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace formAES
{
    public partial class RegistrationForm : Form
    {
        string ip;
        int port;
        NetworkStream serverStream;
        TcpClient client;

        public RegistrationForm(string ip, int port)
        {
            InitializeComponent();
            this.ip = ip;
            this.port = port;
        }

        private void button_registration_MouseClick(object sender, MouseEventArgs e)
        {
            string login = textBox_login.Text;
            string password = textBox_password.Text;

            if (textBox_login.Text != "" && textBox_password.Text != "")
            {
                //client = new TcpClient();
                //Thread thread = new Thread();
                //client.ConnectAsync(IPAddress.Parse(ip), port).Wait(1000);

                //try
                //{
                //    if (!client.ConnectAsync(IPAddress.Parse(ip), port).Wait(1000))
                //    {
                //        label_error.Text = "Сервер не отвечает";
                //        return; // прекращаем выполнение функции
                //    }
                //}
                //catch(Exception ex)
                //{
                //    label_error.Text = "Сервер не отвечает";
                //    return;
                //}
                ////client.Connect(IPAddress.Parse(ip), port);

                //serverStream = client.GetStream();

                //byte[] login = Encoding.UTF8.GetBytes(textBox_login.Text);
                //byte[] hashPassword;

                //using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
                //{
                //    byte[] inputPassword = Encoding.ASCII.GetBytes(textBox_password.Text);
                //    hashPassword = md5.ComputeHash(inputPassword);
                //}

                //byte size_login = Convert.ToByte(login.Length);
                //byte size_hashPassword = 16;

                //int message_size = size_login + size_hashPassword + 3;

                //byte[] message = new byte[message_size];

                //message[0] = 0x01;
                //message[1] = size_login;

                //int i = 2;
                //for(; i < size_login + 2; i++)
                //{
                //    message[i] = login[i - 2];
                //}

                //message[i] = size_hashPassword;
                //i++;

                //for(int j = 0; j < size_hashPassword; j++)
                //{
                //    message[i + j] = hashPassword[j];
                //}

                //serverStream.Write(message, 0, message_size);

                //// получаем сообзение от сервера
                //bool isGood = Convert.ToBoolean(serverStream.ReadByte());

                int result = ClientRequests.Registration(ip, port, login, password);

                if (result == 1)
                {
                    Forms.authForm.hideButtonRegistration(); // прячем кнопку
                    Forms.authForm.Show(); // переходим в форму авторизации
                    Close(); // закрываем форму
                }
                else
                {
                    label_error.Text = "Такой логин уже существует";
                }
            }
        }
    }
}
