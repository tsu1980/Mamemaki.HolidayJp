using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp
{
    abstract class HolidayRule
    {
        public HolidayInfo HolidayInfo { get; set; }

        protected HolidayRule(HolidayInfo holidayInfo)
        {
            HolidayInfo = holidayInfo;
        }

        public abstract Holiday GetHoliday(int year);
    }
}
