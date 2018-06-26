namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.DataAccess.ValueAccessors
{
    using Attributes;
    using DataExchange.Converters.DataAccess.ValueAccessors;
    using DataExchange.DataAccess;
    using Models.ItemModels.DataAccess.ValueAccessors;
    using Repositories;
    using Services.Core.Model;
    using XmlProvider.DataAccess.Readers;

    [SupportedIds("{753FDDAE-A61B-496B-99B0-3B891BB06E64}")]
    public class XmlNodeValueAccessorConverter : ValueAccessorConverter
    {
        public XmlNodeValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override IValueReader GetValueReader(ItemModel source)
        {
            return base.GetValueReader(source) ?? new XmlNodeValueReader(base.GetStringValue(source, XmlNodeValueAccessorItemModel.XPath));
        }
    }
}