using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bearings2000.Portal.Web.Pages
{
    [Authorize]
    public class CockpitModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
