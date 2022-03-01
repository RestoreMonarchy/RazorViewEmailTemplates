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
            EmailTemplateBuilder etb = new();
            
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
            EmailTemplateBuilder etb = new();

            etb.SetCulture(culture);
            etb.SetViewName("/Views/Emails/LocalizationEmail.cshtml");

            IEmailTemplate template = etb.Build();
            
            LocalizationEmailModel model = new()
            {
                Name = name
            };

            string html = await emailHtmlGenerator.GenerateEmailAsync(template, model);
            return Content(html);
        }

        [HttpGet("baseurl")]
        public async Task<IActionResult> GetBaseUrlEmailAsync()
        {
            EmailTemplateBuilder etb = new();

            etb.SetViewName("/Views/Emails/BaseUrlEmail.cshtml");
            etb.WithBaseUrl("http://localhost:44341");
            
            IEmailTemplate template = etb.Build();

            string html = await emailHtmlGenerator.GenerateEmailAsync(template);
            return Content(html);
        }

        [HttpGet("viewdata")]
        public async Task<IActionResult> GetViewDataEmailAsync()
        {
            EmailTemplateBuilder etb = new();

            etb.SetViewName("/Views/Emails/ViewDataEmail.cshtml");
            etb.AddViewData("Brand", "RestoreMonarchy");

            IEmailTemplate template = etb.Build();

            string html = await emailHtmlGenerator.GenerateEmailAsync(template);
            return Content(html);
        }
    }
}
