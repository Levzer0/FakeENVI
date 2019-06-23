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
    public partial class User_Defined_Template : Form
    {
        public bool condition = false;
        public int Template_Size = 3;
        public int[] Template = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public User_Defined_Template()
        {
            InitializeComponent();
            comboBox1.Items.Add("2 × 2");
            comboBox1.Items.Add("3 × 3");
            comboBox1.Text = "3 × 3";
        }
        //确定
        private void button1_Click(object sender, EventArgs e)
        {
            condition = true;

            if (Template_Size == 3)
            {
                Template[0] = int.Parse(textBox1.Text);
                Template[1] = int.Parse(textBox2.Text);
                Template[2] = int.Parse(textBox3.Text);
                Template[3] = int.Parse(textBox4.Text);
                Template[4] = int.Parse(textBox5.Text);
                Template[5] = int.Parse(textBox6.Text);
                Template[6] = int.Parse(textBox7.Text);
                Template[7] = int.Parse(textBox8.Text);
                Template[8] = int.Parse(textBox9.Text);
            }
            else if (Template_Size == 2)
            {
                Template[0] = int.Parse(textBox1.Text);
                Template[1] = int.Parse(textBox2.Text);
                Template[3] = int.Parse(textBox4.Text);
                Template[4] = int.Parse(textBox5.Text);
            }
            else
                MessageBox.Show("Please Select Template Size!", "WARNING");

            this.Close();
        }
        //清空
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text== "2 × 2")
            {
                Template_Size = 2;
                //初始化
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "0";
                //隐藏多余TextBox
                textBox3.Hide();
                textBox6.Hide();
                textBox7.Hide();
                textBox8.Hide();
                textBox9.Hide();
            }
            else if(comboBox1.Text== "3 × 3")
            {
                //显示隐藏控件
                textBox3.Show();
                textBox6.Show();
                textBox7.Show();
                textBox8.Show();
                textBox9.Show();
                //初始化
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "0";
                textBox5.Text = "0";
                textBox6.Text = "0";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
            }
            else
                MessageBox.Show("Please Select Template Size!", "WARNING");
        }
    }
}
