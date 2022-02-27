using Microsoft.AspNetCore.Mvc;
using RazorViewEmailTemplates.Sample.Models.Emails;
using RestoreMonarchy.RazorViewEmailTemplates;
using RestoreMonarchy.RazorViewEmailTemplates.Models;
using RestoreMonarchy.RazorViewEmailTemplates.Services;

namespace RazorViewEmailTemplates.Sample.Controllers
{
    [Route("api/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailHtmlGenerator emailHtmlGenerator;

        public EmailsController(IEmailHtmlGenerator emailHtmlGenerator)
        {
            this.emailHtmlGenerator = emailHtmlGenerator;
        }

        [HttpGet("default")]
        public async Task<IActionResult> GetDefaultEmailAsync([FromQuery] string message = "Hello World!")
        {
            EmailTemplateBuilder etb = new EmailTemplateBuilder();
            
            etb.SetViewName("/Views/Emails/DefaultEmail.cshtml");
            
            IEmailTemplate template = etb.Build();
            
            DefaultEmailModel model = new DefaultEmailModel()
            {
                Message = message
            };

            string html = await emailHtmlGenerator.GenerateEmailAsync(template, model);
            return Content(html);
        }

        [HttpGet("localization")]
        public async Task<IActionResult> GetLocalizationEmailAsync([FromQuery] string name = "Giovanni Giorgio", 
            [FromQuery] string culture = "en-US")
        {
            EmailTemplateBuilder etb = new EmailTemplateBuilder();

            etb.SetCulture(culture);
            etb.SetViewName("/Views/Emails/LocalizationEmail.cshtml");

            IEmailTemplate template = etb.Build();
            
            LocalizationEmailModel model = new LocalizationEmailModel()
            {
                Name = name
            };

            string html = await emailHtmlGenerator.GenerateEmailAsync(template, model);
            return Content(html);
        }
    }
}
