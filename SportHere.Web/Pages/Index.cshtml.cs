using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Web.ViewModels.Select;
using SportHere.Web.ViewModels.Sport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportHere.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISettlementService settlementService;
        private readonly IMapper mapper;

        public IndexModel(
            ISettlementService settlementService,
            IMapper mapper)
        {
            this.settlementService = settlementService;
            this.mapper = mapper;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            
        }
    }
}
