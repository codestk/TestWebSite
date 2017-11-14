using System;
using System.Globalization;
using System.Text;

namespace WMSNet.Common.Extensions
{
  public static class DateTimeExtensions
  {
    public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek, string languageCode)
    {
      DayOfWeek firstDayOfWeek = new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
      return dt.AddDays((double) -(DateTime.Today.DayOfWeek - firstDayOfWeek));
    }

    public static DateTime GetFirstDayOfWeek(this DateTime dt, int weekOffset, string languageCode)
    {
      return DateTimeExtensions.StartOfWeek(dt, DateTimeExtensions.GetFirstDayOfWeekSetting(dt, languageCode), languageCode).AddDays((double) (weekOffset * 7));
    }

    public static DateTime GetFirstDayOfMonth(this DateTime dt)
    {
      return new DateTime(dt.Year, dt.Month, 1);
    }

    public static DateTime GetLastDayOfMonth(this DateTime dt)
    {
      return new DateTime(dt.Year, dt.Month, 1).AddMonths(1).AddDays(-1.0);
    }

    public static string GetWeekDate(this DateTime dt, int weekOffset, string languageCode)
    {
      return DateTimeExtensions.GetFirstDayOfWeek(dt, weekOffset, languageCode).ToString("d-MMM");
    }

    public static string GetWeekDateRange(this DateTime dt, int weekOffset, string languageCode)
    {
      StringBuilder stringBuilder = new StringBuilder(50);
      DateTime firstDayOfWeek = DateTimeExtensions.GetFirstDayOfWeek(dt, weekOffset, languageCode);
      stringBuilder.Append(firstDayOfWeek.ToLongDateString());
      stringBuilder.Append(" - ");
      stringBuilder.Append(firstDayOfWeek.AddDays(6.0).ToLongDateString());
      return ((object) stringBuilder).ToString();
    }

    public static DayOfWeek GetFirstDayOfWeekSetting(this DateTime dt, string languageCode)
    {
      return new CultureInfo(languageCode).DateTimeFormat.FirstDayOfWeek;
    }

    public static int GetFirstDayOfWeekSettingForSql(this DateTime dt, string languageCode)
    {
      DayOfWeek dayOfWeekSetting = DateTimeExtensions.GetFirstDayOfWeekSetting(dt, languageCode);
      if (dayOfWeekSetting == DayOfWeek.Sunday)
        return 7;
      else
        return (int) dayOfWeekSetting;
    }

    public static DateTime FirstDayOfMonth(this DateTime date)
    {
      return new DateTime(date.Year, date.Month, 1);
    }

    public static DateTime LastDayOfMonth(this DateTime date)
    {
      return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }

    public static bool IsWeekend(this DateTime value)
    {
      if (value.DayOfWeek != DayOfWeek.Sunday)
        return value.DayOfWeek == DayOfWeek.Saturday;
      else
        return true;
    }

    public static bool IsWeekend(this DayOfWeek d)
    {
      return !DateTimeExtensions.IsWeekday(d);
    }

    public static bool IsWeekday(this DayOfWeek d)
    {
      switch (d)
      {
        case DayOfWeek.Sunday:
        case DayOfWeek.Saturday:
          return false;
        default:
          return true;
      }
    }

    public static DateTime AddWorkdays(this DateTime d, int days)
    {
      while (DateTimeExtensions.IsWeekday(d.DayOfWeek))
        d = d.AddDays(1.0);
      for (int index = 0; index < days; ++index)
      {
        d = d.AddDays(1.0);
        while (DateTimeExtensions.IsWeekday(d.DayOfWeek))
          d = d.AddDays(1.0);
      }
      return d;
    }

    public static DateTime AddWeekdays(this DateTime date, int days)
    {
      int num1 = days < 0 ? -1 : 1;
      int num2 = Math.Abs(days);
      int num3 = 0;
      while (num3 < num2)
      {
        date = date.AddDays((double) num1);
        if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
          ++num3;
      }
      return date;
    }

    public static DateTime SetTime(this DateTime date, int hour)
    {
      return DateTimeExtensions.SetTime(date, hour, 0, 0, 0);
    }

    public static DateTime SetTime(this DateTime date, int hour, int minute)
    {
      return DateTimeExtensions.SetTime(date, hour, minute, 0, 0);
    }

    public static DateTime SetTime(this DateTime date, int hour, int minute, int second)
    {
      return DateTimeExtensions.SetTime(date, hour, minute, second, 0);
    }

    public static DateTime SetTime(this DateTime date, int hour, int minute, int second, int millisecond)
    {
      return new DateTime(date.Year, date.Month, date.Day, hour, minute, second, millisecond);
    }

    public static DateTime ClearTime(this DateTime d)
    {
      return new DateTime(d.Year, d.Month, d.Day, 0, 0, 0, 0);
    }

    public static string ToRelativeDateString(this DateTime date)
    {
      return DateTimeExtensions.GetRelativeDateValue(date, DateTime.Now);
    }

    public static string ToRelativeDateStringUtc(this DateTime date)
    {
      return DateTimeExtensions.GetRelativeDateValue(date, DateTime.UtcNow);
    }

    private static string GetRelativeDateValue(DateTime date, DateTime comparedTo)
    {
      TimeSpan timeSpan = comparedTo.Subtract(date);
      if (timeSpan.TotalDays >= 365.0)
        return "on " + date.ToString("MMMM d, yyyy");
      if (timeSpan.TotalDays >= 7.0)
        return "on " + date.ToString("MMMM d");
      if (timeSpan.TotalDays > 1.0)
        return string.Format("{0:N0} days ago", (object) timeSpan.TotalDays);
      if (timeSpan.TotalDays == 1.0)
        return "yesterday";
      if (timeSpan.TotalHours >= 2.0)
        return string.Format("{0:N0} hours ago", (object) timeSpan.TotalHours);
      if (timeSpan.TotalMinutes >= 60.0)
        return "more than an hour ago";
      if (timeSpan.TotalMinutes >= 5.0)
        return string.Format("{0:N0} minutes ago", (object) timeSpan.TotalMinutes);
      return timeSpan.TotalMinutes >= 1.0 ? "a few minutes ago" : "less than a minute ago";
    }

    public static string GetString(this DateTime d)
    {
      if (d.Year == 1)
        return string.Empty;
      else
        return d.ToString();
    }

    public static string GetString(this DateTime? d)
    {
      if (!d.HasValue)
        return string.Empty;
      else
        return DateTimeExtensions.GetString(d.Value);
    }

    public static string GetDateString(this DateTime d)
    {
      if (d.Year == 1)
        return string.Empty;
      else
        return d.ToShortDateString();
    }

    public static string GetDateString(this DateTime? d)
    {
      if (!d.HasValue)
        return string.Empty;
      else
        return DateTimeExtensions.GetDateString(d.Value);
    }
  }
}
