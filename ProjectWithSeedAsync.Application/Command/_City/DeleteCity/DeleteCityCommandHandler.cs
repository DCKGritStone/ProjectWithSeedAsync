using MediatR;
using ProjectWithSeedAsync.Domain;

namespace ProjectWithSeedAsync.Application.Command._City.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, int>
    {
        private readonly IRepository Repository;

        public DeleteCityCommandHandler(IRepository cityRepository)
        {
            this.Repository = cityRepository;
        }
        public async Task<int> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            return await Repository.DeleteCityAsync(request.Id);
        }
    }
}
