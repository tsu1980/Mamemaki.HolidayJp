using Mamemaki.HolidayJp.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mamemaki.HolidayJp
{
    public class HolidayCalculator
    {
        static readonly List<HolidayRule> Rules;

        static HolidayCalculator()
        {
            Rules = new List<HolidayRule>
            {
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "元日", "New Year's Day"), 1, 1, 1949, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "成人の日", "Coming of Age Day"), 1, 15, 1949, 1999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "建国記念の日", "National Foundation Day"), 2, 11, 1967, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "天皇誕生日", "The Emperor's Birthday"), 2, 23, 2020, 9999),
                new HolidayRule_Spring(new HolidayInfo(HolidayKind.National, "春分の日", "Vernal Equinox Day")),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "天皇誕生日", "The Emperor's Birthday"), 4, 29, 1949, 1989),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "みどりの日", "Greenery Day"), 4, 29, 1990, 2006),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "昭和の日", "Showa Day"), 4, 29, 2007, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "憲法記念日", "Constitution Memorial Day"), 5, 3, 1949, 9999),
                new HolidayRule_Citizens(new HolidayInfo(HolidayKind.National, "国民の休日", "Holiday for a Nation")),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "みどりの日", "Greenery Day"), 5, 4, 2007, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "こどもの日", "Children's Day"), 5, 5, 1949, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "海の日", "Marine Day"), 7, 20, 1996, 2002),
                new HolidayRule_HappyMonday(new HolidayInfo(HolidayKind.National, "海の日", "Marine Day"), 7, 3, 2003, 2019),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "海の日", "Marine Day"), 7, 23, 2020, 2020),
                new HolidayRule_HappyMonday(new HolidayInfo(HolidayKind.National, "海の日", "Marine Day"), 7, 3, 2021, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "山の日", "Mountain Day"), 8, 11, 2016, 2019),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "山の日", "Mountain Day"), 8, 10, 2020, 2020),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "山の日", "Mountain Day"), 8, 11, 2021, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "敬老の日", "Respect for the Aged Day"), 9, 15, 1966, 2002),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "文化の日", "National Culture Day"), 11, 3, 1948, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "勤労感謝の日", "Labbor Thanksgiving Day"), 11, 23, 1948, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "天皇誕生日", "The Emperor's Birthday"), 12, 23, 1989, 2018),
                new HolidayRule_Autumnal(new HolidayInfo(HolidayKind.National, "秋分の日", "Autumnal Equinox Day")),
                new HolidayRule_HappyMonday(new HolidayInfo(HolidayKind.National, "成人の日", "Coming of Age Day"), 1, 2, 2000, 9999),
                new HolidayRule_HappyMonday(new HolidayInfo(HolidayKind.National, "敬老の日", "Respect for the Aged Day"), 9, 3, 2003, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "体育の日", "Health and Sports Day"), 10, 10, 1966, 1999),
                new HolidayRule_HappyMonday(new HolidayInfo(HolidayKind.National, "体育の日", "Health and Sports Day"), 10, 2, 2000, 2019),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "スポーツの日", "Health and Sports Day"), 7, 24, 2020, 2020),
                new HolidayRule_HappyMonday(new HolidayInfo(HolidayKind.National, "スポーツの日", "Health and Sports Day"), 10, 2, 2021, 9999),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "皇太子明仁親王の結婚の儀", "The Rite of Wedding of HIH Crown Prince Akihito"), 4, 10, 1959, 1959),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "昭和天皇の大喪の礼", "The Funeral Ceremony of Emperor Showa"), 2, 24, 1989, 1989),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "即位礼正殿の儀", "The Ceremony of the Enthronement of His Majesty the Emperor (at the Seiden)"), 11, 12, 1990, 1990),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "皇太子徳仁親王の結婚の儀", "The Rite of Wedding of HIH Crown Prince Naruhito"), 6, 9, 1993, 1993),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "天皇の即位の日", "Day of cadence"), 5, 1, 2019, 2019),
                new HolidayRule_Fixed(new HolidayInfo(HolidayKind.National, "即位礼正殿の儀の行われる日", "The Ceremony of the Enthronement of His Majesty the Emperor (at the Seiden)"), 10, 22, 2019, 2019),
            };
        }
        
        /// <summary>
        /// Get holidays in the specified year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static IEnumerable<Holiday> GetHolidaysInYear(int year)
        {
            var holidays = new List<Holiday>();

            // 固定祝日
            // 春分／秋分の日
            // ハッピーマンデー
            foreach (var rule in Rules)
            {
                var holiday = rule.GetHoliday(year);
                if (holiday != null)
                    holidays.Add(holiday);
            }

            // 振替休日
            var substituteHolidays = GetSubstituteHolidays(holidays);
            holidays.AddRange(substituteHolidays);

            // 国民の休日
            var citizensHolidays = GetCitizensHolidays(holidays);
            holidays.AddRange(citizensHolidays);

            return holidays
                .OrderBy(s => s.Date);
        }

        private static IEnumerable<Holiday> GetSubstituteHolidays(IEnumerable<Holiday> holidays)
        {
            var effectiveDate = new DateTime(1973, 4, 29);
            var substituteHolidays = new List<Holiday>();

            foreach (var holiday in holidays)
            {
                if (holiday.Date.DayOfWeek != DayOfWeek.Sunday)
                    continue;
                if (holiday.Date < effectiveDate)
                    continue;

                var dayOfSubstitute = holiday.Date.AddDays(1);
                while (holidays.Any(s => s.Date == dayOfSubstitute))
                    dayOfSubstitute = dayOfSubstitute.AddDays(1);

                var holidayInfo = new HolidayInfo(HolidayKind.Substitute, 
                    $"{holiday.Name} 振替休日", $"Substitute day (for {holiday.Name})");
                var substituteHoliday = new Holiday(dayOfSubstitute, holidayInfo);
                substituteHolidays.Add(substituteHoliday);
            }

            return substituteHolidays;
        }

        private static IEnumerable<Holiday> GetCitizensHolidays(IEnumerable<Holiday> holidays)
        {
            var citizensHolidays = new List<Holiday>();

            foreach (var holiday0 in holidays)
            {
                if (holiday0.Kind != HolidayKind.National)
                    continue;
                if (holiday0.Date.Year < 2003)
                    continue;

                var day0 = holiday0.Date;

                var day2 = day0.AddDays(2);
                var holiday2 = holidays.FirstOrDefault(
                    s => s.Date == day2 && s.Kind == HolidayKind.National);
                if (holiday2 == null)
                    continue;

                var day1 = day0.AddDays(1);
                if (day1.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                if (holidays.Any(s => s.Date == day1))
                    continue;

                var holidayInfo = new HolidayInfo(HolidayKind.Citizens,
                    $"祝日", $"Citizen's Holiday");
                var citizensHoliday = new Holiday(day1, holidayInfo);
                citizensHolidays.Add(citizensHoliday);
            }

            return citizensHolidays;
        }
    }
}
