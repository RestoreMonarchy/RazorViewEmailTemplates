using Microsoft.Extensions.DependencyInjection;
using RestoreMonarchy.RazorViewEmailTemplates.Services;

namespace RestoreMonarchy.RazorViewEmailTemplates.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailHtmlGenerator(this IServiceCollection services)
        {
            services.AddTransient<IRazorViewToStringRenderer, RazorViewToStringRenderer>();
            services.AddTransient<IEmailHtmlGenerator, EmailHtmlGenerator>();
            return services;
        }
    }
}
