using DebayTechnics.Models;
using DebayTechnics.Services;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace DebayTechnics.Controllers;

public class ContactController : SurfaceController
{
    private readonly IMailService _mailService;
    
    public ContactController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory,
        ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger,
        IPublishedUrlProvider publishedUrlProvider, IMailService mailService) : base(umbracoContextAccessor, databaseFactory, services, appCaches,
        profilingLogger, publishedUrlProvider)
    {
        _mailService = mailService;
    }

    public async Task<IActionResult> SubmitForm(ContactModel model)
    {
        bool success = false;
        if (ModelState.IsValid)
        {
            success = await _mailService.SendEmail(model);
        }
        return RedirectToCurrentUmbracoPage(new QueryString("?success="+ success));
    }
}