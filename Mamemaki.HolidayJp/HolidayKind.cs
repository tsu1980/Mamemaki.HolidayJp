using System;
using System.Collections.Generic;
using System.Text;

namespace Mamemaki.HolidayJp
{
    public enum HolidayKind
    {
        /// <summary>
        /// 国民の祝日
        /// <see cref="https://ja.wikipedia.org/wiki/%E5%9B%BD%E6%B0%91%E3%81%AE%E7%A5%9D%E6%97%A5"/>
        /// </summary>
        National = 1,
        /// <summary>
        /// 国民の休日
        /// <see cref="https://ja.wikipedia.org/wiki/%E5%9B%BD%E6%B0%91%E3%81%AE%E4%BC%91%E6%97%A5"/>
        /// </summary>
        Citizens = 2,
        /// <summary>
        /// 振替休日
        /// <see cref="https://ja.wikipedia.org/wiki/%E6%8C%AF%E6%9B%BF%E4%BC%91%E6%97%A5"/>
        /// </summary>
        Substitute = 3,
    }
}
