using DebayTechnics.Services;
using DebayTechnics.Services.Implementation;
using Umbraco.Cms.Core.Composing;

namespace DebayTechnics.Composer;

public class RegisterServicesComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        //services
        builder.Services.AddScoped<IPortfolioService, PortfolioService>();
        builder.Services.AddScoped<IBlogService, BlogService>();
        builder.Services.AddScoped<IMailService,MailService>();
        builder.Services.AddScoped<IServiceItemService,ServiceItemService>();
        builder.Services.AddScoped<ITemplateService, TemplateService>();
        builder.Services.AddScoped<IJobItemService, JobItemService>();
    }
}