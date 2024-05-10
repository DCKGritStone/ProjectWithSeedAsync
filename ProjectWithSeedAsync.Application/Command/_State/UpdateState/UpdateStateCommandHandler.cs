using MediatR;
using ProjectWithSeedAsync.Domain;
using ProjectWithSeedAsync.Domain.Entity;

namespace ProjectWithSeedAsync.Application.Command._State.UpdateState
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, int>
    {
        private readonly IRepository Repository;

        public UpdateStateCommandHandler(IRepository stateRepository)
        {
            this.Repository = stateRepository;
        }
        public async Task<int> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var updateState = new State
            {
                Id = request.Id,
                Name = request.Name,
                Code = request.Code,
                CountryId = request.CountryId
            };
            return await Repository.UpdateStateAsync(request.Id, updateState);
        }
    }
}