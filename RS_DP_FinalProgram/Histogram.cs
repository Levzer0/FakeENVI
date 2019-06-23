using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RS_DP_FinalProgram
{
    //直方图处理类
    class Histogram
    {
        public Bitmap bitmap;
        public int[] histogram;//频数直方图
        public int[] cumulative_histogram;//累积直方图
        //构造函数
        public Histogram(Bitmap b)
        {
            bitmap = b;
            histogram = new int[256];
            cumulative_histogram = new int[256];

            Calculate_Histogram();
            Calculate_CumulativeHistogram();
        }
        //计算频数直方图
        public void Calculate_Histogram()
        {
            //统计
            for(int i=0;i<bitmap.Width;i++)
            {
                for(int j=0;j<bitmap.Height;j++)
                {
                    int sign = bitmap.GetPixel(i, j).R;
                    histogram[sign]++;
                }
            }
        }
        //计算累积直方图
        public void Calculate_CumulativeHistogram()
        {
            //根据频数直方图求累积直方图
            for(int i=0;i<256;i++)
            {
                if (i == 0)
                    cumulative_histogram[i] = histogram[i];
                else if(i>0)
                {
                    int sum = 0;
                    //累积频数
                    for (int j = 0; j < i; j++)
                        sum += histogram[j];

                    cumulative_histogram[i] = sum;
                }
            }
        }
        //直方图均衡化
        public void Histogram_Equilibrium()
        {
            double[] CumulativeFrequency_Histogram = new double[256];//累积频率直方图
            double[] Theoretical_CumulativeFrequency_Histogram = new double[256];//理论累积频率直方图
            //计算累积频率
            for (int i = 0; i < 256; i++)
            {
                CumulativeFrequency_Histogram[i] = (double)cumulative_histogram[i] / ((double)bitmap.Height * (double)bitmap.Width);
            }
            //计算理论累积频率
            for (int i = 0; i < 256; i++)
            {
                Theoretical_CumulativeFrequency_Histogram[i] = (i + 1) / 256;
            }
            //均衡化
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    double CF = CumulativeFrequency_Histogram[bitmap.GetPixel(i, j).R];//累积频率
                    double difference_min = 1;
                    int new_value = 0;//新值
                    Color temp;
                    //匹配
                    for(int k = 0; k < 256;k++)
                    {
                        if (Math.Abs(CF - Theoretical_CumulativeFrequency_Histogram[k]) < difference_min)
                        {
                            difference_min = Math.Abs(CF - Theoretical_CumulativeFrequency_Histogram[k]);
                            new_value = k;
                        }
                    }
                    //给像素赋新值
                    temp = Color.FromArgb(new_value, new_value, new_value);
                    bitmap.SetPixel(i, j, temp);
                }
            }
            //重新计算属性
            Calculate_Histogram();
            Calculate_CumulativeHistogram();
        }
        //全域线性拉伸
        public void Linear_Stretching(int min,int max)
        {
            int DN_min = 255;
            int DN_max = 0;
            //根据直方图求出图像灰度范围
            for(int i=0;i<256;i++)
            {
                if(histogram[i]!=0)
                {
                    if (i < DN_min)
                        DN_min = i;
                    if (i > DN_max)
                        DN_max = i;
                }
            }
            //遍历求新值
            for(int i=0;i<bitmap.Width;i++)
            {
                for(int j=0;j<bitmap.Height; j++)
                {
                    int R = (max - min) * (bitmap.GetPixel(i, j).R - DN_min) / (DN_max - DN_min) + min;
                    Color temp = Color.FromArgb(R, R, R);
                    bitmap.SetPixel(i, j, temp);
                }
            }
            //重新计算频数直方图和累积直方图
            Calculate_Histogram();
            Calculate_CumulativeHistogram();
        }
        //2%拉伸
        public void Percent2_Stretching()
        {
            double[] CumulativeFrequency_Histogram = new double[256];//累积频率直方图
            //计算累积频率
            for(int i=0;i<256;i++)
            {
                CumulativeFrequency_Histogram[i] = (double)cumulative_histogram[i] / ((double)bitmap.Height * (double)bitmap.Width);
            }
            //计算拉伸域
            int min = 0;
            int max = 255;
            double equal_2 = 1;
            double equal_98 = 1;

            for(int i=0;i<256;i++)
            {
                if (Math.Abs(CumulativeFrequency_Histogram[i] - 0.02) < equal_2)
                {
                    equal_2 = Math.Abs(CumulativeFrequency_Histogram[i] - 0.02);
                    min = i;
                }
                if (Math.Abs(CumulativeFrequency_Histogram[i] - 0.98) < equal_98)
                {
                    equal_98 = Math.Abs(CumulativeFrequency_Histogram[i] - 0.02);
                    max = i;
                }
            }
            //拉伸
            Linear_Stretching(min, max);
        }
        //直方图规定化
        public void Histogram_Specification(Bitmap b)
        {
            if (bitmap.Height == b.Height && bitmap.Width == b.Width)
            {
                Histogram Target = new Histogram(b);
                double[] CumulativeFrequency_Histogram = new double[256];//累积频率直方图
                double[] Theoretical_CumulativeFrequency_Histogram = new double[256];//理论累积频率直方图
                                                                                     //计算累积频率
                for (int i = 0; i < 256; i++)
                {
                    CumulativeFrequency_Histogram[i] = (double)cumulative_histogram[i] / ((double)bitmap.Height * (double)bitmap.Width);
                }
                //计算理论累积频率
                for (int i = 0; i < 256; i++)
                {
                    Theoretical_CumulativeFrequency_Histogram[i] = Target.cumulative_histogram[i] / (bitmap.Height * bitmap.Width);
                }
                //规定化
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int j = 0; j < bitmap.Height; j++)
                    {
                        double CF = CumulativeFrequency_Histogram[bitmap.GetPixel(i, j).R];//累积频率
                        double difference_min = 1;
                        int new_value = 0;//新值
                        Color temp;
                        //匹配
                        for (int k = 0; k < 256; k++)
                        {
                            if (Math.Abs(CF - Theoretical_CumulativeFrequency_Histogram[k]) < difference_min)
                            {
                                difference_min = Math.Abs(CF - Theoretical_CumulativeFrequency_Histogram[i]);
                                new_value = k;
                            }
                        }
                        //给像素赋新值
                        temp = Color.FromArgb(new_value, new_value, new_value);
                        bitmap.SetPixel(i, j, temp);
                    }
                }
                //重新计算属性
                Calculate_Histogram();
                Calculate_CumulativeHistogram();
            }
            else
            {
                //图像不匹配异常处理
                return;
            }

        }

    }
}
