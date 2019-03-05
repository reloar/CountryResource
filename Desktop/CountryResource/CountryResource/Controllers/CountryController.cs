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
    [Authorize]
    [Route("api/[controller]")]
  
    public class CountryController : WebController
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
        public async Task<IActionResult> Getvalue(int countryid)
        {
            var country = _countryManager.GetCountry(countryid);
            return Ok();
        }
        // PUT api/values/5
        [HttpPut("countries/{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryModel model)
        {
            model.CountryId = id;
            var update = await _countryManager.AddCountry(model);
            return Ok(new ApiResponse<CountryModel>()
            {
                Data = model,
                Message = "Succeeded",
                StatusCode = HttpStatusCode.OK
            });
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}