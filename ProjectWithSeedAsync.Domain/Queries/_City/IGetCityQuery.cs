using ProjectWithSeedAsync.Application.Dto;

namespace ProjectWithSeedAsync.Domain.Queries._City
{
    public interface IGetCityQuery
    {
        IList<CityDto> GetAllCityAsync();

        IList<CityDto> GetALLCitiesByStateIdAsync(int id);

        CityDto GetCityByIdAsync(int id);



    }
}
