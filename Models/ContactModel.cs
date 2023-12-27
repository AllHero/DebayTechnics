using System.ComponentModel.DataAnnotations;

namespace DebayTechnics.Models;

public class ContactModel
{
    [Required(ErrorMessage = "Gelieve uw naam in te vullen")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Gelieve uw email in te vullen")]
    [EmailAddress(ErrorMessage = "Gelieve een geldig email in te vullen")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Gelieve een bericht in te vullen")]
    [MaxLength(500, ErrorMessage = "Uw bericht mag niet langer zijn dan 500 karakters")]
    public string Message { get; set; }
    public int ContactFormId { get; set; }
}