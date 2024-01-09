namespace RestaurantApp.Application.Common.Interfaces
{
    public interface ITemplateService
    {
        Task<string> GetTemplate(string name);
        string ReplaceValues(string template, params string[] values);
    }
}
