using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/* AC - 2016
//Given a string containing a paragraph with a date in the format MM/DD/YYYY, return the same 
// paragraph with the date in the format DD/MM/YYYY
using System;*/

namespace ChangeDateFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ChangeDateFormat("Last time it rained was on 07/08/2016 and today is 01/25/2017."));
            Console.ReadLine();
        }


        public static string ChangeDateFormat(string orginalStr)
        {
            return Regex.Replace(orginalStr,
                @"\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b",
                "${day}/${month}/${year}");
        }
    }

}
