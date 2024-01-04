using AutoMapper;

namespace RestaurantApp.Application.Common.Mapping
{
    public interface IMap<T> where T : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
