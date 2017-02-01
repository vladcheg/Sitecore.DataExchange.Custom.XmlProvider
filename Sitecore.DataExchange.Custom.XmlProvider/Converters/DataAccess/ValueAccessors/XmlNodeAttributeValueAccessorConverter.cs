namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.DataAccess.ValueAccessors
{
    using Attributes;
    using DataExchange.Converters.DataAccess.ValueAccessors;
    using DataExchange.DataAccess;
    using Repositories;
    using Services.Core.Model;
    using XmlProvider.DataAccess.Readers;

    [SupportedIds("{69738136-E00F-4764-A07B-C875F3DB7280}")]
    public class XmlNodeAttributeValueAccessorConverter : ValueAccessorConverter
    {
        public XmlNodeAttributeValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        public override IValueAccessor Convert(ItemModel source)
        {
            var accessor = base.Convert(source);
            if (accessor == null)
            {
                return null;
            }

            var attributeName = base.GetStringValue(source, "AttributeName");
            var xpath = base.GetStringValue(source, "XPath");
            if (string.IsNullOrEmpty(attributeName))
            {
                return null;
            }

            if (accessor.ValueReader == null)
            {
                accessor.ValueReader = new XmlNodeAttributeValueReader(xpath, attributeName);
            }

            return accessor;
        }
    }
}