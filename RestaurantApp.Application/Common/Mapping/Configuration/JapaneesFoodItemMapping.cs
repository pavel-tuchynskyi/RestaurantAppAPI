using AutoMapper;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.Common.Mapping.Configuration
{
    public class JapaneesFoodItemMapping : IMap<JapaneesFood>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Susi, FoodItemDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value))
                .ForMember(p => p.Price, pp => pp.MapFrom(x => x.Price.Value));

            profile.CreateMap<Rolls, FoodItemDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value))
                .ForMember(p => p.Price, pp => pp.MapFrom(x => x.Price.Value));

            profile.CreateMap<Set, FoodItemDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value))
                .ForMember(p => p.Price, pp => pp.MapFrom(x => x.Price.Value));

            profile.CreateMap<JapaneesFood, FoodItemDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value))
                .ForMember(p => p.Price, pp => pp.MapFrom(x => x.Price.Value));

            profile.CreateMap<JapaneesFood, IngridientDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value));
        }
    }
}
