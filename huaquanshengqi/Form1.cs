using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace huaquanshengqi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try 
	{
            string number = textBox2.Text;
            string imageurl = textBox1.Text;
		    Image img = Image.FromFile(imageurl);
            Brush brush = Brushes.Coral;
            int ImageWidth, ImageHeight;
            pictureBox1.Image = img;
            ImageWidth = img.Width;
            ImageHeight = img.Height;
            Graphics g = Graphics.FromImage(img);
            SolidBrush brush1 = new SolidBrush(Color.Wheat);
            SolidBrush brush2 = new SolidBrush(Color.Red);
            //Graphics g = this.pictureBox1.CreateGraphics();
            //Pen p = new Pen(Color.Red);
            Font font = new Font("Arial",30);
            g.FillEllipse(brush2, ImageWidth - 50, 0, 50, 50);
            if (number==String.Empty)
            {
            g.DrawString("1",font,brush1,ImageWidth-45,3);
                
            }
            else
            {
                string RegStr = @"^\d$";
                System.Text.RegularExpressions.Regex rg = new System.Text.RegularExpressions.Regex(RegStr);
                if (rg.IsMatch(number))
                {
                    g.DrawString(number, font, brush1, ImageWidth - 45, 3);
                }
                else
                {
                    //Font font1 = new Font("Arial", 30);
                    textBox2.Text = "请输入一位数字";
                }

            }
            
	}
	catch (Exception)
	{
        textBox1.Text = "请输入正确的路径";
	}
              
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save=new SaveFileDialog();
            save.Filter = "(*.jpg)|*.jpg";
            save.FilterIndex = 2;
            save.RestoreDirectory = true;
            if (save.ShowDialog()==DialogResult.OK)
            {
                this.pictureBox1.Image.Save(save.FileName,System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
