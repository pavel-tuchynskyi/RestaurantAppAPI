using System.Reflection;

namespace RestaurantApp.Application.Common.Helpers
{
    public static class StrategyHelper
    {
        public static Dictionary<TKey, TValue> GetStrategies<TKey, TValue>(Type assambly, params object[] parameters)
        {
            var senderTypes = Assembly.GetAssembly(assambly)
               .GetTypes()
               .Where(x => x.IsClass && !x.IsAbstract && x.IsAssignableTo(typeof(TValue)));

            var sendersDic = new Dictionary<TKey, TValue>();

            foreach (var senderType in senderTypes)
            {
                var instance = Activator.CreateInstance(senderType, parameters);
                var prop = senderType.GetProperties().FirstOrDefault(x => x.PropertyType == typeof(TKey));
                var senderKey = (TKey)prop.GetValue(instance);
                sendersDic.Add(senderKey, (TValue)instance);
            }

            return sendersDic;
        }
    }
}
