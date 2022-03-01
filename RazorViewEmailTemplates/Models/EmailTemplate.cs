using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoreMonarchy.RazorViewEmailTemplates.Models
{
    public class EmailTemplate : IEmailTemplate
    {
        public string ViewName { get; internal set; }
        public CultureInfo Culture { get; internal set; }
        public string BaseUrl { get; internal set; }
        public Dictionary<string, object> ViewData { get; set; }
    }
}
