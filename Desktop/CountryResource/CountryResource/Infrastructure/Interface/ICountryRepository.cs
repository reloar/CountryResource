using CountryResource.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.Infrastructure.Interface
{
    public interface ICountryRepository
    {
        Task<CountryModel> AddCountry(CountryModel country);
        Task<List<CountryModel>> GetAllCountries();
        Task<CountryModel> UpdateCountry(CountryModel model);

        Task<CountryModel> GetCountry(int countryid);
        Task<CountryModel> DeleteCountry(int countryid);
    }
}
