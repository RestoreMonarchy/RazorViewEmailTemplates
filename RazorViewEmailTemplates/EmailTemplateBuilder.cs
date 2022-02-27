using RestoreMonarchy.RazorViewEmailTemplates.Models;
using System.Globalization;

namespace RestoreMonarchy.RazorViewEmailTemplates
{
    public class EmailTemplateBuilder
    {
        private readonly EmailTemplate emailTemplate;

        public EmailTemplateBuilder()
        {
            emailTemplate = new EmailTemplate();
        }

        public EmailTemplateBuilder SetViewName(string viewName)
        {
            emailTemplate.ViewName = viewName;
            return this;
        }

        public EmailTemplateBuilder SetCulture(string cultureName)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(cultureName);
            emailTemplate.Culture = cultureInfo;
            return this;
        }

        public IEmailTemplate Build()
        {
            if (string.IsNullOrEmpty(emailTemplate.ViewName))
                throw new ArgumentNullException("ViewName");

            return emailTemplate;
        }
    }
}