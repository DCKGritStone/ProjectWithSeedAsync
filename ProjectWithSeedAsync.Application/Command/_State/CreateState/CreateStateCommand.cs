using MediatR;
using ProjectWithSeedAsync.Application.Dto;

namespace ProjectWithSeedAsync.Application.Command._State.CreateState
{
    public class CreateStateCommand : IRequest<StateDto>
    {
        public string? Name { get; set; }
        public double? Code { get; set; }

        public int CountryId { get; set; }
    }
}
