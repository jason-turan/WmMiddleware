using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Middleware.Integration.Repositories
{
    public class XmlWebCommand : IXmlReadRepository
    {
        private readonly string _url;

        public XmlWebCommand(string url)
        {
            _url = url;
        }

        public XDocument Read()
        {
            var client = new WebClient();
            var rawBytes = client.DownloadData(_url);
            var data = Encoding.UTF8.GetString(rawBytes);
            return XDocument.Load(new XmlTextReader(new StringReader(data)));
        }
    }
}
