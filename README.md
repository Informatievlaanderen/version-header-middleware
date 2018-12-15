# Be.Vlaanderen.Basisregisters.AspNetCore.Mvc.Middleware.AddVersionHeader

Middleware component which adds the version of the assembly as header `x-basisregister-version` to the response.

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