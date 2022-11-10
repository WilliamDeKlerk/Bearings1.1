using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bearings2000.Portal.Web.Areas.Identity.Pages.Account
{
    public class RolesModel : PageModel
    {
        RoleManager<IdentityRole> roleManager;

        public RolesModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Roles = await roleManager.Roles.ToListAsync();

            return Page();
        }
      
    }
}
