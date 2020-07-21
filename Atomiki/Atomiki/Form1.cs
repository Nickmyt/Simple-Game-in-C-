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
    public partial class Form1 : Form
    {

        public static int interV ;
        public static string name = "user";
        public static string lvl = "Easy";


        

        string pathNames = Environment.CurrentDirectory + " /" + "Names.txt";
        string pathScore = Environment.CurrentDirectory + "/" + "Scores.txt";
        string pathLvl = Environment.CurrentDirectory + "/" + "Levels.txt";

       

        public static List<string> GlobalNames = new List<string>();
        public static List<int> GlobalScores = new List<int>();
        public static List<string> GlobalLevel = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            radioButton1.Checked = true;

            var lognames = File.ReadAllLines(pathNames);
            var ScoreTxt = File.ReadAllLines(pathScore);
            var LevelLog = File.ReadAllLines(pathLvl);

            List<string> scoreTxt = new List<string>(ScoreTxt);

            List<string> Names = new List<string>(lognames);

            List<int> Scores = scoreTxt.Select(int.Parse).ToList();

            List<string> levels = new List<string>(LevelLog);

            GlobalNames.AddRange(Names);
            GlobalScores.AddRange(Scores);
            GlobalLevel.AddRange(levels);



            

         }




        private void button4_Click_1(object sender, EventArgs e)
        {
           
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)

        {
            SoundPlayer soundPlayer = new SoundPlayer( "change_name.wav");
            soundPlayer.Play();

            name = textBox1.Text;

            label3.Text = name;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SoundPlayer soundplayer = new SoundPlayer("button.wav");
            soundplayer.Play();

            Form2 form2 = new Form2();
            if (radioButton1.Checked == true)
            {
                interV = 3000;

            }
            if (radioButton2.Checked == true)
            {
                interV = 2000;
                lvl = "Intermediate";
            }
            if(radioButton3.Checked == true)
            {
                interV = 1000;
                lvl = "Hard";
            }
            form2.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer("button.wav");
            soundPlayer.Play();

            if (groupBox1.Visible == false)
            {
                groupBox1.Show();

            }
            else
            {
                groupBox1.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer("button.wav");
            soundPlayer.Play();

            Form3 form3 = new Form3();
            form3.Show();
            
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           Difficulty();
        }


        private void Difficulty()
        {
            SoundPlayer soundPlayer = new SoundPlayer("Difficulty.wav");
            soundPlayer.Play();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Difficulty();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Spaceship destroyer Shutting down");
           
        }
    }
}
