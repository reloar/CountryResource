using CountryResource.DomainModels;
using CountryResource.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CountryResource.Infrastructure.Implementation
{
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepository _contryRepo;
        public CountryManager(ICountryRepository contryRepo)
        {
            _contryRepo = contryRepo;
        }
        public async Task<CountryModel> AddCountry(CountryModel country)
        {
            country.Validate();
            var getcountry = await _contryRepo.GetCountry(country.CountryId);
            if (getcountry.CountryId != 0)
            {
                return await _contryRepo.UpdateCountry(country);
            }
            else
            {
                return await _contryRepo.AddCountry(country);
            }
        }

        public async Task<CountryModel> DeleteCountry(int countryid)
        {
            return await _contryRepo.DeleteCountry(countryid);
        }

        public async Task<List<CountryModel>> GetAllCountries()
        {
            return await _contryRepo.GetAllCountries();
        }

        public async Task<CountryModel> GetCountry(int countryid)
        {
            return await _contryRepo.GetCountry(countryid);
        }

       
    }
}
