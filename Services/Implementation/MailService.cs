using DebayTechnics.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;
using IHostingEnvironment = Umbraco.Cms.Core.Hosting.IHostingEnvironment;

namespace DebayTechnics.Services.Implementation;

public class MailService : IMailService
{
    private readonly IUmbracoContextFactory _umbracoContextFactory;
    private Settings _settings;
    private ITemplateService _templateService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public MailService(IUmbracoContextFactory umbracoContextFactory, ITemplateService templateService,
        IWebHostEnvironment webHostEnvironment)
    {
        _umbracoContextFactory = umbracoContextFactory;
        _settings = GetSettings();
        _templateService = templateService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<bool> SendEmail(ContactModel model)
    {
        MimeMessage message = new MimeMessage();
        message.Subject = "Aanvraag Website: " + model.Name;
        // Body
        message.Body = new TextPart("plain")
        {
            Text = $@"Bericht: {model.Message}
Contactgegevens:
Aanvraag door:  {model.Name} 
Email: {model.Email}
"
        };
        message.To.Add(new MailboxAddress(_settings.FromAddress, _settings.FromAddress));
        message.From.Add(new MailboxAddress(_settings.FromAddress, _settings.FromAddress));
        return await Send(message);
    }

    
    private async Task<bool> Send(MimeMessage message)
    {
        try
        {
            using var smtpClient = new SmtpClient();
            smtpClient.CheckCertificateRevocation = false;
            smtpClient.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            await smtpClient.ConnectAsync(_settings.Host, int.Parse(_settings.Port), SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(_settings.AccountName, _settings.Password);

            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private Settings GetSettings()
    {
        using var umbracoContextRef = _umbracoContextFactory.EnsureUmbracoContext();
        var contextQuery = umbracoContextRef.UmbracoContext.Content;
        var siteroot = contextQuery.GetAtRoot().FirstOrDefault();
        var settings = siteroot.FirstChild<Settings>();
        return settings;
    }
}
