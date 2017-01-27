namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.DataAccess.Readers
{
    using Attributes;
    using DataExchange.Converters;
    using DataExchange.DataAccess;
    using Models.ItemModels.DataAccess.Readers;
    using Repositories;
    using Services.Core.Model;
    using XmlProvider.DataAccess.Readers;

    [SupportedIds("{975A2A0F-F270-466B-A61C-2684826094B0}")]
    public class XmlNodeAttributeValueReaderConverter : BaseItemModelConverter<ItemModel, IValueReader>
    {
        public XmlNodeAttributeValueReaderConverter(IItemModelRepository repository) : base(repository)
        {
        }

        public override IValueReader Convert(ItemModel source)
        {
            var attributeName = base.GetStringValue(source, XmlNodeAttributeValueRaderItemModel.AttributeName);
            return new XmlAttributeValueReader(attributeName);
        }
    }
}