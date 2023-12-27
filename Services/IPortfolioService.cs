using Umbraco.Cms.Core.Models.PublishedContent;

namespace DebayTechnics.Services;

public interface IPortfolioService
{
    IEnumerable<IPublishedContent> GetPortfolioItems();
}