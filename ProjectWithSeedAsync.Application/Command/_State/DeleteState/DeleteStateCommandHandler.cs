using MediatR;
using ProjectWithSeedAsync.Domain;

namespace ProjectWithSeedAsync.Application.Command._State.DeleteState
{
    public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand, int>
    {
        private readonly IRepository Repository;

        public DeleteStateCommandHandler(IRepository stateRepository)
        {
            this.Repository = stateRepository;
        }
        public async Task<int> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            return await Repository.DeleteStateAsync(request.Id);
        }
    }
}
