using System.Xml;
using System.Xml.Linq;
using NewBalance.GP._2010.Legacy;

namespace Middleware.Integration.Repositories
{
    public class GreatPlainsCommand : IXmlWriteRepository
    {
        private readonly MiddlewareController _middlewareController = new MiddlewareController(false, string.Empty);

        public void Save(XDocument document)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = document.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            _middlewareController.Execute(xmlDocument);
        }
    }
}
