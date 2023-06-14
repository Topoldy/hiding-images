
namespace formAES
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_registration = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.button_authentication = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_server_port = new System.Windows.Forms.TextBox();
            this.textBox_server_ip = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_registration
            // 
            this.button_registration.Location = new System.Drawing.Point(11, 11);
            this.button_registration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_registration.Name = "button_registration";
            this.button_registration.Size = new System.Drawing.Size(82, 22);
            this.button_registration.TabIndex = 0;
            this.button_registration.Text = "Регистрация";
            this.button_registration.UseVisualStyleBackColor = true;
            this.button_registration.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_registration_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Пароль";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(67, 91);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(76, 20);
            this.textBox_password.TabIndex = 7;
            this.textBox_password.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Логин";
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(67, 68);
            this.textBox_login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(76, 20);
            this.textBox_login.TabIndex = 5;
            this.textBox_login.Text = "1";
            // 
            // button_authentication
            // 
            this.button_authentication.Location = new System.Drawing.Point(67, 115);
            this.button_authentication.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_authentication.Name = "button_authentication";
            this.button_authentication.Size = new System.Drawing.Size(74, 27);
            this.button_authentication.TabIndex = 9;
            this.button_authentication.Text = "Войти";
            this.button_authentication.UseVisualStyleBackColor = true;
            this.button_authentication.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_authentication_MouseClick);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(16, 141);
            this.label_error.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(0, 13);
            this.label_error.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "ip";
            // 
            // textBox_server_port
            // 
            this.textBox_server_port.Location = new System.Drawing.Point(194, 209);
            this.textBox_server_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_server_port.Name = "textBox_server_port";
            this.textBox_server_port.Size = new System.Drawing.Size(76, 20);
            this.textBox_server_port.TabIndex = 17;
            this.textBox_server_port.Text = "11555";
            // 
            // textBox_server_ip
            // 
            this.textBox_server_ip.Location = new System.Drawing.Point(194, 186);
            this.textBox_server_ip.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_server_ip.Name = "textBox_server_ip";
            this.textBox_server_ip.Size = new System.Drawing.Size(76, 20);
            this.textBox_server_ip.TabIndex = 16;
            this.textBox_server_ip.Text = "192.168.0.113";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Сервер";
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 238);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_server_port);
            this.Controls.Add(this.textBox_server_ip);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.button_authentication);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.button_registration);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AuthForm";
            this.Text = "Аутентификация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AuthForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_registration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Button button_authentication;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_server_port;
        private System.Windows.Forms.TextBox textBox_server_ip;
        private System.Windows.Forms.Label label5;
    }
}