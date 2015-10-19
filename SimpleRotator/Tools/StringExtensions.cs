using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRotator.Tools
{
    public static class StringExtensions
    {
        public static string Left(this string s, int length)
        {
            length = Math.Max(length, 0);
            length = Math.Min(length, s.Length);
 
            return s.Substring(0, length);
        }
    }
}