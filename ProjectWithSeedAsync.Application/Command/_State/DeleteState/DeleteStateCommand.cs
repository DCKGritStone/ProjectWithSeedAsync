using MediatR;

namespace ProjectWithSeedAsync.Application.Command._State.DeleteState
{
    public class DeleteStateCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
