using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Event;

namespace SportHere.Web.Areas.Events.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEventService eventService;

        public IndexModel(
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IEventService eventService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.eventService = eventService;
        }

        [BindProperty]
        public List<EventGridViewModel> Events { get; set; } = new List<EventGridViewModel>();

        public async Task OnGet()
        {
            Events = mapper.Map<List<EventGridViewModel>>(await eventService.GetEventsToUserAsync((await userManager.FindByNameAsync(User.Identity.Name)).Id));
        }

        public IActionResult OnPostDelete(int Id)
        {
            eventService.DeleteEventAsync(Id);
            return LocalRedirect("/Events");
        }
    }
}