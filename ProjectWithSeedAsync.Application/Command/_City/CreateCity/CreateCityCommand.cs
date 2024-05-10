using MediatR;
using ProjectWithSeedAsync.Application.Dto;

namespace ProjectWithSeedAsync.Application.Command._City.CreateCity
{
    public class CreateCityCommand : IRequest<CityDto>
    {
        public string? Name { get; set; }
        public double? Code { get; set; }

        public int StateId { get; set; }
    }
}
