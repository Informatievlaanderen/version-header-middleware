namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware.AddVersionHeader.Tests
{
    using System.Reflection;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Xunit;

    public class AddVersionHeaderMiddlewareTests
    {
        [Fact]
        public async Task AddsAssemblyVersionToResponseHeaders()
        {
            var middleware = new AddVersionHeaderMiddleware(innerContext => Task.CompletedTask);
            var context = new DefaultHttpContext();
            var expectedVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

            await middleware.Invoke(context);

            context.Response.Headers.ContainsKey(AddVersionHeaderMiddleware.HeaderName).Should().BeTrue();
            context.Response.Headers[AddVersionHeaderMiddleware.HeaderName].Should().BeEquivalentTo(expectedVersion);
        }
    }
}
