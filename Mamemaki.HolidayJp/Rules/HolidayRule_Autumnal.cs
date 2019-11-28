using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp.Rules
{
    class HolidayRule_Autumnal : HolidayRule
    {
        public HolidayRule_Autumnal(HolidayInfo holidayInfo)
            : base(holidayInfo)
        {
        }

        public override Holiday GetHoliday(int year)
        {
            int equinoxDay;
            if (year < 1851)
                equinoxDay = (int)Math.Truncate(22.2588 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1983) / 4.0));
            else if (year >= 1851 && year <= 1899)
                equinoxDay = (int)Math.Truncate(22.2588 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1983) / 4.0));
            else if (year >= 1900 && year <= 1979)
                equinoxDay = (int)Math.Truncate(23.2588 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1983) / 4.0));
            else if (year >= 1980 && year <= 2099)
                equinoxDay = (int)Math.Truncate(23.2488 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1980) / 4.0));
            else if (year >= 2100 && year <= 2150)
                equinoxDay = (int)Math.Truncate(24.2488 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1980) / 4.0));
            else
                equinoxDay = (int)Math.Truncate(24.2488 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1980) / 4.0));

            return new Holiday(new DateTime(year, 9, equinoxDay), HolidayInfo);
        }
    }
}
