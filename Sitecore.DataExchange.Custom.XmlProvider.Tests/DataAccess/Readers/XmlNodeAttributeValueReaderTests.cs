namespace Sitecore.DataExchange.Custom.XmlProvider.Tests.DataAccess.Readers
{
    using System.Xml;
    using DataExchange.DataAccess;
    using FluentAssertions;
    using Ploeh.AutoFixture.Xunit2;
    using XmlProvider.DataAccess.Readers;
    using Xunit;

    public class XmlNodeAttributeValueReaderTests
    {
        [Theory, AutoData]
        public void CanReadResult_NegativeResult(XmlNodeAttributeValueReader reader, int source, DataAccessContext context)
        {
            var canReadResult = reader.CanRead(source, context);

            canReadResult.Should().NotBeNull();
            canReadResult.CanReadValue.Should().BeFalse("because source is not {0}", typeof(XmlNode));
        }
    }
}