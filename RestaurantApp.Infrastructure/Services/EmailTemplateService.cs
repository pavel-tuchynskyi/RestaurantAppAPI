using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using RestaurantApp.Application.Common.Interfaces;
using RestaurantApp.Infrastructure.Configuration;

namespace RestaurantApp.Infrastructure.Services
{
    public class EmailTemplateService : ITemplateService
    {
        private readonly EmailTemplates _emailTemplates;
        public EmailTemplateService(IOptions<EmailTemplates> options)
        {
            _emailTemplates = options.Value;
        }

        public async Task<string> GetTemplate(string name)
        {
            var templateFileName = _emailTemplates.Templates[name];
            var templatePath = Path.Combine(_emailTemplates.FolderPath, templateFileName);
            var builder = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(templatePath))
            {
                builder.HtmlBody = await SourceReader.ReadToEndAsync();
            }

            return builder.HtmlBody;
        }

        public string ReplaceValues(string template, params string[] values)
        {
            return string.Format(template, values);
        }
    }
}
