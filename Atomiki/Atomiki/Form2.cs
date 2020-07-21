using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atomiki
{
    public partial class Form2 : Form
    {
        Random r;
        int count;
        int score = 0;

      
            

        string pathNames = Environment.CurrentDirectory + " /" + "Names.txt";       //Getting the directory of file
        string pathScore = Environment.CurrentDirectory + "/" + "Scores.txt";
        string pathLvl = Environment.CurrentDirectory + "/" + "Levels.txt";


        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundPlayer soundplayer = new SoundPlayer("impact.wav");                                        //Everytime we press the spaceship we get +50 on our score and it changes location
            soundplayer.Play();

            r = new Random();
            score = score + 50;
            if (Form1.interV == 3000 || Form1.interV == 2000)
            {
               pictureBox1.Location = new Point(r.Next(panel1.Width - pictureBox1.Width), r.Next(panel1.Height - pictureBox1.Height));
            }
            
            label2.Text = score.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            r = new Random();
            pictureBox1.Location = new Point(r.Next(panel1.Width - pictureBox1.Width), r.Next(panel1.Height - pictureBox1.Height));  //Change picturebox location on timer tick
                                                                                                                    


            count++;
            if (count == 30)                                                           //using count as the time of each game
            {
                timer1.Stop();

                SoundPlayer soundPlayer = new SoundPlayer("Game_End.wav");
                soundPlayer.Play();


                MessageBox.Show("User :" + Form1.name + Environment.NewLine + "Yours score was :" + score);

                


                using (var write = new StreamWriter(pathNames, true))               //Writing the users name on the file "names"
                {
                    write.WriteLine(Form1.name);
                }



                using (var write = new StreamWriter(pathScore,true))              //Writing the users score on the file "scores"
                {
                    write.WriteLine(score);
                }

                using (var write = new StreamWriter(pathLvl,true))
                {
                    write.WriteLine(Form1.lvl);
                }



                Form1.GlobalNames.Add(Form1.name);                                //Adding the name to the form GlobalNames

                Form1.GlobalScores.Add(score);                                   //Adding the score to the form Globalscores

                Form1.GlobalLevel.Add(Form1.lvl);

              
                 
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = Form1.interV;                //Changing the timer interval based on difficulty setting

            if (Form1.interV == 3000)                      //Changing the size of form based on difficulty
            {
                this.Size = new Size(720,480);
                panel1.Size = new Size(600, 380);
            }
            if (Form1.interV == 2000)
            {
                this.Size = new Size(1080, 720);
                panel1.Size = new Size(920,610);
            }
            if(Form1.interV == 1000)
            {
                this.Size = new Size(1440,900);
                panel1.Size = new Size(1250, 800);
            }
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Cross;
        }

        
    }
}
