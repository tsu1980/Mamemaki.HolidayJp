using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp.Rules
{
    class HolidayRule_Citizens : HolidayRule
    {
        public HolidayRule_Citizens(HolidayInfo holidayInfo)
            : base(holidayInfo)
        {
        }

        public override Holiday GetHoliday(int year)
        {
            if (year < 1988 || year > 2006 || year == 1992 || year == 1997 || year == 1998 || year == 2003)
                return null;

            return new Holiday(new DateTime(year, 5, 4), HolidayInfo);
        }
    }
}
