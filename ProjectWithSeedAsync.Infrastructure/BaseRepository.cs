using Microsoft.EntityFrameworkCore;
using ProjectWithSeedAsync.Domain;
using ProjectWithSeedAsync.Domain.Entity;
using ProjectWithSeedAsync.Infrastructure.Data;

namespace ProjectWithSeedAsync.Infrastructure
{
    public class BaseRepository : IRepository
    {
        private readonly CityStateCountryDbContext dbContext;

        public BaseRepository(CityStateCountryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Country> CreateCountryAsync(Country country)
        {
            await dbContext.Countries.AddAsync(country);
            await dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<int> DeleteCountryAsync(int id)
        {
            return await dbContext.Countries.Where(model => model.Id == id).ExecuteDeleteAsync();
        }



        public async Task<int> UpdateCountryAsync(int id, Country country)
        {
            return await dbContext.Countries.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.Name, country.Name)
                                                                                                         .SetProperty(x => x.Code, country.Code));
        }

        public async Task<State> CreateStateAsync(State state)
        {
            await dbContext.States.AddAsync(state);
            await dbContext.SaveChangesAsync();
            return state;
        }

        public async Task<int> DeleteStateAsync(int id)
        {
            return await dbContext.States.Where(model => model.Id == id).ExecuteDeleteAsync();
        }



        public async Task<int> UpdateStateAsync(int id, State state)
        {
            return await dbContext.States.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.Name, state.Name)
                                                                                                          .SetProperty(x => x.Code, state.Code)
                                                                                                          .SetProperty(x => x.CountryId, state.CountryId));
        }

        public async Task<City> CreateCityAsync(City city)
        {
            await dbContext.Cities.AddAsync(city);
            await dbContext.SaveChangesAsync();
            return city;
        }

        public async Task<int> DeleteCityAsync(int id)
        {
            return await dbContext.Cities.Where(model => model.Id == id).ExecuteDeleteAsync();
        }



        public async Task<int> UpdateCityAsync(int id, City city)
        {
            return await dbContext.Cities.Where(model => model.Id == id).ExecuteUpdateAsync(setter => setter.SetProperty(x => x.Name, city.Name)
                                                                                                          .SetProperty(x => x.Code, city.Code)
                                                                                                          .SetProperty(x => x.StateId, city.StateId));
        }
    }
}
