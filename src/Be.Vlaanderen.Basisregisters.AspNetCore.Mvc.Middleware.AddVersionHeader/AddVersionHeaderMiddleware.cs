namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware
{
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Add a 'x-basisregister-version' header to the response containing the assembly version.
    /// </summary>
    public class AddVersionHeaderMiddleware
    {
        public static string HeaderName = "x-basisregister-version";

        private readonly RequestDelegate _next;

        public AddVersionHeaderMiddleware(RequestDelegate next) => _next = next;

        public Task Invoke(HttpContext context)
        {
            var version = Assembly.GetEntryAssembly().GetName().Version.ToString();
            context.Response.Headers.Add(HeaderName, version);

            return _next(context);
        }
    }
}
