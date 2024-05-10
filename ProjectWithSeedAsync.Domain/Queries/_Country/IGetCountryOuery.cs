using ProjectWithSeedAsync.Application.Dto;

namespace ProjectWithSeedAsync.Domain.Queries._Country
{
    public interface IGetCountryOuery
    {
        IList<CountryDto> GetAllCountryAsync();

        CountryDto GetCountryByIdAsync(int id);
    }
}
