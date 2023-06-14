namespace formAES
{
    partial class DecryptForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_path_keys = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_decrypt = new System.Windows.Forms.Button();
            this.button_add_image = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView_images = new System.Windows.Forms.ListView();
            this.file = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.isHaveKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_delete_image = new System.Windows.Forms.Button();
            this.groupBox_settings = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_path_save = new System.Windows.Forms.TextBox();
            this.checkBox_settings = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_logs = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Путь к файлам с ключами";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "список картинок";
            // 
            // button_decrypt
            // 
            this.button_decrypt.Location = new System.Drawing.Point(496, 161);
            this.button_decrypt.Margin = new System.Windows.Forms.Padding(4);
            this.button_decrypt.Name = "button_decrypt";
            this.button_decrypt.Size = new System.Drawing.Size(160, 42);
            this.button_decrypt.TabIndex = 12;
            this.button_decrypt.Text = "Расшифровать все";
            this.button_decrypt.UseVisualStyleBackColor = true;
            this.button_decrypt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Decrypt_button_MouseClick);
            // 
            // button_add_image
            // 
            this.button_add_image.Location = new System.Drawing.Point(664, 34);
            this.button_add_image.Margin = new System.Windows.Forms.Padding(4);
            this.button_add_image.Name = "button_add_image";
            this.button_add_image.Size = new System.Drawing.Size(191, 28);
            this.button_add_image.TabIndex = 13;
            this.button_add_image.Text = "Добавить папку";
            this.button_add_image.UseVisualStyleBackColor = true;
            this.button_add_image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Add_image_button_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(16, 210);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(639, 331);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // listView_images
            // 
            this.listView_images.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.file,
            this.path,
            this.isHaveKey});
            this.listView_images.HideSelection = false;
            this.listView_images.Location = new System.Drawing.Point(21, 34);
            this.listView_images.Margin = new System.Windows.Forms.Padding(4);
            this.listView_images.Name = "listView_images";
            this.listView_images.Size = new System.Drawing.Size(633, 118);
            this.listView_images.TabIndex = 21;
            this.listView_images.UseCompatibleStateImageBehavior = false;
            this.listView_images.View = System.Windows.Forms.View.Details;
            this.listView_images.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
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
            // button_delete_image
            // 
            this.button_delete_image.Location = new System.Drawing.Point(664, 70);
            this.button_delete_image.Margin = new System.Windows.Forms.Padding(4);
            this.button_delete_image.Name = "button_delete_image";
            this.button_delete_image.Size = new System.Drawing.Size(191, 28);
            this.button_delete_image.TabIndex = 22;
            this.button_delete_image.Text = "Убрать изображение";
            this.button_delete_image.UseVisualStyleBackColor = true;
            this.button_delete_image.Visible = false;
            this.button_delete_image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Delete_image_button_MouseClick);
            // 
            // groupBox_settings
            // 
            this.groupBox_settings.Controls.Add(this.label4);
            this.groupBox_settings.Controls.Add(this.textBox_path_save);
            this.groupBox_settings.Controls.Add(this.label2);
            this.groupBox_settings.Controls.Add(this.textBox_path_keys);
            this.groupBox_settings.Location = new System.Drawing.Point(664, 134);
            this.groupBox_settings.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_settings.Name = "groupBox_settings";
            this.groupBox_settings.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_settings.Size = new System.Drawing.Size(243, 121);
            this.groupBox_settings.TabIndex = 23;
            this.groupBox_settings.TabStop = false;
            this.groupBox_settings.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Путь для сохранения результата";
            // 
            // textBox_path_save
            // 
            this.textBox_path_save.Location = new System.Drawing.Point(8, 87);
            this.textBox_path_save.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_path_save.Name = "textBox_path_save";
            this.textBox_path_save.Size = new System.Drawing.Size(153, 22);
            this.textBox_path_save.TabIndex = 13;
            this.textBox_path_save.Text = "decrypted images\\";
            // 
            // checkBox_settings
            // 
            this.checkBox_settings.AutoSize = true;
            this.checkBox_settings.Location = new System.Drawing.Point(664, 106);
            this.checkBox_settings.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_settings.Name = "checkBox_settings";
            this.checkBox_settings.Size = new System.Drawing.Size(101, 21);
            this.checkBox_settings.TabIndex = 24;
            this.checkBox_settings.Text = "Настройки";
            this.checkBox_settings.UseVisualStyleBackColor = true;
            this.checkBox_settings.CheckedChanged += new System.EventHandler(this.CheckBox_settings_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(665, 314);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Отчёт";
            // 
            // textBox_logs
            // 
            this.textBox_logs.Location = new System.Drawing.Point(664, 334);
            this.textBox_logs.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_logs.Multiline = true;
            this.textBox_logs.Name = "textBox_logs";
            this.textBox_logs.Size = new System.Drawing.Size(385, 208);
            this.textBox_logs.TabIndex = 28;
            // 
            // DecryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBox_settings);
            this.Controls.Add(this.textBox_logs);
            this.Controls.Add(this.groupBox_settings);
            this.Controls.Add(this.button_delete_image);
            this.Controls.Add(this.listView_images);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_add_image);
            this.Controls.Add(this.button_decrypt);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DecryptForm";
            this.Text = "DecryptForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DecryptForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_settings.ResumeLayout(false);
            this.groupBox_settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_path_keys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_decrypt;
        private System.Windows.Forms.Button button_add_image;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView_images;
        private System.Windows.Forms.ColumnHeader file;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.ColumnHeader isHaveKey;
        private System.Windows.Forms.Button button_delete_image;
        private System.Windows.Forms.GroupBox groupBox_settings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_path_save;
        private System.Windows.Forms.CheckBox checkBox_settings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_logs;
    }
}