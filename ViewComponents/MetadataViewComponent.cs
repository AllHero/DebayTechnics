using System.Dynamic;
using DebayTechnics.Models;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace AllHero.ViewComponents;

[ViewComponent(Name = "Metadata")]
public class MetadataViewComponent:ViewComponent
{
    public IViewComponentResult Invoke(IPublishedContent model)
    {
        var metadataModel = new MetadataModel()
        {
            Title = !string.IsNullOrEmpty(model.Value<string>("title")) ? model.Value<string>("title") : "Debay Technics",
            Description = !string.IsNullOrEmpty(model.Value<string>("metaDescription")) ? model.Value<string>("metaDescription") : "Debay Technics",
            Keywords = model.Value<string[]>("metaKeywords").Any() ? string.Join(",",model.Value<string[]>("metaKeywords")) : "Debay Technics",
            Url = model.Url(mode: UrlMode.Absolute),
            ImageUrl = model.Value("socialShareImage") != null ? model.Value<MediaWithCrops>("socialShareImage").GetCropUrl(urlMode: UrlMode.Absolute) : ""
        };
        return View(metadataModel);
    }
}