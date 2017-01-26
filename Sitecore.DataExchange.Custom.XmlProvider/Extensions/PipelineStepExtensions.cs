namespace Sitecore.DataExchange.Custom.XmlProvider.Extensions
{
    using DataExchange.Models;
    using Plugins;

    public static class PipelineStepExtensions
    {
        public static XmlNodesFiltersSettings GetXmlNodesFiltersSettings(this PipelineStep pipelineStep)
        {
            return pipelineStep.GetPlugin<XmlNodesFiltersSettings>();
        }

        public static bool HasXmlNodesFiltersSettings(this PipelineStep pipelineStep)
        {
            return (GetXmlNodesFiltersSettings(pipelineStep) != null);
        }
    }
}