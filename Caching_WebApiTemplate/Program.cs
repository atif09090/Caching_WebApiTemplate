using Caching_WebApiTemplate.Configuration;
using Caching_WebApiTemplate.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddScoped<CacheService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddCustomCors();
builder.Services.AddCacheProfiles();
builder.Services.AddResponseCaching();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseResponseCaching();
app.MapControllers();

app.Run();
