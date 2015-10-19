using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleRotator.Managers;
using SimpleRotatorTests.Models;
using SimpleRotatorTests.TestTools;

namespace SimpleRotatorTests.Managers
{
    [TestClass]
    public class AdRepoTests
    {
        [TestMethod]
        public void AdRepo_Should_Load_Zones_From_Directories()
        {
            var io = new ZoneTest.TestIO();

            var list = new List<string>()
                {
                    "file1",
                    "file2"
                };

            var leader = new ZoneTest.DummyDirectory("leader");
            var box = new ZoneTest.DummyDirectory("box");
            var sky = new ZoneTest.DummyDirectory("sky");

            io.DummyDirectories.Add("leader", leader);
            io.DummyDirectories.Add("box", box);
            io.DummyDirectories.Add("sky", sky);

            var sut = new AdRepo(io, "root");

            Assert.AreEqual(3, sut.Zones.Count());
        }
    }
}