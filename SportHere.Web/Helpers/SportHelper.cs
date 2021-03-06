﻿using SportHere.Web.ViewModels.Sport;
using System.Collections.Generic;

namespace SportHere.Web.Helpers
{
    public static class SportHelper
    {
        public static List<SportViewModel> SetSelectedSportsTrue(List<SportViewModel> sportokPagedList, List<int> selectedIds)
        {
            sportokPagedList.ForEach(sport => {
                selectedIds.ForEach(id =>
                {
                    if (sport.Id == id)
                    {
                        sport.IsSelected = true;
                    }
                });
            });

            return sportokPagedList;
        }
    }
}
