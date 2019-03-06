using CountryResource.Entities;
using CountryResource.Infrastructure.Implementation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CountryResource.DataContext
{
    public class CountryData : DbContext
    {

        public CountryData(DbContextOptions<CountryData> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        // public DbSet<Audit> Audits { get; set; }


        private void Audits()
        {
            var entities = ChangeTracker.Entries();

            var userId = Environment.UserName;
            foreach (var item in entities)
            {
                if (item.State == EntityState.Added)
                {
                    if (item.Entity is Audit entity)
                    {
                        entity.CreatedBy = userId;
                        entity.DateCreated = DateTime.Now;
                        entity.CreatedBy = userId;
                        entity.IsActive = true;
                        entity.IsDeleted = false;

                    }

                }
                else if (item.State == EntityState.Modified)
                {
                    if (item.Entity is Audit entity)
                    {
                        entity.UpdatedBy = userId;
                        entity.UpdateDate = DateTime.Now;
                        entity.CreatedBy = userId;
                        if (entity.IsDeleted)
                        {
                            entity.DeletedBy = userId;

                        }

                    }
                }

            }
        }
    }

 }


       