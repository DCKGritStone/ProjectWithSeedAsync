using MediatR;
using ProjectWithSeedAsync.Domain;
using ProjectWithSeedAsync.Domain.Entity;

namespace ProjectWithSeedAsync.Application.Command._City.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, int>
    {
        private readonly IRepository Repository;

        public UpdateCityCommandHandler(IRepository cityRepository)
        {
            this.Repository = cityRepository;
        }
        public async Task<int> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var updateCity = new City
            {
                Id = request.Id,
                Name = request.Name,
                Code = request.Code,
                StateId = request.StateId
            };
            return await Repository.UpdateCityAsync(request.Id, updateCity);

        }
    }
}
