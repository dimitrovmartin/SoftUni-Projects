using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int GetDifferenceBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            TimeSpan t = firstDate - secondDate;

            return Math.Abs(t.Days);
        }
    }
}
