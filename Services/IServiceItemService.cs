using Umbraco.Cms.Core.Models.PublishedContent;

namespace DebayTechnics.Services;

public interface IServiceItemService
{
    IEnumerable<IPublishedContent> GetServiceItems();
}