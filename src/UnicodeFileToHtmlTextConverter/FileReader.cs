using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class FileReader : IReader
    {
        private readonly string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public TextReader GetTextReader()
        {
            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"{_filePath} not found");
            }
            return File.OpenText(_filePath);
        }
    }
}
