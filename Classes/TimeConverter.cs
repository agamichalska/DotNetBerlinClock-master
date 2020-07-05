using System;
using System.Collections.Generic;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private IClock _clock;
        public TimeConverter(IClock clock)
        {
            _clock = clock;
        }
        public string convertTime(string aTime)
        {
            var time = new List<int>();

            foreach(var t in aTime.Split(':'))
            {
                int partTime;                
                if (!int.TryParse(t, out partTime))
                {
                    throw new ArgumentException("Incorrect time format");
                }
                time.Add(partTime);
            }

            return _clock.ReadTime(GetTimeTable(time));
        }
        private List<int> GetTimeTable(List<int> time)
        {
            var timeTable = new List<int>();

            timeTable.Add(HandleSeconds(time[2]));
            timeTable.AddRange(HandleHrMin(time[0]));
            timeTable.AddRange(HandleHrMin(time[1]));

            return timeTable;
        }
        private int HandleSeconds(int seconds)
        {
            return (seconds + 1) % 2;
        }
        private List<int> HandleHrMin(int time)
        {
            var timeTable = new List<int>();

            timeTable.Add(time / 5);
            timeTable.Add(time % 5);

            return timeTable;
        }
    }
}
