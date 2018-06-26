using Sitecore.Services.Core.Diagnostics;

namespace Sitecore.DataExchange.Custom.XmlProvider.Processors.PipelineSteps
{
    using System;
    using System.IO;
    using System.Xml;
    using Attributes;
    using Contexts;
    using DataExchange.Models;
    using DataExchange.Plugins;
    using DataExchange.Processors.PipelineSteps;
    using Extensions;
    using Plugins;

    public class ReadXmlNodesStepProcessor : BaseReadXmlStepProcessor
    {
        protected override void ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger)
        {
            XmlDocument xmlDocument = base.LoadXml(endpoint, pipelineStep, pipelineContext, logger);
            if (xmlDocument == null)
            {
                pipelineContext.Finished = true;
                logger.Error("Cannot load xml document");
                return;
            }

            var xpath = base.GetXpath(pipelineStep, pipelineContext);
            if (string.IsNullOrWhiteSpace(xpath))
            {
                pipelineContext.Finished = true;
                logger.Error("Cannot get xpath");
                return;
            }

            var xmlNodeList = xmlDocument.SelectNodes(xpath);
            var iterableDataSettings = new IterableDataSettings(xmlNodeList);
            pipelineContext.AddPlugin(iterableDataSettings);
        }
    }
}