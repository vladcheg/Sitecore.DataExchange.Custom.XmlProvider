namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.DataAccess.ValueAccessors
{
    using Attributes;
    using DataExchange.Converters.DataAccess.ValueAccessors;
    using DataExchange.DataAccess;
    using Repositories;
    using Services.Core.Model;
    using XmlProvider.DataAccess.Readers;

    [SupportedIds("{753FDDAE-A61B-496B-99B0-3B891BB06E64}")]
    public class XmlNodeValueAccessorConverter : ValueAccessorConverter
    {
        public XmlNodeValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        public override IValueAccessor Convert(ItemModel source)
        {
            var accessor = base.Convert(source);
            if (accessor == null)
            {
                return null;
            }

            var xpath = base.GetStringValue(source, "XPath");

            if (accessor.ValueReader == null)
            {
                accessor.ValueReader = new XmlNodeValueReader(xpath);
            }

            return accessor;
        }
    }
}