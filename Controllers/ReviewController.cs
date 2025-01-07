using DebayTechnics.Composer;
using DebayTechnics.Models;
using Microsoft.AspNetCore.Mvc;
using Polly;
using StackExchange.Profiling.Internal;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace DebayTechnics.Controllers;

public class ReviewController: SurfaceController
{
    private readonly IScopeProvider _scopeProvider;

    public ReviewController(IScopeProvider scopeProvider, IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger,
    IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches,
        profilingLogger, publishedUrlProvider)
    {
        _scopeProvider = scopeProvider;
    }
    
    public async Task<IActionResult> SubmitForm(TestimonialModel model)
    {
        bool success = false;
        if (ModelState.IsValid && !model.Agree.HasValue())
        {
            using var scope = _scopeProvider.CreateScope();
                    scope.Database.Insert(new AddCommentsTable.TestimonialsSchema()
                    {
                        Message = model.Message,
                        Name = model.Name
                    });
                    scope.Complete();
                    success = true;
        }
        return RedirectToCurrentUmbracoPage(new QueryString("?success="+ success));
    }
}