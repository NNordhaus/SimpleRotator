using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SimpleRotator.Tools;

namespace SimpleRotator.Models
{
    public class Zone
    {
        public string Name { get; set; }
        public IList<IAd> Ads { get; set; }

        public Zone(FileIO io, string directory)
        {
            Name = io.GetFolderName(directory);

            var files = io.GetFiles(directory);

            Ads = new List<IAd>(files.Count());
            foreach (var file in files)
            {
                Ads.Add(new Ad(io.ReadAllText(directory, file)));
            }
        }
    }
}