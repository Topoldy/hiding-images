﻿
namespace formAES
{
    partial class SendForm
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
            System.Windows.Forms.Button button_checkForConnection;
            this.listView1 = new System.Windows.Forms.ListView();
            this.file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isHaveKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_settings = new System.Windows.Forms.CheckBox();
            this.button_send_keys = new System.Windows.Forms.Button();
            this.button_send_images = new System.Windows.Forms.Button();
            this.textBox_path_keys = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_path_encrypted_images = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_settings = new System.Windows.Forms.GroupBox();
            this.textBox_checkForConnection = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_logs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            button_checkForConnection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_checkForConnection
            // 
            button_checkForConnection.Location = new System.Drawing.Point(118, 138);
            button_checkForConnection.Name = "button_checkForConnection";
            button_checkForConnection.Size = new System.Drawing.Size(95, 44);
            button_checkForConnection.TabIndex = 33;
            button_checkForConnection.Text = "Онлайн?";
            button_checkForConnection.UseVisualStyleBackColor = true;
            button_checkForConnection.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_checkForConnection_MouseClick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.file,
            this.path,
            this.isHaveKey});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 13);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(639, 118);
            this.listView1.TabIndex = 25;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // file
            // 
            this.file.Text = "Изображение";
            this.file.Width = 148;
            // 
            // path
            // 
            this.path.Text = "Путь к файлу";
            this.path.Width = 262;
            // 
            // isHaveKey
            // 
            this.isHaveKey.Text = "Ключ";
            this.isHaveKey.Width = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(13, 189);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(639, 331);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, -40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "список картинок";
            // 
            // checkBox_settings
            // 
            this.checkBox_settings.AutoSize = true;
            this.checkBox_settings.Location = new System.Drawing.Point(684, 13);
            this.checkBox_settings.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_settings.Name = "checkBox_settings";
            this.checkBox_settings.Size = new System.Drawing.Size(101, 21);
            this.checkBox_settings.TabIndex = 32;
            this.checkBox_settings.Text = "Настройки";
            this.checkBox_settings.UseVisualStyleBackColor = true;
            // 
            // button_send_keys
            // 
            this.button_send_keys.Location = new System.Drawing.Point(494, 138);
            this.button_send_keys.Name = "button_send_keys";
            this.button_send_keys.Size = new System.Drawing.Size(158, 44);
            this.button_send_keys.TabIndex = 27;
            this.button_send_keys.Text = "Отправить ключи";
            this.button_send_keys.UseVisualStyleBackColor = true;
            this.button_send_keys.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_send_keys_MouseClick);
            // 
            // button_send_images
            // 
            this.button_send_images.Location = new System.Drawing.Point(330, 138);
            this.button_send_images.Name = "button_send_images";
            this.button_send_images.Size = new System.Drawing.Size(158, 44);
            this.button_send_images.TabIndex = 28;
            this.button_send_images.Text = "Отправить картинки";
            this.button_send_images.UseVisualStyleBackColor = true;
            this.button_send_images.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_send_images_MouseClick);
            // 
            // textBox_path_keys
            // 
            this.textBox_path_keys.Location = new System.Drawing.Point(8, 34);
            this.textBox_path_keys.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_path_keys.Name = "textBox_path_keys";
            this.textBox_path_keys.Size = new System.Drawing.Size(153, 22);
            this.textBox_path_keys.TabIndex = 9;
            this.textBox_path_keys.Text = "keys\\";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Путь к файлам с ключами";
            // 
            // textBox_path_encrypted_images
            // 
            this.textBox_path_encrypted_images.Location = new System.Drawing.Point(8, 87);
            this.textBox_path_encrypted_images.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_path_encrypted_images.Name = "textBox_path_encrypted_images";
            this.textBox_path_encrypted_images.Size = new System.Drawing.Size(153, 22);
            this.textBox_path_encrypted_images.TabIndex = 13;
            this.textBox_path_encrypted_images.Text = "encrypted images\\";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Путь с зашиф. картинками";
            // 
            // groupBox_settings
            // 
            this.groupBox_settings.Controls.Add(this.label5);
            this.groupBox_settings.Controls.Add(this.textBox_path_encrypted_images);
            this.groupBox_settings.Controls.Add(this.label6);
            this.groupBox_settings.Controls.Add(this.textBox_path_keys);
            this.groupBox_settings.Location = new System.Drawing.Point(684, 40);
            this.groupBox_settings.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_settings.Name = "groupBox_settings";
            this.groupBox_settings.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_settings.Size = new System.Drawing.Size(243, 121);
            this.groupBox_settings.TabIndex = 31;
            this.groupBox_settings.TabStop = false;
            this.groupBox_settings.Visible = false;
            // 
            // textBox_checkForConnection
            // 
            this.textBox_checkForConnection.Location = new System.Drawing.Point(12, 160);
            this.textBox_checkForConnection.Name = "textBox_checkForConnection";
            this.textBox_checkForConnection.Size = new System.Drawing.Size(100, 22);
            this.textBox_checkForConnection.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Пользователь:";
            // 
            // textBox_logs
            // 
            this.textBox_logs.Location = new System.Drawing.Point(660, 303);
            this.textBox_logs.Multiline = true;
            this.textBox_logs.Name = "textBox_logs";
            this.textBox_logs.ReadOnly = true;
            this.textBox_logs.Size = new System.Drawing.Size(267, 216);
            this.textBox_logs.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(657, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 38;
            this.label3.Text = "отчёт";
            // 
            // SendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 531);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_logs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_checkForConnection);
            this.Controls.Add(button_checkForConnection);
            this.Controls.Add(this.checkBox_settings);
            this.Controls.Add(this.groupBox_settings);
            this.Controls.Add(this.button_send_images);
            this.Controls.Add(this.button_send_keys);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "SendForm";
            this.Text = "SendForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_settings.ResumeLayout(false);
            this.groupBox_settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader file;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader isHaveKey;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_settings;
        private System.Windows.Forms.Button button_send_keys;
        private System.Windows.Forms.Button button_send_images;
        private System.Windows.Forms.TextBox textBox_path_keys;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_path_encrypted_images;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox_settings;
        private System.Windows.Forms.TextBox textBox_checkForConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_logs;
        private System.Windows.Forms.Label label3;
    }
}