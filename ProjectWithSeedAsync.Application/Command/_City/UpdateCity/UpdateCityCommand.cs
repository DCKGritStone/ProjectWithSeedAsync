using MediatR;

namespace ProjectWithSeedAsync.Application.Command._City.UpdateCity
{
    public class UpdateCityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Code { get; set; }

        public int StateId { get; set; }
    }
}
