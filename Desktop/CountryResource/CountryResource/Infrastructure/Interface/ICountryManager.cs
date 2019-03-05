using CountryResource.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.Infrastructure.Interface
{
    public interface ICountryManager
    {
        Task<CountryModel> AddCountry(CountryModel country);
        Task<List<CountryModel>> GetAllCountries();
          Task<CountryModel> GetCountry(int countryid);
        Task<CountryModel> DeleteCountry(int countryid);
    }
}
