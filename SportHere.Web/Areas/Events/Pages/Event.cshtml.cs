using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal.Entities.Events;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Event;
using SportHere.Web.ViewModels.Select;
using System;
using System.Threading.Tasks;

namespace SportHere.Web.Areas.Events.Pages
{
    [Authorize]
    public class EventModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEventService eventService;

        public EventModel(
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IEventService eventService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.eventService = eventService;
        }

        public int Id { get; set; }

        [BindProperty]
        public EventViewModel Event { get; set; } = new EventViewModel();

        public async Task OnGet(int id)
        {
            Id = id;
            var ev = await eventService.GetEventByIdAsync(id);

            Event = mapper.Map<EventViewModel>(ev);
            Event.TimeTo = ev.To.Hour + " : " + ev.To.Minute;
            Event.SportSelect = mapper.Map<SelectViewModel>(ev.Sport);

            if (Event.Date < DateTime.Now || await userManager.FindByNameAsync(User.Identity.Name) != ev.CreatedBy)
            {
                Event.IsExpired = true;
            }

            if(ev is Challenge)
            {
                Event.IsChallenge = true;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            await eventService.EditEventAsync(mapper.Map<Event>(Event), (await userManager.FindByNameAsync(User.Identity.Name)).Id);
            return LocalRedirect("/Events");
        }
    }
}