using Mamemaki.HolidayJp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace Mamemaki.HolidayJp.Test
{
    public class JapanHolidayTest
    {
        public JapanHolidayTest()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        class HolidayName
        {
            public DateTime Date { get; set; }
            public string Name { get; set; }

            public HolidayName(DateTime date, string name)
            {
                Date = date;
                Name = name;
            }

            public override bool Equals(object obj)
            {
                return obj is HolidayName name &&
                       Date == name.Date &&
                       Name == name.Name;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(Date, Name);
            }
        }

        [Fact]
        public void Year_2019()
        {
            var holidays = HolidayCalculator.GetHolidaysInYear(2019);
            var holidaysExpected = new List<HolidayName>()
            {
                new HolidayName(new DateTime(2019,01,01), "Œ³“ú"),
                new HolidayName(new DateTime(2019,01,14), "¬l‚Ì“ú"),
                new HolidayName(new DateTime(2019,02,11), "Œš‘‹L”O‚Ì“ú"),
                new HolidayName(new DateTime(2019,03,21), "t•ª‚Ì“ú"),
                new HolidayName(new DateTime(2019,04,29), "º˜a‚Ì“ú"),
                new HolidayName(new DateTime(2019,04,30), "j“ú"),
                new HolidayName(new DateTime(2019,05,01), "“Vc‚Ì‘¦ˆÊ‚Ì“ú"),
                new HolidayName(new DateTime(2019,05,02), "j“ú"),
                new HolidayName(new DateTime(2019,05,03), "Œ›–@‹L”O“ú"),
                new HolidayName(new DateTime(2019,05,04), "‚Ý‚Ç‚è‚Ì“ú"),
                new HolidayName(new DateTime(2019,05,05), "‚±‚Ç‚à‚Ì“ú"),
                new HolidayName(new DateTime(2019,05,06), "‚±‚Ç‚à‚Ì“ú U‘Ö‹x“ú"),
                new HolidayName(new DateTime(2019,07,15), "ŠC‚Ì“ú"),
                new HolidayName(new DateTime(2019,08,11), "ŽR‚Ì“ú"),
                new HolidayName(new DateTime(2019,08,12), "ŽR‚Ì“ú U‘Ö‹x“ú"),
                new HolidayName(new DateTime(2019,09,16), "Œh˜V‚Ì“ú"),
                new HolidayName(new DateTime(2019,09,23), "H•ª‚Ì“ú"),
                new HolidayName(new DateTime(2019,10,14), "‘Ìˆç‚Ì“ú"),
                new HolidayName(new DateTime(2019,10,22), "‘¦ˆÊ—ç³“a‚Ì‹V‚Ìs‚í‚ê‚é“ú"),
                new HolidayName(new DateTime(2019,11,03), "•¶‰»‚Ì“ú"),
                new HolidayName(new DateTime(2019,11,04), "•¶‰»‚Ì“ú U‘Ö‹x“ú"),
                new HolidayName(new DateTime(2019,11,23), "‹Î˜JŠ´ŽÓ‚Ì“ú"),
            };
            Assert.Equal(holidaysExpected, AsHolidayNames(holidays));
        }

        [Fact]
        public void JapanHoliday()
        {
            var jphol = new JapanHoliday();
            Assert.False(jphol.IsWorkingDay(new DateTime(2019, 1, 1)));
            Assert.True(jphol.IsHoliday(new DateTime(2019, 1, 1)));
            Assert.Equal(new DateTime(2019, 1, 2), jphol.NextWorkingDay(new DateTime(2019, 1, 1)));
            Assert.Equal(new DateTime(2018, 12, 31), jphol.PreviousWorkingDay(new DateTime(2019, 1, 1)));
        }

        [Fact]
        public void SyukujitsuCsv()
        {
            var jphol = new JapanHoliday();
            var holidays = jphol.GetHolidaysInDateRange(new DateTime(1955, 1, 1), new DateTime(2020, 12, 31))
                .Select(s => s.Date)
                .ToList();
            var syukujitsuDates = LoadSyukujitsuCsv()
                .Select(s => s.Date)
                .ToList();
            Assert.Equal(syukujitsuDates, holidays);
        }

        private List<HolidayName> LoadSyukujitsuCsv()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Mamemaki.HolidayJp.Test.syukujitsu.csv";
            var syukujitsuNames = new List<HolidayName>();

            var r = new Regex(@"(\d+)/(\d+)/(\d+),\s*(.+)");
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream, Encoding.GetEncoding("Shift_JIS")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var m = r.Match(line);
                    if (!m.Success)
                        continue;
                    var date = new DateTime(
                        int.Parse(m.Groups[1].Value),
                        int.Parse(m.Groups[2].Value),
                        int.Parse(m.Groups[3].Value));
                    var name = m.Groups[4].Value;
                    syukujitsuNames.Add(new HolidayName(date, name));
                }
            }

            return syukujitsuNames;
        }

        private List<HolidayName> AsHolidayNames(IEnumerable<Holiday> holidays)
        {
            return holidays.Select(s => new HolidayName(s.Date, s.Name)).ToList();
        }
    }
}
