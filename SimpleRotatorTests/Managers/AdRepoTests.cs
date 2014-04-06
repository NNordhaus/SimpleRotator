using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleRotator.Managers;
using SimpleRotatorTests.TestTools;

namespace SimpleRotatorTests.Managers
{
    [TestClass]
    public class AdRepoTests
    {
        [TestMethod]
        public void AdRepo_Should_Load_Zones_From_Directories()
        {
            var tmpDir = DiskIO.GetTempFolder();

            // create folders in that folder
            Directory.CreateDirectory(Path.Combine(tmpDir, "Apples"));
            Directory.CreateDirectory(Path.Combine(tmpDir, "Oranges"));

            var sut = new AdRepo(tmpDir);

            Assert.AreEqual(2, sut.Zones.Count());
        }
    }
}