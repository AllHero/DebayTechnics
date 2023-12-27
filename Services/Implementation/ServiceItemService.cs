using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace DebayTechnics.Services.Implementation;

public class ServiceItemService : IServiceItemService
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public ServiceItemService(IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextFactory = umbracoContextFactory;
    }

    public IEnumerable<IPublishedContent> GetServiceItems()
    {
        using var umbracoContextRef = _umbracoContextFactory.EnsureUmbracoContext();
        var contextQuery = umbracoContextRef.UmbracoContext.Content;
        var siteroot = contextQuery.GetAtRoot().FirstOrDefault();
        var items = siteroot.FirstChild(f => f.ContentType.Alias == "services").Children();
        return items;
    }
}