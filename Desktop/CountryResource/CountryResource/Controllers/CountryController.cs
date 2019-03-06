using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CountryResource.DomainModels;
using CountryResource.Extension;
using CountryResource.Infrastructure.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryResource.Controllers
{
    //[Authorize]
    [Route("api/[Controller]")]
  
    public class CountryController : Controller
    {
        private readonly ICountryManager _countryManager;
        public CountryController(ICountryManager countryManager)
        {
            _countryManager = countryManager;
        }
        [HttpPost("countries")]
        public async Task<IActionResult> AddCountry([FromBody]CountryModel model)
        {
           //var currentUser = CurrentUser();
            //model. = currentUser?.UserId;

            var add = await _countryManager.AddCountry(model);
            return Ok(new ApiResponse<CountryModel>()
            {
                Data = model,
                Message = "Succeeded",
                StatusCode = HttpStatusCode.OK
            });
        }
      
        [HttpGet("countries")]

        public async Task<IActionResult> GetCountries()
        {
            var countries = await _countryManager.GetAllCountries();

            return Ok(new ApiResponse<List<CountryModel>>()
            {
                Data = countries,
                Message = "",
                StatusCode = HttpStatusCode.OK
            });
        }

        // GET api/values/5
        [HttpGet("countries/{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country =await  _countryManager.GetCountry(id);

            return Ok(new ApiResponse<CountryModel>()
            {
                Data = country,
                Message = "Succesful",
                StatusCode = HttpStatusCode.OK
            });
           
        }
        // PUT api/values/5
        [HttpPut("countries/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryModel model)
        {
            model.CountryId = id;
            var update = await _countryManager.AddCountry(model);
            return Ok(new ApiResponse<CountryModel>()
            {
                Data = update,
                Message = "Successful",
                StatusCode = HttpStatusCode.OK
            });
        }

        // DELETE api/values/5
        [HttpDelete("countries/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var update = await _countryManager.DeleteCountry(id);
            return Ok(new ApiResponse<CountryModel>()
            {
                Data = update,
                Message = "Delete Successful",
                StatusCode = HttpStatusCode.OK
            });
        }


        [HttpGet("acivities")]

        public async Task<IActionResult> GetActivities()
        {
            var countries = await _countryManager.GetAllCountries();

            return Ok(new ApiResponse<List<CountryModel>>()
            {
                Data = countries,
                Message = "",
                StatusCode = HttpStatusCode.OK
            });
        }
    }
}