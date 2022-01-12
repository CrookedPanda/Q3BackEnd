using System;
using System.Collections.Generic;
using System.Text;

namespace DTO {
    public class UptimeDTO {
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public string Type { get; }

        public UptimeDTO(DateTime startTime, DateTime endTime, string type) {
            StartTime = startTime;
            EndTime = endTime;
            Type = type;
        }
    }
}
