using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Tests
{
    [TestFixture]
    public class UnicodeFileToHtmlTextConverterTests
    {
        [Test]
        public void Check_HTML_Encoding_when_single_line_is_read()
        {
            Mock<IReader> mockReader = new Mock<IReader>();
            string fakeFileContents = "<script type='javascript'>";
            byte[] fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);
            MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);

            mockReader.Setup(x => x.GetTextReader()).Returns(() => new StreamReader(fakeMemoryStream));

            var unicodeFileToHtmlTextConverter = new UnicodeFileToHtmlTextConverter(mockReader.Object);

            var output = unicodeFileToHtmlTextConverter.ConvertToHtml();

            Assert.AreEqual("&lt;script type=&#39;javascript&#39;&gt;<br />", output );
        }

        [Test]
        public void Check_HTML_Encoding_when_multiple_line_is_read()
        {
            Mock<IReader> mockReader = new Mock<IReader>();
            string fakeFileContents = $"<script type='javascript'>{Environment.NewLine}</script>";
            byte[] fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);
            MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);

            mockReader.Setup(x => x.GetTextReader()).Returns(() => new StreamReader(fakeMemoryStream));

            var unicodeFileToHtmlTextConverter = new UnicodeFileToHtmlTextConverter(mockReader.Object);

            var output = unicodeFileToHtmlTextConverter.ConvertToHtml();

            Assert.AreEqual("&lt;script type=&#39;javascript&#39;&gt;<br />&lt;/script&gt;<br />", output);
        }
    }
}
