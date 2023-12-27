using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace DebayTechnics.Services.Implementation;

public class BlogService : IBlogService
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public BlogService(IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextFactory = umbracoContextFactory;
    }

    public IEnumerable<IPublishedContent> GetBlogItems()
    {
        using var umbracoContextRef = _umbracoContextFactory.EnsureUmbracoContext();
        var contextQuery = umbracoContextRef.UmbracoContext.Content;
        var siteroot = contextQuery.GetAtRoot().FirstOrDefault();
        var items = siteroot.FirstChild(f => f.ContentType.Alias == "blog").Children();
        return items.OrderByDescending(x => x.UpdateDate);
    }
}