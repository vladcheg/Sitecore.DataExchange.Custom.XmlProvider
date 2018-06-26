namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.DataAccess.ValueAccessors
{
    using Attributes;
    using DataExchange.Converters.DataAccess.ValueAccessors;
    using DataExchange.DataAccess;
    using Models.ItemModels.DataAccess.ValueAccessors;
    using Repositories;
    using Services.Core.Model;
    using XmlProvider.DataAccess.Readers;

    [SupportedIds("{69738136-E00F-4764-A07B-C875F3DB7280}")]
    public class XmlNodeAttributeValueAccessorConverter : ValueAccessorConverter
    {
        public XmlNodeAttributeValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override IValueReader GetValueReader(ItemModel source)
        {
            return base.GetValueReader(source) ?? new XmlNodeAttributeValueReader(
                       base.GetStringValue(source, XmlNodeAttributeValueAccessorItemModel.XPath),
                       base.GetStringValue(source, XmlNodeAttributeValueAccessorItemModel.Attribute));
        }
    }
}