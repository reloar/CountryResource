using CountryResource.DataContext;
using CountryResource.DomainModels;
using CountryResource.Entities;
using CountryResource.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.Infrastructure.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CountryData _context;
        public CountryRepository(CountryData context)
        {
            _context = context;
        }
        public async Task<CountryModel> AddCountry(CountryModel country)
        {
            country.DateCreated = DateTime.Now;
            var newcountry = new Country().Assign(country);

            await _context.AddAsync(newcountry);
            await _context.SaveChangesAsync();
         


            return country;
        }

        public async Task<CountryModel> DeleteCountry(int countryid)
        {
            var deletecountry = await _context.Countries.FindAsync(countryid);

               var isDeleted=_context.Entry(deletecountry).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return new CountryModel().Assign(isDeleted);
        }

        public async Task<List<CountryModel>> GetAllCountries()
        {
            var allcountry = await _context.Countries
                 .Select(x =>
                     new CountryModel
                     {
                         CountryId = x.CountryId,
                         Name = x.Name,
                         DateCreated = x.DateCreated,
                         Continent = x.Continent
                     })
                 .ToListAsync();
            return allcountry;
        }

        public async Task<CountryModel> GetCountry(int countryid)
        {

            var query = await _context.Countries.FirstOrDefaultAsync(p => p.CountryId == countryid);

            return new CountryModel().Assign(query);

        }

        public async Task<CountryModel> UpdateCountry(CountryModel model)
        {
            model.DateCreated = DateTime.Now;
            var updatecountry = await _context.Countries.FindAsync(model.CountryId);
            if (updatecountry == null) throw new Exception("country not Found");
            updatecountry.Assign(model);
          

            await _context.SaveChangesAsync();
            return new CountryModel().Assign(updatecountry);
        }
    }
}
