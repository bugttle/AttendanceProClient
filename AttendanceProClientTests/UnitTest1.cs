using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using AttendanceProClient.Log;

namespace AttendanceProClientTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var doc = new HtmlDocument();

            doc.Load("../../TestHtml/AttendanceExercisedMonthlyDetails/1.html");
            var log = new WorkingLogSubordinate(doc, 7);

            doc.Load("../../TestHtml/AttendanceExercisedMonthlyDetails/2.html");
            log = new WorkingLogSubordinate(doc, 8);
        }
    }
}
