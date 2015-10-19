using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using SimpleRotator.Models;
using SimpleRotator.Tools;

namespace SimpleRotator.Managers
{
    public class AdRepo
    {
        public AdRepo(FileIO io, string directory)
        {
            rootDir = directory;
            LoadZones(io, true);
        }

        private string rootDir;

        public IList<Zone> Zones;

        private void LoadZones(FileIO io, bool forceRefresh)
        {
            if (forceRefresh || Zones == null)
            {
                var zoneDirs = io.GetDirs(rootDir);

                Zones = new List<Zone>(zoneDirs.Count());

                foreach (string dir in zoneDirs)
                {
                    Zones.Add(new Zone(io, dir));
                }
            }
        }
    }
}