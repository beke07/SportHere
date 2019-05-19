using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportHere.Bll.ServiceInterfaces;
using SportHere.BLL.Services;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Select;

namespace SportHere.Web.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class SettlementsModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly ISettlementService settlementService;
        private readonly UserManager<ApplicationUser> userManager;

        [BindProperty]
        public List<int> SelectedIds { get; set; } = new List<int>();

        [BindProperty]
        public List<SelectViewModel> SelectedSettlements { get; set; } = new List<SelectViewModel>();

        public SettlementsModel(
            IMapper mapper,
            ISettlementService settlementService,
            UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.settlementService = settlementService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> OnGetSettlementList(string term)
        {
            var settlements = mapper.Map<List<SelectViewModel>>(await settlementService.FindSettlements(term));
            return new JsonResult(settlements);
        }

        public async Task OnGetAsync()
        {
            var user = await userManager.GetUserAsync(User);
            var varosok = await settlementService.GetUserSettlements(user.Id);

            SelectedSettlements.AddRange(mapper.Map<List<SelectViewModel>>(varosok));
            SelectedIds.AddRange(varosok.Select(v => v.Id));
        }

        public async Task<IActionResult> OnPost()
        {
            await settlementService.AddSettlementsToUser((await userManager.FindByNameAsync(User.Identity.Name)).Id, SelectedIds);
            return LocalRedirect(Url.Content("/Identity/Account/Manage/Settlements"));
        }
    }
}