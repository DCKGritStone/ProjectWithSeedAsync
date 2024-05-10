using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectWithSeedAsync.Application.Dto;
using ProjectWithSeedAsync.Domain.Queries._City;
using ProjectWithSeedAsync.Infrastructure.Data;

namespace ProjectWithSeedAsync.Infrastructure.Queries._City
{
    public class GetCityQuery : IGetCityQuery
    {
        private readonly CityStateCountryDbContext dbContext;
        private readonly IMapper mapper;

        public GetCityQuery(CityStateCountryDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IList<CityDto> GetAllCityAsync()
        {

            /*  return mapper.Map<IList<CityDto>>(dbContext.Cities.ToList());

             // OR
  */


            /*return mapper.Map<IList<CityDto>>(dbContext.Cities.Include(city => city.State).Include(city=> city.State.Country).Select(city => new CityDto()
            {
                Id = city.Id,
                Name = city.Name,
                Code = city.Code,
                StateId = city.StateId,
                State = new StateDto()
                {
                    Id = city.State.Id,
                    Name = city.State.Name,
                    Code = city.State.Code,
                    CountryId = city.State.CountryId,
                    Country = new CountryDto
                    {
                        Id= city.State.Country.Id,
                        Name = city.State.Country.Name,
                        Code = city.State.Country.Code
                    }
                }

            }).ToList());*/

            var cityList = (from c in dbContext.Cities.ToList()
                            join s in dbContext.States.ToList() on c.StateId equals s.Id
                            join co in dbContext.Countries.ToList() on s.CountryId equals co.Id

                            select new CityDto
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Code = c.Code,
                                StateId = c.StateId,
                                State = new StateDto
                                {
                                    Id = s.Id,
                                    Name = s.Name,
                                    Code = s.Code,
                                    CountryId = s.CountryId,
                                    Country = mapper.Map<CountryDto>(s.Country)/*new CountryDto
                                    {
                                        Id=co.Id,
                                        Name=co.Name,
                                        Code=co.Code
                                    }*/
                                }
                            }).ToList();
            /*
                        return mapper.Map<IList<CityDto>>(cityList);*/

            return cityList;
        }

        public CityDto GetCityByIdAsync(int id)
        {
            return mapper.Map<CityDto>(dbContext.Cities.FirstOrDefaultAsync(C => C.Id == id));
        }

        public IList<CityDto> GetALLCitiesByStateIdAsync(int id)
        {
            return mapper.Map<IList<CityDto>>(dbContext.Cities.Where(city => city.StateId == id).ToList());
        }

    }
}
