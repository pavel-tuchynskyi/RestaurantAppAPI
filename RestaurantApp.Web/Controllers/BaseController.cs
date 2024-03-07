using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.Web.Controllers
{
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        private IMediator _mediator;
        protected ILogger<T> _logger => HttpContext.RequestServices.GetService<ILogger<T>>();

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
