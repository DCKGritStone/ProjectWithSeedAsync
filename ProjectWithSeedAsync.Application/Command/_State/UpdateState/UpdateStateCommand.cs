using MediatR;

namespace ProjectWithSeedAsync.Application.Command._State.UpdateState
{
    public class UpdateStateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Code { get; set; }

        public int CountryId { get; set; }
    }
}
