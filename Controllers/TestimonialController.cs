using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Cms.Web.Common.Controllers;

namespace DebayTechnics.Controllers;

[Route("umbraco/api/[controller]")]
[ApiController]
public class TestimonialController: UmbracoApiController
{
    private readonly IScopeProvider _scopeProvider;

    public TestimonialController(IScopeProvider scopeProvider)
    {
        _scopeProvider = scopeProvider;
    }

    [HttpGet]
    public IEnumerable<dynamic> GetTestimonials()
    {
        using var scope = _scopeProvider.CreateScope();
        var results = scope.Database.Fetch<dynamic>("SELECT * FROM Testimonials");
        scope.Complete();
        return results;
    }

    [HttpPost]
    public void Post(object testimonial)
    {
        using var scope = _scopeProvider.CreateScope();
        scope.Database.Insert<dynamic>(testimonial);
        scope.Complete();
    }
    
}