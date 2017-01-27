namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.DataAccess.Readers
{
    using Attributes;
    using DataExchange.Converters;
    using DataExchange.DataAccess;
    using Repositories;
    using Services.Core.Model;
    using XmlProvider.DataAccess.Readers;

    
    [SupportedIds("{7BC635A0-F17D-4101-81D4-621D4C37DCD0}")]
    public class XmlNodeValueReaderConverter : BaseItemModelConverter<ItemModel, IValueReader>
    {
        public XmlNodeValueReaderConverter(IItemModelRepository repository) : base(repository)
        {
        }

        public override IValueReader Convert(ItemModel source)
        {
            return new XmlNodeValueReader();
        }
    }
}