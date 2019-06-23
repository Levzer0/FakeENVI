using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS_DP_FinalProgram
{
    public partial class Show_Image : Form
    {
        int Image_Type = 0;//图像类型
        int W = 0;//图像宽
        int H = 0;//图像高
        int DN_MAX = 255;//像素值最大值
        int DN_MIN = 0;//像素值最小值
        Bitmap Result_Image;//处理结果图像
        Bitmap Band_R, Band_G, Band_B;//彩色图像各波段
        Histogram histogram_R, histogram_G, histogram_B;//直方图
        
        //初始化
        public Show_Image(Bitmap bitmap,int band_count)
        {
            InitializeComponent();
            pictureBox1.Image = bitmap;
            Result_Image = new Bitmap(bitmap);
            W = bitmap.Width;
            H = bitmap.Height;

            if (band_count == 1)
            {
                comboBox1.Items.Add("b1");
                Image_Type = 1;
                histogram_R = new Histogram(Result_Image);
            }
            if(band_count == 3)
            {
                comboBox1.Items.Add("R");
                comboBox1.Items.Add("G");
                comboBox1.Items.Add("B");
                Image_Type = 3;

                Band_R = new Bitmap(W, H);
                Band_G = new Bitmap(W, H);
                Band_B = new Bitmap(W, H);
                //分解
                Color temp;
                int R, G, B;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        R = Result_Image.GetPixel(i, j).R;
                        G = Result_Image.GetPixel(i, j).G;
                        B = Result_Image.GetPixel(i, j).B;
                        temp = Color.FromArgb(R, R, R);
                        Band_R.SetPixel(i, j, temp);
                        temp = Color.FromArgb(G, G, G);
                        Band_G.SetPixel(i, j, temp);
                        temp = Color.FromArgb(B, B, B);
                        Band_B.SetPixel(i, j, temp);
                    }
                }

                histogram_R = new Histogram(Band_R);
                histogram_G = new Histogram(Band_G);
                histogram_B = new Histogram(Band_B);
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        //2%拉伸
        private void stretchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //单波段
            if(Image_Type == 1)
            {
                histogram_R.Percent2_Stretching();
                Result_Image = histogram_R.bitmap;
                pictureBox1.Image = Result_Image;
            }
            else if(Image_Type == 3)
            {
                //分别对三个波段进行拉伸
                histogram_R.Percent2_Stretching();
                histogram_G.Percent2_Stretching();
                histogram_B.Percent2_Stretching();

                Band_R = histogram_R.bitmap;
                Band_G = histogram_G.bitmap;
                Band_B = histogram_B.bitmap;
                //合成
                Color temp;
                for(int i=0;i<W;i++)
                {
                    for(int j=0;j<H;j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i,j).R, Band_G.GetPixel(i,j).G, Band_B.GetPixel(i,j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //线性拉伸
        private void linearStretchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Choose_Range Get_Range = new Choose_Range(DN_MAX, DN_MIN);
            Get_Range.ShowDialog();

            if(Get_Range.Input_Condition==true)
            {
                //单波段
                if (Image_Type == 1)
                {
                    histogram_R.Linear_Stretching(Get_Range.Min, Get_Range.Max);
                    Result_Image = histogram_R.bitmap;
                    pictureBox1.Image = Result_Image;
                }
                else if (Image_Type == 3)
                {
                    //分别对三个波段进行拉伸
                    histogram_R.Linear_Stretching(Get_Range.Min, Get_Range.Max);
                    histogram_G.Linear_Stretching(Get_Range.Min, Get_Range.Max);
                    histogram_B.Linear_Stretching(Get_Range.Min, Get_Range.Max);

                    Band_R = histogram_R.bitmap;
                    Band_G = histogram_G.bitmap;
                    Band_B = histogram_B.bitmap;
                    //合成
                    Color temp;
                    for (int i = 0; i < W; i++)
                    {
                        for (int j = 0; j < H; j++)
                        {
                            temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                            Result_Image.SetPixel(i, j, temp);
                        }
                    }
                    //显示
                    pictureBox1.Image = Result_Image;
                }
                else
                    MessageBox.Show("No Available Band!", "WARNING");

                Get_Range.Close();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //Point p = e.Location;
            //int R = Result_Image.GetPixel(p.X, p.Y).R;
            //int G = Result_Image.GetPixel(p.X, p.Y).G;
            //int B = Result_Image.GetPixel(p.X, p.Y).B;

            //textBox1.Text = R.ToString();
            //textBox2.Text = G.ToString();
            //textBox3.Text = B.ToString();
        }
        //均值滤波
        private void meanFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Mean_Filter();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Mean_Filter();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Mean_Filter();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Mean_Filter();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //中值滤波
        private void medianFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Median_Filter();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Median_Filter();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Median_Filter();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Median_Filter();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //梯度倒数加权
        private void gradientInverseWeightedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Gradient_Inverse_Weight();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Gradient_Inverse_Weight();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Gradient_Inverse_Weight();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Gradient_Inverse_Weight();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //梯度法
        private void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Gradient_Sharpening();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Gradient_Sharpening();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Gradient_Sharpening();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Gradient_Sharpening();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //Robert梯度
        private void robortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Robert_Sharpening();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Robert_Sharpening();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Robert_Sharpening();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Robert_Sharpening();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //Prewitt梯度X方向锐化
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Prewitt_X_Sharpening();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Prewitt_X_Sharpening();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Prewitt_X_Sharpening();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Prewitt_X_Sharpening();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //Prewitt梯度Y方向锐化
        private void yToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Prewitt_Y_Sharpening();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Prewitt_Y_Sharpening();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Prewitt_Y_Sharpening();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Prewitt_Y_Sharpening();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //Sobel梯度X方向锐化
        private void xToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Sobel_X_Sharpening();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Sobel_X_Sharpening();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Sobel_X_Sharpening();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Sobel_X_Sharpening();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
        }
        //Sobel梯度Y方向锐化
        private void yToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Sobel_Y_Sharpening();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Sobel_Y_Sharpening();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Sobel_Y_Sharpening();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Sobel_Y_Sharpening();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
        }
        //自定义卷积核模板
        private void userDefinedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User_Defined_Template Define_Form = new User_Defined_Template();
            Define_Form.ShowDialog();
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Convolution(Define_Form.Template, Define_Form.Template_Size);
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Convolution(Define_Form.Template, Define_Form.Template_Size);
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Convolution(Define_Form.Template, Define_Form.Template_Size);
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Convolution(Define_Form.Template, Define_Form.Template_Size);
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
        }
        //Laplacian算子
        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap_Process Current_Band;
            //单波段
            if (Image_Type == 1)
            {
                Current_Band = new Bitmap_Process(Result_Image);
                Current_Band.Laplacian_Sharpening();
                pictureBox1.Image = Result_Image;
            }
            else if (Image_Type == 3)
            {
                //分别对三个波段进行滤波
                Current_Band = new Bitmap_Process(Band_R);
                Current_Band.Laplacian_Sharpening();
                Current_Band = new Bitmap_Process(Band_G);
                Current_Band.Laplacian_Sharpening();
                Current_Band = new Bitmap_Process(Band_B);
                Current_Band.Laplacian_Sharpening();
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i, j).R, Band_G.GetPixel(i, j).G, Band_B.GetPixel(i, j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
        }
        //保存文件
        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "普通图像 |*.jpg;*.jepg;*.png;*.bmp;*.gif|遥感数字图像|*.hdr";

            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                Result_Image.Save(saveFileDialog1.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //直方图均衡化
        private void equilibriumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //单波段直方图均衡化
            if (Image_Type == 1)
            {
                histogram_R.Histogram_Equilibrium();
                Result_Image = histogram_R.bitmap;
                pictureBox1.Image = Result_Image;
            }
            //多波段直方图均衡化
            else if (Image_Type == 3)
            {
                //分别对单个波段均衡化
                histogram_R.Histogram_Equilibrium();
                histogram_G.Histogram_Equilibrium();
                histogram_B.Histogram_Equilibrium();

                Band_R = histogram_R.bitmap;
                Band_G = histogram_G.bitmap;
                Band_B = histogram_B.bitmap;
                //合成
                Color temp;
                for (int i = 0; i < W; i++)
                {
                    for (int j = 0; j < H; j++)
                    {
                        temp = Color.FromArgb(Band_R.GetPixel(i,j).R, Band_G.GetPixel(i,j).G, Band_B.GetPixel(i,j).B);
                        Result_Image.SetPixel(i, j, temp);
                    }
                }
                //显示
                pictureBox1.Image = Result_Image;
            }
            else
                MessageBox.Show("No Available Band!", "WARNING");
        }
        //全屏显示
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Full_Screen_Display Display_Form = new Full_Screen_Display(Result_Image);
            Display_Form.Show();
        }
        //绘制直方图并输出统计特征
        private void button1_Click(object sender, EventArgs e)
        {
            int[] Current_Histogram = new int[256];
            int max_y = 0;//最大y值
            Bitmap_Process Current_Band;
            //获取将要绘制的直方图并输出统计参数
            if (comboBox1.Text == "R")
            {
                Current_Histogram = histogram_R.histogram;
                Current_Band = new Bitmap_Process(Band_R);

                //求最大值
                for (int i = 255; i >= 0; i--)
                {
                    if (Current_Histogram[i] != 0)
                    {
                        DN_MAX = i;
                        break;
                    }
                }
                //求最小值
                for (int i = 0; i < 255; i++)
                {
                    if (Current_Histogram[i] != 0)
                    {
                        DN_MIN = i;
                        break;
                    }
                }

                textBox1.Text = string.Format("{0:F2}", Current_Band.Mean);
                textBox2.Text = string.Format("{0:F2}", Current_Band.Variance);
                textBox3.Text = (DN_MAX - DN_MIN).ToString();
            }
            if (comboBox1.Text == "G")
            {
                Current_Histogram = histogram_G.histogram;
                Current_Band = new Bitmap_Process(Band_G);

                //求最大值
                for (int i = 255; i >= 0; i--)
                {
                    if (Current_Histogram[i] != 0)
                    {
                        DN_MAX = i;
                        break;
                    }
                }
                //求最小值
                for (int i = 0; i < 255; i++)
                {
                    if (Current_Histogram[i] != 0)
                    {
                        DN_MIN = i;
                        break;
                    }
                }

                textBox1.Text = string.Format("{0:F2}", Current_Band.Mean);
                textBox2.Text = string.Format("{0:F2}", Current_Band.Variance);
                textBox3.Text = (DN_MAX - DN_MIN).ToString();
            }
            if (comboBox1.Text == "B")
            {
                Current_Histogram = histogram_B.histogram;
                Current_Band = new Bitmap_Process(Band_B);

                //求最大值
                for (int i = 255; i >= 0; i--)
                {
                    if (Current_Histogram[i] != 0)
                    {
                        DN_MAX = i;
                        break;
                    }
                }
                //求最小值
                for (int i = 0; i < 255; i++)
                {
                    if (Current_Histogram[i] != 0)
                    {
                        DN_MIN = i;
                        break;
                    }
                }

                textBox1.Text = string.Format("{0:F2}", Current_Band.Mean);
                textBox2.Text = string.Format("{0:F2}", Current_Band.Variance);
                textBox3.Text = (DN_MAX - DN_MIN).ToString();
            }
            if (comboBox1.Text == "b1")
            {
                Current_Histogram = histogram_R.histogram;
                Current_Band = new Bitmap_Process(Result_Image);

                //求最大值
                for (int i = 255; i >= 0; i--)
                {
                    if (Current_Histogram[i] != 0)
                    {
                        DN_MAX = i;
                        break;
                    }
                }
                //求最小值
                for (int i = 0; i < 255; i++)
                {
                    if (Current_Histogram[i] != 0)
                    {
                        DN_MIN = i;
                        break;
                    }
                }

                textBox1.Text = string.Format("{0:F2}", Current_Band.Mean);
                textBox2.Text = string.Format("{0:F2}", Current_Band.Variance);
                textBox3.Text = (DN_MAX - DN_MIN).ToString();
            }
            //计算最大y值
            for (int i = 0; i < 256; i++)
            {
                if (Current_Histogram[i] > max_y)
                {
                    max_y = Current_Histogram[i];
                }
            }
            //绘图
            Graphics g = pictureBox2.CreateGraphics();
            g.Clear(Color.White);
            Pen curPen = new Pen(Brushes.Black, 1);
            //绘制坐标系
            g.DrawLine(curPen, 15, 240, 275, 240);
            g.DrawLine(curPen, 15, 240, 15, 45);
            g.DrawLine(curPen, 65, 240, 65, 242);
            g.DrawLine(curPen, 115, 240, 115, 242);
            g.DrawLine(curPen, 165, 240, 165, 242);
            g.DrawLine(curPen, 215, 240, 215, 242);
            g.DrawLine(curPen, 265, 240, 265, 242);
            g.DrawLine(curPen, 13, 47, 15, 45);
            g.DrawLine(curPen, 17, 47, 15, 45);
            g.DrawLine(curPen, 270, 237, 275, 240);
            g.DrawLine(curPen, 270, 243, 275, 240);
            g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(13, 242));
            g.DrawString("50", new Font("New Timer", 8), Brushes.Black, new PointF(65, 242));
            g.DrawString("100", new Font("New Timer", 8), Brushes.Black, new PointF(115, 242));
            g.DrawString("150", new Font("New Timer", 8), Brushes.Black, new PointF(165, 242));
            g.DrawString("200", new Font("New Timer", 8), Brushes.Black, new PointF(215, 242));
            g.DrawString("255", new Font("New Timer", 8), Brushes.Black, new PointF(265, 242));
            g.DrawString("0", new Font("New Timer", 8), Brushes.Black, new PointF(6, 234));
            g.DrawString("Y", new Font("New Timer", 8), Brushes.Black, new PointF(6, 34));
            g.DrawString("X", new Font("New Timer", 8), Brushes.Black, new PointF(280, 23));

            double temp = 0;

            for (int i = 0; i < 256; i++)
            {
                temp = 190.0 * Current_Histogram[i] / max_y;
                g.DrawLine(curPen, 15 + i, 240, 15 + i, 240 - (int)temp);
            }

            curPen.Dispose();
        }

    }
}
