using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using AngleSharp.Html.Parser;

namespace StudentFormApp.Tests
{
    [TestClass]
    public class HtmlFormTests
    {
        private string LoadHtml() =>
            File.ReadAllText("../../../../StudentFormApp/Views/Home/StudentForm.cshtml");

        private AngleSharp.Html.Dom.IHtmlDocument GetDoc()
        {
            var parser = new HtmlParser();
            return parser.ParseDocument(LoadHtml());
        }

        [TestMethod]
        public void Test_Has_FullName_Input()
        {
            var input = GetDoc().QuerySelector("input[name='FullName'][type='text']");
            Assert.IsNotNull(input, "Full Name input is missing or incorrect type");
        }

        [TestMethod]
        public void Test_Has_StudentNumber_Input()
        {
            var input = GetDoc().QuerySelector("input[name='StudentNumber'][type='text']");
            Assert.IsNotNull(input, "Student Number input is missing or incorrect type");
        }

        [TestMethod]
        public void Test_Has_Email_Input()
        {
            var input = GetDoc().QuerySelector("input[name='EmailAddress'][type='email']");
            Assert.IsNotNull(input, "Email Address input is missing or incorrect type");
        }

        [TestMethod]
        public void Test_Has_Gender_RadioButtons()
        {
            var male = GetDoc().QuerySelector("input[name='Gender'][type='radio'][value='Male']");
            var female = GetDoc().QuerySelector("input[name='Gender'][type='radio'][value='Female']");
            Assert.IsNotNull(male, "Male radio button is missing");
            Assert.IsNotNull(female, "Female radio button is missing");
        }

        [TestMethod]
        public void Test_Has_YearLevel_Dropdown()
        {
            var select = GetDoc().QuerySelector("select[name='YearLevel']");
            Assert.IsNotNull(select, "Year Level dropdown is missing");
            var options = select.QuerySelectorAll("option");
            Assert.IsTrue(options.Length >= 4, "Year Level dropdown should have at least 4 options");
        }

        [TestMethod]
        public void Test_Has_Course_Dropdown()
        {
            var select = GetDoc().QuerySelector("select[name='Course']");
            Assert.IsNotNull(select, "Course dropdown is missing");
            var options = select.QuerySelectorAll("option");
            Assert.IsTrue(options.Length >= 3, "Course dropdown should have at least 3 options");
        }

        [TestMethod]
        public void Test_Has_AboutMe_Textarea()
        {
            var textarea = GetDoc().QuerySelector("textarea[name='AboutMe']");
            Assert.IsNotNull(textarea, "About Me textarea is missing");
        }

        [TestMethod]
        public void Test_Has_Submit_Button()
        {
            var button = GetDoc().QuerySelector("button[type='submit']");
            Assert.IsNotNull(button, "Submit button is missing");
        }
    }
}
