using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp
{
    class DateUtil
    {
        /// <summary>
        /// Get day number of Nth day of week in the month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="dow"></param>
        /// <param name="weekNumOfMonth">week number of month. (1~5, -1~-5)
        /// if negative, calculate from the last day of month instead the first day of month</param>
        /// <returns>day number of month(1~31) or null if not exist.</returns>
        public static int? GetNthDayOfWeekInMonth(int year, int month, DayOfWeek dow, int weekNumOfMonth)
        {
            if (weekNumOfMonth < -5 || weekNumOfMonth == 0 || weekNumOfMonth > 5)
                throw new ArgumentOutOfRangeException("weekNumOfMonth", $"weekNumOfMonth must be between 1~5 or -1~-5. ({weekNumOfMonth})");

            int daysOfMonth = DateTime.DaysInMonth(year, month);

            if (weekNumOfMonth > 0)
            {
                var firstDay = new DateTime(year, month, 1);
                var firstDayOfTargetDOW = (int)dow - (int)firstDay.DayOfWeek;
                if (firstDayOfTargetDOW < 0)
                    firstDayOfTargetDOW += 7;
                var resultedDay = (firstDayOfTargetDOW + 1) + (7 * (weekNumOfMonth - 1));

                if (resultedDay > daysOfMonth)
                    return null;

                return resultedDay;
            }
            else
            {
                var lastDay = new DateTime(year, month, daysOfMonth);
                var firstDayOfTargetDOW = (int)lastDay.DayOfWeek - (int)dow;
                if (firstDayOfTargetDOW < 0)
                    firstDayOfTargetDOW += 7;
                var resultedDay = firstDayOfTargetDOW + (7 * (Math.Abs(weekNumOfMonth) - 1));

                if (resultedDay > daysOfMonth)
                    return null;

                return (daysOfMonth - resultedDay);
            }
        }
    }
}
