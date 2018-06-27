using System;
using System.Xml;
using Sitecore.DataExchange.DataAccess;

namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    public class XmlNodesValueReader : BaseXmlXpathValueReader
    {
        public XmlNodesValueReader(string xPath) : base(xPath)
        {
        }

        public override ReadResult Read(object source, DataAccessContext context)
        {
            if (!(source is XmlNode xmlNode))
            {
                return ReadResult.NegativeResult(DateTime.Now);
            }

            if (string.IsNullOrWhiteSpace(base.XPath))
            {
                return ReadResult.NegativeResult(DateTime.Now);
            }
            
            try
            {
                return ReadResult.PositiveResult(xmlNode.SelectNodes(base.XPath), DateTime.Now);
            }
            catch (Exception)
            {
                return ReadResult.NegativeResult(DateTime.Now);
            }
        }
    }
}