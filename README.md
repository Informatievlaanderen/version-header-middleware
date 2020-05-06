# Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware.AddVersionHeader [![Build Status](https://github.com/Informatievlaanderen/version-header-middleware/workflows/CI/badge.svg)](https://github.com/Informatievlaanderen/version-header-middleware/actions)

Middleware component which adds the version of the assembly as header `x-basisregister-version` to the response.

It is also possible to configure a custom header name to be used.

## Usage

```csharp
public void Configure(IApplicationBuilder app, ...)
{
    app
        ...
        .UseMiddleware<AddVersionHeaderMiddleware>()
        ...
}
```

```csharp
public void Configure(IApplicationBuilder app, ...)
{
    app
        ...
        .UseMiddleware<AddVersionHeaderMiddleware>("x-your-custom-header")
        ...
}
```
