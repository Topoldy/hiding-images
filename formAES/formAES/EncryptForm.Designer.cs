namespace formAES
{
    partial class EncryptForm
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
            this.listBox_Images = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_add_image = new System.Windows.Forms.Button();
            this.button_delete_image = new System.Windows.Forms.Button();
            this.textBox_path_keys = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_encrypt_many = new System.Windows.Forms.Button();
            this.textBox_path_save = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_area = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButton_RGB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_ARGB = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_custom = new System.Windows.Forms.RadioButton();
            this.radioButton_100 = new System.Windows.Forms.RadioButton();
            this.label_block_size = new System.Windows.Forms.Label();
            this.textBox_block_offset = new System.Windows.Forms.TextBox();
            this.label_block_offset = new System.Windows.Forms.Label();
            this.textBox_block_size = new System.Windows.Forms.TextBox();
            this.groupBox_settings = new System.Windows.Forms.GroupBox();
            this.checkBox_settings = new System.Windows.Forms.CheckBox();
            this.textBox_logs = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_encrypt_one = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Images
            // 
            this.listBox_Images.FormattingEnabled = true;
            this.listBox_Images.Location = new System.Drawing.Point(12, 29);
            this.listBox_Images.Name = "listBox_Images";
            this.listBox_Images.Size = new System.Drawing.Size(480, 108);
            this.listBox_Images.TabIndex = 0;
            this.listBox_Images.SelectedIndexChanged += new System.EventHandler(this.ListImages_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "список картинок";
            // 
            // button_add_image
            // 
            this.button_add_image.Location = new System.Drawing.Point(312, 143);
            this.button_add_image.Name = "button_add_image";
            this.button_add_image.Size = new System.Drawing.Size(99, 23);
            this.button_add_image.TabIndex = 2;
            this.button_add_image.Text = "Добавить папку";
            this.button_add_image.UseVisualStyleBackColor = true;
            this.button_add_image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Add_image_button_MouseClick);
            // 
            // button_delete_image
            // 
            this.button_delete_image.Location = new System.Drawing.Point(417, 143);
            this.button_delete_image.Name = "button_delete_image";
            this.button_delete_image.Size = new System.Drawing.Size(75, 23);
            this.button_delete_image.TabIndex = 3;
            this.button_delete_image.Text = "Удалить";
            this.button_delete_image.UseVisualStyleBackColor = true;
            this.button_delete_image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Delete_image_button_MouseClick);
            // 
            // textBox_path_keys
            // 
            this.textBox_path_keys.Location = new System.Drawing.Point(6, 29);
            this.textBox_path_keys.Name = "textBox_path_keys";
            this.textBox_path_keys.Size = new System.Drawing.Size(116, 20);
            this.textBox_path_keys.TabIndex = 4;
            this.textBox_path_keys.Text = "keys\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Путь к файлам с ключами";
            // 
            // button_encrypt_many
            // 
            this.button_encrypt_many.Location = new System.Drawing.Point(364, 172);
            this.button_encrypt_many.Name = "button_encrypt_many";
            this.button_encrypt_many.Size = new System.Drawing.Size(128, 40);
            this.button_encrypt_many.TabIndex = 7;
            this.button_encrypt_many.Text = "Зашифровать все";
            this.button_encrypt_many.UseVisualStyleBackColor = true;
            this.button_encrypt_many.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Generate_and_encrypt_button_MouseClick);
            // 
            // textBox_path_save
            // 
            this.textBox_path_save.Location = new System.Drawing.Point(6, 72);
            this.textBox_path_save.Name = "textBox_path_save";
            this.textBox_path_save.Size = new System.Drawing.Size(116, 20);
            this.textBox_path_save.TabIndex = 8;
            this.textBox_path_save.Text = "encrypted images\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Путь сохранения результата";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "область шифрования";
            // 
            // textBox_area
            // 
            this.textBox_area.Location = new System.Drawing.Point(16, 192);
            this.textBox_area.Name = "textBox_area";
            this.textBox_area.ReadOnly = true;
            this.textBox_area.Size = new System.Drawing.Size(100, 20);
            this.textBox_area.TabIndex = 11;
            this.textBox_area.Text = "(0;0)(0;0)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 218);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // radioButton_RGB
            // 
            this.radioButton_RGB.AutoSize = true;
            this.radioButton_RGB.Location = new System.Drawing.Point(7, 19);
            this.radioButton_RGB.Name = "radioButton_RGB";
            this.radioButton_RGB.Size = new System.Drawing.Size(48, 17);
            this.radioButton_RGB.TabIndex = 13;
            this.radioButton_RGB.TabStop = true;
            this.radioButton_RGB.Text = "RGB";
            this.radioButton_RGB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_ARGB);
            this.groupBox1.Controls.Add(this.radioButton_RGB);
            this.groupBox1.Location = new System.Drawing.Point(498, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 71);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип пикселя";
            // 
            // radioButton_ARGB
            // 
            this.radioButton_ARGB.AutoSize = true;
            this.radioButton_ARGB.Location = new System.Drawing.Point(7, 43);
            this.radioButton_ARGB.Name = "radioButton_ARGB";
            this.radioButton_ARGB.Size = new System.Drawing.Size(55, 17);
            this.radioButton_ARGB.TabIndex = 14;
            this.radioButton_ARGB.TabStop = true;
            this.radioButton_ARGB.Text = "ARGB";
            this.radioButton_ARGB.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_custom);
            this.groupBox2.Controls.Add(this.radioButton_100);
            this.groupBox2.Location = new System.Drawing.Point(589, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 71);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Область шифрования";
            // 
            // radioButton_custom
            // 
            this.radioButton_custom.AutoSize = true;
            this.radioButton_custom.Location = new System.Drawing.Point(7, 43);
            this.radioButton_custom.Name = "radioButton_custom";
            this.radioButton_custom.Size = new System.Drawing.Size(73, 17);
            this.radioButton_custom.TabIndex = 1;
            this.radioButton_custom.TabStop = true;
            this.radioButton_custom.Text = "Настоить";
            this.radioButton_custom.UseVisualStyleBackColor = true;
            this.radioButton_custom.CheckedChanged += new System.EventHandler(this.RadioButton_custom_CheckedChanged);
            // 
            // radioButton_100
            // 
            this.radioButton_100.AutoSize = true;
            this.radioButton_100.Location = new System.Drawing.Point(7, 20);
            this.radioButton_100.Name = "radioButton_100";
            this.radioButton_100.Size = new System.Drawing.Size(51, 17);
            this.radioButton_100.TabIndex = 0;
            this.radioButton_100.TabStop = true;
            this.radioButton_100.Text = "100%";
            this.radioButton_100.UseVisualStyleBackColor = true;
            this.radioButton_100.CheckedChanged += new System.EventHandler(this.RadioButton_100_CheckedChanged);
            // 
            // label_block_size
            // 
            this.label_block_size.AutoSize = true;
            this.label_block_size.Location = new System.Drawing.Point(589, 112);
            this.label_block_size.Name = "label_block_size";
            this.label_block_size.Size = new System.Drawing.Size(82, 13);
            this.label_block_size.TabIndex = 16;
            this.label_block_size.Text = "Размер блока:";
            // 
            // textBox_block_offset
            // 
            this.textBox_block_offset.Location = new System.Drawing.Point(674, 134);
            this.textBox_block_offset.Name = "textBox_block_offset";
            this.textBox_block_offset.Size = new System.Drawing.Size(48, 20);
            this.textBox_block_offset.TabIndex = 19;
            this.textBox_block_offset.Text = "0";
            // 
            // label_block_offset
            // 
            this.label_block_offset.AutoSize = true;
            this.label_block_offset.Location = new System.Drawing.Point(543, 137);
            this.label_block_offset.Name = "label_block_offset";
            this.label_block_offset.Size = new System.Drawing.Size(128, 13);
            this.label_block_offset.TabIndex = 18;
            this.label_block_offset.Text = "Отступ между блоками:";
            // 
            // textBox_block_size
            // 
            this.textBox_block_size.Location = new System.Drawing.Point(674, 109);
            this.textBox_block_size.Name = "textBox_block_size";
            this.textBox_block_size.Size = new System.Drawing.Size(48, 20);
            this.textBox_block_size.TabIndex = 17;
            this.textBox_block_size.Text = "0";
            // 
            // groupBox_settings
            // 
            this.groupBox_settings.Controls.Add(this.textBox_path_keys);
            this.groupBox_settings.Controls.Add(this.label2);
            this.groupBox_settings.Controls.Add(this.textBox_path_save);
            this.groupBox_settings.Controls.Add(this.label4);
            this.groupBox_settings.Location = new System.Drawing.Point(498, 176);
            this.groupBox_settings.Name = "groupBox_settings";
            this.groupBox_settings.Size = new System.Drawing.Size(162, 103);
            this.groupBox_settings.TabIndex = 24;
            this.groupBox_settings.TabStop = false;
            this.groupBox_settings.Visible = false;
            // 
            // checkBox_settings
            // 
            this.checkBox_settings.AutoSize = true;
            this.checkBox_settings.Location = new System.Drawing.Point(505, 160);
            this.checkBox_settings.Name = "checkBox_settings";
            this.checkBox_settings.Size = new System.Drawing.Size(170, 17);
            this.checkBox_settings.TabIndex = 25;
            this.checkBox_settings.Text = "Дополнительные настройки";
            this.checkBox_settings.UseVisualStyleBackColor = true;
            this.checkBox_settings.CheckedChanged += new System.EventHandler(this.CheckBox_settings_CheckedChanged);
            // 
            // textBox_logs
            // 
            this.textBox_logs.Location = new System.Drawing.Point(498, 302);
            this.textBox_logs.Multiline = true;
            this.textBox_logs.Name = "textBox_logs";
            this.textBox_logs.Size = new System.Drawing.Size(301, 185);
            this.textBox_logs.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Отчёт";
            // 
            // button_encrypt_one
            // 
            this.button_encrypt_one.Location = new System.Drawing.Point(230, 172);
            this.button_encrypt_one.Name = "button_encrypt_one";
            this.button_encrypt_one.Size = new System.Drawing.Size(128, 40);
            this.button_encrypt_one.TabIndex = 28;
            this.button_encrypt_one.Text = "Зашифровать одну";
            this.button_encrypt_one.UseVisualStyleBackColor = true;
            this.button_encrypt_one.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button_encrypt_one_MouseClick);
            // 
            // EncryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 498);
            this.Controls.Add(this.button_encrypt_one);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_logs);
            this.Controls.Add(this.checkBox_settings);
            this.Controls.Add(this.groupBox_settings);
            this.Controls.Add(this.textBox_block_offset);
            this.Controls.Add(this.label_block_offset);
            this.Controls.Add(this.textBox_block_size);
            this.Controls.Add(this.label_block_size);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_area);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_encrypt_many);
            this.Controls.Add(this.button_delete_image);
            this.Controls.Add(this.button_add_image);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Images);
            this.Name = "EncryptForm";
            this.Text = "Шифрование";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EncryptForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_settings.ResumeLayout(false);
            this.groupBox_settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Images;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_add_image;
        private System.Windows.Forms.Button button_delete_image;
        private System.Windows.Forms.TextBox textBox_path_keys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_encrypt_many;
        private System.Windows.Forms.TextBox textBox_path_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_area;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButton_RGB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_ARGB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_custom;
        private System.Windows.Forms.RadioButton radioButton_100;
        private System.Windows.Forms.Label label_block_size;
        private System.Windows.Forms.TextBox textBox_block_offset;
        private System.Windows.Forms.Label label_block_offset;
        private System.Windows.Forms.TextBox textBox_block_size;
        private System.Windows.Forms.GroupBox groupBox_settings;
        private System.Windows.Forms.CheckBox checkBox_settings;
        private System.Windows.Forms.TextBox textBox_logs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_encrypt_one;
    }
}