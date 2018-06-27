using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.DataAccess.ValueAccessors
{
    [SupportedIds("{74A89C82-AF84-4615-A2B0-0DEF2B18537C}")]
    public class XmlNodesValueAccessorConverter : ValueAccessorConverter
    {
        public const string FieldNameXPath = "XPath";
        public XmlNodesValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override IValueReader GetValueReader(ItemModel source)
        {
            return new XmlNodesValueReader(base.GetStringValue(source, FieldNameXPath));
        }
    }
}