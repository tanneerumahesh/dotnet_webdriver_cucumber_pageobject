using System;
using System.Linq;

namespace ToproomsAutomation.Support
{
    public class ProgramUtils
    {
        public DateTime ConvertStringToDate(string date)
        {
            return date.Contains('~') ? DateTime.Now.AddDays(Convert.ToInt32(date.Split('~')[1])) : DateTime.Now;
        }
    }
}
