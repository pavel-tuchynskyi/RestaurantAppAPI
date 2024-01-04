using MediatR;

namespace RestaurantApp.Application.Ingridients.Queries.GetIngridient
{
    public class GetIngridientQueryHandler : IRequestHandler<GetIngridientQuery>
    {
        public Task Handle(GetIngridientQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
