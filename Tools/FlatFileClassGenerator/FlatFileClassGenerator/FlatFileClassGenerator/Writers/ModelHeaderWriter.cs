using System;
using System.IO;

namespace FlatFileClassGenerator.Writers
{
    public class ModelHeaderWriter : IDisposable
    {
        private readonly TextWriter _writer;

        public ModelHeaderWriter(TextWriter writer, string @namespace, string className)
        {
            _writer = writer;

            _writer.WriteLine("using System;");
            _writer.WriteLine("using System.Globalization;");
            _writer.WriteLine("using Dapper.Contrib.Extensions;");
            _writer.WriteLine("using FlatFile.FixedLength;");
            _writer.WriteLine("using FlatFile.FixedLength.Attributes;");
            _writer.WriteLine("using WmMiddleware.Common.DataFiles;");

            _writer.WriteLine();
            _writer.WriteLine("namespace " + @namespace);
            _writer.WriteLine("{");
            _writer.WriteLine("    // Generated with FlatFileClassGenerator");
            _writer.WriteLine("    [FixedLengthFile]");
            _writer.WriteLine("    [Table(\"" + className + "\")]");
            _writer.WriteLine("    public partial class " + className + " : IGeneratedFlatFile");
            _writer.WriteLine("    {");
            _writer.WriteLine("        [Key]");
            _writer.WriteLine("         public int " + className + "Id { get; set; }");
            _writer.WriteLine("");
        }

        public void Dispose()
        {
            _writer.WriteLine("    }");
            _writer.WriteLine("}");
        }
    }
}
