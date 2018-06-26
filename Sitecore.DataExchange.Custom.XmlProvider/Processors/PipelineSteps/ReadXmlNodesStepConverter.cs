using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.PipelineSteps;
using Sitecore.DataExchange.Custom.XmlProvider.Models.ItemModels.PipelineSteps;
using Sitecore.DataExchange.Custom.XmlProvider.Plugins;
using Sitecore.DataExchange.Extensions;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sitecore.DataExchange.Custom.XmlProvider.Processors.PipelineSteps
{
    [SupportedIds("{791B1050-8429-4DB3-8BCF-301E226071BA}", "{57F611F1-C18C-4131-BCF4-C0FEF8AB1EA2}")]
    public class ReadXmlNodesStepConverter : BasePipelineStepConverter
    {
        public ReadXmlNodesStepConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override void AddPlugins(ItemModel source, PipelineStep pipelineStep)
        {
            var endpointSettings = new EndpointSettings()
            {
                EndpointFrom = base.ConvertReferenceToModel<Endpoint>(source, ReadXmlNodesItemModel.EndpointFrom)
            };

            var xmlNodesFiltersSettings = new XmlNodesFiltersSettings()
            {
                XPath = base.GetStringValue(source, ReadXmlNodesItemModel.XPath),
            };


            pipelineStep.AddPlugins(endpointSettings, xmlNodesFiltersSettings);
        }
    }
}