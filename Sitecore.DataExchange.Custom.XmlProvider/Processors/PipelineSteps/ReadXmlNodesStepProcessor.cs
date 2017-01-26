namespace Sitecore.DataExchange.Custom.XmlProvider.Processors.PipelineSteps
{
    using System.Xml;
    using Attributes;
    using Contexts;
    using DataExchange.Models;
    using DataExchange.Plugins;
    using DataExchange.Processors.PipelineSteps;
    using Extensions;
    using Plugins;

    [RequiredEndpointPlugins(typeof(XmlFileSettings))]
    [RequiredPipelineStepPlugins(typeof(XmlNodesFiltersSettings))]
    public class ReadXmlNodesStepProcessor : BaseReadDataStepProcessor
    {
        protected override void ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext)
        {
            var logger = pipelineContext.PipelineBatchContext.Logger;
            var xmlFileSettings = endpoint.GetXmlFileSettings();
            if (xmlFileSettings == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(xmlFileSettings.Path))
            {
                logger.Error($"No path is specified on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }

            var xmlNodesFiltersSettings = pipelineStep.GetXmlNodesFiltersSettings();
            if (xmlNodesFiltersSettings == null)
            {
                //TODO: write to log
                return;
            }

            var xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(xmlFileSettings.Path);
            }
            catch (XmlException ex)
            {
                logger.Error($"Cannot load xml file. (path: {xmlFileSettings.Path}, pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name}, errorMessage: {ex.Message})");
                return;
            }

            var xmlNodeList = xmlDocument.SelectNodes(xmlNodesFiltersSettings.XPath);
            var iterableDataSettings = new IterableDataSettings(xmlNodeList);
            pipelineContext.Plugins.Add(iterableDataSettings);
        }
    }
}