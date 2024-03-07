using System.Text;

namespace RestaurantApp.Application.Common.Builders
{
    public class UriPathBuilder
    {
        private UriBuilder _uriBuilder;

        public UriPathBuilder(string scheme, string host, int port)
        {
            _uriBuilder = new UriBuilder();
            _uriBuilder.Scheme = scheme;
            _uriBuilder.Host = host;
            _uriBuilder.Port = port;
        }

        public UriPathBuilder(string url)
        {
            _uriBuilder = new UriBuilder(url);
        }

        public UriPathBuilder SetPath(params string[] args)
        {
            for(int i = 0; i < args.Length; i++)
            {
                _uriBuilder.Path = Path.Combine(_uriBuilder.Path, args[i]);
            }

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
