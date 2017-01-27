namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    using System;
    using System.Xml;
    using DataExchange.DataAccess;
    public class XmlNodeAttributeValueReader : IValueReader
    {
        public string AttributeName { get; protected set; }

        public XmlNodeAttributeValueReader(string attributeName)
        {
            this.AttributeName = attributeName;
        }

        public virtual CanReadResult CanRead(object source, DataAccessContext context)
        {
            var node = source as XmlNode;
            if (node?.Attributes != null )
            {
                return new CanReadResult() {CanReadValue = true};
            }

            return new CanReadResult();
        }

        public virtual ReadResult Read(object source, DataAccessContext context)
        {
            if (this.CanRead(source, context).CanReadValue)
            {
                var node = source as XmlNode;
                return ReadResult.PositiveResult(node?.Attributes?[this.AttributeName]?.Value, DateTime.Now);
            }

            return ReadResult.NegativeResult(DateTime.Now);
        }
    }
}