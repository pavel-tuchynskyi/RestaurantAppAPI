using System.Text;

namespace RestaurantApp.Application.Common.Builders
{
    public class UriPathBuilder
    {
        private UriBuilder _uriBuilder;

        public UriPathBuilder()
        {
            _uriBuilder = new UriBuilder();
            _uriBuilder.Scheme = "https";
            _uriBuilder.Host = "localhost";
            _uriBuilder.Port = 7296;
        }

        public UriPathBuilder SetPath(string controller, string action) 
        {
            _uriBuilder.Path = Path.Combine("api", controller, action);
            return this;
        }

        public UriPathBuilder SetQuery(Dictionary<string, string> parameters)
        {
            var count = parameters.Count() - 1;
            var sb = new StringBuilder();

            foreach(var parameter in parameters)
            {
                sb.Append(string.Format("{0}={1}", parameter.Key, parameter.Value));

                if(count > 0)
                {
                    sb.Append("&");
                }

                count--;
            }

            _uriBuilder.Query = sb.ToString();
            return this;
        }

        public string Build()
        {
            return _uriBuilder.Uri.ToString();
        }
    }
}
