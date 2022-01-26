using System;
using System.Collections.Generic;

namespace DrumSiteApi.Entities
{
    public class Day
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int systemATime { get; set; }
        public int systemBTime { get; set; }
        public int systemCTime { get; set; }
        public int systemDTime { get; set; }

        public virtual List<Exercise> Exercises { get; set; }
    }
}
