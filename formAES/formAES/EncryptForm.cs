using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace formAES
{
    public partial class EncryptForm : Form
    {
        Point mouse_down_location;
        Point mouse_up_location;
        Point shift_image;

        float img_width;
        float img_height;
        float zoom;
        Bitmap bitmap;
        ToolTip toolTip; 

        Rectangle rectangle_selected;

        public EncryptForm()
        {
            InitializeComponent();

            button_delete_image.Hide();
            button_encrypt_one.Hide();
            button_encrypt_many.Hide();

            radioButton_100.Select();
            radioButton_RGB.Select();

            shift_image = new Point();
            rectangle_selected = new Rectangle(0, 0, 0, 0);

            toolTip = new ToolTip();
            toolTip.SetToolTip(button_encrypt_many, "Шифрует картинки с одинаковым размером");
            toolTip.SetToolTip(button_encrypt_one, "Шифрует только выбранную картинку");

            string path = "images\\";

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
                    listBox_Images.Items.Add(file);
                }
            }
            textBox_logs.Text += $"\"{path}\": найдено {listBox_Images.Items.Count}  изображений\r\n";
        }

        private Rectangle ToRectangle(Point p1, Point p2)
        {
            return new Rectangle(Math.Min(p1.X, p2.X), 
                Math.Min(p1.Y, p2.Y), 
                Math.Max(p1.X, p2.X) - Math.Min(p1.X, p2.X), 
                Math.Max(p1.Y, p2.Y) - Math.Min(p1.Y, p2.Y));
        }

        private void Add_image_button_MouseClick(object sender, MouseEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                int before_count = listBox_Images.Items.Count;

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    var files = Directory.GetFiles(fbd.SelectedPath, "*.*", SearchOption.TopDirectoryOnly).Where(
                    s =>
                    s.EndsWith(".png") ||
                    s.EndsWith(".bmp") ||
                    s.EndsWith(".tif") ||
                    s.EndsWith(".tiff")||
                    s.EndsWith(".jpg") ||
                    s.EndsWith(".jpeg"));


                    foreach(var file in files)
                    {
                        listBox_Images.Items.Add(file);
                    }
                }

                textBox_logs.Text += $"\"{fbd.SelectedPath}\": добавлено {listBox_Images.Items.Count - before_count}  изображений\r\n";
            }
        }

        private unsafe void SaveKey(byte[] buff_mode, byte[] buff_area, byte* key, string path)
        {
            using (StreamWriter sw = new StreamWriter(path + ".key"))
            {
                sw.BaseStream.Write(buff_mode, 0, 5);
                sw.BaseStream.Write(buff_area, 0, 8);

                for (int i = 0; i < 16; i++)
                {
                    sw.BaseStream.WriteByte(key[i]);
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

            if(isCustomType)
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

        private unsafe bool GetArgs(out byte[] buff_mode, out byte[] buff_area, out bool isCustomType, out bool isARGB, out int size, out int block_size, out int block_offset, out int x1, out int y1, out int x2, out int y2)
        {
            Regex area_regex = new Regex(@"\((?'x1'\d+)\;(?'y1'\d+)\)\((?'x2'\d+)\;(?'y2'\d+)\)");

            Match res = area_regex.Match(textBox_area.Text);
            x1 = Int32.Parse(res.Groups["x1"].Value);
            y1 = Int32.Parse(res.Groups["y1"].Value);
            x2 = Int32.Parse(res.Groups["x2"].Value);
            y2 = Int32.Parse(res.Groups["y2"].Value);

            size = (x2 - x1 + 1) * (y2 - y1 + 1);

            buff_area = new byte[8];
            buff_mode = new byte[5];

            if (!(size > 0 && listBox_Images.SelectedIndex != -1))
            {
                isARGB = false;
                isCustomType = false;
                block_offset = 0;
                block_size = 0;

                return false;
            }

            buff_area[0] = Convert.ToByte(x1 >> 8);
            buff_area[1] = Convert.ToByte(x1 % 256);

            buff_area[2] = Convert.ToByte(y1 >> 8);
            buff_area[3] = Convert.ToByte(y1 % 256);

            buff_area[4] = Convert.ToByte(x2 >> 8);
            buff_area[5] = Convert.ToByte(x2 % 256);

            buff_area[6] = Convert.ToByte(y2 >> 8);
            buff_area[7] = Convert.ToByte(y2 % 256);

            buff_mode[0] = 0;


            isARGB = false;
            if (radioButton_RGB.Checked)
            {
                buff_mode[0] ^= 0b0;
            }
            else if (radioButton_ARGB.Checked)
            {
                buff_mode[0] ^= 0b1;
                isARGB = true;
            }

            isCustomType = false;
            if (radioButton_100.Checked)
            {
                buff_mode[0] ^= 0b00;
            }
            else if (radioButton_custom.Checked)
            {
                buff_mode[0] ^= 0b10;
                isCustomType = true;
            }

            block_size = int.Parse(0 + textBox_block_size.Text);
            block_offset = int.Parse(0 + textBox_block_offset.Text);


            if (isCustomType)
            {
                if (block_size <= 0)
                {
                    MessageBox.Show($"размер блока не может быть равен {block_size}");
                    return false;
                }
                if (block_offset <= 0)
                {
                    MessageBox.Show($"отступ между блоками не может быть равен {block_offset}");
                    return false;
                }

                buff_mode[1] = Convert.ToByte(block_size >> 8);
                buff_mode[2] = Convert.ToByte(block_size % 256);

                buff_mode[3] = Convert.ToByte(block_offset >> 8);
                buff_mode[4] = Convert.ToByte(block_offset % 256);
            }
            else
            {
                buff_mode[1] = 0;
                buff_mode[2] = 0;

                buff_mode[3] = 0;
                buff_mode[4] = 0;
            }


            if (isARGB)
            {
                size *= 4;
            }
            else
            {
                size *= 3;
            }


            return true;
        }

        private unsafe void Generate_and_encrypt_button_MouseClick(object sender, MouseEventArgs e)
        {
            button_delete_image.Hide();
            button_encrypt_one.Hide();
            button_encrypt_many.Hide();

            byte[] buff_mode;
            byte[] buff_area;
            byte* key = stackalloc byte[16];

            bool isCustomType;
            bool isARGB;

            int size;

            int block_size;
            int block_offset;
            int x1;
            int y1;
            int x2;
            int y2;

            int before_count = listBox_Images.Items.Count;

            bool isGood = GetArgs(out buff_mode, out buff_area, out isCustomType, out isARGB, out size, out block_size, out block_offset, out x1, out y1, out x2, out y2);


            if (isGood)
            {
                byte[] bytes = new byte[size];
                for (int i = 0; i < listBox_Images.Items.Count; i++)
                {
                    string img_str = listBox_Images.Items[i].ToString();

                    // будем шифровать только картинки с такой же формой
                    if (Image.FromFile(img_str).Size == bitmap.Size)
                    {
                        Bitmap img = (Bitmap)Image.FromFile(img_str);

                        key = ImportAES.generateKey(); // генерируем ключ
                        ImportAES.setKey(key); // устанавливаем ключ


                        GetPixels(ref img, ref bytes, isCustomType, isARGB, block_size, block_offset, x1, y1, x2, y2);

                        fixed (byte* buff = bytes)
                        {
                            ImportAES.encrypt(buff, bytes.Length / 16, true); // шифруем
                        }

                        SetPixels(ref img, ref bytes, isCustomType, isARGB, block_size, block_offset, x1, y1, x2, y2); ;


                        int ii = img_str.LastIndexOf("\\") + 1;
                        string picture_name = img_str.Substring(ii);

                        img.Save(textBox_path_save.Text + picture_name, ImageFormat.Png); // сохраняем в пнг формате картинку
                        SaveKey(buff_mode, buff_area, key, textBox_path_keys.Text + picture_name); // сохраняем ключ

                        listBox_Images.Items.RemoveAt(i); // удаляем из списка только что зашифрованную картинку
                        i--;
                        img.Dispose();
                    }
                }

                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;

                textBox_logs.Text += $"\"{textBox_path_save.Text}\": зашифровано {before_count - listBox_Images.Items.Count}  изображений\r\n";
            }
        }

        private unsafe void button_encrypt_one_MouseClick(object sender, MouseEventArgs e)
        {
            button_delete_image.Hide();
            button_encrypt_one.Hide();
            button_encrypt_many.Hide();

            byte[] buff_mode;
            byte[] buff_area;
            byte* key = stackalloc byte[16];

            bool isCustomType;
            bool isARGB;

            int size;

            int block_size;
            int block_offset;
            int x1;
            int y1;
            int x2;
            int y2;

            bool isGood = GetArgs(out buff_mode, out buff_area, out isCustomType, out isARGB, out size, out block_size, out block_offset, out x1, out y1, out x2, out y2);

            if (isGood)
            {
                byte[] bytes = new byte[size];

                int i = listBox_Images.SelectedIndex;

                string img_str = listBox_Images.Items[i].ToString();

                Bitmap img = (Bitmap)Image.FromFile(img_str);

                key = ImportAES.generateKey(); // генерируем ключ
                ImportAES.setKey(key); // устанавливаем ключ


                GetPixels(ref img, ref bytes, isCustomType, isARGB, block_size, block_offset, x1, y1, x2, y2);

                fixed (byte* buff = bytes)
                {
                    ImportAES.encrypt(buff, bytes.Length / 16, true); // шифруем
                }

                SetPixels(ref img, ref bytes, isCustomType, isARGB, block_size, block_offset, x1, y1, x2, y2); ;


                int ii = img_str.LastIndexOf("\\") + 1;
                string picture_name = img_str.Substring(ii);

                img.Save(textBox_path_save.Text + picture_name, ImageFormat.Png); // сохраняем в пнг формате картинку
                SaveKey(buff_mode, buff_area, key, textBox_path_keys.Text + picture_name); // сохраняем ключ

                listBox_Images.Items.RemoveAt(i); // удаляем из списка только что зашифрованную картинку
                   
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;

                textBox_logs.Text += $"\"{textBox_path_save.Text}\": зашифровано {1}  изображение\r\n";
            }
        }

        private void Delete_image_button_MouseClick(object sender, MouseEventArgs e)
        {
            if(listBox_Images.SelectedIndex != -1)
            {
                textBox_logs.Text += $"\"{listBox_Images.Items[listBox_Images.SelectedIndex]}\" удалено\r\n";

                button_delete_image.Hide();
                button_encrypt_one.Hide();
                button_encrypt_many.Hide();

                listBox_Images.Items.RemoveAt(listBox_Images.SelectedIndex);

                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private void ListImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox_Images.SelectedIndex != -1)
            {
                button_delete_image.Show();
                button_encrypt_one.Show();
                button_encrypt_many.Show();

                rectangle_selected = new Rectangle(0, 0, 0, 0);
                bitmap = new Bitmap(listBox_Images.Items[listBox_Images.SelectedIndex].ToString());
                pictureBox1.Image = bitmap;

                // вычисляем сдвиг картинки в pictureBox1
                img_width = pictureBox1.Image.Size.Width;
                img_height = pictureBox1.Image.Size.Height;

                float a = img_width / pictureBox1.Width; // соотношение ширины картинки и ширины pictureBox1
                float b = img_height / pictureBox1.Height; // соотношение высоты картинки и высоты pictureBox1

                if (a > b)
                {
                    zoom = a;
                    shift_image.X = 0;
                    float c = pictureBox1.Height / (a / b);

                    shift_image.Y = Convert.ToInt32(Math.Round((pictureBox1.Height - c) / 2));
                }
                else
                {
                    zoom = b;
                    shift_image.Y = 0;
                    float c = pictureBox1.Width / (b / a);

                    shift_image.X = Convert.ToInt32(Math.Round((pictureBox1.Width - c) / 2));
                }
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (listBox_Images.SelectedIndex != -1)
            {
                if (!isInImage(e.Location))
                {
                    MessageBox.Show("Вы не попали по картинке");
                }
                else
                {
                    mouse_down_location = e.Location;
                }
            }
        }

        private bool isInImage(Point p)
        {
            return p.X >= shift_image.X && p.Y >= shift_image.Y &&
                p.X <= pictureBox1.Width - shift_image.X && p.Y <= pictureBox1.Height - shift_image.Y;
        }

        private byte ToByte(int number)
        {
            return Convert.ToByte((number + 256) % 256);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (listBox_Images.SelectedIndex != -1)
            {
                if (!isInImage(e.Location))
                {
                    MessageBox.Show("Вы вышли за пределы картинки");
                }
                else
                {
                    mouse_up_location = e.Location;

                    if(!rectangle_selected.IsEmpty)
                    {

                        for (int x = rectangle_selected.X; x <= rectangle_selected.X + rectangle_selected.Size.Width; x++)
                        {
                            for (int y = rectangle_selected.Y; y <= rectangle_selected.Y + rectangle_selected.Size.Height; y++)
                            {
                                Color c = bitmap.GetPixel(x, y);

                                bitmap.SetPixel(x, y, Color.FromArgb(ToByte(c.A + 128), ToByte(c.R + 128), ToByte(c.G + 128), ToByte(c.B + 128)));
                            }
                        }
                    }

                    Point p1 = new Point(
                        Convert.ToInt32(Math.Round((mouse_down_location.X - shift_image.X) * zoom)),
                        Convert.ToInt32(Math.Round((mouse_down_location.Y - shift_image.Y) * zoom)));

                    Point p2 = new Point(
                        Convert.ToInt32(Math.Round((mouse_up_location.X - shift_image.X) * zoom)),
                        Convert.ToInt32(Math.Round((mouse_up_location.Y - shift_image.Y) * zoom)));

                    rectangle_selected = ToRectangle(p1, p2);

                    for (int x = rectangle_selected.X; x <= rectangle_selected.X + rectangle_selected.Size.Width; x++)
                    {
                        for (int y = rectangle_selected.Y; y <= rectangle_selected.Y + rectangle_selected.Size.Height; y++)
                        {
                            Color c = bitmap.GetPixel(x, y);

                            bitmap.SetPixel(x, y, Color.FromArgb(ToByte(c.A - 128), ToByte(c.R - 128), ToByte(c.G - 128), ToByte(c.B - 128)));
                        }
                    }

                    pictureBox1.Refresh();

                    textBox_area.Text = $"({rectangle_selected.X};{rectangle_selected.Y})({rectangle_selected.X + rectangle_selected.Width};{rectangle_selected.Y + rectangle_selected.Height})";
                }
            }
        }

        private void RadioButton_100_CheckedChanged(object sender, EventArgs e)
        {
            label_block_size.Hide();
            textBox_block_size.Hide();

            label_block_offset.Hide();
            textBox_block_offset.Hide();
        }

        private void RadioButton_custom_CheckedChanged(object sender, EventArgs e)
        {
            label_block_size.Show();
            textBox_block_size.Show();

            label_block_offset.Show();
            textBox_block_offset.Show();
        }

        private void EncryptForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Forms.entryForm.Show();
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
