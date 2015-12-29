using System;
using System.IO;

namespace FlatFileClassGenerator
{
    public class ClassHeaderWriter : IDisposable
    {
        private readonly TextWriter _writer;

        public ClassHeaderWriter(TextWriter writer, string @namespace, string className)
        {
            _writer = writer;

            _writer.WriteLine("using System;");
            _writer.WriteLine("using System.Globalization;");
            _writer.WriteLine("using FlatFile.FixedLength;");
            _writer.WriteLine("using FlatFile.FixedLength.Attributes;");
            _writer.WriteLine();
            _writer.WriteLine("// ReSharper disable InconsistentNaming");
            _writer.WriteLine("// ReSharper disable CheckNamespace");
            _writer.WriteLine("namespace " + @namespace);
            _writer.WriteLine("{");
            _writer.WriteLine("    // Generated with FlatFileClassGenerator");
            _writer.WriteLine("    [FixedLengthFile]");
            _writer.WriteLine("    internal partial class " + className);
            _writer.WriteLine("    {");
        }

        public void Dispose()
        {
            _writer.WriteLine("    }");
            _writer.WriteLine("}");
            _writer.WriteLine("// ReSharper restore InconsistentNaming");
            _writer.WriteLine("// ReSharper restore CheckNamespace"); 
        }
    }
}
