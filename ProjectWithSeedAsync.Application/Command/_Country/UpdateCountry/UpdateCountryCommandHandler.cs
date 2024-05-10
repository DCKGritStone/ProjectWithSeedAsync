using MediatR;
using ProjectWithSeedAsync.Domain;
using ProjectWithSeedAsync.Domain.Entity;

namespace ProjectWithSeedAsync.Application.Command._Country.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, int>
    {
        private readonly IRepository Repository;

        public UpdateCountryCommandHandler(IRepository countryRepository)
        {
            this.Repository = countryRepository;
        }
        public async Task<int> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var updateCountry = new Country
            {
                Id = request.Id,
                Name = request.Name,
                Code = request.Code
            };

            return await Repository.UpdateCountryAsync(request.Id, updateCountry);
        }
    }
}
