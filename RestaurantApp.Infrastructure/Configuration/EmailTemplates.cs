namespace RestaurantApp.Infrastructure.Configuration
{
    public class EmailTemplates
    {
        public string FolderPath { get; set; }
        public Dictionary<string,string> Templates { get; set; }
    }
}
