# Microservices with ocelot (Ocelot API Gateway)

Ocelot is a .NET API Gateway designed for microservices or service-oriented architectures, providing a unified entry point for systems using HTTP(S). It integrates seamlessly with ASP.NET Core and supports platforms compatible with it.

## Installation:

**Install Ocelot via NuGet**: `Install-Package Ocelot` </br>
- Add Ocelot to the service configuration in `Program.cs`

```csharp
builder.Services.AddOcelot(builder.Configuration);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
```

**Configure the Ocelot pipeline**:

```csharp
await app.UseOcelot();
```

**Ocelot json**: `ocelot.json`</br>
- Create ocelot.json in root directory

```json
{
  "GlobalConfiguration": {
    "BaseUrl": "https://localhost:7071"
  },
  "Routes": [
    {
      "UpstreamPathTemplate": "/gateway/products",
      "UpstreamHttpMethod": ["GET"],
      "DownstreamPathTemplate": "/api/products",
      "DownstreamScheme": "https",
      "DownstreamHostAndPorts": [
        {
          "Host": "localhost",
          "Port": 5188
        }
      ]
    }
  ]
}
```

**Options for Ocelot**: `Install-Package Ocelot.Cache.CacheManager`

- EnableRateLimiting for restrict api call limit 3 within 10 sec.

```json
  "RateLimitOptions": {
    "EnableRateLimiting": true,
    "Period": "10s",
    "Limit": 3,
    "PeriodTimespan": 10
  }
```

For the full README content, including setup instructions, advanced configurations, and contribution guidelines, visit the repository directly at https://github.com/ThreeMammals/Ocelot.
