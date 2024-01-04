using AutoMapper;
using RestaurantApp.Application.Common.DTOs.Orders;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.Orders;

namespace RestaurantApp.Application.Common.Mapping.Configuration
{
    public class OrderMapping : IMap<Order>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>()
                .ForMember(p => p.City, pp => pp.MapFrom(x => x.Address.City))
                .ForMember(p => p.Address, pp => pp.MapFrom(x => x.Address.Address))
                .ForMember(p => p.Price, pp => pp.MapFrom(x => x.Price.Value));

            profile.CreateMap<MenuItem, OrderItemDto>()
                .ForMember(p => p.Name, pp => pp.MapFrom(x => x.Name.Value))
                .ForMember(p => p.Price, pp => pp.MapFrom(x => x.Price.Value));
        }
    }
}
