namespace Caching_WebApiTemplate.Configuration
{
    public static class CorsOptions
    {
        private const string CorsPolicyName = "AllowAll";

        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicyName, policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }

        public static void UseCustomCors(this WebApplication app)
        {
            app.UseCors(CorsPolicyName);
        }
    }
}