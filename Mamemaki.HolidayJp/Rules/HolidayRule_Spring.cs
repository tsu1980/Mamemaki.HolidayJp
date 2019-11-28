using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp.Rules
{
    class HolidayRule_Spring : HolidayRule
    {
        public HolidayRule_Spring(HolidayInfo holidayInfo)
            : base(holidayInfo)
        {
        }

        public override Holiday GetHoliday(int year)
        {
            int equinoxDay;
            if (year < 1851)
                equinoxDay = (int)Math.Truncate(19.8277 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1983) / 4.0));
            else if (year >= 1851 && year <= 1899)
                equinoxDay = (int)Math.Truncate(19.8277 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1983) / 4.0));
            else if (year >= 1900 && year <= 1979)
                equinoxDay = (int)Math.Truncate(20.8357 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1983) / 4.0));
            else if (year >= 1980 && year <= 2099)
                equinoxDay = (int)Math.Truncate(20.8431 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1980) / 4.0));
            else if (year >= 2100 && year <= 2150)
                equinoxDay = (int)Math.Truncate(21.8510 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1980) / 4.0));
            else
                equinoxDay = (int)Math.Truncate(21.8510 + 0.242194 * (year - 1980) - (int)Math.Truncate((year - 1980) / 4.0));

            return new Holiday(new DateTime(year, 3, equinoxDay), HolidayInfo);
        }
    }
}
