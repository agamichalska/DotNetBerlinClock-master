using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock
{
    public class Clock : IClock
    {
        private readonly List<List<Lamp>> _rows;
        public Clock()
        {
            _rows = new List<List<Lamp>>();

            //seconds
            _rows.Add(new List<Lamp> { new YellowLamp() });
            //hours: 4 x 5h
            _rows.Add(new List<Lamp> { new RedLamp(), new RedLamp(), new RedLamp(), new RedLamp() });
            //hours: 4 x 1h
            _rows.Add(new List<Lamp> { new RedLamp(), new RedLamp(), new RedLamp(), new RedLamp() });
            //minutes: 11 x 5min
            _rows.Add(new List<Lamp> {    new YellowLamp(), new YellowLamp(), new RedLamp(),
                                                new YellowLamp(), new YellowLamp(), new RedLamp(),
                                                new YellowLamp(), new YellowLamp(), new RedLamp(),
                                                new YellowLamp(), new YellowLamp() });
            //minutes: 4 x 1min
            _rows.Add(new List<Lamp> { new YellowLamp(), new YellowLamp(), new YellowLamp(), new YellowLamp() });
        }
        public string ReadTime(List<int> timeTable)
        {
            if(timeTable.Count != 5)
            {
                throw new ArgumentException("Incorrect time table");
            }
            Reset();
            SetTime(timeTable);

            var sb = new StringBuilder();

            for (int i = 0; i < _rows.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append("\r\n");
                }

                _rows[i].ForEach(lamp => sb.Append(lamp.GetColor()));
            }

            return sb.ToString();
        }
        private void Reset()
        {
            foreach (var row in _rows)
            {
                foreach (var lamp in row)
                {
                    lamp.TurnOff();
                }
            }
        }
        private void SetTime(List<int> timeTable)
        {
            for (int i = 0; i < timeTable.Count; i++)
            {
                SwitchLampsInRow(i, timeTable[i]);
            }
        }
        private void SwitchLampsInRow(int rowNumber, int lampCounter)
        {
            for (int i = 0; i < lampCounter; i++)
            {
                _rows[rowNumber][i].TurnOn();
            }
        }
    }
}
