using System;
using System.Collections.Generic;
using System.Text;

namespace Date_Modifier
{
    public static class DateModifier
    {
        public static int DaysDifference(string firstDateStr, string secondDateStr)
        {
            DateTime firstDate = DateTime.Parse(firstDateStr);
            DateTime secondDate = DateTime.Parse(secondDateStr);

            var diff =  firstDate - secondDate;

            return diff.Days;
        }
    }
}
