using Bearings2000.Portal.Web.Models;
using Bearings2000.Portal.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bearings2000.Portal.Web.Pages
{
    //[Authorize]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IDataService _dataService;
       
       

        public PrivacyModel(ILogger<PrivacyModel> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }


        public void OnGet()
        {
           
        }
    }
}