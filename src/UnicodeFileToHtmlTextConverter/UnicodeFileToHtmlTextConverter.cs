using System.IO;
using System.Web;
using TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        
        private readonly IReader _reader;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath) : this(new FileReader(fullFilenameWithPath))
        {
            
        }

        public UnicodeFileToHtmlTextConverter(IReader reader)
        {
            _reader = reader;
        }

        public string ConvertToHtml()
        {
            using (TextReader unicodeFileStream = _reader.GetTextReader())
            {
                string html = string.Empty;

                string line = unicodeFileStream.ReadLine();
                while (line != null)
                {
                    html += HttpUtility.HtmlEncode(line);
                    html += "<br />";
                    line = unicodeFileStream.ReadLine();
                }

                return html;
            }
        }
    }
}
