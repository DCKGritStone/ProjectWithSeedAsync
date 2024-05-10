using ProjectWithSeedAsync.Application.Dto;

namespace ProjectWithSeedAsync.Domain.Queries._State
{
    public interface IGetStateQuery
    {
        IList<StateDto> GetAllStateAsync();

        StateDto GetStateByIdAsync(int id);
    }
}
