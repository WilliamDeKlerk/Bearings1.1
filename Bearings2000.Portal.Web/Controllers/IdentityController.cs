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

namespace Bearings2000.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class IdentityController : Controller
    {
        private readonly BearingsContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public IdentityController(BearingsContext context, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
       
        [HttpGet]
     
        public object GetUsers(DataSourceLoadOptions loadOptions)
        {

            return DataSourceLoader.Load(_userManager.Users.ToList(), loadOptions);
        }

      
        [HttpPost]
       
        public IActionResult PostUser(string values)
        {
            var newAppUser = new AppUser();
            //JsonConvert.PopulateObject(values, newAppUser);

            //if (!TryValidateModel(newAppUser))
            //    return BadRequest(ModelState);

            //_data.Employees.Add(newEmployee);
            //_data.SaveChanges();

            return Ok();
        }

     
        [HttpPut]
      
        public IActionResult PutUser(Guid key, string values)
        {
            System.Diagnostics.Debug.WriteLine(key.ToString());
            //var userName =  _userManager.GetUserName(user);
            // JsonConvert.PopulateObject(values, employee);

            // if (!TryValidateModel(employee))
            //     return BadRequest(ModelState);

            // _data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
       
        public void DeleteUser(Guid key)
        {
            System.Diagnostics.Debug.WriteLine(key.ToString());
            //var employee = _data.Employees.First(a => a.ID == key);
            //_data.Employees.Remove(employee);
            //_data.SaveChanges();
        }

    }
}
