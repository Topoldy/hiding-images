using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formAES
{
    public partial class EntryForm : Form
    {
        public EntryForm()
        {
            InitializeComponent();
        }

        private void Encrypt_button_MouseClick(object sender, MouseEventArgs e)
        {
            Forms.encryptForm = new EncryptForm();
            Hide();
            Forms.encryptForm.Show();
        }

        private void Decrypt_button_MouseClick(object sender, MouseEventArgs e)
        {
            Forms.decryptForm = new DecryptForm();
            Hide();
            Forms.decryptForm.Show();
        }

        private void Send_button_MouseClick(object sender, MouseEventArgs e)
        {
            Forms.authForm = new AuthForm();

           // Forms.sendForm = new SendForm();
            Hide();
            //Forms.sendForm.Show();
            Forms.authForm.Show();
        }
    }
}
