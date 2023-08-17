using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter.Interfaces
{
    /// <summary>
    /// An interface to provide text reader.
    /// </summary>
    public interface IReader
    {
        TextReader GetTextReader();
    }
}
