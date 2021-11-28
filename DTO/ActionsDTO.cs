using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ActionsDTO
    {
        public ActionsDTO(int week, int count)
        {
            this.week = week;
            this.count = count;
        }

        public int week { get; set; }
        public int count { get; set; }
    }
}
