using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleRotator.Models;
using SimpleRotatorTests.TestTools;

namespace SimpleRotatorTests.Models
{
    [TestClass]
    public class ZoneTest
    {
        [TestMethod]
        public void Zone_Should_Load_Files_In_Given_Directory()
        {
            var tmpDir = DiskIO.GetTempFolder();

            File.WriteAllText(Path.Combine(tmpDir, "20140101 0000_20150101 0000_1.html"), "blah");
            File.WriteAllText(Path.Combine(tmpDir, "20140101 0000_20150101 0000_2.html"), "blah");

            var sut = new Zone(tmpDir);

            Assert.AreEqual(2, sut.Ads.Count());
        }
    }
}