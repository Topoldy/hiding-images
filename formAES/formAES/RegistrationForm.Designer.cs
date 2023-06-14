
namespace formAES
{
    partial class RegistrationForm
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
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_error = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_registration
            // 
            this.button_registration.Location = new System.Drawing.Point(36, 102);
            this.button_registration.Margin = new System.Windows.Forms.Padding(2);
            this.button_registration.Name = "button_registration";
            this.button_registration.Size = new System.Drawing.Size(126, 32);
            this.button_registration.TabIndex = 0;
            this.button_registration.Text = "Зарегистрироваться";
            this.button_registration.UseVisualStyleBackColor = true;
            this.button_registration.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_registration_MouseClick);
            // 
            // textBox_login
            // 
            this.textBox_login.Location = new System.Drawing.Point(86, 55);
            this.textBox_login.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(76, 20);
            this.textBox_login.TabIndex = 1;
            this.textBox_login.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(86, 78);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(76, 20);
            this.textBox_password.TabIndex = 3;
            this.textBox_password.Text = "1";
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.Location = new System.Drawing.Point(11, 145);
            this.label_error.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(0, 13);
            this.label_error.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Регистрация";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 167);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_login);
            this.Controls.Add(this.button_registration);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegistrationForm";
            this.Text = "Регистрация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_registration;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.Label label4;
    }
}