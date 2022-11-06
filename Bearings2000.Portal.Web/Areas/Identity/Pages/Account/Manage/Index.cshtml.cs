// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Bearings2000.Portal.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bearings2000.Portal.Web.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }


            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Display(Name = "Surname")]
            public string Surname { get; set; }
            [Display(Name = "ID Number")]
            public string IDNumber { get; set; }
            [Display(Name = "Comment")]
            public string Comment { get; set; }

            [Display(Name = "Can Create Enquiry")]
            public bool CanCreateEnquiry { get; set; } 

            [Display(Name = "Can View Tracking")]
            public bool CanViewTracking { get; set; } 

            [Display(Name = "Can View Documents")]
            public bool CanViewDocuments { get; set; }

            [Display(Name = "Individual Pricing")]
            public bool IndividualPricing { get; set; }

            [Display(Name = "Customer Pricing")]
            public bool CustomerPricing { get; set; }

            [Display(Name = "Show Price")]
            public bool ShowPrice { get; set; }

            [Display(Name = "Show Actual Quantity")]
            public bool ShowActualQuantity { get; set; }


            [Display(Name = "Show No Quantity")]
            public bool ShowNoQuantity { get; set; }


            [Display(Name = "Show High level Quantity")]
            public bool ShowHighlevelQuantity { get; set; }


            [Display(Name = "Show Max Allowed To View Quantity")]
            public bool ShowMaxAllowedToViewQuantity { get; set; }

            [Display(Name = "Type of user")]
            public int UserTypeId { get; set; }

            [Display(Name = "Linked Customer")]
            public int CustomerId { get; set; }
        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //customer fields
            var firstName = user.FirstName;
            var surName = user.Surname;
            var idNumber = user.IDNumber;

            var canCreateEnquiry = false;
            if (user.CanCreateEnquiry.HasValue)
                canCreateEnquiry = user.CanCreateEnquiry.Value;

            var canViewDocuments = false;
            if (user.CanViewDocuments.HasValue)
                canViewDocuments = user.CanViewDocuments.Value;

            var canViewTracking = false;
            if (user.CanViewTracking.HasValue)
                canViewTracking = user.CanViewTracking.Value;

            var individualPricing = false;
            if (user.IndividualPricing.HasValue)
                individualPricing = user.IndividualPricing.Value;

            var customerPricing = false;
            if (user.CustomerPricing.HasValue)
                customerPricing = user.CustomerPricing.Value;

            var showPrice = false;
            if (user.ShowPrice.HasValue)
                showPrice = user.ShowPrice.Value;

            var showActualQuantity = false;
            if (user.ShowActualQuantity.HasValue)
                showActualQuantity = user.ShowActualQuantity.Value;

            var showNoQuantity = false;
            if (user.ShowNoQuantity.HasValue)
                showNoQuantity = user.ShowNoQuantity.Value;

            var showHighlevelQuantity = false;
            if (user.ShowHighlevelQuantity.HasValue)
                showHighlevelQuantity = user.ShowHighlevelQuantity.Value;

            var showMaxAllowedToViewQuantity = false;
            if (user.ShowMaxAllowedToViewQuantity.HasValue)
                showMaxAllowedToViewQuantity = user.ShowMaxAllowedToViewQuantity.Value;


            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                Surname = surName,
                IDNumber = idNumber,
                CanCreateEnquiry = canCreateEnquiry,
                CanViewDocuments = canViewDocuments,
                CanViewTracking = canViewTracking,
                IndividualPricing = individualPricing,
                CustomerPricing = customerPricing,
                ShowPrice = showPrice,
                ShowActualQuantity = showActualQuantity,
                ShowNoQuantity = showNoQuantity,
                ShowHighlevelQuantity = showHighlevelQuantity,
                ShowMaxAllowedToViewQuantity = showMaxAllowedToViewQuantity,


            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            //custom properties
            user.FirstName = Input.FirstName;
            user.Surname = Input.Surname;
            user.IDNumber = Input.IDNumber;
            user.CanCreateEnquiry = Input.CanCreateEnquiry;
            user.CanViewDocuments = Input.CanViewDocuments;
            user.CanViewTracking = Input.CanViewTracking;
            user.IndividualPricing = Input.IndividualPricing;
            user.CustomerPricing = Input.CustomerPricing;
            user.ShowPrice = Input.ShowPrice;
            user.ShowActualQuantity = Input.ShowActualQuantity;
            user.ShowNoQuantity = Input.ShowNoQuantity;
            user.ShowHighlevelQuantity = Input.ShowHighlevelQuantity;
            user.ShowMaxAllowedToViewQuantity = Input.ShowMaxAllowedToViewQuantity;
            
            await _userManager.UpdateAsync(user);



            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
