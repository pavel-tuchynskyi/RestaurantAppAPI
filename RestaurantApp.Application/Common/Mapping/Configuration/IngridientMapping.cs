using AutoMapper;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Domain.MenuItems.Entities;

namespace RestaurantApp.Application.Common.Mapping.Configuration
{
    public class IngridientMapping : IMap<Ingridient>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ItalianFoodIngridient, IngridientDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value));

            profile.CreateMap<JapaneesFoodIngridient, IngridientDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value));
        }
    }
}
