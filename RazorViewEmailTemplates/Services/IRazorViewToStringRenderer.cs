namespace RestoreMonarchy.RazorViewEmailTemplates.Services
{
    public interface IRazorViewToStringRenderer
    {
        Task<string> RenderViewToStringAsync(string viewName, object model, Dictionary<string, object> viewData);
    }
}
