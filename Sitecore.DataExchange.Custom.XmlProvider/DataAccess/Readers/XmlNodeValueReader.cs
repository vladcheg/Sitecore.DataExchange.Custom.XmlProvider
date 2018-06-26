namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    using System;
    using System.Xml;
    using DataExchange.DataAccess;
    public class XmlNodeValueReader : IValueReader
    {
        public string XPath { get; protected set; }


        public XmlNodeValueReader()
        {
            
        }

        public XmlNodeValueReader(string xpath)
        {
            this.XPath = xpath;
        }

        public ReadResult Read(object source, DataAccessContext context)
        {
            if (!(source is XmlNode xmlNode))
            {
                return ReadResult.NegativeResult(DateTime.Now);
            }

            return string.IsNullOrWhiteSpace(this.XPath)
                    ? ReadResult.PositiveResult(xmlNode?.Value, DateTime.Now)
                    : ReadResult.PositiveResult(xmlNode?.SelectSingleNode(this.XPath)?.InnerText, DateTime.Now);
        }
    }
}