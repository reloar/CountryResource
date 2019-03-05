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
        private readonly DbContext _context;
        public CountryRepository(DbContext context)
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

        public Task<CountryModel> DeleteCountry(int countryid)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CountryModel>> GetAllCountries()
        {
            var allcountry = await _context.Set<Country>()
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

            var query = await _context.Set<Country>().FirstOrDefaultAsync(p => p.CountryId == countryid);
           
            var model = new CountryModel().Assign(query);

            return model;
        }

        public async Task<CountryModel> UpdateCountry(CountryModel model)
        {
            var updatecountry = await _context.Set<Country>().FindAsync(model.CountryId);
            if (updatecountry == null) throw new Exception("Product not Found");
            updatecountry.Assign(model);
            _context.Update(updatecountry);

            await _context.SaveChangesAsync();
            return model;
        }
    }
}
