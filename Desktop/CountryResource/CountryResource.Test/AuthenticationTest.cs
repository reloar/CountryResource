using CountryResource.DataContext;
using CountryResource.DomainModels;
using CountryResource.Infrastructure.Implementation;
using CountryResource.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountryResource.Test
{
   
    [TestClass]
    public class AuthenticationTest
    {
        readonly string _optionsJson = @"
          {
            'userName': 'stephen',
            'password': 'password@1',
            'email': 'samplr@gmail.com',
            'firstname': 'sample',
            'lastname': 'lastname',
            'DateOfBirth': '2018-03-29',
          }
        ";

        [TestMethod]
        public async Task CanAuthenticateClient()
        {
            //Arrange
            var user = JsonConvert.DeserializeObject<UserModel>(_optionsJson);
               var options = new DbContextOptionsBuilder<CountryData>()
           .UseInMemoryDatabase(databaseName: "Get_Countries")
           .Options;

            // Run the test against one instance of the context
            using (var context = new CountryData(options))
            {
                var repository = new UserRepository(context);
                var modelmanager = new UserManager(repository);

                //Act
                await modelmanager.CreateUser(user);
                var result = await repository.Verifyuser(user.Email,user.password);

                //Assert
                Assert.IsNotNull(result, "Authentication Failed");
            }
        }
    }
}

