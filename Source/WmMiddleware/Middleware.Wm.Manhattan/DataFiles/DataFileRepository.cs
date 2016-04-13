using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FlatFile.Core;
using FlatFile.FixedLength.Attributes;
using FlatFile.FixedLength.Implementation;
using Middleware.Wm.Manhattan.Text;

namespace Middleware.Wm.Manhattan.DataFiles
{
    public class DataFileRepository<T> where T : class, new()
    {
        private readonly IFlatFileEngine _engine = new FixedLengthFileEngineFactory().GetEngine<T>();

        public void Save(IEnumerable<T> items, string location)
        {
            var path = Path.GetDirectoryName(location);
            if (path != null && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var scrubStream = new MemoryStream())
            {
                _engine.Write(scrubStream, items);
                scrubStream.Position = 0;

                using (var scrubReader = new StreamReader(scrubStream))
                using (var stream = File.Create(location))
                using (var streamWriter = new StreamWriter(stream))
                {
                    var line = scrubReader.ReadLine();
                    while (line != null)
                    {
                        streamWriter.WriteLine(line.Englify());
                        line = scrubReader.ReadLine();
                    }
                }

            }
        }

        public IEnumerable<T> Get(string location)
        {
            NormalizeLineLength(new FileInfo(location));

            using (var stream = File.OpenRead(location))
            {
                return _engine.Read<T>(stream).ToList();
            }
        }

        private static void NormalizeLineLength(FileSystemInfo fileInfo)
        {
            var normalized = new StringBuilder();

            var lineLength = ((IGeneratedFlatFile)new T()).TotalFileLength;

            using (var streamreader = new StreamReader(fileInfo.FullName))
            {
                string line;

                while ((line = streamreader.ReadLine()) != null)
                {
                    var normalizedLine = line + new String(' ', lineLength - line.Length);
                    normalized.AppendLine(normalizedLine);
                }
            }

            using (var fileStream = new FileStream(fileInfo.FullName,
                                                   FileMode.Truncate,
                                                   FileAccess.Write))
            {
                var streamWriter = new StreamWriter(fileStream);
                streamWriter.Write(normalized);
                streamWriter.Close();
                fileStream.Close();
            }
        }
    }
}
