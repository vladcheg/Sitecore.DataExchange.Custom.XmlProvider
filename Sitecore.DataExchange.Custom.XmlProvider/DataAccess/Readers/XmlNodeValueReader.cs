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

        public CanReadResult CanRead(object source, DataAccessContext context)
        {
            var node = source as XmlNode;
            if (node != null && string.IsNullOrWhiteSpace(this.XPath))
            {
                return new CanReadResult() {CanReadValue = true};
            }

            if (node?.SelectSingleNode(this.XPath) != null)
            {
                return new CanReadResult() {CanReadValue = true};
            }

            return new CanReadResult();
        }

        public ReadResult Read(object source, DataAccessContext context)
        {
            if (this.CanRead(source, context).CanReadValue)
            {
                var node = source as XmlNode;
                return string.IsNullOrWhiteSpace(this.XPath)
                    ? ReadResult.PositiveResult(node?.Value, DateTime.Now)
                    : ReadResult.PositiveResult(node?.SelectSingleNode(this.XPath)?.Value, DateTime.Now);
            }

            return ReadResult.NegativeResult(DateTime.Now);
        }
    }
}