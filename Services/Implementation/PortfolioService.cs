using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace DebayTechnics.Services.Implementation;

public class PortfolioService : IPortfolioService
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;

    public PortfolioService(IUmbracoContextFactory umbracoContextFactory)
    {
        _umbracoContextFactory = umbracoContextFactory;
    }

    public IEnumerable<IPublishedContent> GetPortfolioItems()
    {
        using var umbracoContextRef = _umbracoContextFactory.EnsureUmbracoContext();
        var contextQuery = umbracoContextRef.UmbracoContext.Content;
        var siteroot = contextQuery.GetAtRoot().FirstOrDefault();
        var items = siteroot.FirstChild(f => f.ContentType.Alias == "portfolio").Children();
        return items.OrderByDescending(x => x.UpdateDate);
    }
}