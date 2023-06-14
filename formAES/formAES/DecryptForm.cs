using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;
using System.Net.Sockets;

namespace formAES
{
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();

            string path = "encrypted images\\";

            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(
                    s =>
                    s.EndsWith(".png") ||
                    s.EndsWith(".bmp") ||
                    s.EndsWith(".tif") ||
                    s.EndsWith(".tiff") ||
                    s.EndsWith(".jpg") ||
                    s.EndsWith(".jpeg"));

                foreach (var file in files)
                {
                    int ii = file.LastIndexOf("\\") + 1;
                    string file_name = file.Substring(ii);
                    string file_path = file.Substring(0, file.Length - file_name.Length);

                    string path_key = textBox_path_keys.Text + file_name + ".key";
                    string isHaveKey = "";
                    if (File.Exists(path_key)) isHaveKey = "+";

                    ListViewItem lvi = new ListViewItem(new string[] { file_name, file_path, isHaveKey });
                    lvi.Tag = file_path;
                    listView_images.Items.Add(lvi);
                }

                textBox_logs.Text += $"\"{path}: найдено {listView_images.Items.Count}  изображений\"\r\n";
            }

        }

        private unsafe void readKey(ref byte[] buff_mode, ref byte[] buff_area, byte* key, string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                sr.BaseStream.Read(buff_mode, 0, 5);
                sr.BaseStream.Read(buff_area, 0, 8);

                byte[] buff = new byte[16];
                sr.BaseStream.Read(buff, 0, 16);

                for(int i = 0; i < 16; i++)
                {
                    key[i] = buff[i];
                }
            }
        }

        private void GetPixels(ref Bitmap img, ref byte[] buff, bool isCustomType, bool isARGB, int block_size, int block_offset, int x1, int y1, int x2, int y2)
        {
            int index = 0;

            if (isCustomType)
            {
                int offset = block_size + block_offset;
                int count_block_x = (x2 - x1 + block_size) / offset;
                int count_block_y = (y2 - y1 + block_size) / offset;

                for (int i_block = 0; i_block < count_block_x; i_block++)
                {
                    for (int j_block = 0; j_block < count_block_y; j_block++)
                    {
                        int tmp_block_size_x = i_block * offset + block_size;

                        for (int x = x1 + i_block * offset; x < x1 + tmp_block_size_x && x <= x2; x++)
                        {
                            int tmp_block_size_y = j_block * offset + block_size;

                            for (int y = y1 + j_block * offset; y < y1 + tmp_block_size_y && y <= y2; y++)
                            {
                                Color c = img.GetPixel(x, y);
                                if (isARGB) buff[index++] = c.A;
                                buff[index++] = c.R;
                                buff[index++] = c.G;
                                buff[index++] = c.B;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int x = x1; x <= x2; x++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        Color c = img.GetPixel(x, y);
                        if (isARGB) buff[index++] = c.A;
                        buff[index++] = c.R;
                        buff[index++] = c.G;
                        buff[index++] = c.B;
                    }
                }
            }
        }

        private void SetPixels(ref Bitmap img, ref byte[] buff, bool isCustomType, bool isARGB, int block_size, int block_offset, int x1, int y1, int x2, int y2)
        {
            int A;
            int index = 0;

            if (isCustomType)
            {
                int offset = block_size + block_offset;
                int count_block_x = (x2 - x1 + block_size) / offset;
                int count_block_y = (y2 - y1 + block_size) / offset;

                for (int i_block = 0; i_block < count_block_x; i_block++)
                {
                    for (int j_block = 0; j_block < count_block_y; j_block++)
                    {
                        int tmp_block_size_x = i_block * offset + block_size;

                        for (int x = x1 + i_block * offset; x < x1 + tmp_block_size_x && x <= x2; x++)
                        {
                            int tmp_block_size_y = j_block * offset + block_size;

                            for (int y = y1 + j_block * offset; y < y1 + tmp_block_size_y && y <= y2; y++)
                            {
                                if (isARGB)
                                {
                                    img.SetPixel(x, y, Color.FromArgb(buff[index++], buff[index++], buff[index++], buff[index++]));
                                }
                                else
                                {
                                    A = img.GetPixel(x, y).A;
                                    img.SetPixel(x, y, Color.FromArgb(A, buff[index++], buff[index++], buff[index++])); // buff[index++],
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int x = x1; x <= x2; x++)
                {
                    for (int y = y1; y <= y2; y++)
                    {
                        if (isARGB)
                        {
                            img.SetPixel(x, y, Color.FromArgb(buff[index++], buff[index++], buff[index++], buff[index++]));
                        }
                        else
                        {
                            A = img.GetPixel(x, y).A;
                            img.SetPixel(x, y, Color.FromArgb(A, buff[index++], buff[index++], buff[index++])); // buff[index++],
                        }
                    }
                }
            }
        }

        private unsafe void Decrypt_button_MouseClick(object sender, MouseEventArgs e)
        {
            string path_save = textBox_path_save.Text;

            int before_count = listView_images.Items.Count;

            byte[] buff_mode = new byte[5];
            byte[] buff_area = new byte[8];

            byte* key = stackalloc byte[16];

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose(); // картинку убираем
                pictureBox1.Image = null;
            }

            for (int i = 0; i < listView_images.Items.Count; i++)
            {
                string picture_name = listView_images.Items[i].Text;

                string path_key = textBox_path_keys.Text + picture_name + ".key";

                if (File.Exists(path_key))
                {
                    readKey(ref buff_mode, ref buff_area, key, path_key);

                    ImportAES.setKey(key);

                    bool isARGB;

                    if ((buff_mode[0] & 0b1) == 0b0)
                    {
                        isARGB = false;
                    }
                    else
                    {
                        isARGB = true;
                    }

                    bool isCustomType;

                    if ((buff_mode[0] & 0b10) == 0b00)
                    {
                        isCustomType = false;
                    }
                    else
                    {
                        isCustomType = true;
                    }

                    int block_size = (buff_mode[1] << 8) ^ buff_mode[2];
                    int block_offset = (buff_mode[3] << 8) ^ buff_mode[4];

                    int x1 = (buff_area[0] << 8) ^ buff_area[1];
                    int y1 = (buff_area[2] << 8) ^ buff_area[3];
                    int x2 = (buff_area[4] << 8) ^ buff_area[5];
                    int y2 = (buff_area[6] << 8) ^ buff_area[7];


                    int size;
                    if (isARGB)
                    {
                        size = 4 * (x2 - x1 + 1) * (y2 - y1 + 1);
                    }
                    else
                    {
                        size = 3 * (x2 - x1 + 1) * (y2 - y1 + 1);
                    }

                    byte[] bytes = new byte[size];
                    string path_img = listView_images.Items[i].Tag + picture_name;
                    Bitmap img = (Bitmap)Image.FromFile(path_img);


                    GetPixels(ref img, ref bytes, isCustomType, isARGB, block_size, block_offset, x1, y1, x2, y2);
                   
                    fixed (byte* buff = bytes)
                    {
                        ImportAES.decrypt(buff, bytes.Length / 16, true);
                    }

                    SetPixels(ref img, ref bytes, isCustomType, isARGB, block_size, block_offset, x1, y1, x2, y2);


                    ImageFormat imgForm;

                    bool isDeleteEncryptImg = false;

                    if (picture_name.EndsWith(".bmp"))
                    {
                        imgForm = ImageFormat.Bmp;
                    }
                    else if (picture_name.EndsWith(".tif") || picture_name.EndsWith(".tiff"))
                    {
                        imgForm = ImageFormat.Tiff;
                    }
                    else if (picture_name.EndsWith(".jpg") || picture_name.EndsWith(".jpeg"))
                    {
                        imgForm = ImageFormat.Jpeg;
                    }
                    else
                    {
                        imgForm = ImageFormat.Png;
                    }

                    img.Save(path_save + picture_name, imgForm);
                    img.Dispose();

                    if(isDeleteEncryptImg)
                    {
                        File.Delete(path_img); // удаляем картинку
                        File.Delete(path_key); // удаляем ключ
                    }

                    textBox_logs.Text += $"\"{textBox_path_save.Text}\": \"{picture_name}\" расшифрованно\r\n";

                    listView_images.Items.RemoveAt(i);
                    i--;
                }
            }

            textBox_logs.Text += $"\"{textBox_path_save.Text}\": расшифрованно {before_count - listView_images.Items.Count}  изображений\r\n";
        }

        private void Add_image_button_MouseClick(object sender, MouseEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                int before_count = listView_images.Items.Count;

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.TopDirectoryOnly).Where(
                        s =>
                        s.EndsWith(".png") ||
                        s.EndsWith(".bmp") ||
                        s.EndsWith(".tif") ||
                        s.EndsWith(".tiff") ||
                        s.EndsWith(".jpg") ||
                        s.EndsWith(".jpeg"));

                    foreach (var file in files)
                    {
                        int ii = file.LastIndexOf("\\") + 1;
                        string file_name = file.Substring(ii);
                        string file_path = file.Substring(0, file.Length - file_name.Length);

                        string path_key = textBox_path_keys.Text + file_name + ".key";
                        string isHaveKey = "";
                        if (File.Exists(path_key)) isHaveKey = "+";

                        ListViewItem lvi = new ListViewItem(new string[] { file_name, file_path, isHaveKey });
                        lvi.Tag = file_path;
                        listView_images.Items.Add(lvi);
                    }
                }

                textBox_logs.Text += $"\"{fbd.SelectedPath}\": добавлено {listView_images.Items.Count - before_count}  изображений\r\n";
            }
        }

        private void DecryptForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.entryForm.Show();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_images.SelectedItems.Count != 0)
            {
                string path = listView_images.SelectedItems[0].Tag as string;
                string file = listView_images.SelectedItems[0].Text;

                pictureBox1.Image = new Bitmap(path + file);
            }
        }

        private void Delete_image_button_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < listView_images.Items.Count; i++)
            {
                textBox_logs.Text += $"\"{listView_images.Items[i].Tag + listView_images.Items[i].Text}\" удалено\r\n";
                if (listView_images.Items[i].Selected)
                {
                    listView_images.Items.RemoveAt(i);
                    i--;
                }
            }
        }

        private void CheckBox_settings_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_settings.Checked)
            {
                groupBox_settings.Show();
            }
            else
            {
                groupBox_settings.Hide();
            }
        }
    }
}
