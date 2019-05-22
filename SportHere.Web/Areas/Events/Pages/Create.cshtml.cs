using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal.Entities.Events;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Event;
using SportHere.Web.ViewModels.Select;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportHere.Web.Areas.Events.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEventService eventService;
        private readonly ISportService sportService;

        public CreateModel(
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IEventService eventService,
            ISportService sportService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.eventService = eventService;
            this.sportService = sportService;
        }

        [BindProperty]
        public EventViewModel Event{ get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetSportList(string term)
        {
            return new JsonResult(mapper.Map<List<SelectViewModel>>(await sportService.GetSportsAsync(term)));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Event.IsChallenge)
            {
                await eventService.CreateChallengeAsync(mapper.Map<Challenge>(Event), (await userManager.FindByNameAsync(User.Identity.Name)).Id);
            }
            else
            {
                await eventService.CreateEventAsync(mapper.Map<Event>(Event), (await userManager.FindByNameAsync(User.Identity.Name)).Id);
            }
            return LocalRedirect("/Events");
        }
    }
}