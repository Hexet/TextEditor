using System.IO;
using System.Text;

namespace ClassLibrary
{
    public interface IFileManager
    {
        bool isExist(string filePath);
        string GetContent(string filePath);
        string GetContent(string filePath, Encoding encoding);
        void SaveContent(string filePath, string content);
        void SaveContent(string filePath, string content, Encoding encoding);
        int GetSymbolCount(string content);
    }

    public class FileManager: IFileManager
    {
        private readonly Encoding _defaultEncoding = Encoding.GetEncoding(1251);

        public bool isExist(string filePath)
        {
            return File.Exists(filePath);
        }

        public string GetContent(string filePath)
        {
            string content = File.ReadAllText(filePath, _defaultEncoding);
            return content;
        }
        public string GetContent(string filePath, Encoding encoding)
        {
            string content = File.ReadAllText(filePath, encoding);
            return content;
        }

        public void SaveContent(string content, string filePath)
        {
            SaveContent(content, filePath, _defaultEncoding);
        }
        public void SaveContent(string content, string filePath, Encoding encoding)
        {
            File.WriteAllText(filePath, content, encoding);
        }

        public int GetSymbolCount(string content)
        {
            return content.Length;  
        }
    }
}
