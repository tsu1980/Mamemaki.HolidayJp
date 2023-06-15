using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mamemaki.HolidayJp
{
    /// <summary>
    /// Utility class of holidays in Japan
    /// 
    /// This class caching caclulated holidays result.
    /// </summary>
    public class JapanHoliday
    {
        private readonly Dictionary<DateTime, Holiday> holidayDict;
        private readonly HashSet<int> loadedYears;

        public JapanHoliday()
        {
            holidayDict = new Dictionary<DateTime, Holiday>();
            loadedYears = new HashSet<int>();
        }

        private void EnsureHolidaysLoaded(int year)
        {
            lock (loadedYears)
            {
                if (!loadedYears.Contains(year))
                {
                    var holidays = HolidayCalculator.GetHolidaysInYear(year);
                    foreach (var holiday in holidays)
                    {
                        holidayDict.Add(holiday.Date, holiday);
                    }
                    loadedYears.Add(year);
                }
            }
        }

        /// <summary>
        /// Get public holidays in the specified year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public IEnumerable<Holiday> GetHolidaysInYear(int year)
        {
            EnsureHolidaysLoaded(year);
            return holidayDict.Values.Where(s => s.Date.Year == year);
        }

        /// <summary>
        /// Get public holidays for a date range
        /// </summary>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <returns></returns>
        public IEnumerable<Holiday> GetHolidaysInDateRange(DateTime dateStart, DateTime dateEnd)
        {
            dateStart = dateStart.Date;
            dateEnd = dateEnd.Date;
            if (dateStart > dateEnd)
                throw new ArgumentOutOfRangeException("dateStart", "must be less than dateEnd");

            for (var year = dateStart.Year; year <= dateEnd.Year; year++)
            {
                EnsureHolidaysLoaded(year);
            }
            return holidayDict.Values.Where(s => s.Date >= dateStart && s.Date <= dateEnd);
        }

        /// <summary>
        /// Get public holiday for the specified date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>public holiday or null if not holiday</returns>
        public Holiday GetHoliday(DateTime date)
        {
            date = date.Date;
            EnsureHolidaysLoaded(date.Year);
            if (!holidayDict.TryGetValue(date, out var holiday))
                return null;
            return holiday;
        }

        /// <summary>
        /// Check if a date is a public holiday
        /// </summary>
        /// <param name="date"></param>
        /// <returns>return true if date is public holiday, otherwise return false</returns>
        public bool IsHoliday(DateTime date)
        {
            return (GetHoliday(date) != null);
        }

        /// <summary>
        /// Check if a date is a weekday
        /// weekday means Monday to Friday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsWeekday(DateTime date)
        {
            return (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday);
        }

        /// <summary>
        /// Check if a date is a weekend
        /// weekend means Saturday or Sunday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsWeekend(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday);
        }

        /// <summary>
        /// Check if today is a working day
        /// working day means Monday to Friday and does not holiday.
        /// </summary>
        /// <returns></returns>
        public bool IsWorkingDay()
        {
            return IsWorkingDay(DateTime.Now);
        }

        /// <summary>
        /// Check if a date is a working day
        /// working day means Monday to Friday and does not holiday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsWorkingDay(DateTime date)
        {
            return (IsWeekday(date) && IsHoliday(date) == false);
        }

        /// <summary>
        /// Get next working day of the specified date
        /// working day means Monday to Friday and does not holiday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime NextWorkingDay(DateTime date)
        {
            date = date.Date.AddDays(1);

            bool isWorkingDay = false;
            while (isWorkingDay == false)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday)
                    date = date.AddDays(2);
                else if (date.DayOfWeek == DayOfWeek.Sunday)
                    date = date.AddDays(1);
                else if (IsWorkingDay(date))
                    isWorkingDay = true;
                else
                    date = date.AddDays(1);
            }
            return date;
        }

        /// <summary>
        /// Get previous working day of the specified date
        /// working day means Monday to Friday and does not holiday.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public DateTime PreviousWorkingDay(DateTime date)
        {
            date = date.Date.AddDays(-1);

            bool isWorkingDay = false;
            while (isWorkingDay == false)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                    date = date.AddDays(-2);
                if (date.DayOfWeek == DayOfWeek.Saturday)
                    date = date.AddDays(-1);
                else if (IsWorkingDay(date))
                    isWorkingDay = true;
                else
                    date = date.AddDays(-1);
            }
            return date;
        }
    }
}
