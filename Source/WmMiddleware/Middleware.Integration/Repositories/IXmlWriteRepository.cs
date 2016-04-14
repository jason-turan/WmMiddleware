using System.Xml.Linq;

namespace Middleware.Integration.Repositories
{
    public interface IXmlWriteRepository
    {
        void Save(XDocument document);
    }
}
