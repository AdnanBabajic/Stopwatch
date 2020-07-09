using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Stopwatch : Form
    {
        private int _hours, _minutes, _seconds;
        private string sHours, sMinutes, sSeconds;
        private Timer timer = new Timer();
         
        public Stopwatch()
        {
            InitializeComponent();
            _hours = 0;
            _minutes = 0;
            _seconds = 0;
            displayTime();

            timer.Interval = (1000);
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _seconds++;
            if(_seconds > 60)
            {
                _minutes++;
                _seconds = 0;
            }

            else if(_minutes > 60)
            {
                _hours++;
                _minutes = 0;
            }

            displayTime();
        }

        private void displayTime()
        {
            transformIntToStringWithDoubleDigit();
            timerLabel.Text = sHours + ":" + sMinutes + ":" + sSeconds;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            resetTimer();
        }

        private void timerLabel_Click(object sender, EventArgs e)
        {

        }

        private void transformIntToStringWithDoubleDigit()
        {
            sHours = string.Format("{0:00}", _hours);
            sMinutes = string.Format("{0:00}", _minutes);
            sSeconds = string.Format("{0:00}", _seconds);
        }

        private void start_Click(object sender, EventArgs e)
        {
            start.Text = timer.Enabled ? "Start" : "Stop";

            startOrStopTimer();
        }

        private void startOrStopTimer()
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }

        private void resetTimer()
        {
            _seconds = 0;
            _minutes = 0;
            _hours = 0;

            displayTime();
        }
    }
}
