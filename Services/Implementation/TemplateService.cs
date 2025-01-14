using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DebayTechnics.Services.Implementation;

public class TemplateService:ITemplateService
{
    private readonly IRazorViewEngine _razorViewEngine;
    private readonly IServiceProvider _serviceProvider;
    private readonly ITempDataProvider _tempDataProvider;

    public TemplateService(
        IRazorViewEngine engine,
        IServiceProvider serviceProvider,
        ITempDataProvider tempDataProvider)
    {
        _razorViewEngine = engine;
        _serviceProvider = serviceProvider;
        _tempDataProvider = tempDataProvider;
    }

    public async Task<string> GetTemplateHtmlAsStringAsync<T>(
        string viewName, T model) where T : class
    {
        var httpContext = new DefaultHttpContext() { RequestServices = _serviceProvider };
        var actionContext = new ActionContext(httpContext, new RouteData(), new ActionDescriptor());

        var viewResult = _razorViewEngine.FindView(actionContext, "MailTemplates/" + viewName, false);

        if (viewResult.View == null)
        {
            return string.Empty;
        }

        var metadataProvider = new EmptyModelMetadataProvider();
        var msDictionary = new ModelStateDictionary();
        var viewDataDictionary = new ViewDataDictionary(metadataProvider, msDictionary)
        {
            Model = model
        };

        var tempDictionary = new TempDataDictionary(actionContext.HttpContext, _tempDataProvider);

        using var sw = new StringWriter();
        var viewContext = new ViewContext(
            actionContext,
            viewResult.View,
            viewDataDictionary,
            tempDictionary,
            sw,
            new HtmlHelperOptions()
        );

        await viewResult.View.RenderAsync(viewContext);
        return sw.ToString();
    }
}