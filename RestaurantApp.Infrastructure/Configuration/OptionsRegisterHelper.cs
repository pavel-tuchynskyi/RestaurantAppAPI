using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RestaurantApp.Infrastructure.Configuration
{
    public static class OptionsRegisterHelper
    {
        public static void RegisterOptions<TOptionInterface>(this IServiceCollection services, IConfiguration configuration)
        {
            var options = GetOptionsTypes<TOptionInterface>();

            foreach (var option in options)
            {
                services.RegisterOption(configuration, option);
            }
        }

        private static List<Type> GetOptionsTypes<TOptionType>()
        {
            var options = Assembly.GetAssembly(typeof(TOptionType))
                .GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.IsAssignableTo(typeof(TOptionType)))
                .ToList();

            return options;
        }

        public static void RegisterOption(this IServiceCollection services, IConfiguration configuration, Type option)
        {
            var myMethod = typeof(OptionsConfigurationServiceCollectionExtensions)
              .GetMethods(BindingFlags.Static | BindingFlags.Public)
              .Where(x => x.Name == nameof(OptionsConfigurationServiceCollectionExtensions.Configure) && x.IsGenericMethodDefinition)
              .Where(x => x.GetGenericArguments().Length == 1)
              .Where(x => x.GetParameters().Length == 2)
              .First();

            MethodInfo generic = myMethod.MakeGenericMethod(option);
            generic.Invoke(null, new object[] { services, configuration.GetSection(option.Name) });
        }
    }
}
