using System.Xml.Linq;

namespace Middleware.Integration.Repositories
{
    public interface IXmlReadRepository
    {
        XDocument Read();
    }
}
