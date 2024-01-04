using AutoMapper;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.Common.Mapping.Configuration
{
    public class ItalianFoodItemMapping : IMap<ItalianFood>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pizza, FoodItemDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value))
                .ForMember(p => p.Price, pp => pp.MapFrom(x => x.Price.Value));
        }
    }
}
