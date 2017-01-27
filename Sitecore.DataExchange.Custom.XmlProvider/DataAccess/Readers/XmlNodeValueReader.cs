namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    using System;
    using System.Xml;
    using DataExchange.DataAccess;
    public class XmlNodeValueReader : IValueReader
    {
        public CanReadResult CanRead(object source, DataAccessContext context)
        {
            var node = source as XmlNode;
            if (node != null)
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
                return ReadResult.PositiveResult(node?.Value, DateTime.Now);
            }

            return ReadResult.NegativeResult(DateTime.Now);
        }
    }
}