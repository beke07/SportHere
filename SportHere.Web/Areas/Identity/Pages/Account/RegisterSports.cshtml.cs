using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal.Entities;
using SportHere.Dal.Entities.Users;
using SportHere.Web.Constants;
using SportHere.Web.Helpers;
using SportHere.Web.ViewModels.Pagination;
using SportHere.Web.ViewModels.Sport;

namespace SportHere.Web.Areas.Identity.Pages.Account
{
    public class RegisterSportsModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISportService sportService;

        public RegisterSportsModel(
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            ISportService sportService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.sportService = sportService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty]
        public List<SportViewModel> SportokPagedList { get; set; }

        public PaginationViewModel Pagination { get; set; } = new PaginationViewModel();

        public static List<int> SelectedIds { get; set; } = new List<int>();

        public async Task OnGetAsync()
        {
            SportokPagedList = mapper.Map<List<SportViewModel>>(await sportService.GetPaginatedSportListAsync(CurrentPage, PagerConstants.PageSize));
            SportokPagedList = SportHelper.SetSelectedSportsTrue(SportokPagedList, SelectedIds);

            Pagination.Count = await sportService.GetCountAsync();
            Pagination.TotalPages = (int)Math.Ceiling(decimal.Divide(Pagination.Count, PagerConstants.PageSize));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await sportService.AddSportsToUserAsync((await userManager.FindByNameAsync(User.Identity.Name)).Id, SelectedIds);
            return LocalRedirect(Url.Content("/Identity/Account/RegisterSettlements"));
        }

        public void OnGetCheck(int id)
        {
            if (SelectedIds.Contains(id))
            {
                SelectedIds.Remove(id);
            }
            else
            {
                SelectedIds.Add(id);
            }
        }
    }
}