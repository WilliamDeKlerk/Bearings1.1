using Bearings2000.Portal.Web.Areas.Identity.Data;
using Bearings2000.Portal.Web.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bearings2000.Portal.Web.Controllers
{
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private readonly BearingsContext _context;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<IdentityController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(BearingsContext context,
            SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleMgr, ILogger<IdentityController> logger)
        {
            _context = context;
          
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleMgr;
        }

        [HttpGet]

        public object GetRoles(DataSourceLoadOptions loadOptions)
        {

            return DataSourceLoader.Load(_roleManager.Roles.ToList(), loadOptions);
        }

        [HttpPost]

        public async Task<IActionResult> PostRoles(string values)
        {
            var newRole = new IdentityRole();
            JsonConvert.PopulateObject(values, newRole);

            var result = await _roleManager.CreateAsync(newRole);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else if (result.Succeeded)
            {
                _logger.LogInformation($"Role created a new role was created {DateTime.Now}.");
                //do something to validate the user and send email
            }



            return Ok();
        }


        [HttpPut]

        public async Task<IActionResult> PutRoles(Guid key, string values)
        {


            var role = await _roleManager.FindByIdAsync(key.ToString());

            if (role == null)
            {
                return NotFound($"Unable to load role with ID {key}.");
            }
            JsonConvert.PopulateObject(values, role);
            await _roleManager.UpdateAsync(role);

            return Ok();
        }

        [HttpDelete]

        public async Task DeleteRoles(Guid key)
        {
            //System.Diagnostics.Debug.WriteLine(key.ToString());
            var role = await _roleManager.FindByIdAsync(key.ToString());

            if (role == null)
            {
                return;
            }
            await _roleManager.DeleteAsync(role);
        }
    }
}
