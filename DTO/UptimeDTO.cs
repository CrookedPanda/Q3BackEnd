using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class UptimeDTO
    {
        public UptimeDTO(DateTime strt, List<DateTime> ts)
        {
            startTime = strt;
            timestamps = ts;
            uptime = calcUptime();
        }

        public DateTime startTime { get; set; }
        public List<DateTime> timestamps { get; set; }
        public int uptime { get; set; }

        private int calcUptime() {
            //TODO
            return 0;
        }
    }
}
