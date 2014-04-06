using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SimpleRotator.Models;

namespace SimpleRotator.Managers
{
    public class AdRepo
    {
        public AdRepo(string directory)
        {
            rootDir = directory;
            LoadZones(true);
        }

        private string rootDir;

        public IList<Zone> Zones;

        private void LoadZones(bool forceRefresh)
        {
            if (forceRefresh || Zones == null)
            {
                var dirs = Directory.GetDirectories(rootDir);
                Zones = new List<Zone>(dirs.Count());

                foreach (string dir in dirs)
                {
                    Zones.Add(new Zone(dir));
                }
            }
        }
    }
}