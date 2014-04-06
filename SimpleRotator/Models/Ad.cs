using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace SimpleRotator
{
    public class Ad
    {
        public Ad(string file)
        {
            // File Format:
            // {startdate(yyyymmdd hh:mm)}_{endDate}_{rotation}.html

            var fName = new FileInfo(file).Name;

            // strip file extension
            fName = fName.Replace(".html", string.Empty);

            var parts = fName.Split('_');

            if (parts.Length < 3)
            {
                throw new FormatException("Filename in incorrect format");
            }

            int rotation;
            if (!int.TryParse(parts[2], out rotation))
            {
                throw new FormatException("Unable to parse rotation portion of filename");
            }
            Rotation = rotation;
          
            StartDate = ParseDate(parts[0], "start date");
            EndDate = ParseDate(parts[1], "end date");

            Html = File.ReadAllText(file);
        }

        public string Html { get; set; }
        public int Rotation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        CultureInfo enUS = new CultureInfo("en-US");

        private DateTime ParseDate(string txt, string paramName)
        {
            DateTime start;
            if (!DateTime.TryParseExact(txt, "yyyyMMdd hhmm", enUS, DateTimeStyles.AssumeLocal,  out start))
            {
                throw new FormatException("Unable to parse " + paramName + " portion of filename");
            }
            return start;
        }
    }
}