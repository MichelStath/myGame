using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace myGame
{
    public partial class Form1 : Form
    {
        int counter;
        int countDown = 30;
        int countDown1 = 30;
        int countDown2 = 20;
        int countDown3 = 20;
        int countDown4 = 14;
        Random random;
        int randomImage;
        int sum;
        int hscore = 0;
        String Username;
        List<Player> playerList = new List<Player>();
        List<Player> loglist = new List<Player>();



        public Form1()
        {
            InitializeComponent();
        }
        public Form1(String s)
        {
            InitializeComponent();
            label8.Text = s;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            random = new Random();
            Username = label8.Text;
            hscoreLabel.Text = hscore.ToString();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("student.ser", FileMode.OpenOrCreate, FileAccess.Read);
            loglist = (List<Player>)formatter.Deserialize(stream);           
            bool newplayer = false;
            /*clear log list
            for (int i = 0; i < loglist.Count; i++)
            {
                loglist.Remove(loglist.ElementAt(i));
            }*/
            foreach (Player play in loglist)
            {
                playerList.Add(play);
                //MessageBox.Show(play.HighScore.ToString());
                //MessageBox.Show(play.UserName);
                if (play.UserName.Equals(Username))
                    {
                        hscore = play.HighScore;
                        newplayer = false;
                }
                    else 
                    {
                        newplayer = true;                       
                    }
                   //MessageBox.Show(play.HighScore.ToString());
                   //MessageBox.Show(play.UserName);
            }
            if (newplayer)
            {
                Player p = new Player(Username, 0);
                playerList.Add(p);
                newplayer = false;

            }
            stream.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            fastclock.Enabled = true;
            colortimer.Enabled = true;
            button1.Visible = false;
            crazybox.Visible = true;
            counter = 0;
            sum = 0;
            lvl1.Enabled = false;
            lvl2.Enabled = false;
            lvl3.Enabled = false;
            lvl4.Enabled = false;

            if (lvl1.Checked)
            {
                countDown = countDown1;
                crazybox.Enabled = true;
            }
            else if (lvl2.Checked)
            {
                countDown = countDown2;
                crazybox.Enabled = true;
            }
            else if (lvl3.Checked)
            {
                countDown = countDown3;
                crazybox.Enabled = true;
            }
            else if (lvl4.Checked)
            {
                countDown = countDown4;
                crazybox.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            fastclock.Enabled = false;
            colortimer.Enabled = false;
            button1.Visible = true;
            crazybox.Enabled = false;
            timeLabel.Text = "???";
            counter = 0;
            sum = 0;
            lvl1.Enabled = true;
            lvl2.Enabled = true;
            lvl3.Enabled = true;
            lvl4.Enabled = true;
            crazybox.Visible = false;
            this.panel1.BackColor = Color.Black;
            hscoreLabel.Text = hscore.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lvl1.Checked || lvl2.Checked)
            {
                crazybox.Enabled = true;
                randomImage = random.Next(1, 7);
                crazybox.ImageLocation = "zaria/" + randomImage.ToString() + ".png";
                int x1, y1;
                x1 = random.Next(this.panel1.Width - crazybox.Width);
                y1 = random.Next(this.panel1.Height - crazybox.Height);
                crazybox.Location = new Point(x1, y1);


            }
                countDown--;
                timeLabel.Text = countDown.ToString();
                if (countDown == 0)
                {
                    timer1.Enabled = false;
                    crazybox.Enabled = false;
                    colortimer.Enabled = false;
                    crazybox.Visible = false;
                    button1.Visible = true;
                    this.panel1.BackColor = Color.Black;
                    lvl1.Enabled = true;
                    lvl2.Enabled = true;
                    lvl3.Enabled = true;
                    lvl4.Enabled = true;
                if (sum > hscore)
                {
                    hscore = sum;
                    hscoreLabel.Text = hscore.ToString();
                }

            }
            
      }

        private void crazybox_Click(object sender, EventArgs e)
        {
            counter++;
            clicksLabel.Text = counter.ToString();
            sum += randomImage;
            scoreLabel.Text = sum.ToString();
                 
        }

        private void lvl1_CheckedChanged(object sender, EventArgs e)
        {
            levelLabel.Text = "1";
            countDown = countDown1;
            timeLabel.Text = countDown1.ToString();
        }

        private void lvl2_CheckedChanged(object sender, EventArgs e)
        {
            levelLabel.Text = "2";
            countDown = countDown2;
            timeLabel.Text = countDown2.ToString();
        }

        private void lvl3_CheckedChanged(object sender, EventArgs e)
        {
            levelLabel.Text = "3";
            countDown = countDown3;
            timeLabel.Text = countDown3.ToString();
        }

        private void lvl4_CheckedChanged(object sender, EventArgs e)
        {
            levelLabel.Text = "4";
            countDown = countDown4;
            timeLabel.Text = countDown4.ToString();
        }

        private void fastclock_Tick(object sender, EventArgs e)
        {
            if (lvl3.Checked || lvl4.Checked)
            {
                crazybox.Enabled = true;
                randomImage = random.Next(1, 7);
                crazybox.ImageLocation = "zaria/" + randomImage.ToString() + ".png";
                int x1, y1;
                x1 = random.Next(this.panel1.Width - crazybox.Width);
                y1 = random.Next(this.panel1.Height - crazybox.Height);
                crazybox.Location = new Point(x1, y1);
                
            }
            if (lvl3.Checked)
            {
                this.panel1.BackColor = Color.FromKnownColor((KnownColor)random.Next((int)KnownColor.YellowGreen) + 1);
            }
            if (countDown == 0)
            {
                fastclock.Enabled = false;
                colortimer.Enabled = false;
                crazybox.Enabled = false;
                button1.Visible = true;
                lvl1.Enabled = true;
                lvl2.Enabled = true;
                lvl3.Enabled = true;
                lvl4.Enabled = true;
                this.panel1.BackColor = Color.Black;
            }          
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            if (lvl3.Checked)
            {
                sum = sum - 2;
                scoreLabel.Text = sum.ToString();
            }
            if (lvl4.Checked)
            {
                sum = sum - 4;
                scoreLabel.Text = sum.ToString();
            }
        }

        private void colortimer_Tick(object sender, EventArgs e)
        {
            if (lvl4.Checked)
            {
                this.panel1.BackColor = Color.FromKnownColor((KnownColor)random.Next((int)KnownColor.YellowGreen) + 1);
            }
            if (countDown == 0)
            {
                this.panel1.BackColor = Color.Black;
                fastclock.Enabled = false;
                colortimer.Enabled = false;
                crazybox.Enabled = false;
                button1.Visible = true;
                lvl1.Enabled = true;
                lvl2.Enabled = true;
                lvl3.Enabled = true;
                lvl4.Enabled = true;                 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            String Username = label8.Text;
            foreach(Player pl in playerList)
            {
                if (pl.UserName.Equals(Username))
                {
                    pl.HighScore = hscore;
                }
            }
           
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("student.ser", FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(stream, playerList);
            stream.Close();             
            //MessageBox.Show(pl.HighScore.ToString());
            //MessageBox.Show(pl.UserName);
            this.Close();

        }
    }
}
