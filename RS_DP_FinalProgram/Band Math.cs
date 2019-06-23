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

    public partial class Band_Math : Form
    {
        Bitmap[] Band_Math_Image;
        string[] Band_Name;
        int band_count = 0;
        int Band1 = -1;
        int Band2 = -1;
        int Arithmetic = -1;
        Bitmap Result;
        bool condition = false;
        //初始化
        public Band_Math(string[] Bands,int Band_Count, Bitmap[] Image)
        {
            InitializeComponent();
            //初始化数据
            Band_Math_Image = new Bitmap[Band_Count];
            Band_Name = new string[Band_Count];
            band_count = Band_Count;
            for(int i=0;i<band_count;i++)
            {
                Band_Math_Image[i] = new Bitmap(Image[i]);
                Band_Name[i] = Bands[i];
            }
            //在combobox中插入波段信息
            for(int i=0;i<Band_Count;i++)
            {
                comboBox1.Items.Add(Bands[i]);
                comboBox2.Items.Add(Bands[i]);
            }
            //初始化运算选择combobox
            comboBox3.Items.Add("+");
            comboBox3.Items.Add("-");
            comboBox3.Items.Add("*");
        }
        //获取待计算的波段2
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < band_count; i++)
            {
                if (comboBox1.Text == Band_Name[i])
                {
                    Band2 = i;
                    break;
                }
            }
        }
        //确定计算
        private void button1_Click(object sender, EventArgs e)
        {
            //判断是否输入完成
            if (Band1 == -1 || Band2 == -1)
            {
                MessageBox.Show("Please Select Band!", "WARNING");
                return;
            }
            if(Arithmetic==-1)
            {
                MessageBox.Show("Please Select Arithmetic!", "WARNING");
                return;
            }
            //计算
            if(Arithmetic == 1)
            {
                Bitmap_Process temp = new Bitmap_Process(Band_Math_Image[Band1]);
                temp.Band_Math_Add(Band_Math_Image[Band2]);
                Result = Band_Math_Image[Band1];
            }
            else if(Arithmetic == 2)
            {
                Bitmap_Process temp = new Bitmap_Process(Band_Math_Image[Band1]);
                temp.Band_Math_Subtract(Band_Math_Image[Band2]);
                Result = Band_Math_Image[Band1];
            }
            else if (Arithmetic == 3)
            {
                Bitmap_Process temp = new Bitmap_Process(Band_Math_Image[Band1]);
                temp.Band_Math_Multiplication(Band_Math_Image[Band2]);
                Result = Band_Math_Image[Band1];
            }

            condition = true;
        }
        //获取待计算的波段1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for(int i=0;i<band_count;i++)
            {
                if (comboBox1.Text == Band_Name[i])
                {
                    Band1 = i;
                    break;
                }
            }
        }
        //获取运算符
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "+")
                Arithmetic = 1;
            if (comboBox3.Text == "-")
                Arithmetic = 2;
            if (comboBox3.Text == "*")
                Arithmetic = 3;
        }
        //保存结果
        private void button2_Click(object sender, EventArgs e)
        {
            if(condition==false)
            {
                MessageBox.Show("If you have selected all parameter.\r\nPlease click the button OK!", "WARNING");
            }
            else if(condition==true)
            {
                saveFileDialog1.Filter = "普通图像 |*.jpg;*.jepg;*.png;*.bmp;*.gif|遥感数字图像|*.hdr";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Result.Save(saveFileDialog1.FileName);
                }
            }
        }
    }
}
