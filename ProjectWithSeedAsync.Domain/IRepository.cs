using ProjectWithSeedAsync.Domain.Entity;

namespace ProjectWithSeedAsync.Domain
{
    public interface IRepository
    {

        Task<Country> CreateCountryAsync(Country country);
        Task<int> UpdateCountryAsync(int id, Country country);

        Task<int> DeleteCountryAsync(int id);
        Task<State> CreateStateAsync(State state);
        Task<int> UpdateStateAsync(int id, State state);

        Task<int> DeleteStateAsync(int id);
        Task<City> CreateCityAsync(City city);
        Task<int> UpdateCityAsync(int id, City city);

        Task<int> DeleteCityAsync(int id);
    }
}
