# Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware.AddVersionHeader [![Build Status](https://github.com/Informatievlaanderen/version-header-middleware/workflows/Build/badge.svg)](https://github.com/Informatievlaanderen/version-header-middleware/actions)

## Goal

Middleware component which adds the version of the assembly as header `x-basisregister-version` to the response.

It is also possible to configure a custom header name to be used.

## Usage

### Default x-version header

```csharp
namespace Example
{
    using System.Threading.Tasks;
    using Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(x => x.UseStartup<Startup>());

            await builder.RunConsoleAsync();
        }
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app
                .UseMiddleware<AddVersionHeaderMiddleware>()
                .Run(async context => await context.Response.WriteAsync("Hello World"));
        }
    }
}
```

Running this and making a request to it will result in:

```bash
$ curl -v localhost:5000
* Rebuilt URL to: localhost:5000/
*   Trying 127.0.0.1...
* Connected to localhost (127.0.0.1) port 5000 (#0)
> GET / HTTP/1.1
> Host: localhost:5000
> User-Agent: curl/7.47.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Date: Mon, 13 Jul 2020 21:01:57 GMT
< Server: Kestrel
< Transfer-Encoding: chunked
< x-version: 1.0.0.0
<
Hello World
```

### Custom header

```csharp
namespace Example
{
    using System.Threading.Tasks;
    using Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(x => x.UseStartup<Startup>());

            await builder.RunConsoleAsync();
        }
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app
                .UseMiddleware<AddVersionHeaderMiddleware>("x-your-custom-header")
                .Run(async context => await context.Response.WriteAsync("Hello World"));
        }
    }
}
```

Running this and making a request to it will result in:

```bash
$ curl -v localhost:5000
* Rebuilt URL to: localhost:5000/
*   Trying 127.0.0.1...
* Connected to localhost (127.0.0.1) port 5000 (#0)
> GET / HTTP/1.1
> Host: localhost:5000
> User-Agent: curl/7.47.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Date: Mon, 13 Jul 2020 21:01:57 GMT
< Server: Kestrel
< Transfer-Encoding: chunked
< x-your-custom-header: 1.0.0.0
<
Hello World
```

## License

[MIT License](https://choosealicense.com/licenses/mit/)

## Credits

### Languages & Frameworks

* [.NET Core](https://github.com/Microsoft/dotnet/blob/master/LICENSE) - [MIT](https://choosealicense.com/licenses/mit/)
* [.NET Core Runtime](https://github.com/dotnet/coreclr/blob/master/LICENSE.TXT) - _CoreCLR is the runtime for .NET Core. It includes the garbage collector, JIT compiler, primitive data types and low-level classes._ - [MIT](https://choosealicense.com/licenses/mit/)
* [.NET Core APIs](https://github.com/dotnet/corefx/blob/master/LICENSE.TXT) - _CoreFX is the foundational class libraries for .NET Core. It includes types for collections, file systems, console, JSON, XML, async and many others._ - [MIT](https://choosealicense.com/licenses/mit/)
* [.NET Core SDK](https://github.com/dotnet/sdk/blob/master/LICENSE.TXT) - _Core functionality needed to create .NET Core projects, that is shared between Visual Studio and CLI._ - [MIT](https://choosealicense.com/licenses/mit/)
* [Roslyn and C#](https://github.com/dotnet/roslyn/blob/master/License.txt) - _The Roslyn .NET compiler provides C# and Visual Basic languages with rich code analysis APIs._ - [Apache License 2.0](https://choosealicense.com/licenses/apache-2.0/)
* [F#](https://github.com/fsharp/fsharp/blob/master/LICENSE) - _The F# Compiler, Core Library & Tools_ - [MIT](https://choosealicense.com/licenses/mit/)
* [F# and .NET Core](https://github.com/dotnet/netcorecli-fsc/blob/master/LICENSE) - _F# and .NET Core SDK working together._ - [MIT](https://choosealicense.com/licenses/mit/)

### Libraries

* [xUnit](https://github.com/xunit/xunit/blob/master/license.txt) - _xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework._ - [Apache License 2.0](https://choosealicense.com/licenses/apache-2.0/)
* [FluentAssertions](https://github.com/fluentassertions/fluentassertions/blob/master/LICENSE) - _Fluent API for asserting the results of unit tests._ - [Apache License 2.0](https://choosealicense.com/licenses/apache-2.0/)

### Tooling

* [npm](https://github.com/npm/cli/blob/latest/LICENSE) - _A package manager for JavaScript._ - [Artistic License 2.0](https://choosealicense.com/licenses/artistic-2.0/)
* [semantic-release](https://github.com/semantic-release/semantic-release/blob/master/LICENSE) - _Fully automated version management and package publishing._ - [MIT](https://choosealicense.com/licenses/mit/)
* [semantic-release/changelog](https://github.com/semantic-release/changelog/blob/master/LICENSE) - _Semantic-release plugin to create or update a changelog file._ - [MIT](https://choosealicense.com/licenses/mit/)
* [semantic-release/commit-analyzer](https://github.com/semantic-release/commit-analyzer/blob/master/LICENSE) - _Semantic-release plugin to analyze commits with conventional-changelog._ - [MIT](https://choosealicense.com/licenses/mit/)
* [semantic-release/exec](https://github.com/semantic-release/exec/blob/master/LICENSE) - _Semantic-release plugin to execute custom shell commands._ - [MIT](https://choosealicense.com/licenses/mit/)
* [semantic-release/git](https://github.com/semantic-release/git/blob/master/LICENSE) - _Semantic-release plugin to commit release assets to the project's git repository._ - [MIT](https://choosealicense.com/licenses/mit/)
* [semantic-release/github](https://github.com/semantic-release/github/blob/master/LICENSE) - _Semantic-release plugin to publish a GitHub release._ - [MIT](https://choosealicense.com/licenses/mit/)
* [semantic-release/npm](https://github.com/semantic-release/npm/blob/master/LICENSE) - _Semantic-release plugin to publish a npm package._ - [MIT](https://choosealicense.com/licenses/mit/)
* [semantic-release/release-notes-generator](https://github.com/semantic-release/release-notes-generator/blob/master/LICENSE) - _Semantic-release plugin to generate changelog content with conventional-changelog._ - [MIT](https://choosealicense.com/licenses/mit/)
* [commitlint](https://github.com/conventional-changelog/commitlint/blob/master/license.md) - _Lint commit messages._ - [MIT](https://choosealicense.com/licenses/mit/)
* [commitizen/cz-cli](https://github.com/commitizen/cz-cli/blob/master/LICENSE) - _The commitizen command line utility._ - [MIT](https://choosealicense.com/licenses/mit/)
* [commitizen/cz-conventional-changelog](https://github.com/commitizen/cz-conventional-changelog/blob/master/LICENSE) _A commitizen adapter for the angular preset of conventional-changelog._ - [MIT](https://choosealicense.com/licenses/mit/)
* [husky](https://github.com/typicode/husky/blob/master/LICENSE) - _Git hooks made easy._  - [MIT](https://choosealicense.com/licenses/mit/)

### Flemish Government Libraries

* [Be.Vlaanderen.Basisregisters.Build.Pipeline](https://github.com/informatievlaanderen/build-pipeline/blob/main/LICENSE) - _Contains generic files for all Basisregisters Vlaanderen pipelines._ - [MIT](https://choosealicense.com/licenses/mit/)
