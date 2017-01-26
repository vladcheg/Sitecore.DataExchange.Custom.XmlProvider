namespace Sitecore.DataExchange.Custom.XmlProvider.Converters.PipelineSteps
{
    using Attributes;
    using DataExchange.Converters.PipelineSteps;
    using DataExchange.Models;
    using DataExchange.Plugins;
    using Models.PipelineSteps;
    using Plugins;
    using Queues;
    using Repositories;
    using Services.Core.Model;

    [SupportedIds("{FA315BE9-A96E-417D-8AFB-A93A722B10C5}")]
    public class ReadXmlNodesStepConverter : BasePipelineStepConverter<ItemModel>
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


            pipelineStep.Plugins.Add(endpointSettings);
            pipelineStep.Plugins.Add(xmlNodesFiltersSettings);
        }
    }
}