# Microservices with ocelot (Ocelot API Gateway)

Ocelot is a .NET API Gateway designed for microservices or service-oriented architectures, providing a unified entry point for systems using HTTP(S). It integrates seamlessly with ASP.NET Core and supports platforms compatible with it.

## Features:

- Dynamic routing via Ocelot
- Scalable microservices (Products, Users)

## Architecture:

![Microservices Architecture](https://github.com/user-attachments/assets/9eb03876-b2bd-4ca6-9fc3-15d4a2131bb3)

## Installation & Configuration:

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

**Setup**:

- Clone the repository

  ```bash
  git clone https://github.com/iamnomandra/microservices_with_ocelot
  ```

- Restore dependencies

  ```bash
   dotnet restore
  ```

- Run the application
  1. Go Run `►` and with help dropdown `▼` click `Configure Startup Projects...`
  2. Check `Multiple Startup Projects`
  3. Set `Action` all project `Start`

**Demo**:

- Test the API using Postman:

  ```markdown
  `GET http://localhost:7071/gateway/products` - Retrieves products list
  `GET http://localhost:7071/gateway/products/find{id}` - Retrieves product from id
  `POST http://localhost:7071/gateway/users/login` - Authenticate users
  ```
## Screenshot:

`Endpoint Get Products`</br>
<img src="https://github.com/iamnomandra/microservices_with_ocelot/blob/master/Screenshot%202025-05-13%20005442.png" width="800">  
`Endpoint Login User`</br>
<img src="https://github.com/iamnomandra/microservices_with_ocelot/blob/master/Screenshot%202025-05-13%20005421.png" width="800">  

## License:
 - MIT License
  
For the full README content, including setup instructions, advanced configurations, and contribution guidelines, visit the repository directly at https://github.com/ThreeMammals/Ocelot.
