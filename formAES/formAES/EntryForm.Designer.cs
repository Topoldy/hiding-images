namespace formAES
{
    partial class EntryForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.encrypt_button = new System.Windows.Forms.Button();
            this.decrypt_button = new System.Windows.Forms.Button();
            this.send_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Приветствую! Выбери чем планируешь заниматься";
            // 
            // encrypt_button
            // 
            this.encrypt_button.Location = new System.Drawing.Point(103, 92);
            this.encrypt_button.Margin = new System.Windows.Forms.Padding(4);
            this.encrypt_button.Name = "encrypt_button";
            this.encrypt_button.Size = new System.Drawing.Size(184, 28);
            this.encrypt_button.TabIndex = 1;
            this.encrypt_button.Text = "Шифровать";
            this.encrypt_button.UseVisualStyleBackColor = true;
            this.encrypt_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Encrypt_button_MouseClick);
            // 
            // decrypt_button
            // 
            this.decrypt_button.Location = new System.Drawing.Point(103, 127);
            this.decrypt_button.Margin = new System.Windows.Forms.Padding(4);
            this.decrypt_button.Name = "decrypt_button";
            this.decrypt_button.Size = new System.Drawing.Size(184, 28);
            this.decrypt_button.TabIndex = 2;
            this.decrypt_button.Text = "Расшифровать";
            this.decrypt_button.UseVisualStyleBackColor = true;
            this.decrypt_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Decrypt_button_MouseClick);
            // 
            // send_button
            // 
            this.send_button.Location = new System.Drawing.Point(103, 164);
            this.send_button.Margin = new System.Windows.Forms.Padding(4);
            this.send_button.Name = "send_button";
            this.send_button.Size = new System.Drawing.Size(184, 28);
            this.send_button.TabIndex = 3;
            this.send_button.Text = "Отправить / получить";
            this.send_button.UseVisualStyleBackColor = true;
            this.send_button.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Send_button_MouseClick);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 303);
            this.Controls.Add(this.send_button);
            this.Controls.Add(this.decrypt_button);
            this.Controls.Add(this.encrypt_button);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EntryForm";
            this.Text = "Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button encrypt_button;
        private System.Windows.Forms.Button decrypt_button;
        private System.Windows.Forms.Button send_button;
    }
}

