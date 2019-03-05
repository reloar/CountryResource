using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountryResource.DomainModels;
using CountryResource.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.DependencyInjection;

namespace CountryResource.Extension
{
    public abstract class WebController : Controller
    {

        protected UserModel CurrentUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var usermanager = HttpContext.RequestServices.GetService<UserManager<User>>();
                var currentuser = usermanager.Users.FirstOrDefault(x => x.Email == User.Identity.Name);
                return new UserModel().Assign(currentuser);
            }
            return new UserModel();
        }
    }
}