using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoreMonarchy.RazorViewEmailTemplates.Models
{
    public interface IEmailTemplate
    {
        string ViewName { get; }
        CultureInfo Culture { get; }
    }
}
