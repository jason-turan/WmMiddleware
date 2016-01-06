using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Middleware.Integration.Repositories
{
    public class XmlFileCommand : IXmlReadRepository
    {
        private readonly string _directory;
        private readonly string _filename;

        public XmlFileCommand(string directory, string filename)
        {
            _directory = directory;
            _filename = filename;
        }

        public virtual XDocument Read()
        {
            var file = GetTargetFile();
            var text = File.ReadAllText(file.FullName);
            return new XDocument(new XmlTextReader(new StringReader(text)));
        }

        protected FileInfo GetTargetFile()
        {
            var targetFilename = _filename;
            if (_filename.Contains("."))
            {
                targetFilename = _filename.Remove(_filename.LastIndexOf(".", StringComparison.Ordinal));
            }

            var matchingFiles = new List<FileInfo>();
            var utcDateToMatch = DateTime.Now;
            return matchingFiles.Where(x => x.CreationTimeUtc.CompareTo(utcDateToMatch) <= 0).OrderByDescending(
                            x => x.CreationTimeUtc).FirstOrDefault();
        }

        //protected virtual string GetFileExtension()
        //{
            
        //}
    }
}
