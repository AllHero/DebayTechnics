using DebayTechnics.Models;
using Microsoft.AspNetCore.Mvc;

namespace DebayTechnics.ViewComponents;

[ViewComponent(Name = "Review")]
public class ReviewViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(TestimonialModel model)
    {
        return View(model);
    }
}