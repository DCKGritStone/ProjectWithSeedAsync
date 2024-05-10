using AutoMapper;
using MediatR;
using ProjectWithSeedAsync.Application.Dto;
using ProjectWithSeedAsync.Domain;
using ProjectWithSeedAsync.Domain.Entity;

namespace ProjectWithSeedAsync.Application.Command._Country.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CountryDto>
    {
        private readonly IRepository Repository;
        private readonly IMapper mapper;

        public CreateCountryCommandHandler(IRepository countryRepository, IMapper mapper)
        {
            this.Repository = countryRepository;
            this.mapper = mapper;
        }
        public async Task<CountryDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var createCountry = new Country
            {
                Name = request.Name,
                Code = request.Code
            };

            var result = await Repository.CreateCountryAsync(createCountry);

            return mapper.Map<CountryDto>(result);
        }
    }
}
