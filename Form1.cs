using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)//窗体标题为当前鼠标坐标
        {
            this.Text = e.X + "," + e.Y;
        }

        private void Startbutton_Click(object sender, EventArgs e)//游戏开始
        {
            timer1.Start();
            this.label1.Text = rnd.Next(1000).ToString();//随机数置初始值

        }

        Random rnd = new Random();//随机数
        private int correct_count = 0;//正确数
        private int all_count = 0;//总数


        private void Timer1_Tick(object sender, EventArgs e)
        {

            //label4.Text = label1.Text;

            all_count++;
            if (textBox1.Text == label1.Text) //记录正确数         
                label3.Text = (++correct_count).ToString();
            String count = string.Format("{0,5:P2}", correct_count * 1.0 / all_count);//计算正确率
            if (all_count != 0)
            {
                this.label5.Text = count.ToString();
            }            
            this.label1.Location = new Point(rnd.Next(350), rnd.Next(230));//随机数位置随机
            this.label1.Text = rnd.Next(1000).ToString();//产生随机数
            this.label1.ForeColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));//随机数颜色随机
            this.textBox1.Text = "";//lable清空

        }

        private void Finishbutton_Click(object sender, EventArgs e)//结束按钮
        {
            timer1.Stop();
        }

        private void Button3_Click(object sender, EventArgs e)//退出按钮
        {
            timer1.Stop();
            DialogResult dr = MessageBox.Show("确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
                Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)//速度变快
        {
            timer1.Interval -= 200;
        }

        private void Button2_Click(object sender, EventArgs e)//速度变慢
        {
            timer1.Interval += 200;
        }
    }
}
