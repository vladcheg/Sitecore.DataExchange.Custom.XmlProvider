using System.Xml;
using Sitecore.DataExchange.Contexts;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.Services.Core.Diagnostics;

namespace Sitecore.DataExchange.Custom.XmlProvider.Processors.PipelineSteps
{
    public class ReadSingleXmlNodeStepProcessor : BaseReadXmlStepProcessor
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

            var xmlNode = xmlDocument.SelectSingleNode(xpath);
            var synchronizationSettings = new SynchronizationSettings(){Source = xmlNode};
            pipelineContext.AddPlugin(synchronizationSettings);
        }
    }
}