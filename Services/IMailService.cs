using DebayTechnics.Models;

namespace DebayTechnics.Services;

public interface IMailService
{
    Task<bool> SendEmail(ContactModel model);
}