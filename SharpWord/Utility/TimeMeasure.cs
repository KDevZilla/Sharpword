using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWord.Utility
{
    public class TimeMeasure
    {
        private Stopwatch stopwatch = null;
        public void Start()
        {
            stopwatch = Stopwatch.StartNew();

        }
        public void Finish()
        {
            stopwatch.Stop();
        }
        public TimeSpan TimeTakes
        {
            get
            {
                return stopwatch.Elapsed;
            }
        }
    }
}
