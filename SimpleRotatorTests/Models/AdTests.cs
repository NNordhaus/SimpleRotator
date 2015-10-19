using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SimpleRotator.Models;

namespace SimpleRotatorTests.Models
{
    [TestClass]
    public class AdTests
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Constructor_Should_Throw_Error_If_File_Content_Doesnt_Have_Minimum_4_Non_Comment_Lines()
        {
            var sut = new Ad(
            @"//
            blah
            //
            blah
            //
            blah
            //");

            sut.StartDate = DateTime.Now;
        }

        [TestMethod]
        public void Constructor_Should_Parse_StartDate()
        {
            var sut = new Ad(
                @"//Start Date
                2015-10-21 16:00
                // End Date
                2099-12-31 08:15
                // Rotation
                20
                // Html
                <p>blah");

            Assert.AreEqual(new DateTime(2015,10,21,16,0,0), sut.StartDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Fail_On_Unparseable_StartDate()
        {
            var sut = new Ad(
                @"//Start Date
                donald duck
                // End Date
                2099-12-31 08:15
                // Rotation
                20
                // Html
                <p>blah");

            Assert.AreEqual(new DateTime(2015, 10, 21, 16, 0, 0), sut.StartDate);
        }

        [TestMethod]
        public void Constructor_Should_Parse_EndDate()
        {
            var sut = new Ad(
                @"//Start Date
                2015-10-21 16:00
                // End Date
                2099-12-31 08:15
                // Rotation
                20
                // Html
                <p>blah");

            Assert.AreEqual(new DateTime(2099, 12, 31, 8, 15, 0), sut.EndDate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Should_Fail_On_Unparseable_EndDate()
        {
            var sut = new Ad(
                @"//Start Date
                2015-10-21 16:00
                // End Date
                mickey mouse
                // Rotation
                20
                // Html
                <p>blah");

            Assert.AreEqual(new DateTime(2015, 10, 21, 16, 0, 0), sut.StartDate);
        }

        [TestMethod]
        public void Constructor_Should_Parse_Rotation()
        {
            var sut = new Ad(
                @"//Start Date
                2015-10-21 16:00
                // End Date
                2099-12-31 08:15
                // Rotation
                20
                // Html
                <p>blah");

            Assert.AreEqual(20, sut.Rotation);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Constructor_Should_Throw_Exception_if_bad_Rotation()
        {
            var sut = new Ad(
                @"//Start Date
                2015-10-21 16:00
                // End Date
                2099-12-31 08:15
                // Rotation
                minnie mouse
                // Html
                <p>blah");
        }


        [TestMethod]
        public void Constructor_Should_Read_Remaining_File_Contents_into_HTML()
        {
            var sut = new Ad(
                @"//Start Date
                2015-10-21 16:00
                // End Date
                2099-12-31 08:15
                // Rotation
                20
                // Html
                <p>blah");

            Assert.AreEqual("<p>blah", sut.Html);
        }

        [TestMethod]
        public void Constructor_Should_Read_Remaining_Multiline_File_Contents_into_HTML()
        {
            var sut = new Ad(@"//Start Date
                2015-10-21 16:00
                // End Date
                2099-12-31 08:15
                // Rotation
                20
                // Html
                <p>blah
                more html");

            Assert.AreEqual("<p>blah\nmore html", sut.Html);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Fail_On_1_Char_Line()
        {
            var sut = new Ad(@"//Start Date
                2015-10-21 16:00
                // End Date
                2099-12-31 08:15
                // Rotation
                2
                // Html
                <p>blah
                more html");

            Assert.AreEqual("<p>blah\nmore html", sut.Html);
        }
    }
}