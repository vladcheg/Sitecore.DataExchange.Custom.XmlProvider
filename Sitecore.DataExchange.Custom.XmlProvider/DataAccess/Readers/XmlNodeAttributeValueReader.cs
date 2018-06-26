namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    using System;
    using System.Xml;
    using DataExchange.DataAccess;
    public class XmlNodeAttributeValueReader : IValueReader
    {
        public string AttributeName { get; protected set; }

        public string XPath { get; protected set; }

        public XmlNodeAttributeValueReader(string attributeName)
        {
            this.AttributeName = attributeName;
        }

        public XmlNodeAttributeValueReader(string xpath, string attributeName):this(attributeName)
        {
            this.XPath = xpath;
        }

        public virtual bool CanRead(object source, DataAccessContext context)
        {
            if (string.IsNullOrWhiteSpace(this.AttributeName))
            {
                return false;
            }

            var node = source as XmlNode;

            if (!string.IsNullOrWhiteSpace(this.XPath) &&
                node?.SelectSingleNode(this.XPath)?.Attributes?[this.AttributeName]?.Value != null)
            {
                return true;
            }
            
            if (node?.Attributes != null )
            {
                return true;
            }

            return false;
        }

        public virtual ReadResult Read(object source, DataAccessContext context)
        {
            if (this.CanRead(source, context))
            {
                var node = source as XmlNode;

                if (!string.IsNullOrWhiteSpace(this.XPath))
                {
                    return ReadResult.PositiveResult(node?.SelectSingleNode(this.XPath)?.Attributes?[this.AttributeName]?.Value, DateTime.Now);
                }

                return ReadResult.PositiveResult(node?.Attributes?[this.AttributeName]?.Value, DateTime.Now);
            }

            return ReadResult.NegativeResult(DateTime.Now);
        }
    }
}