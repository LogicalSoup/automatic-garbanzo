using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//A program to test github under the guise of a very simple program

namespace Steinsgate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ClientSize = new Size(280, 40);
        }

        int Mil=00, Sec=00, Min=00, Hour=00;
        string SecS="0", MinS="0", HourS="0";

        Label Gate = new Label()
        {
            Location = new Point(0, 0),
            Font = new Font("Courier New", 30),
            AutoSize = false,
            Size = new Size(290, 40),
            Text = ("00:00;00,00")
        };

        Timer Milli = new Timer()
        {
            Enabled = true,
            Interval = 100,
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(Gate);
            Milli.Tick += new EventHandler(Milli_Tick);
        }

        private void Milli_Tick(object sender, EventArgs e)
        {
            Mil++;

            if(Mil == 10){
                Mil = 0;
                Sec++;
                if(Sec == 60)
                {
                    Sec = 0;
                    Min++;
                    if(Min == 60)
                    {
                        Min = 0;
                        Hour++;
                    }
                }
            }

            if(Sec >= 10) { SecS = ""; } else { SecS = "0"; }
            if(Min >= 10) { MinS = ""; } else { MinS = "0"; }
            if (Hour >= 10) { HourS = ""; } else { HourS = "0"; }

            Gate.Text = HourS + Hour.ToString() + ":" + MinS + Min.ToString() + ";" + SecS + Sec.ToString() + ",0" + Mil.ToString();
        }
    }
}
