using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Query.Dynamic;

namespace SimpleRotator
{
    public class Ad
    {
        public Ad(string fileContent)
        {
            // Split the file into lines
            var fileLines = fileContent.Split('\n');

            // Trim all lines, remove any comment lines
            var lines = fileLines.Select(l => l.Trim()).Where(l => l.Substring(0, 2) != "//").ToArray();

            if (lines.Length < 4)
            {
                throw new FormatException("Input file must have at least 4 lines");
            }

            // First line is the start date
            StartDate = ParseDate(lines[0], "StartDate");

            // Second line is the start date
            EndDate = ParseDate(lines[1], "EndDate");

            // Third line is rotation
            Rotation = int.Parse(lines[2]);

            // Fourth line, and any subsequent lines, is the html
            Html = string.Join("\n", lines.Skip(3));
        }

        public string Html { get; set; }
        public int Rotation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        CultureInfo enUS = new CultureInfo("en-US");

        private DateTime ParseDate(string txt, string paramName)
        {
            DateTime dt;
            if (!DateTime.TryParse(txt,  out dt))
            {
                throw new ArgumentException("Unable to parse " + paramName + " portion of file");
            }
            return dt;
        }
    }
}