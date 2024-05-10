using MediatR;
using ProjectWithSeedAsync.Domain;

namespace ProjectWithSeedAsync.Application.Command._Country.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, int>
    {
        private readonly IRepository Repository;

        public DeleteCountryCommandHandler(IRepository countryRepository)
        {
            this.Repository = countryRepository;
        }
        public async Task<int> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            return await Repository.DeleteCountryAsync(request.Id);
        }
    }
}
