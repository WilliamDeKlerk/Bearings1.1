using Bearings2000.Portal.Web.Areas.Identity.Data;
using Bearings2000.Portal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using DevExtreme.AspNet.Mvc;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Bearings2000.Portal.Web.Data;
using Microsoft.AspNetCore.Cors;
using Bearings2000.Portal.Web.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bearings2000.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class IdentityController : Controller
    {
        private readonly BearingsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(BearingsContext context, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, ILogger<IdentityController> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;

        }

        [HttpGet]

        public object GetUsers(DataSourceLoadOptions loadOptions)
        {

            return DataSourceLoader.Load(_userManager.Users.ToList(), loadOptions);
        }


        [HttpPost]

        public async Task<IActionResult> PostUser(string values)
        {
            var newAppUser = new AppUser();
            JsonConvert.PopulateObject(values, newAppUser);

            var result = await _userManager.CreateAsync(newAppUser, newAppUser.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else if (result.Succeeded)
            {
                _logger.LogInformation("User created a new account with password.");
                //do something to validate the user and send email
            }



            return Ok();
        }


        [HttpPut]

        public async Task<IActionResult> PutUser(Guid key, string values)
        {


            var appUser = await _userManager.FindByIdAsync(key.ToString());

            if (appUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            JsonConvert.PopulateObject(values, appUser);
            await _userManager.UpdateAsync(appUser);

            return Ok();
        }

        [HttpDelete]

        public async Task DeleteUser(Guid key)
        {
            System.Diagnostics.Debug.WriteLine(key.ToString());
            var appUser = await _userManager.FindByIdAsync(key.ToString());

            if (appUser == null)
            {
                return;
            }
            await _userManager.DeleteAsync(appUser);
        }



    }
}
