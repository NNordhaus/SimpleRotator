using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Query.Dynamic;

using SimpleRotator.Tools;

namespace SimpleRotator.Models
{
    public interface IAd
    {
        string Html { get; set; }
        int Rotation { get; set; }
        System.DateTime StartDate { get; set; }
        System.DateTime EndDate { get; set; }
    }

    public class Ad : IAd
    {
        public Ad(string fileContent)
        {
            // Split the file into lines
            var fileLines = fileContent.Split('\n');

            // Trim all lines, remove any comment lines TODO: handle lines less than 2 chars long
            var lines = fileLines.Select(l => l.Trim()).Where(l => l.Length > 0 && l.Left(2) != "//").ToArray();

            if (lines.Length < 4)
            {
                throw new FormatException("Input file must have at least 4 non-comment lines");
            }

            // First line is the start date
            StartDate = ParseDate(lines[0], "StartDate");

            // Second line is the end date
            EndDate = ParseDate(lines[1], "EndDate");

            // Third line is rotation
            Rotation = int.Parse(lines[2]);

            // Fourth line, and any subsequent lines, is the html
            Html = string.Join("\n", lines.Skip(3));
        }

        public string Html { get; set; }
        public int Rotation { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }

        CultureInfo enUS = new CultureInfo("en-US");

        private System.DateTime ParseDate(string txt, string paramName)
        {
            System.DateTime dt;
            if (!System.DateTime.TryParse(txt,  out dt))
            {
                throw new ArgumentException("Unable to parse " + paramName + " portion of file");
            }
            return dt;
        }
    }

    //public class DummyAd : IAd
    //{
    //    public DummyAd(string fileContent)
    //    {
    //        // Dummy Data
    //        StartDate = DateTime.MinValue;
    //        EndDate = DateTime.MaxValue;
    //        Rotation = 50;
    //        Html = "html here";
    //    }
    //
    //    public string Html { get; set; }
    //    public int Rotation { get; set; }
    //    public DateTime StartDate { get; set; }
    //    public DateTime EndDate { get; set; }
    //}
}