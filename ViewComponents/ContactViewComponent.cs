using DebayTechnics.Models;
using Microsoft.AspNetCore.Mvc;

namespace DebayTechnics.ViewComponents;

[ViewComponent(Name= "Contact")]
public class ContactViewComponent : ViewComponent
{

    public IViewComponentResult Invoke(ContactModel model)
    {
        return View(model);
    }
    
}