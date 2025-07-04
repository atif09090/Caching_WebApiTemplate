# Caching Web API Template (.NET 8)

A clean, extensible Web API template built on .NET 8 that demonstrates various caching strategies: in-memory caching, distributed caching (Redis), and response/CDN caching.

---

## 🚀 Features

- ✅ .NET 8 compatible
- ⚡ In-Memory & Redis Distributed Caching
- 🌐 Response Caching via Cache-Control headers
- 🌍 CORS Policy Support
- 🧩 Modular Configurations (Cache, CORS, Cache Profiles)
- 📦 Swagger/OpenAPI with caching-aware endpoints
- 📂 Clean architecture and folder structure

---

## 📁 Project Structure

```plaintext
CachingWebApiTemplate/
├── Controllers/
│ └── WeatherForecastController.cs
├── Models/
│ ├── WeatherForecast.cs
│ └── CacheKeys.cs
├── Services/
│ └── CacheService.cs
├── Configuration/
│ ├── CorsOptions.cs
│ └── CacheProfiles.cs
├── Program.cs
├── appsettings.json
└── README.md


---

## 🧠 Caching Strategies Used

### 🟡 In-Memory Cache

Uses `MemoryCache` to store frequently accessed data for fast retrieval in a single-instance app.

### 🔴 Redis (Optional)

You can extend `CacheService` to use Redis distributed cache for multi-node consistency.

### 🟢 Response / CDN Caching

Set via `[ResponseCache]` attributes and `Cache-Control` headers. Ideal for static content or GET endpoints.

---

## 🔧 NuGet Packages

```xml
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.17" />
<PackageReference Include="Microsoft.AspNetCore.ResponseCaching" Version="8.0.17" />
<PackageReference Include="Microsoft.Extensions.Caching.Memory" Version="8.0.0" />
<PackageReference Include="Microsoft.Extensions.Caching.StackExchangeRedis" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
