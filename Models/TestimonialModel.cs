using System.ComponentModel.DataAnnotations;

namespace DebayTechnics.Models;

public class TestimonialModel
{
    [Required(ErrorMessage = "Gelieve uw naam in te vullen")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Gelieve een bericht in te vullen")]
    [MaxLength(500, ErrorMessage = "Uw bericht mag niet langer zijn dan 500 karakters")]
    public string Message { get; set; }
    public string? Agree { get; set; }
    public int TestimonialFormId { get; set; }
}