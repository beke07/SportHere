using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Select;

namespace SportHere.Web.Areas.Identity.Pages.Account
{
    public class RegisterSettlementsModel : PageModel
    {
        private readonly ISettlementService settlementService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        [BindProperty]
        public List<int> SelectedIds { get; set; }

        public RegisterSettlementsModel(
            ISettlementService settlementService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.settlementService = settlementService;
            this.userManager = userManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnGetSettlementList(string term)
        {
            return new JsonResult(mapper.Map<List<SelectViewModel>>(await settlementService.FindSettlements(term)));
        }

        public async Task<IActionResult> OnPost()
        {
            await settlementService.AddSettlementsToUser((await userManager.FindByNameAsync(User.Identity.Name)).Id, SelectedIds);
            return LocalRedirect(Url.Content("~/"));
        }
    }
}