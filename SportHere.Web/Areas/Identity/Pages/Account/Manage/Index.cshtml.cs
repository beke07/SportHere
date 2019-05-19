using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Register;

namespace SportHere.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IApplicationUserService userService;
        private readonly IMapper mapper;
        private readonly Bll.ServiceInterfaces.IEmailSender _emailSender;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IApplicationUserService userService,
            IMapper mapper,
            Bll.ServiceInterfaces.IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.userService = userService;
            this.mapper = mapper;
            _emailSender = emailSender;
        }

        public UserType UserType{ get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public UserProfilViewModel UserInput { get; set; }

        [BindProperty]
        public TeamProfilViewModel TeamInput { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            UserType = user is User ? UserType.User : UserType.Csapat;

            if (UserType == UserType.User)
            {
                UserInput = mapper.Map<UserProfilViewModel>(user);
            }
            else if (UserType == UserType.Csapat)
            {
                TeamInput = mapper.Map<TeamProfilViewModel>(user);
            }

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var curretnUser = await _userManager.GetUserAsync(User);
            if (curretnUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if(UserType == UserType.Csapat)
            {
                Team team = mapper.Map<Team>(TeamInput);
                await userService.SetTeamAsync(curretnUser.Id, team);
            }
            else
            {
                User user = mapper.Map<User>(TeamInput);
                await userService.SetUserAsync(curretnUser.Id, user);
            }

            await _signInManager.RefreshSignInAsync(curretnUser);
            StatusMessage = "Your profile has been updated";

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
