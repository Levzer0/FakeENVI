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
    public partial class Choose_Range : Form
    {
        public int Max;
        public int Min;
        public bool Input_Condition = false;

        public Choose_Range(int Max,int Min)
        {
            InitializeComponent();
            //显示当前图像DN值范围
            textBox1.Text = Max.ToString();
            textBox2.Text = Min.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                Max = int.Parse(textBox3.Text);
                Min = int.Parse(textBox4.Text);
                Input_Condition = true;
                this.Close();
            }
            else
                MessageBox.Show("Please Enter Value!", "WARNING");
        }
    }
}
