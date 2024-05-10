using MediatR;

namespace ProjectWithSeedAsync.Application.Command._City.DeleteCity
{
    public class DeleteCityCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
