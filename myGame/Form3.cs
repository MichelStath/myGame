using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myGame
{
    public partial class Form3 : Form
    {
        Random random;
        int randomImage;
        public Form3()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            randomImage = random.Next(1, 7);
            pictureBox1.ImageLocation = "zaria/" + randomImage.ToString() + ".png";
            randomImage = random.Next(1, 7);
            pictureBox2.ImageLocation = "zaria/" + randomImage.ToString() + ".png";
            randomImage = random.Next(1, 7);
            pictureBox3.ImageLocation = "zaria/" + randomImage.ToString() + ".png";
            randomImage = random.Next(1, 7);
            pictureBox4.ImageLocation = "zaria/" + randomImage.ToString() + ".png";
            randomImage = random.Next(1, 7);
            pictureBox5.ImageLocation = "zaria/" + randomImage.ToString() + ".png";
            randomImage = random.Next(1, 7);
            pictureBox6.ImageLocation = "zaria/" + randomImage.ToString() + ".png";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            random = new Random();
            timer1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
