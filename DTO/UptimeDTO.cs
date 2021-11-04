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
            uptime = calcUptime(ts);
            downtime = 30 - uptime;
        }

        public DateTime startTime { get; set; }
        public int uptime { get; set; }
        public int downtime { get; set; }

        private int calcUptime(List<DateTime> ts) {
            int uptimeDefault = 30;
            TimeSpan? timeOffline = TimeSpan.Parse("00:05:00");
            DateTime? timeStore = null;
            if (ts == null)
            {
                return 0;
            }
            foreach (var item in ts)
            {
                if (timeStore == null)
                {
                    timeStore = item;
                }
                var thing = timeStore.HasValue ? item - timeStore : null;
                if (thing > timeOffline)
                {
                    TimeSpan time = TimeSpan.Parse(thing.ToString());
                    uptimeDefault = uptimeDefault - Convert.ToInt32(time.TotalMinutes);
                    if (uptimeDefault <= 0)
                    {
                        return 0;
                    }
                }
                timeStore = item;
            }
            return uptimeDefault;
        }
    }
}
