namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.Endpoints
{
    using Attributes;
    using DataExchange.Converters.Endpoints;
    using DataExchange.Models;
    using Models.ItemModels.Endpoints;
    using Plugins;
    using Repositories;
    using Services.Core.Model;

    [SupportedIds("{391516D3-BE29-4985-A630-8C6242C5A119}")]
    public class XmlFileEndpointConverter : BaseEndpointConverter<ItemModel>
    {
        public XmlFileEndpointConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            var xmlFileSettings = new XmlFileSettings()
            {
                Path = base.GetStringValue(source, XmlFileEndpointItemModel.Path)
            };

            endpoint.Plugins.Add(xmlFileSettings);
        }
    }
}