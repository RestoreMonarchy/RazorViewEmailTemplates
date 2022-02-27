using RestoreMonarchy.RazorViewEmailTemplates.Models;
using System.Globalization;

namespace RestoreMonarchy.RazorViewEmailTemplates.Services
{
    public class EmailHtmlGenerator : IEmailHtmlGenerator
    {
        private readonly IRazorViewToStringRenderer renderer;

        public EmailHtmlGenerator(IRazorViewToStringRenderer renderer)
        {
            this.renderer = renderer;
        }

        public async Task<string> GenerateEmailAsync(IEmailTemplate template, object model = null)
        {
            CultureInfo prevCulture = CultureInfo.CurrentCulture;
            CultureInfo prevUICulture = CultureInfo.CurrentUICulture;

            if (template.Culture != null)
            {
                CultureInfo.CurrentCulture = template.Culture;
                CultureInfo.CurrentUICulture = template.Culture;
            }   
            
            string html = await renderer.RenderViewToStringAsync(template.ViewName, model);
            
            if (template.Culture != null)
            {
                CultureInfo.CurrentCulture = prevCulture;
                CultureInfo.CurrentUICulture = prevUICulture;
            }   

            return html;
        }
    }
}
