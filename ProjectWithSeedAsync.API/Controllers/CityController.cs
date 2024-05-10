using Microsoft.AspNetCore.Mvc;
using ProjectWithSeedAsync.Application.Command._City.CreateCity;
using ProjectWithSeedAsync.Application.Command._City.DeleteCity;
using ProjectWithSeedAsync.Application.Command._City.UpdateCity;
using ProjectWithSeedAsync.Domain.Queries._City;

namespace ProjectWithSeedAsync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ApiController
    {
        private readonly IGetCityQuery getCityQuery;

        public CityController(IGetCityQuery getCityQuery)
        {
            this.getCityQuery = getCityQuery;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var city = getCityQuery.GetAllCityAsync();

            return Ok(city);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var city = getCityQuery.GetCityByIdAsync(id);

            if (city == null)
            {
                return BadRequest();
            }

            return Ok(city);
        }

        [HttpGet("GetAllCitiesByStateId")]

        public IActionResult GetCitiesByStateId(int id)
        {
            var cities = getCityQuery.GetALLCitiesByStateIdAsync(id);
            if (cities == null)
            {
                return BadRequest();
            }
            return Ok(cities);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateCityCommand command)
        {
            var createCity = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = createCity.Id }, createCity);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, UpdateCityCommand command)
        {
            if (id == command.Id) { return BadRequest(); }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteCityCommand { Id = id });
            return NoContent();
        }
    }
}
