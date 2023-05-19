using Album.Api;
namespace Album.Api.Tests
{
    public class GreetingService_GreetingShould
    {
        [Fact]
        public void Greeting_InputIsNull_ReturnHelloWorld()
        {
            var greetingService = new Services.GreetingService();
            string result = greetingService.Hello(null);
            Assert.Equal("Hello World", result);
        }
        [Fact]
        public void Greeting_InputIsTemplateName_ReturnHelloTemplateName()
        {
            var greetingService = new Services.GreetingService();
            string result = greetingService.Hello("TemplateName");
            Assert.Equal("Hello TemplateName", result);
        }
        [Fact]
        public void Greeting_InputIsWSpace_ReturnHelloWorld()
        {
            var greetingService = new Services.GreetingService();
            string result = greetingService.Hello("   ");
            Assert.Equal("Hello World", result);
        }
    }
}