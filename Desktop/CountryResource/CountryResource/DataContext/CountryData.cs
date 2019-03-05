using CountryResource.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryResource.DataContext
{
    public class CountryData:  DbContext
    {
        public CountryData(DbContextOptions<CountryData> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
