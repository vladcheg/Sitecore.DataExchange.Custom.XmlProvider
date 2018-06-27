using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters;
using Sitecore.DataExchange.Custom.XmlProvider.Models.ItemModels.DataAccess.Readers;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sitecore.DataExchange.Custom.XmlProvider.DataAccess.Readers
{
    [SupportedIds("{975A2A0F-F270-466B-A61C-2684826094B0}")]
    public class XmlNodeAttributeValueReaderConverter : BaseItemModelConverter<IValueReader>
    {
        public XmlNodeAttributeValueReaderConverter(IItemModelRepository repository) : base(repository)
        {
        }


        protected override ConvertResult<IValueReader> ConvertSupportedItem(ItemModel source)
        {
            var attributeName = base.GetStringValue(source, XmlNodeAttributeValueRaderItemModel.AttributeName);
            return ConvertResult<IValueReader>.PositiveResult(new XmlNodeAttributeValueReader(attributeName));
        }
    }
}