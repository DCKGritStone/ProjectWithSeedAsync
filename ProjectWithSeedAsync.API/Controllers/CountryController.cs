using Microsoft.AspNetCore.Mvc;
using ProjectWithSeedAsync.Application.Command._Country.CreateCountry;
using ProjectWithSeedAsync.Application.Command._Country.DeleteCountry;
using ProjectWithSeedAsync.Application.Command._Country.UpdateCountry;
using ProjectWithSeedAsync.Domain.Queries._Country;

namespace ProjectWithSeedAsync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ApiController
    {
        private readonly IGetCountryOuery getCountryOuery;

        public CountryController(IGetCountryOuery getCountryOuery)
        {
            this.getCountryOuery = getCountryOuery;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var country = getCountryOuery.GetAllCountryAsync();

            return Ok(country);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var country = getCountryOuery.GetCountryByIdAsync(id);

            if (country == null)
            {
                return BadRequest();
            }

            return Ok(country);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateCountryCommand command)
        {
            var createCountry = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = createCountry.Id }, createCountry);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, UpdateCountryCommand command)
        {
            if (id == command.Id) { return BadRequest(); }

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteCountryCommand { Id = id });

            return NoContent();
        }
    }
}
