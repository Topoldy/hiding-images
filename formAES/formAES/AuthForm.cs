using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formAES
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        public void hideButtonRegistration()
        {
            button_registration.Hide();
        }

        private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.entryForm.Show();
        }

        private void button_registration_MouseClick(object sender, MouseEventArgs e)
        {
            string ip = textBox_server_ip.Text;
            int port = int.Parse(textBox_server_port.Text);

            Forms.registrationForm = new RegistrationForm(ip, port);
            Hide();
            Forms.registrationForm.Show();
        }

        private void button_authentication_MouseClick(object sender, MouseEventArgs e)
        {
            string login = textBox_login.Text;
            string password = textBox_password.Text;

            if (login != "" && password != "")
            {
                TcpClient tcpClient;

                string ip = textBox_server_ip.Text;
                int port = int.Parse(textBox_server_port.Text);

                int result = ClientRequests.Authentication(ip, port, login, password, out tcpClient);

                if (result == 1)
                {
                    Forms.sendForm = new SendForm(tcpClient, login);
                    Forms.sendForm.Show(); // переходим в форму авторизации

                    FormClosed -= AuthForm_FormClosed; // убираем событие закрытия формы

                    Close(); // закрываем форму
                }
                else if(result == 0)
                {
                    label_error.Text = "Не верный логин или пароль";
                }
                else
                {
                    label_error.Text = "Проблемы с сервером";
                }
            }
        }
    }
}
