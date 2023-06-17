
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
            this.SuspendLayout();
            // 
            // button_registration
            // 
            this.button_registration.Location = new System.Drawing.Point(13, 13);
            this.button_registration.Name = "button_registration";
            this.button_registration.Size = new System.Drawing.Size(110, 23);
            this.button_registration.TabIndex = 0;
            this.button_registration.Text = "Регистрация";
            this.button_registration.UseVisualStyleBackColor = true;
            this.button_registration.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_registration_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Пароль";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(89, 112);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(100, 22);
            this.textBox_password.TabIndex = 7;
            this.textBox_password.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Логин";
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(89, 84);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(100, 22);
            this.textBox_login.TabIndex = 5;
            this.textBox_login.Text = "1";
            // 
            // button_authentication
            // 
            this.button_authentication.Location = new System.Drawing.Point(56, 141);
            this.button_authentication.Name = "button_authentication";
            this.button_authentication.Size = new System.Drawing.Size(132, 23);
            this.button_authentication.TabIndex = 9;
            this.button_authentication.Text = "Аутентификация";
            this.button_authentication.UseVisualStyleBackColor = true;
            this.button_authentication.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_authentication_MouseClick);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(22, 174);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(0, 17);
            this.label_error.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "ip";
            // 
            // textBox_server_port
            // 
            this.textBox_server_port.Location = new System.Drawing.Point(258, 257);
            this.textBox_server_port.Name = "textBox_server_port";
            this.textBox_server_port.Size = new System.Drawing.Size(100, 22);
            this.textBox_server_port.TabIndex = 17;
            this.textBox_server_port.Text = "11555";
            // 
            // textBox_server_ip
            // 
            this.textBox_server_ip.Location = new System.Drawing.Point(258, 229);
            this.textBox_server_ip.Name = "textBox_server_ip";
            this.textBox_server_ip.Size = new System.Drawing.Size(100, 22);
            this.textBox_server_ip.TabIndex = 16;
            this.textBox_server_ip.Text = "192.168.0.113";
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 293);
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
            this.Name = "AuthForm";
            this.Text = "Вход";
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
    }
}