using Sitecore.DataExchange.DataAccess.Readers;

namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    using System;
    using System.Xml;
    using DataExchange.DataAccess;
    public class XmlNodeValueReader : IValueReader
    {
        public string XPath { get; protected set; }
        public string Property { get; protected set; }


        public XmlNodeValueReader()
        {

        }

        public XmlNodeValueReader(string xpath = null, string property = null)
        {
            this.XPath = xpath;
            this.Property = property;
        }

        public virtual ReadResult Read(object source, DataAccessContext context)
        {
            if (!(source is XmlNode xmlNode))
            {
                return ReadResult.NegativeResult(DateTime.Now);
            }

            if (string.IsNullOrWhiteSpace(XPath) && string.IsNullOrWhiteSpace(Property))
            {
                return ReadResult.PositiveResult(xmlNode, DateTime.Now);
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(XPath) && string.IsNullOrWhiteSpace(Property))
                {

                    return ReadResult.PositiveResult(xmlNode.SelectSingleNode(this.XPath), DateTime.Now);
                }

                var propertyValueReader = new PropertyValueReader(Property);
                
                var selectSingleNode = xmlNode.SelectSingleNode(XPath);
                return selectSingleNode == null
                    ? ReadResult.PositiveResult(null, DateTime.Now)
                    : propertyValueReader.Read(selectSingleNode, new DataAccessContext());

            }
            catch (Exception)
            {
                return ReadResult.NegativeResult(DateTime.Now);
            }

        }
    }
}