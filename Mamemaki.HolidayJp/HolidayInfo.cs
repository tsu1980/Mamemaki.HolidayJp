using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp
{
    /// <summary>
    /// Public holiday info
    /// </summary>
    public class HolidayInfo : IEquatable<HolidayInfo>
    {
        /// <summary>
        /// Kind of public holiday
        /// </summary>
        public HolidayKind Kind { get; private set; }

        /// <summary>
        /// public holiday name in Japanese
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// public holiday name in English
        /// </summary>
        public string GlobalName { get; private set; }

        /// <summary>
        /// Related holiday info for Substitute holiday or Citizens holiday
        /// </summary>
        public HolidayInfo RelatedHolidayInfo { get; private set; }

        /// <summary>
        /// Related holiday info for Citizens holiday
        /// </summary>
        public HolidayInfo RelatedHolidayInfo2 { get; private set; }

        public HolidayInfo(HolidayKind kind, string name, string globalName)
        {
            Kind = kind;
            Name = name;
            GlobalName = globalName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as HolidayInfo);
        }

        public bool Equals(HolidayInfo other)
        {
            return other != null &&
                   Kind == other.Kind &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = -1759818271;
            hashCode = hashCode * -1521134295 + Kind.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}
