using System;
using System.IO;
using System.Xml;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Contexts;
using Sitecore.DataExchange.Custom.XmlProvider.Extensions;
using Sitecore.DataExchange.Custom.XmlProvider.Plugins;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Processors.PipelineSteps;
using Sitecore.Services.Core.Diagnostics;

namespace Sitecore.DataExchange.Custom.XmlProvider.Processors.PipelineSteps
{
    [RequiredEndpointPlugins(typeof(XmlFileSettings))]
    [RequiredPipelineStepPlugins(typeof(XmlNodesFiltersSettings))]
    public abstract class BaseReadXmlStepProcessor : BaseReadDataStepProcessor
    {
        protected BaseReadXmlStepProcessor()
        {
        }

        protected static string ResolvePath(string path)
        {
            return !Path.IsPathRooted(path) ? $"{AppDomain.CurrentDomain.BaseDirectory}{path}" : path;
        }

        protected virtual string GetXpath(PipelineStep pipelineStep, PipelineContext pipelineContext)
        {
             return  pipelineStep.GetXmlNodesFiltersSettings()?.XPath;
        }

        protected virtual XmlDocument LoadXml(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext, ILogger logger)
        {
            var xmlFileSettings = endpoint.GetXmlFileSettings();
            if (xmlFileSettings == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(xmlFileSettings.Path))
            {
                logger.Error($"No path is specified on the endpoint. (pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name})");
                return null;
            }

            var path = ResolvePath(xmlFileSettings.Path);


            if (!File.Exists(path))
            {
                logger.Error("The path specified on the endpoint does not exist. (pipeline step: {0}, endpoint: {1}, path: {2})", pipelineStep.Name, endpoint.Name, path);
                return null;
            }


            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(path);
            }
            catch (Exception ex)
            {
                logger.Error($"Exception during loading xml file. (path: {xmlFileSettings.Path}, pipeline step: {pipelineStep.Name}, endpoint: {endpoint.Name}, errorMessage: {ex.Message})");
                return null;
            }

            return xmlDocument;
        }
    }
}