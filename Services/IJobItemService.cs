using Umbraco.Cms.Core.Models.PublishedContent;

namespace DebayTechnics.Services;

public interface IJobItemService
{
    IEnumerable<IPublishedContent> GetJobItems();
}