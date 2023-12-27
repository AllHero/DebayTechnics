using Umbraco.Cms.Core.Models.PublishedContent;

namespace DebayTechnics.Services;

public interface IBlogService
{
    IEnumerable<IPublishedContent> GetBlogItems();
}