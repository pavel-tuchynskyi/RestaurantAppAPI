using RestaurantApp.Application.Common.Enums;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Common.Builders.IngridientBuilder
{
    public class IngridientBuilder
    {
        protected ItemName Name { get; set; }
        protected Image Image { get; set; }

        private readonly Dictionary<Type, IIngridientBuilder> _builders;
        public IngridientBuilder()
        {
            _builders = StrategyHelper.GetStrategies<Type, IIngridientBuilder>(typeof(IngridientBuilder));
        }

        public Ingridient Create<T>()
            where T : Ingridient
        {
            var builder = _builders[typeof(T)];
            var item = builder.Create(Name, Image);

            return item;
        }

        public IngridientBuilder SetName(string name)
        {
            Name = ItemName.Create(name);
            return this;
        }

        public IngridientBuilder SetImage(byte[] imageBlob, string format)
        {
            Image = Image.Create(imageBlob, format);
            return this;
        }
    }
}
