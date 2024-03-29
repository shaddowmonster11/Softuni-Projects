﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WorldUniversity.Data.Models;
using WorldUniversity.Services;
using WorldUniversity.Services.Messaging;

namespace WorldUniversity.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IStudentsService studentsService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IMailHelper mailHelper;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IStudentsService studentsService,
            ILogger<RegisterModel> logger,
            IMailHelper mailHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.studentsService = studentsService;
            _logger = logger;
            this.mailHelper = mailHelper;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "The field is required!")]
            [MinLength(3, ErrorMessage = "The field requires more than 3 characters!")]
            [MaxLength(30, ErrorMessage = "The field must not be more than 30 characters!")]
            [DisplayName("First Name")]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "The field is required!")]
            [MinLength(3, ErrorMessage = "The field requires more than 3 characters!")]
            [MaxLength(30, ErrorMessage = "The field must not be more than 30 characters!")]
            [DisplayName("Last Name")]
            public string LastName { get; set; }
            [Required(ErrorMessage = "The field is required!")]
            [MinLength(3, ErrorMessage = "The field requires more than 3 characters!")]
            [MaxLength(30, ErrorMessage = "The field must not be more than 30 characters!")]
            [Display(Name = "Username")]
            public string UserName { get; set; }
            [Required(ErrorMessage = "The field is required!")]
            [EmailAddress]          
            [Display(Name = "Email")]
            [Remote(action: "VerifyEmail", controller: "Users")]

            public string Email { get; set; }

            [Required(ErrorMessage = "The field is required!")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

        }
      
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }
      
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var isEmailAvaliable = studentsService.IsEmailInUse(Input.Email);
            if (isEmailAvaliable)
            {
                ModelState.AddModelError(string.Empty, $"User with email {Input.Email} already exist!");
            }
            var isUsernameAvaliable = studentsService.IsUsernameInUse(Input.UserName);
            if (isUsernameAvaliable)
            {
                ModelState.AddModelError(string.Empty, $"User with username {Input.UserName} already exist!");
            }
            if (ModelState.IsValid)
            {             
                var user = new ApplicationUser 
                {
                    FirstName=Input.FirstName,
                    LastName=Input.LastName,                   
                    UserName = Input.UserName,
                    Email = Input.Email,
                };
               
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                   
                    await _userManager.AddToRoleAsync(user, "User");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await this.mailHelper.SendFromIdentityAsync(
                     this.Input.Email,
                     "Confirm your email",
                     this.Input.UserName,
                    $"{HtmlEncoder.Default.Encode(callbackUrl)}");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
