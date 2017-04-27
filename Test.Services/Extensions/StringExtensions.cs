using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes duplicate entries from a CSV string.  Will ignore spacing and case when removing entries.
        /// </summary>
        /// <param name="csvString"></param>
        /// <returns>Returns a CSV with no duplicate entries.</returns>
        public static string RemoveDuplicatesFromCSV(this string csvString)
        {
            List<string> uniques = csvString.ToLower().Split(',').Select(p => p.Trim()).Distinct().ToList();
            csvString = String.Join(",", uniques);
            return csvString;
        }
    }
}
