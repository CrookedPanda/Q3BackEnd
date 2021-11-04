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
            uptime = calcUptime(ts);
        }

        public DateTime startTime { get; set; }
        public List<DateTime> timestamps { get; set; }
        public int uptime { get; set; }

        private int calcUptime(List<DateTime> ts) {
            int uptimeDefault = 30;
            TimeSpan? timeOffline = TimeSpan.Parse("00:05:00");
            DateTime? timeStore = null;
            if (ts != null)
            {
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
                        uptimeDefault = uptimeDefault - int.Parse(time.TotalMinutes.ToString());
                    }
                    timeStore = item;
                }
                return uptimeDefault;
            }
            return 0;
        }
    }
}
