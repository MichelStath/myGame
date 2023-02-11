using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace myGame
{
    public partial class Form2 : Form
    {
        Random random;
        int randomImage;
        String username;
        List<Player> loglist = new List<Player>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            random = new Random();
            timer1.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(richTextBox1.Text);
            form1.Show();
            timer1.Enabled = false;
            richTextBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

         private void button4_Click(object sender, EventArgs e)
        {
             username = richTextBox1.Text;
             bool newplayer = false;
             IFormatter formatter = new BinaryFormatter();
             Stream stream = new FileStream("student.ser", FileMode.OpenOrCreate, FileAccess.Read);
             loglist = (List<Player>)formatter.Deserialize(stream);
             foreach(Player pl in loglist)
             {
                 if (pl.UserName.Equals(richTextBox1.Text))
                 {
                     MessageBox.Show("your HIGH SCORE IS:  " + pl.HighScore.ToString());
                    MessageBox.Show("PLAY TO MAKE A HIGH SCORE");
                    newplayer = false;
                     break;
                 }
                 else
                 {
                     newplayer = true;
                 }

             }
             if (newplayer)
             {
                MessageBox.Show("HALLO NEW PLAYER,YOU HAVE NO HIGH SCORE");
                MessageBox.Show("PLAY TO MAKE A HIGH SCORE");
             }
             stream.Close();
         }

             private void button3_Click(object sender, EventArgs e)
             {
                 username = richTextBox1.Text;
                 IFormatter formatter = new BinaryFormatter();
                 Stream stream = new FileStream("student.ser", FileMode.OpenOrCreate, FileAccess.Read);
                 loglist = (List<Player>)formatter.Deserialize(stream);
                 for (int i = 0; i < loglist.Count; i++)
                 {
                    richTextBox2.AppendText(loglist.ElementAt(i).UserName + " " + loglist.ElementAt(i).HighScore +  Environment.NewLine);
                 }
                 stream.Close();
             }
    }
}
