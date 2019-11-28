# Mamemaki.HolidayJp
[![Actions Status](https://github.com/Mamemaki/Mamemaki.HolidayJp/workflows/Master/badge.svg)](https://github.com/Mamemaki/Mamemaki.HolidayJp/actions)
[![NuGet Badge](https://buildstats.info/nuget/Mamemaki.HolidayJp)](https://www.nuget.org/packages/Mamemaki.HolidayJp/)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)

.NET library for Calculate Japan public Holidays

- Purely holiday calculator.
- No dataset or other external resources used
- No dependencies
- Support 1955 to 2150 years range
- Tested with [syukujitsu.csv](https://www8.cao.go.jp/chosei/shukujitsu/gaiyou.html)

## Install

Install with NuGet:

``` sh
PM> Install-Package Mamemaki.HolidayJp
```

## Example Usage

### Calculate public holidays of a year

```cs
var holidays = HolidayCalculator.GetHolidaysInYear(2019);
foreach (var holiday in holidays)
{
    Console.WriteLine($"[{holiday.Date.ToString("yyyy/MM/dd")}] {holiday.Name}");
}
```

### Get public holidays for a date range
```cs
var jphol = new JapanHoliday();
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2018, 5, 31);
var holidays = jphol.GetHolidaysInDateRange(startDate, endDate);
foreach (var holiday in holidays)
{
    Console.WriteLine($"[{holiday.Date.ToString("yyyy/MM/dd")}] {holiday.Name}");
}
```

### Get public holiday for a date
```cs
var jphol = new JapanHoliday();
var date = new DateTime(2019, 1, 1);
var holiday = jphol.GetHoliday(date);
if (holiday != null)
{
    Console.WriteLine($"[{holiday.Date.ToString("yyyy/MM/dd")}] {holiday.Name}");
}
else
{
    Console.WriteLine($"{date.ToString("yyyy/MM/dd")} is not public holiday");
}
```

### Check if a date is a weekend/weekday/holiday/workingday day
```cs
var jphol = new JapanHoliday();
var date = new DateTime(2019,11,8);
Console.WriteLine($"{date.ToString("yyyy/MM/dd")} is {(jphol.IsWeekday(date) ? "weekday" : "not weekday")}");
Console.WriteLine($"{date.ToString("yyyy/MM/dd")} is {(jphol.IsWeekend(date) ? "weekend" : "not weekend")}");
Console.WriteLine($"{date.ToString("yyyy/MM/dd")} is {(jphol.IsHoliday(date) ? "holiday" : "not holiday")}");
Console.WriteLine($"{date.ToString("yyyy/MM/dd")} is {(jphol.IsWorkingDay(date) ? "workingday" : "not workingday")}");
Console.WriteLine($"{date.ToString("yyyy/MM/dd")}'s next workingday is {jphol.NextWorkingDay(date).ToString("yyyy/MM/dd")}");
Console.WriteLine($"{date.ToString("yyyy/MM/dd")}'s previous workingday is {jphol.PreviousWorkingDay(date).ToString("yyyy/MM/dd")}");

## API References

### Holiday object

Name  | Description
------------- | -------------
`Date` | Date of the holiday.
`Kind` | Kind of the holiday. see [HolidayKind](#HolidayKind-enum).
`Name` | Name of the holiday in Japanese.
`GlobalName` | Name of the holiday in English.

### HolidayKind enum

Name  | Description
------------- | -------------
`National` | [çëñØÇÃèjì˙](https://ja.wikipedia.org/wiki/%E5%9B%BD%E6%B0%91%E3%81%AE%E7%A5%9D%E6%97%A5)
`Citizens` | [çëñØÇÃãxì˙](https://ja.wikipedia.org/wiki/%E5%9B%BD%E6%B0%91%E3%81%AE%E4%BC%91%E6%97%A5)
`Substitute` | [êUë÷ãxì˙](https://ja.wikipedia.org/wiki/%E6%8C%AF%E6%9B%BF%E4%BC%91%E6%97%A5)

### HolidayCalculator class

This class is to calculate japan holidays. it has only one public method `GetHolidaysInYear(int year)` that calculates holidays in the specified year.

### JapanHoliday class

This class has many utility methods for Japan holidays. And calculated results are cached so calculation does not execute twice.

#### Methods

##### `IEnumerable<Holiday> GetHolidaysInYear(int year)`
Get holidays in the specified year.

##### `IEnumerable<Holiday> GetHolidaysInDateRange(DateTime dateStart, DateTime dateEnd)`
Get public holidays for a date range.

##### `Holiday GetHoliday(DateTime date)`
Get holidays in the specified year.

##### `bool IsHoliday(DateTime date)`
Check if a date is a public holiday.

##### `bool IsWeekday(DateTime date)`
Check if a date is a weekday.
weekday means Monday to Friday.

##### `bool IsWeekend(DateTime date)`
Check if a date is a weekend
weekend means Saturday or Sunday.

##### `bool IsWorkingDay()`
Check if today is a working day
working day means Monday to Friday and does not holiday.

##### `bool IsWorkingDay(DateTime date)`
Check if a date is a working day
working day means Monday to Friday and does not holiday.

##### `DateTime NextWorkingDay(DateTime date)`
Get next working day of the specified date
working day means Monday to Friday and does not holiday.

##### `DateTime PreviousWorkingDay(DateTime date)`
Get previous working day of the specified date
working day means Monday to Friday and does not holiday.

## Thanks

[ì‡ätï{ÉzÅ[ÉÄÉyÅ[ÉW](https://www8.cao.go.jp/chosei/shukujitsu/gaiyou.html)
https://zariganitosh.hatenablog.jp/entry/20140929/japanese_holiday_memo
https://www.pahoo.org/e-soul/webtech/php02/php02-27-01.shtm
https://www.atmarkit.co.jp/ait/articles/1507/22/news024.html

## License

[Apache 2.0](https://opensource.org/licenses/Apache-2.0)
