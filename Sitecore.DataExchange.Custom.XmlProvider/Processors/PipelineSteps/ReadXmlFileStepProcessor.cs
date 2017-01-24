namespace Sitecore.DataExchange.Custom.XmlProvider.Processors.PipelineSteps
{
    using System;
    using System.Xml;
    using Attributes;
    using Contexts;
    using DataExchange.Models;
    using DataExchange.Plugins;
    using DataExchange.Processors.PipelineSteps;
    using Extensions;
    using Plugins;

    [RequiredEndpointPlugins(typeof(XmlFileSettings))]
    public class ReadXmlFileStepProcessor : BaseReadDataStepProcessor
    {
        protected override void ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext)
        {
            var logger = pipelineContext.PipelineBatchContext.Logger;
            var textFileSettings = endpoint.GetTextFileSettings();
            if (textFileSettings == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(textFileSettings.Path))
            {
                logger.Error($"No path is specified on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return;
            }

            var xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(textFileSettings.Path);
            }
            catch (XmlException ex)
            {
                logger.Error($"Cannot load xml file. (path: {textFileSettings.Path}, pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name}, errorMessage: {ex.Message})");
                return;
            }

            //TODO: Get xpath from plugin
            var xmlNodeList = xmlDocument.SelectNodes("/Contacts/Contact");
            var iterableDataSettings = new IterableDataSettings(xmlNodeList);
            pipelineContext.Plugins.Add(iterableDataSettings);
        }
    }
}