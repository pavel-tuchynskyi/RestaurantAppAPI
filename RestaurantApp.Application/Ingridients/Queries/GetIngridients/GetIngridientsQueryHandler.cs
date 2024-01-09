using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems.Entities;

namespace RestaurantApp.Application.Ingridients.Queries.GetIngridients
{
    public class GetIngridientsQueryHandler<T> : IRequestHandler<GetIngridientsQuery<T>, PagedList<IngridientDto>>
    where T : Ingridient
    {
        private readonly IIngridientsRepository<T> _ingridientsRepository;

        public GetIngridientsQueryHandler(IIngridientsRepository<T> ingridientsRepository)
        {
            _ingridientsRepository = ingridientsRepository;
        }

        public async Task<PagedList<IngridientDto>> Handle(GetIngridientsQuery<T> request, CancellationToken cancellationToken)
        {
            var ingridients = await _ingridientsRepository.GetAllAsync<IngridientDto>(
                new IngridientNameSearchSpecification<T>(request.Name));

            return ingridients;
        }
    }
}
