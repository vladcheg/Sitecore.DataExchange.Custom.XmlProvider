namespace Sitecore.DataExchange.Custom.XmlProvider.Tests
{
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;
    using Ploeh.AutoFixture.Xunit2;

    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(new Fixture()
            .Customize(new AutoNSubstituteCustomization()))
        {
        }
    }
}