using Sitecore.DataExchange.DataAccess;

namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    public abstract class BaseXmlXpathValueReader : IValueReader
    {
        public string XPath { get; protected set; }

        protected BaseXmlXpathValueReader(string xPath)
        {
            this.XPath = xPath;
        }
        public abstract ReadResult Read(object source, DataAccessContext context);
    }
}