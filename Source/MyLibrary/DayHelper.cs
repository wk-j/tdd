using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary
{
    public class DayHelper
    {
        public string ToFrieldlyText(int[] input)
        {
            if (input.Length == 0 ) {
                return "";
            } else if (input.Length == 1) {
                return input.First().ToString();
            } else if  (input.Length > 1) {
                return input.First().ToString() + "-" + input.Last().ToString();
            }
            return "1";
        }
    }
}