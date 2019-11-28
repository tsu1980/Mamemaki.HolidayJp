using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp.Rules
{
    class HolidayRule_Fixed : HolidayRule
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public HolidayRule_Fixed(HolidayInfo holidayInfo, int month, int day, int startYear, int endYear)
            : base(holidayInfo)
        {
            Month = month;
            Day = day;
            StartYear = startYear;
            EndYear = endYear;
        }

        public override Holiday GetHoliday(int year)
        {
            if (year < StartYear || year > EndYear)
                return null;

            return new Holiday(new DateTime(year, Month, Day), HolidayInfo);
        }
    }
}
