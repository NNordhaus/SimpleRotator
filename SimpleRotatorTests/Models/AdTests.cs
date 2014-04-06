using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleRotator;
using SimpleRotatorTests.TestTools;

namespace SimpleRotatorTests.Models
{
    [TestClass]
    public class AdTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Constructor_Should_Throw_Error_If_File_Name_Missing_Underscores()
        {
            var sut = new Ad("20140101 0000_20150101 0000-10");
        }

        [TestMethod]
        public void Constructor_Should_Parse_Rotation()
        {
            var tmpFile = DiskIO.WriteTextFileToTempFolder("20140101 0000_20150101 0000_10.html", "html goes here");

            var sut = new Ad(tmpFile);

            Assert.AreEqual(10, sut.Rotation);
        }

        [TestMethod]
        public void Constructor_Should_Parse_Rotation_2()
        {
            var tmpFile = DiskIO.WriteTextFileToTempFolder("20140101 0000_20150101 0000_2.html", "html goes here");

            var sut = new Ad(tmpFile);

            Assert.AreEqual(2, sut.Rotation);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Constructor_Should_Throw_Exception_if_bad_Rotation()
        {
            var tmpFile = DiskIO.WriteTextFileToTempFolder("20140101 0000_20150101 0000_blah.html", "html goes here");

            var sut = new Ad(tmpFile);
        }

        [TestMethod]
        public void Constructor_Should_Parse_Start_Date()
        {
            var tmpFile = DiskIO.WriteTextFileToTempFolder("20140101 0000_20150101 0000_10.html", "html goes here");

            var sut = new Ad(tmpFile);

            Assert.AreEqual(new DateTime(2014, 1, 1), sut.StartDate);
        }

        [TestMethod]
        public void Constructor_Should_Parse_End_Date()
        {
            var tmpFile = DiskIO.WriteTextFileToTempFolder("20140101 0000_20150101 0000_10.html", "html goes here");

            var sut = new Ad(tmpFile);

            Assert.AreEqual(new DateTime(2015, 1, 1), sut.EndDate);
        }

        [TestMethod]
        public void Constructor_Should_Read_File_Contents_into_HTML()
        {
            var tmpFile = DiskIO.WriteTextFileToTempFolder("20140101 0000_20150101 0000_15.html", "html goes here");

            var sut = new Ad(tmpFile);

            Assert.AreEqual("html goes here", sut.Html);
        }

    }
}