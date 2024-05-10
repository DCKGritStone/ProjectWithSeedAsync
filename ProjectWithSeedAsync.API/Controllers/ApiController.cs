using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWithSeedAsync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private ISender? mediator;

        protected ISender? Mediator => mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
