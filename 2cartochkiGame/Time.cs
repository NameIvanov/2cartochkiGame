using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _2cartochkiGame
{
    internal class Time
    {
        Timer timer = new Timer();
        static public int itogTime { get; set; }
        public void Start()
        {
            timer.Interval = 1000;
            timer.Elapsed += OnTimedEvent;
            itogTime = 0;
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            itogTime++;
        }

    }
}
