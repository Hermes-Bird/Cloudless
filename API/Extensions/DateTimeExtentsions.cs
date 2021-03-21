using System;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Services.Extensions
{
    public static class DateTimeExtentsions
    {
        public static string ActiveLastTime(this DateTime lastSeen)
        {
            var today = DateTime.Now;

            if (today.Year == lastSeen.Year && today.DayOfYear == lastSeen.DayOfYear)
            {
                return $"{lastSeen.Hour}:{lastSeen.Minute}";
            }

            if (today.Year == lastSeen.Year) return $"{lastSeen:MMMM} {lastSeen.Day} в {lastSeen.Hour}:{lastSeen.Minute}".FirstCharToUpper();

            return $"{lastSeen.Year} {lastSeen.ToString("MMMM").FirstCharToUpper()} {lastSeen.Day} в {lastSeen.Hour}:{lastSeen.Minute}";
        }
    }
}