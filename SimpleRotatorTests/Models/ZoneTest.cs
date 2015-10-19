using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleRotator.Models;
using SimpleRotator.Tools;
using SimpleRotatorTests.TestTools;

namespace SimpleRotatorTests.Models
{
    [TestClass]
    public class ZoneTest
    {
        [TestMethod]
        public void Zone_Should_Load_Files_In_Given_Directory()
        {
            // TODO: replace the dependencies on Ad using Castle Windsor

            string ad = @"//Start Date
                2015-10-21 16:00
                // End Date
                2099-12-31 08:15
                // Rotation
                20
                // Html
                <p>blah";

            var io = new TestIO();
            var dir = new DummyDirectory("dir");
            dir.DummyFiles.Add("file1.html", ad);
            dir.DummyFiles.Add("file2.html", ad);
            io.DummyDirectories.Add("dir", dir);

            var sut = new Zone(io, "dir");

            Assert.AreEqual(2, sut.Ads.Count);
        }

        //[TestMethod]
        //public void Zone_Name_Should_Be_Directory_Name()
        //{
        //    
        //}

        public class TestIO : FileIO
        {
            public Dictionary<string, DummyDirectory> DummyDirectories = new Dictionary<string, DummyDirectory>();

            public string ReadAllText(string directory, string filePath)
            {
                return DummyDirectories[directory].DummyFiles[filePath];
            }

            public IList<string> GetFiles(string directory)
            {
                return DummyDirectories[directory].DummyFiles.Keys.ToList();
            }

            public IList<string> GetDirs(string directory)
            {
                return DummyDirectories.Keys.ToList();
            }

            public string GetFolderName(string directory)
            {
                return directory;
            }
        }

        public class DummyDirectory
        {
            public DummyDirectory(string name)
            {
                Name = name;
            }
            public string Name { get; private set; }
            public Dictionary<string, string> DummyFiles = new Dictionary<string, string>();
        }
    }
}