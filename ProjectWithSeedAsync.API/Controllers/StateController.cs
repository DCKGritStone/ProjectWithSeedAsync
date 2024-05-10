using Microsoft.AspNetCore.Mvc;
using ProjectWithSeedAsync.Application.Command._State.CreateState;
using ProjectWithSeedAsync.Application.Command._State.DeleteState;
using ProjectWithSeedAsync.Application.Command._State.UpdateState;
using ProjectWithSeedAsync.Domain.Queries._State;

namespace ProjectWithSeedAsync.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ApiController
    {
        private readonly IGetStateQuery getStateQuery;

        public StateController(IGetStateQuery getStateQuery)
        {
            this.getStateQuery = getStateQuery;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var state = getStateQuery.GetAllStateAsync();

            return Ok(state);
        }

        [HttpGet("Id")]

        public IActionResult GetById(int id)
        {
            var state = getStateQuery.GetStateByIdAsync(id);

            if (state == null)
            {
                return BadRequest();
            }

            return Ok(state);
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateStateCommand command)
        {
            var createState = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = createState.Id }, createState);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, UpdateStateCommand command)
        {
            if (id == command.Id) { return BadRequest(); }

            await Mediator.Send(command);

            return NoContent();
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteStateCommand { Id = id });

            return NoContent();
        }
    }
}
