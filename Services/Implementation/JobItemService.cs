using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace DebayTechnics.Services.Implementation;

public class JobItemService : IJobItemService
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public JobItemService(IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextFactory = umbracoContextFactory;
    }

    public IEnumerable<IPublishedContent> GetJobItems()
    {
        using var umbracoContextRef = _umbracoContextFactory.EnsureUmbracoContext();
        var contextQuery = umbracoContextRef.UmbracoContext.Content;
        var siteroot = contextQuery.GetAtRoot().FirstOrDefault();
        var items = siteroot.FirstChild(f => f.ContentType.Alias == "jobs").Children();
        return items;
    }
}