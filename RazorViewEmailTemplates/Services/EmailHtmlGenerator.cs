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

            Dictionary<string, object> viewData = new();
                        
            if (!string.IsNullOrEmpty(template.BaseUrl))
            {
                viewData.Add("BaseUrl", template.BaseUrl);
            }

            if (template.ViewData != null)
            {
                foreach (KeyValuePair<string, object> data in template.ViewData)
                {
                    viewData.Add(data.Key, data.Value);
                }
            }
            
            string html = await renderer.RenderViewToStringAsync(template.ViewName, model, viewData);
            
            if (template.Culture != null)
            {
                CultureInfo.CurrentCulture = prevCulture;
                CultureInfo.CurrentUICulture = prevUICulture;
            }   

            return html;
        }
    }
}
