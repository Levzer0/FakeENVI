using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RS_DP_FinalProgram
{
    //单波段函数处理类
    class Bitmap_Process
    {
        public Bitmap bitmap;
        public double Mean;
        public double Variance;
        int H = 0;
        int W = 0;
        //构造函数
        public Bitmap_Process(Bitmap b)
        {
            bitmap = b;
            Calculate_Mean();
            Calculate_Variance();
            W = bitmap.Width;
            H = bitmap.Height;
        }
        //求单波段图像均值
        public void Calculate_Mean()
        {
            int count = 0, sum = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    sum += bitmap.GetPixel(i, j).R;
                    count++;
                }
            }

            Mean = (double)sum / (double)count;
        }
        //求单波段图像的方差
        public void Calculate_Variance()
        {
            int count = 0;
            double difference_sum = 0;

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    difference_sum += (bitmap.GetPixel(i, j).R - Mean) * (bitmap.GetPixel(i, j).R - Mean);
                    count++;
                }
            }

            Variance = (double)difference_sum / (double)count;
        }
        //计算两波段间的协方差
        public double Calculate_Convariance(Bitmap b)
        {
            if (bitmap.Width == b.Width && bitmap.Height == b.Height)
            {
                Bitmap_Process temp = new Bitmap_Process(b);
                double bitmap_Mean = Mean;
                double b_Mean = temp.Mean;
                double sum = 0;

                for(int i=0;i<bitmap.Width;i++)
                {
                    for(int j=0;j<bitmap.Height;j++)
                    {
                        sum += (bitmap.GetPixel(i, j).R - bitmap_Mean) * (b.GetPixel(i, j).R - b_Mean);
                    }
                }

                return sum / (bitmap.Height * bitmap.Width);
            }
            else
                return -999;
        }
        //计算两波段间的相关系数
        public double Calculate_RelatedCoefficient(Bitmap b)
        {
            if (bitmap.Width == b.Width && bitmap.Height == b.Height)
            {
                Bitmap_Process temp = new Bitmap_Process(b);
                double bitmap_stdV = Math.Sqrt(Variance);
                double b_stdV = Math.Sqrt(temp.Variance);

                return Calculate_Convariance(b) / (bitmap_stdV * b_stdV);
            }
            else
                return -999;
        }
        //均值滤波
        public void Mean_Filter()
        {
            int[,] Image_Matrix = new int[W, H];
            Color temp;
            //将像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix[i, j] = bitmap.GetPixel(i, j).R;
                }
            }
            //滤波
            for(int i=1;i<W-1;i++)
            {
                for(int j=1;j<H-1;j++)
                {
                    Image_Matrix[i, j] = (Image_Matrix[i - 1, j - 1] + Image_Matrix[i, j - 1] + Image_Matrix[i + 1, j - 1] + Image_Matrix[i - 1, j] + Image_Matrix[i + 1, j] + Image_Matrix[i - 1, j + 1] + Image_Matrix[i, j + 1] + Image_Matrix[i + 1, j + 1]) / 8;
                }
            }
            //矩阵值返回图像
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    temp = Color.FromArgb(Image_Matrix[i, j], Image_Matrix[i, j], Image_Matrix[i, j]);
                    bitmap.SetPixel(i, j, temp);
                }
            }
        }
        //中值滤波
        public void Median_Filter()
        {
            int[,] Image_Matrix = new int[W, H];
            Color temp;
            //将像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix[i, j] = bitmap.GetPixel(i, j).R;
                }
            }
            //滤波
            for (int i = 1; i < W - 1; i++)
            {
                for (int j = 1; j < H; j++)
                {
                    Image_Matrix[i, j] = Get_Median(Image_Matrix[i - 1, j], Image_Matrix[i, j], Image_Matrix[i + 1, j]);
                }
            }
            //矩阵值返回图像
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    temp = Color.FromArgb(Image_Matrix[i, j], Image_Matrix[i, j], Image_Matrix[i, j]);
                    bitmap.SetPixel(i, j, temp);
                }
            }
        }
        //求中值
        public int Get_Median(int a,int b,int c)
        {
            int temp;
            //排序
            if(a>b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            if(b>c)
            {
                temp = b;
                b = c;
                c = temp;
            }
            if (a > b)
            {
                temp = a;
                a = b;
                b = temp;
            }
            return b;
        }
        //梯度倒数加权
        public void Gradient_Inverse_Weight()
        {
            int[,] Image_Matrix = new int[W, H];
            Color temp;
            //将像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix[i, j] = bitmap.GetPixel(i, j).R;
                }
            }
            //滤波
            for (int i = 1; i < W - 1; i++)
            {
                for (int j = 1; j < H - 1; j++)
                {
                    //计算梯度倒数
                    double w1 = Math.Abs(Image_Matrix[i - 1, j - 1] - Image_Matrix[i, j]);
                    double w2 = Math.Abs(Image_Matrix[i, j - 1] - Image_Matrix[i, j]);
                    double w3 = Math.Abs(Image_Matrix[i + 1, j - 1] - Image_Matrix[i, j]);
                    double w4 = Math.Abs(Image_Matrix[i - 1, j] - Image_Matrix[i, j]);
                    double w5 = Math.Abs(Image_Matrix[i + 1, j] - Image_Matrix[i, j]);
                    double w6 = Math.Abs(Image_Matrix[i - 1, j + 1] - Image_Matrix[i, j]);
                    double w7 = Math.Abs(Image_Matrix[i, j + 1] - Image_Matrix[i, j]);
                    double w8 = Math.Abs(Image_Matrix[i + 1, j + 1] - Image_Matrix[i, j]);
                    //系数归一化
                    double sum = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8;

                    if (sum == 0)
                        continue;
                    w1 = w1 / sum / 2;
                    w2 = w2 / sum / 2;
                    w3 = w3 / sum / 2;
                    w4 = w4 / sum / 2;
                    w5 = w5 / sum / 2;
                    w6 = w6 / sum / 2;
                    w7 = w7 / sum / 2;
                    w8 = w8 / sum / 2;
                    //计算
                    double result = w1 * Image_Matrix[i - 1, j - 1] + w2 * Image_Matrix[i, j - 1] + w3 * Image_Matrix[i + 1, j - 1] + w4 * Image_Matrix[i - 1, j];
                    result += Image_Matrix[i, j] / 2 + w5 * Image_Matrix[i + 1, j] + w6 * Image_Matrix[i - 1, j + 1] + w7 * Image_Matrix[i, j + 1] + w8 * Image_Matrix[i + 1, j + 1];

                    Image_Matrix[i, j] = (int)result;
                }
            }
            //矩阵值返回图像
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    temp = Color.FromArgb(Image_Matrix[i, j], Image_Matrix[i, j], Image_Matrix[i, j]);
                    bitmap.SetPixel(i, j, temp);
                }
            }
        }
        //梯度法锐化
        public void Gradient_Sharpening()
        {
            int[,] Image_Matrix1 = new int[W, H];
            int[,] Image_Matrix2 = new int[W, H];
            int Max = 0; 
            int Min = 255;
            Color temp;
            //将像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = bitmap.GetPixel(i, j).R;
                }
            }

            Image_Matrix2 = Image_Matrix1;
            //锐化
            //X方向
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    Image_Matrix1[i, j] = Image_Matrix1[i, j] - Image_Matrix1[i, j + 1];
                }
            }
            //Y方向
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    Image_Matrix2[i, j] = Image_Matrix2[i, j] - Image_Matrix2[i + 1, j];
                }
            }
            //相加得到梯度图像矩阵
            Max = Image_Matrix1[0, 0] + Image_Matrix2[0, 0];
            Min = Max;

            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    Image_Matrix1[i, j] = Image_Matrix1[i, j] + Image_Matrix2[i, j];
                    if (Image_Matrix1[i, j] > Max)
                        Max = Image_Matrix1[i, j];
                    if (Image_Matrix1[i, j] < Min)
                        Min = Image_Matrix1[i, j];
                }
            }
            //灰度变换到正值
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    Image_Matrix1[i, j] = 255 * (Image_Matrix1[i, j] - Min) / (Max - Min);
                }
            }
            ////和原始图像相加
            ////获取原始图像矩阵
            //for (int i = 0; i < W; i++)
            //{
            //    for (int j = 0; j < H; j++)
            //    {
            //        Image_Matrix2[i, j] = bitmap.GetPixel(i, j).R;
            //    }
            //}

            //Max = Image_Matrix1[0, 0] + Image_Matrix2[0, 0];
            //Min = Max;
            ////相加
            //for (int i = 0; i < W; i++)
            //{
            //    for (int j = 0; j < H; j++)
            //    {
            //        Image_Matrix1[i, j] = Image_Matrix1[i, j] + Image_Matrix2[i, j];
            //        if (Image_Matrix1[i, j] > Max)
            //            Max = Image_Matrix1[i, j];
            //        if (Image_Matrix1[i, j] < Min)
            //            Min = Image_Matrix1[i, j];
            //    }
            //}
            ////灰度变换至0-255
            //for (int i = 0; i < W; i++)
            //{
            //    for (int j = 0; j < H; j++)
            //    {
            //        Image_Matrix1[i, j] = 255 * (Image_Matrix1[i, j] - Min) / (Max - Min);
            //    }
            //}
            //矩阵值返回图像
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    temp = Color.FromArgb(Image_Matrix1[i, j], Image_Matrix1[i, j], Image_Matrix1[i, j]);
                    bitmap.SetPixel(i, j, temp);
                }
            }
        }
        //卷积计算
        public void Convolution(int[] Template,int Template_Size)
        {
            int[,] Image_Matrix1 = new int[W, H];
            int[,] Image_Matrix2 = new int[W, H];
            int Max = 0;
            int Min = 255;
            Color temp;
            //将像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = bitmap.GetPixel(i, j).R;
                    Image_Matrix2[i, j] = bitmap.GetPixel(i, j).R;
                }
            }

            
            //2X2窗口
            if (Template_Size == 2)
            {
                Max = Template[0] * Image_Matrix1[0, 0] + Template[1] * Image_Matrix1[1, 0] + Template[2] * Image_Matrix1[0, 1] + Template[3] * Image_Matrix1[1, 1];
                Min = Max;
                //卷积运算
                for (int i = 0; i < W - 1; i++)
                {
                    for (int j = 0; j < H - 1; j++)
                    {
                        Image_Matrix2[i, j] = Template[0] * Image_Matrix1[i, j] + Template[1] * Image_Matrix1[i + 1, j] + Template[2] * Image_Matrix1[i, j + 1] + Template[3] * Image_Matrix1[i + 1, j + 1];
                        //计算结果灰度范围
                        if (Image_Matrix2[i, j] > Max)
                            Max = Image_Matrix2[i, j];
                        if (Image_Matrix2[i, j] < Min)
                            Min = Image_Matrix2[i, j];
                    }
                }
                //灰度变化到0-255
                for (int i = 0; i < W - 1; i++)
                {
                    for (int j = 0; j < H - 1; j++)
                    {
                        Image_Matrix2[i, j] = 255 * (Image_Matrix2[i, j] - Min) / (Max - Min);
                    }
                }
                //矩阵值返回图像
                for (int i = 0; i < W - 1; i++)
                {
                    for (int j = 0; j < H - 1; j++)
                    {
                        temp = Color.FromArgb(Image_Matrix2[i, j], Image_Matrix2[i, j], Image_Matrix2[i, j]);
                        bitmap.SetPixel(i, j, temp);
                    }
                }
            }
            //3X3窗口
            else if (Template_Size == 3)
            {
                Max = Template[0] * Image_Matrix1[0, 0] + Template[1] * Image_Matrix1[1, 0] + Template[2] * Image_Matrix1[2, 0];
                Max += Template[3] * Image_Matrix1[0, 1] + Template[4] * Image_Matrix1[1, 1] + Template[5] * Image_Matrix1[2, 1];
                Max += Template[6] * Image_Matrix1[0, 2] + Template[7] * Image_Matrix1[1, 2] + Template[8] * Image_Matrix1[2, 2];
                Min = Max;
                //卷积运算
                for (int i = 1; i < W - 1; i++)
                {
                    for (int j = 1; j < H - 1; j++)
                    {
                        Image_Matrix2[i, j] = Template[0] * Image_Matrix1[i - 1, j - 1] + Template[1] * Image_Matrix1[i, j - 1] + Template[2] * Image_Matrix1[i + 1, j - 1];
                        Image_Matrix2[i, j] += Template[3] * Image_Matrix1[i - 1, j] + Template[4] * Image_Matrix1[i, j] + Template[5] * Image_Matrix1[i + 1, j];
                        Image_Matrix2[i, j] += Template[6] * Image_Matrix1[i - 1, j + 1] + Template[7] * Image_Matrix1[i, j + 1] + Template[8] * Image_Matrix1[i + 1, j + 1];
                        //计算结果灰度范围
                        if (Image_Matrix2[i, j] > Max)
                            Max = Image_Matrix2[i, j];
                        if (Image_Matrix2[i, j] < Min)
                            Min = Image_Matrix2[i, j];
                    }
                }
                //灰度变化至0-255
                for (int i = 1; i < W - 1; i++)
                {
                    for (int j = 0; j < H - 1; j++)
                    {
                        Image_Matrix2[i, j] = 255 * (Image_Matrix2[i, j] - Min) / (Max - Min);
                    }
                }
                //矩阵值返回图像
                for (int i = 1; i < W - 1; i++)
                {
                    for (int j = 1; j < H - 1; j++)
                    {
                        temp = Color.FromArgb(Image_Matrix2[i, j], Image_Matrix2[i, j], Image_Matrix2[i, j]);
                        bitmap.SetPixel(i, j, temp);
                    }
                }
            }
            else
                return;
        }
        //Robert梯度
        public void Robert_Sharpening()
        {
            int[,] Image_Matrix1 = new int[W, H];
            int Max = 0;
            int Min = 255;
            Color temp;
            //将像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = bitmap.GetPixel(i, j).R;
                }
            }

            Max = Image_Matrix1[0, 0];
            Min = Max;
            //锐化
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    Image_Matrix1[i, j] = Math.Abs(Image_Matrix1[i, j] - Image_Matrix1[i + 1, j + 1]) + Math.Abs(Image_Matrix1[i, j + 1] - Image_Matrix1[i + 1, j]);
                    if (Image_Matrix1[i, j] > Max)
                        Max = Image_Matrix1[i, j];
                    if (Image_Matrix1[i, j] < Min)
                        Min = Image_Matrix1[i, j];
                }
            }
            //灰度变换至0-255
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = 255 * (Image_Matrix1[i, j] - Min) / (Max - Min);
                }
            }
            //矩阵值返回图像
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    temp = Color.FromArgb(Image_Matrix1[i, j], Image_Matrix1[i, j], Image_Matrix1[i, j]);
                    bitmap.SetPixel(i, j, temp);
                }
            }
        }
        //Prewitt梯度X方向
        public void Prewitt_X_Sharpening()
        {
            int[] Template_X = { -1, 0, 1, -1, 0, 1, -1, 0, 1 };
            this.Convolution(Template_X, 3);
        }
        //Prewitt梯度Y方向
        public void Prewitt_Y_Sharpening()
        {
            int[] Template_Y = { -1, -1, -1, 0, 0, 0, 1, 1, 1 };
            this.Convolution(Template_Y, 3);
        }
        //Sobel梯度X方向
        public void Sobel_X_Sharpening()
        {
            int[] Template_X = { -1, 0, 1, -2, 0, 2, -1, 0, 1 };
            this.Convolution(Template_X, 3);
        }
        //Sobel梯度Y方向
        public void Sobel_Y_Sharpening()
        {
            int[] Template_Y = { 1, 2, 1, 0, 0, 0, -1, -2, -1 };
            this.Convolution(Template_Y, 3);
        }
        //Laplacian算子
        public void Laplacian_Sharpening()
        {
            int[] Template_Laplacian = { 0, 1, 0, 1, -4, 1, 0, 1, 0 };
            this.Convolution(Template_Laplacian, 3);
        }
        //波段相加
        public void Band_Math_Add(Bitmap b)
        {
            int[,] Image_Matrix1 = new int[W, H];
            int[,] Image_Matrix2 = new int[W, H];
            int Max = 0;
            int Min = 510;
            Color temp;
            //像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = bitmap.GetPixel(i, j).R;
                    Image_Matrix2[i, j] = b.GetPixel(i, j).R;
                }
            }
            //相加
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] += Image_Matrix2[i, j];
                    if (Image_Matrix1[i, j] > Max)
                        Max = Image_Matrix1[i, j];
                    if (Image_Matrix1[i, j] < Min)
                        Min = Image_Matrix1[i, j];
                }
            }
            //灰度变换至0-255
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = 255 * (Image_Matrix1[i, j] - Min) / (Max - Min);
                }
            }
            //矩阵值返回图像
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    temp = Color.FromArgb(Image_Matrix1[i, j], Image_Matrix1[i, j], Image_Matrix1[i, j]);
                    bitmap.SetPixel(i, j, temp);
                }
            }
        }
        //波段相减
        public void Band_Math_Subtract(Bitmap b)
        {
            int[,] Image_Matrix1 = new int[W, H];
            int[,] Image_Matrix2 = new int[W, H];
            int Max;
            int Min;
            Color temp;
            //像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; i < H; j++)
                {
                    Image_Matrix1[i, j] = bitmap.GetPixel(i, j).R;
                    Image_Matrix2[i, j] = b.GetPixel(i, j).R;
                }
            }
            Max = Image_Matrix1[0, 0] - Image_Matrix2[0, 0];
            Min = Max;
            //相减
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] -= Image_Matrix2[i, j];
                    if (Image_Matrix1[i, j] > Max)
                        Max = Image_Matrix1[i, j];
                    if (Image_Matrix1[i, j] < Min)
                        Min = Image_Matrix1[i, j];
                }
            }
            //灰度变换至0-255
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = 255 * (Image_Matrix1[i, j] - Min) / (Max - Min);
                }
            }
            //矩阵值返回图像
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    temp = Color.FromArgb(Image_Matrix1[i, j], Image_Matrix1[i, j], Image_Matrix1[i, j]);
                    bitmap.SetPixel(i, j, temp);
                }
            }
        }
        //波段相乘
        public void Band_Math_Multiplication(Bitmap b)
        {
            int[,] Image_Matrix1 = new int[W, H];
            int[,] Image_Matrix2 = new int[W, H];
            int Max;
            int Min;
            Color temp;
            //像素值读入矩阵
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; i < H; j++)
                {
                    Image_Matrix1[i, j] = bitmap.GetPixel(i, j).R;
                    Image_Matrix2[i, j] = b.GetPixel(i, j).R;
                }
            }
            Max = Image_Matrix1[0, 0] - Image_Matrix2[0, 0];
            Min = Max;
            //相减
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = Image_Matrix2[i, j] * Image_Matrix1[i, j];
                    if (Image_Matrix1[i, j] > Max)
                        Max = Image_Matrix1[i, j];
                    if (Image_Matrix1[i, j] < Min)
                        Min = Image_Matrix1[i, j];
                }
            }
            //灰度变换至0-255
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    Image_Matrix1[i, j] = 255 * (Image_Matrix1[i, j] - Min) / (Max - Min);
                }
            }
            //矩阵值返回图像
            for (int i = 0; i < W - 1; i++)
            {
                for (int j = 0; j < H - 1; j++)
                {
                    temp = Color.FromArgb(Image_Matrix1[i, j], Image_Matrix1[i, j], Image_Matrix1[i, j]);
                    bitmap.SetPixel(i, j, temp);
                }
            }
        }
    }
}
