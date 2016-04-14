using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Middleware.Integration.Repositories
{
    public class XmlZipFileCommand : XmlFileCommand
    {
        public XmlZipFileCommand(string directory, string filename)
            : base(directory, filename)
        {
        }

        public override XDocument Read()
        {
            return base.Read();
        }
    }
}
