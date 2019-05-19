using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Register;

namespace SportHere.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IMapper mapper,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        [BindProperty]
        public RegisterViewModel Input { get; set; }

        [BindProperty]
        public TeamRegisterViewModel TeamInput { get; set; }

        [BindProperty]
        public UserRegisterViewModel UserInput { get; set; }

        public string ReturnUrl { get; set; }

        [BindProperty]
        public UserType UserType { get; set; }


        public void OnGet(string returnUrl = null, UserType userType = UserType.User)
        {
            ReturnUrl = returnUrl;
            UserType = userType;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {   
            if (ModelState.IsValid)
            {
                ApplicationUser user;
                
                if (UserType == UserType.Csapat)
                {
                    Team team = _mapper.Map<Team>(Input);
                    team.HeadCount = TeamInput.HeadCount;

                    user = team;
                }
                else
                {
                    User inputUser = _mapper.Map<User>(Input);
                    inputUser.FirstName = UserInput.FirstName;
                    inputUser.LastName = UserInput.LastName;

                    user = inputUser;
                }

                var result = await _userManager.CreateAsync(user, Input.Password);
                returnUrl = returnUrl ?? Url.Content("/Identity/Account/RegisterSports");

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
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
