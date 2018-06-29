using System;
using System.IO;
using System.Xml;
using Sitecore.DataExchange.Custom.XmlProvider.Extensions;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Troubleshooters;

namespace Sitecore.DataExchange.Custom.XmlProvider.Troubleshooters
{
    public class TestLoadXmlTroubleshooter : BaseEndpointTroubleshooter
    {
        protected override ITroubleshooterResult Troubleshoot(Endpoint endpoint, TroubleshooterContext context)
        {
            var path = endpoint?.GetXmlFileSettings()?.Path;
            if (string.IsNullOrWhiteSpace(path))
            {
                return new TroubleshooterResult(){ Message = "Path to the file not set or empty.", Success = false};
            }

            string resolvedPath = ResolvePath(path);
            if (!File.Exists(resolvedPath))
            {
                return new TroubleshooterResult() {Message = "File does not exist.", Success = false};
            }

            try
            {
                new XmlDocument().Load(resolvedPath);
            }
            catch (Exception e)
            {
                return new TroubleshooterResult() { Message = "Cannot load xml file.", Success = false, Exception = e};
            }

            return new TroubleshooterResult() {Message = "Xml file was successfully loaded.", Success = true};
        }

        protected static string ResolvePath(string path)
        {
            return !Path.IsPathRooted(path) ? $"{AppDomain.CurrentDomain.BaseDirectory}{path}" : path;
        }
    }
}