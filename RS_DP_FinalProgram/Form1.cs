using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS_DP_FinalProgram
{
    public partial class Form1 : Form
    {
        int File_Count = 0;//打开图像计数
        int Band_Count = 0;//当前图像波段计数
        public int W = 0;//当前图像宽
        public int H = 0;//当前图像高
        Bitmap[] Image;//当前图像波段序列
        string[] Files;//文件名序列
        string[] Bands;//波段名序列
        public Bitmap band_R, band_G, band_B, band_S;

        public Form1()
        {
            InitializeComponent();
        }

        private void RS_DP_FinalProgram_Load(object sender, EventArgs e)
        {

        }

        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "普通图像 |*.jpg;*.jepg;*.png;*.bmp;*.gif|遥感数字图像|*.hdr";
            //openFileDialog1.Multiselect = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                //更新文件序列
                if(File_Count==0)
                {
                    File_Count++;
                    Files = new string[1];
                    Files[0] = openFileDialog1.FileName;
                }
                else if(File_Count>0)
                {
                    File_Count++;
                    string[] temp = Files;
                    Files = new string[File_Count];

                    for (int i = 0; i < File_Count - 1; i++)
                        Files[i] = temp[i];

                    Files[File_Count - 1] = openFileDialog1.FileName;
                }
                //在TextBox1中显示文件名
                textBox1.Clear();//清屏
                string Content=Files[0];

                for(int i=1;i<File_Count;i++)
                {
                    Content += "\r\n";
                    Content += Files[i];
                }

                textBox1.Text = Content;
                //在ComboBox5中插入文件名
                comboBox5.Items.Add(openFileDialog1.FileName);

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Band_Count; i++)
            {
                if (comboBox2.Text == Bands[i])
                {
                    band_G = Image[i];
                    break;
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i=0;i<Band_Count;i++)
            {
                if (comboBox4.Text == Bands[i])
                {
                    band_S = Image[i];
                    break;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Band_Count; i++)
            {
                if (comboBox1.Text == Bands[i])
                {
                    band_R = Image[i];
                    break;
                }
            }
        }
        //计算OIF
        private void button2_Click(object sender, EventArgs e)
        {
            //判断波段是否选择
            if (band_R != null && band_G != null && band_B != null)
            {
                double OIF_part1, OIF_part2;
                Bitmap_Process b1, b2, b3;
                b1 = new Bitmap_Process(band_R);
                b2 = new Bitmap_Process(band_G);
                b3 = new Bitmap_Process(band_B);
                //计算
                OIF_part1 = (Math.Sqrt(b1.Variance) + Math.Sqrt(b2.Variance) + Math.Sqrt(b3.Variance));//OIF分子
                OIF_part2 = Math.Abs(b1.Calculate_RelatedCoefficient(band_G)) + Math.Abs(b1.Calculate_RelatedCoefficient(band_B)) + Math.Abs(b2.Calculate_RelatedCoefficient(band_B));
                //显示
                textBox3.Text = string.Format("{0:N3}", OIF_part1 / OIF_part2);
            }
            else
                MessageBox.Show("Please Select Band!","WARNING");
             
        }
        //显示灰阶图像
        private void button1_Click(object sender, EventArgs e)
        {
            if (band_S != null)
            {
                Show_Image new_Form1 = new Show_Image(band_S, 1);
                new_Form1.Show();
            }
            else
                MessageBox.Show("Please Select Band!", "WARNING");
        }
        //显示彩色图像
        private void button3_Click(object sender, EventArgs e)
        {
            //合成后图像
            Bitmap Synthesis_Image = new Bitmap(W, H);
            
            if (band_R != null && band_G != null && band_B != null)
            {
                Color temp;
                //合成
                for(int i=0;i<W;i++)
                {
                    for(int j=0;j<H;j++)
                    {
                        temp = Color.FromArgb(band_R.GetPixel(i, j).R, band_G.GetPixel(i, j).G, band_B.GetPixel(i, j).B);
                        Synthesis_Image.SetPixel(i, j, temp);
                    }
                }
                //新建窗口显示
                Show_Image new_Form2 = new Show_Image(Synthesis_Image, 3);
                new_Form2.Show();
            }
            else
                MessageBox.Show("Please Select Band!", "WARNING");
        }
        
        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Egg Form = new Egg();
            Form.Show();
        }
        //波段运算
        private void bandMathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "")
            {
                MessageBox.Show("Please Select Image", "WARNING");
            }
            else
            {
                Band_Math Math_Form = new Band_Math(Bands, Band_Count, Image);
                Math_Form.Show();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Band_Count; i++)
            {
                if (comboBox3.Text == Bands[i])
                {
                    band_B = Image[i];
                    break;
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取当前文件名
            int Current_Image = 0;

            for(int i=0;i<File_Count;i++)
            {
                if (comboBox5.Text == Files[i])
                    Current_Image = i;
            }
            //清空各控件中的值
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            //判断文件类型并建立波段序列
            //遥感图像格式
            if (Files[Current_Image].Contains(".hdr"))
            {
                //***************************文件读取*****************************//

            }
            //一般图像格式
            else
            {
                int R, G, B;
                Color temp;
                //初始化波段序列
                Band_Count = 3;
                Bitmap bitmap = new Bitmap(Files[Current_Image]);
                Bands = new string[Band_Count];
                Image = new Bitmap[Band_Count];
                H = bitmap.Height;
                W = bitmap.Width;

                for(int i=0;i<Band_Count;i++)
                {
                    Image[i] = new Bitmap(W, H);
                }

                for(int i=0;i<W;i++)
                {
                    for(int j=0;j<H;j++)
                    {
                        R = bitmap.GetPixel(i, j).R;
                        G = bitmap.GetPixel(i, j).G;
                        B = bitmap.GetPixel(i, j).B;
                        //R波段
                        temp = Color.FromArgb(R, R, R);
                        Image[0].SetPixel(i, j, temp);
                        //G波段
                        temp = Color.FromArgb(G, G, G);
                        Image[1].SetPixel(i, j, temp);
                        //B波段
                        temp = Color.FromArgb(B, B, B);
                        Image[2].SetPixel(i, j, temp);
                    }
                }
                //将波段序列信息同步到各控件
                //在TextBox2中显示波段数和波段名
                textBox2.Clear();

                for (int i = 0; i < Band_Count; i++)
                {
                    Bands[i] = "b" + string.Format("{0:D1}", i+1);
                    textBox2.Text += (Bands[i] + "\r\n");
                }
                //在ComboBox1、2、3、4中插入波段名
                for (int i = 0; i < Band_Count; i++)
                {
                    comboBox1.Items.Add(Bands[i]);
                    comboBox2.Items.Add(Bands[i]);
                    comboBox3.Items.Add(Bands[i]);
                    comboBox4.Items.Add(Bands[i]);
                }
            }
        }
    }
}
