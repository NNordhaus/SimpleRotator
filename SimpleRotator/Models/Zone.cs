using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SimpleRotator.Models
{
    public class Zone
    {
        public string Name { get; set; }
        public IList<Ad> Ads { get; set; }

        public Zone(string dir)
        {
            Name = new DirectoryInfo(dir).Name;

            var files = Directory.GetFiles(dir, "*.html");

            Ads = new List<Ad>(files.Count());
            foreach (var file in files)
            {
                Ads.Add(new Ad(file));
            }
        }
    }
}