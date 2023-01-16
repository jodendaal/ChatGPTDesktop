namespace Winforms.Routing.Tests
{
    public class RouteConfigurationTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
           RouteConfiguration configuration= new RouteConfiguration();
            configuration.MapRoutes(typeof(Form2).Assembly);
        }
    }
}