using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SimpleRotator.Models;

namespace SimpleRotator.Managers
{
    public class AdSelector
    {
        private static Random r = new Random(DateTime.UtcNow.Millisecond * 1999993);

        public static string GetAd(string zone)
        {
            // Get all ads in the given zone

            // Exclude any that are before the start date

            // Exclude any that are past the end date

            // Get the sum of all rotation values

            // Select one at random, weighted by rotation

            return "No Ad found in that Zone";
        }
    }
}