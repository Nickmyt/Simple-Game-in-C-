using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atomiki
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)

        {

            

            for (int i = 1; i < Form1.GlobalNames.Count; i++)
            {
                for (int m = 0; m < Form1.GlobalNames.Count - i; m++)
                {
                    if (Form1.GlobalScores[m] < Form1.GlobalScores[m + 1])
                    {
                        int temp = Form1.GlobalScores[m];
                        Form1.GlobalScores[m] = Form1.GlobalScores[m + 1];
                        Form1.GlobalScores[m + 1] = temp;

                        string tmp2 = Form1.GlobalNames[m];
                        Form1.GlobalNames[m] = Form1.GlobalNames[m + 1];
                        Form1.GlobalNames[m + 1] = tmp2;

                        string tmp3 = Form1.GlobalLevel[m];
                        Form1.GlobalLevel[m] = Form1.GlobalLevel[m + 1];
                        Form1.GlobalLevel[m + 1] = tmp3;


                    }
                }
            }

            List<string> scr = Form1.GlobalScores.ConvertAll<string>(x => x.ToString());

            for (int i = 0; i < Form1.GlobalNames.Count; i++)
            {
                if (Form1.GlobalLevel[i] == "Hard")
                {
                    richTextBox3.AppendText( Form1.GlobalLevel[i]+ "\r\n");
                    richTextBox2.AppendText( scr[i]+"\r\n");
                    richTextBox1.AppendText( Form1.GlobalNames[i]+ "\r\n");
                }
            }

        

            for (int i = 0; i <Form1.GlobalNames.Count ; i++)
            {
                if (Form1.GlobalLevel[i] == "Intermediate")
                {
                    
                        richTextBox3.AppendText(Form1.GlobalLevel[i] + "\r\n");
                  
                        richTextBox2.AppendText(scr[i] + "\r\n");
                        richTextBox1.AppendText(Form1.GlobalNames[i] + "\r\n");
                    
                }
            }

          


            for (int i = 0; i < Form1.GlobalNames.Count; i++)
            {
                if (Form1.GlobalLevel[i]== "Easy")
                {
                    richTextBox3.AppendText( Form1.GlobalLevel[i] + "\r\n");
                    richTextBox2.AppendText( scr[i]+"\r\n");
                    richTextBox1.AppendText( Form1.GlobalNames[i]+"\r\n");
                }
            }

       


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }
    }
}
