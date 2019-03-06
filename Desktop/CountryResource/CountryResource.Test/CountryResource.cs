using CountryResource.Controllers;
using CountryResource.DataContext;
using CountryResource.DomainModels;
using CountryResource.Infrastructure.Implementation;
using CountryResource.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CountryResource.Test
{
   
    [TestClass]
    public class CountryResource
    {
        [TestMethod]
        public async Task RepoCreateandGetCountryFoUser()
        {
            //Arrange
            var userId = "8742954e-0993-4498-bea5-5b3d60857a86";
            var country = new CountryModel
            {
                CountryId = 10,
                Name = "Nigeria",
                Continent = "Africa",
                //DateCreated = DateTime.Now
            };

            var options = new DbContextOptionsBuilder<CountryData>()
                .UseInMemoryDatabase(databaseName: "Get_Countries")
                .Options;

            // Run the test against one instance of the context
            using (var context = new CountryData(options))
            {
                var repository = new CountryRepository(context);
                var modelmanager = new CountryManager(repository);

                //Act
                await modelmanager.AddCountry(country);
                var result = await modelmanager.GetAllCountries();

                //Assert
                Assert.AreEqual(country.Name, result[0].Name);
            }
        }
        [TestMethod]
        public async Task Task_UpdateCountry_OkResult()
        {

            var country = new CountryModel
            {
                CountryId = 5,
                Name = "Nigeria",
                Continent = "Africa",
                //DateCreated = DateTime.Now
            };

            //Arrange  
            var options = new DbContextOptionsBuilder<CountryData>()
               .UseInMemoryDatabase(databaseName: "Get_Countries")
               .Options;


            // Run the test against one instance of the context
            using (var context = new CountryData(options))
            {

               
                var repository = new CountryRepository(context);
                var modelmanager = new CountryManager(repository);



                //Act
                await modelmanager.AddCountry(country);

                var result = await modelmanager.GetAllCountries();

                //Assert
               
                Assert.AreEqual(country.Name, result[0].Name);
            }

        }

        [TestMethod]
        public async Task Task_GetCountry_OkResult()
        {

            var country = new CountryModel
            {
                CountryId = 5
               
            };

            //Arrange  
            var options = new DbContextOptionsBuilder<CountryData>()
               .UseInMemoryDatabase(databaseName: "Get_Countries")
               .Options;


            // Run the test against one instance of the context
            using (var context = new CountryData(options))
            {


                var repository = new CountryRepository(context);
                var modelmanager = new CountryManager(repository);



                //Act
                
                var result = await modelmanager.GetCountry(country.CountryId);

                //Assert

                Assert.AreEqual(country.Name,result.Name);
            }


        }
        [TestMethod]
        public async Task Task_DeleteCountry_OkResult()
        {

            var country = new CountryModel
            {
                CountryId = 5,
                Name = "Nigeria",
                Continent = "Africa",
                //DateCreated = DateTime.Now
            };

            //Arrange  
            var options = new DbContextOptionsBuilder<CountryData>()
               .UseInMemoryDatabase(databaseName: "Get_Countries")
               .Options;


            // Run the test against one instance of the context
            using (var context = new CountryData(options))
            {


                var repository = new CountryRepository(context);
                var modelmanager = new CountryManager(repository);



                //Act
                await modelmanager.DeleteCountry(country.CountryId);

                var result = await modelmanager.GetAllCountries();

                //Assert

                Assert.AreEqual(country.Name, result[0].Name);
            }


        }



    }
  
}
