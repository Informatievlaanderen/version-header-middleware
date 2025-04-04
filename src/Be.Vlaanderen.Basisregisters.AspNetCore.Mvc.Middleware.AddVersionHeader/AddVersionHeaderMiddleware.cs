namespace Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware
{
    using System.Reflection;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Add an 'x-basisregister-version' header to the response containing the assembly version.
    /// </summary>
    public class AddVersionHeaderMiddleware
    {
        public const string HeaderName = "x-version";

        private readonly RequestDelegate _next;
        private readonly string _headerName;

        public AddVersionHeaderMiddleware(
            RequestDelegate next,
            string headerName = HeaderName)
        {
            _next = next;
            _headerName = headerName;
        }

        public Task Invoke(HttpContext context)
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString();
            context.Response.Headers.Append(_headerName, version);
            return _next(context);
        }
    }
}
