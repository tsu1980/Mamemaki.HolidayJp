using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp
{
    /// <summary>
    /// Indicate individual holiday
    /// </summary>
    public class Holiday : IEquatable<Holiday>
    {
        /// <summary>
        /// Date of public holiday
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Kind of public holiday
        /// </summary>
        public HolidayKind Kind
        {
            get
            {
                return HolidayInfo.Kind;
            }
        }

        /// <summary>
        /// public holiday name in Japanese
        /// </summary>
        public string Name
        {
            get
            {
                return HolidayInfo.Name;
            }
        }

        /// <summary>
        /// public holiday name in English
        /// </summary>
        public string GlobalName
        {
            get
            {
                return HolidayInfo.GlobalName;
            }
        }

        /// <summary>
        /// Holiday info
        /// </summary>
        public HolidayInfo HolidayInfo { get; private set; }

        public Holiday(DateTime date, HolidayInfo holidayInfo)
        {
            this.Date = date;
            this.HolidayInfo = holidayInfo;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Holiday);
        }

        public bool Equals(Holiday other)
        {
            return other != null &&
                   Date == other.Date &&
                   EqualityComparer<HolidayInfo>.Default.Equals(HolidayInfo, other.HolidayInfo);
        }

        public override int GetHashCode()
        {
            var hashCode = 1175272768;
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<HolidayInfo>.Default.GetHashCode(HolidayInfo);
            return hashCode;
        }

        public override string ToString()
        {
            return $"[{Date.ToString("yyyy/MM/dd")}] {Name}";
        }
    }
}
