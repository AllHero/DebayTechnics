namespace DebayTechnics.Services;

public interface ITemplateService
{
    Task<string> GetTemplateHtmlAsStringAsync<T>(string viewName, T model) where T : class;
}