using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    [SupportedIds("{7BC635A0-F17D-4101-81D4-621D4C37DCD0}")]
    public class XmlNodeValueReaderConverter : BaseItemModelConverter<IValueReader>
    {
        public const string FieldNameXPath = "XPath";
        public const string FieldNameProperty = "Property";
        public XmlNodeValueReaderConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override ConvertResult<IValueReader> ConvertSupportedItem(ItemModel source)
        {
            return ConvertResult<IValueReader>.PositiveResult(new XmlNodeValueReader(base.GetStringValue(source, FieldNameXPath), GetStringValue(source, FieldNameProperty)));
        }
    }
}