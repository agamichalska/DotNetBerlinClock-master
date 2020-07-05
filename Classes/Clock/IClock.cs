using System.Collections.Generic;

namespace BerlinClock
{
    public interface IClock
    {
        string ReadTime(List<int> timeTable);
    }
}
