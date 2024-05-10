using AutoMapper;
using MediatR;
using ProjectWithSeedAsync.Application.Dto;
using ProjectWithSeedAsync.Domain;
using ProjectWithSeedAsync.Domain.Entity;

namespace ProjectWithSeedAsync.Application.Command._City.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CityDto>
    {
        private readonly IRepository Repository;
        private readonly IMapper mapper;

        public CreateCityCommandHandler(IRepository cityRepository, IMapper mapper)
        {
            this.Repository = cityRepository;
            this.mapper = mapper;
        }
        public async Task<CityDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var createCity = new City
            {
                Name = request.Name,
                Code = request.Code,
                StateId = request.StateId
            };

            var result = await Repository.CreateCityAsync(createCity);

            return mapper.Map<CityDto>(result);
        }
    }
}
