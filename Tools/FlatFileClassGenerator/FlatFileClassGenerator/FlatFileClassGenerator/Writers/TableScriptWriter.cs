using System;
using System.IO;

namespace FlatFileClassGenerator.Writers
{
    public class TableScriptWriter : IDisposable
    {
        private readonly TextWriter _writer;

        public TableScriptWriter(TextWriter writer, string className)
        {
            _writer = writer;

            _writer.WriteLine("CREATE TABLE " + className);
            _writer.WriteLine("(");
            _writer.WriteLine("        " + className + "Id" + " INT PRIMARY KEY IDENTITY(1,1)");
        }

        public void Dispose()
        {
            _writer.WriteLine(")");
        }
    }
}
