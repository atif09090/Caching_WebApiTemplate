using Microsoft.AspNetCore.Mvc;

namespace Caching_WebApiTemplate.Configuration
{
    public static class CacheProfiles
    {
        public static void AddCacheProfiles(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                options.CacheProfiles.Add("Default60", new CacheProfile
                {
                    Duration = 60,
                    Location = ResponseCacheLocation.Any,
                    NoStore = false
                });

                options.CacheProfiles.Add("NoCache", new CacheProfile
                {
                    Location = ResponseCacheLocation.None,
                    NoStore = true
                });

                options.CacheProfiles.Add("Client10Sec", new CacheProfile
                {
                    Duration = 10,
                    Location = ResponseCacheLocation.Client
                });

                options.CacheProfiles.Add("CDN_Static1Day", new CacheProfile
                {
                    Duration = 86400, // 1 day
                    Location = ResponseCacheLocation.Any,
                    NoStore = false
                });
            });
        }
    }
}
