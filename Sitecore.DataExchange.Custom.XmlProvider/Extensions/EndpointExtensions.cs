namespace Sitecore.DataExchange.Custom.XmlProvider.Extensions
{
    using DataExchange.Models;
    using Plugins;

    public static class EndpointExtensions
    {
        public static XmlFileSettings GetTextFileSettings(this Endpoint endpoint)
        {
            return endpoint.GetPlugin<XmlFileSettings>();
        }
        public static bool HasXmlFileSettings(this Endpoint endpoint)
        {
            return GetTextFileSettings(endpoint) != null;
        }
    }
}