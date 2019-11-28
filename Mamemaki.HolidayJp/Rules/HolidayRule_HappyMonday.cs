using Mamemaki.HolidayJp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp.Rules
{
    class HolidayRule_HappyMonday : HolidayRule
    {
        public int Month { get; set; }
        public int WeekNumberOfMonth { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public HolidayRule_HappyMonday(HolidayInfo holidayInfo, 
            int month, int weekNumberOfMonth, int startYear, int endYear)
            : base(holidayInfo)
        {
            Month = month;
            WeekNumberOfMonth = weekNumberOfMonth;
            StartYear = startYear;
            EndYear = endYear;
        }

        public override Holiday GetHoliday(int year)
        {
            if (year < StartYear || year > EndYear)
                return null;

            var day = DateUtil.GetNthDayOfWeekInMonth(year, Month, DayOfWeek.Monday, WeekNumberOfMonth);
            if (!day.HasValue)
                return null;

            return new Holiday(new DateTime(year, Month, day.Value), HolidayInfo);
        }
    }
}
