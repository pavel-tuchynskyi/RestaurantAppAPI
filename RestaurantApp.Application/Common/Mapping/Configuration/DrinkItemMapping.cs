using AutoMapper;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.Common.Mapping.Configuration
{
    public class DrinkItemMapping : IMap<DrinkMenuItem>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DrinkMenuItem, DrinkItemDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value))
                .ForMember(p => p.Price, pp => pp.MapFrom(x => x.Price.Value))
                .ForMember(p => p.Description, pp => pp.MapFrom(x => x.Description.Value));
        }
    }
}
