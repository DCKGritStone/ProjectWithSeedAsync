using MediatR;
using ProjectWithSeedAsync.Application.Dto;

namespace ProjectWithSeedAsync.Application.Command._Country.CreateCountry
{
    public class CreateCountryCommand : IRequest<CountryDto>
    {
        public string? Name { get; set; }
        public double? Code { get; set; }
    }
}
