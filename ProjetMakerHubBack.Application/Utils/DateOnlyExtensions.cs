using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMakerHubBack.Application.Utils
{
    public static class DateOnlyExtensions
    {
        public static DateOnly ToWeekStartMonday(this DateOnly date)
        {
            int diff = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            return date.AddDays(-diff);
        }
    }
}
