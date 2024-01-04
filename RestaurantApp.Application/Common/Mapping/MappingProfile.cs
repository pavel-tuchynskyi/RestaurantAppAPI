using AutoMapper;
using System.Reflection;

namespace RestaurantApp.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AddMappings(AppDomain.CurrentDomain.GetAssemblies().Where(x => !x.IsDynamic).ToArray());
        }

        private void AddMappings(Assembly[] assemblies)
        {
            var types = new List<Type>();

            foreach (Assembly assembly in assemblies)
            {
                types.AddRange(assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMap<>)))
                .ToList());
            }

            CreateMapperConfiguration(types, "Mapping");
        }

        private void CreateMapperConfiguration(List<Type> types, string method)
        {
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(method);
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
