using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportHere.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEventService eventService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        [BindProperty]
        public List<EventCardViewModel> Events { get; set; } = new List<EventCardViewModel>();

        public IndexModel(
            IEventService eventService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            this.eventService = eventService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public int RecordsPerPage { get; set; } = 3;

        private async Task<List<EventCardViewModel>> GetAllEvents()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var events = await eventService.GetEventsByNear(user.Id);
            var EventViewModels = mapper.Map<List<EventCardViewModel>>(events);

            events.ForEach(ev =>
            {
                Events.ForEach(evView =>
                {
                    if (ev.Id == evView.Id && ev.Participants.Select(e => e.User).Contains(user))
                    {
                        evView.ImParticipant = true;
                    }
                    ev.Participants.ForEach(p =>
                    {
                        evView.Participants += p.User is User ? 1 : Convert.ToInt32((p.User as Team).HeadCount);
                    });
                });
            });

            return EventViewModels;
        }

        private async Task<List<EventCardViewModel>> GetPaginatedEvents(int page = 1)
        {
            var skipRecords = page * RecordsPerPage;

            return (await GetAllEvents())
                .Skip(skipRecords)
                .Take(RecordsPerPage)
                .ToList();
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.User.Identity.Name == null)
            {
                return LocalRedirect("/Identity/Account/Login");
            }
            else
            {
                Events = await GetPaginatedEvents(0);
            }

            return Page();
        }

        public async Task<IActionResult> OnGetEvents(int id)
        {
            return new PartialViewResult()
            {
                ViewName = "_Events",
                ViewData = new ViewDataDictionary<List<EventCardViewModel>>(ViewData, await GetPaginatedEvents(id)),
                TempData = TempData
            };
        }

        public async Task<IActionResult> OnGetParticipate(int id)
        {
            await eventService.ParticipateAsync(id, (await userManager.FindByNameAsync(User.Identity.Name)).Id);
            return LocalRedirect("/");
        }
    }
}
