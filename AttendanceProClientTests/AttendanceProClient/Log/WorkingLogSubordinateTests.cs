using AttendanceProClient.Log;
using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AttendanceProClientTests
{
    [TestClass]
    public class WorkingLogSubordinateTests
    {
        [TestMethod]
        public void WorkingLogSubordinateTest()
        {
            var doc = new HtmlDocument();

            doc.Load("../../TestHtml/AttendanceExercisedMonthlyDetails/1.html");
            var log = new WorkingLogSubordinate(doc, 7);

            doc.Load("../../TestHtml/AttendanceExercisedMonthlyDetails/2.html");
            log = new WorkingLogSubordinate(doc, 8);
        }
    }
}
