using RestoreMonarchy.RazorViewEmailTemplates.Models;

namespace RestoreMonarchy.RazorViewEmailTemplates.Services
{
    public interface IEmailHtmlGenerator
    {
        Task<string> GenerateEmailAsync(IEmailTemplate template, object model = null);
    }
}
