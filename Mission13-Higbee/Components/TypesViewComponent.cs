using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission13_Higbee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_Higbee.Components
{
    public class TypesViewComponent : ViewComponent //inherits from view component
    {
        private BowlingDbContext context { get; set; } //connects to the bowling db context
        public TypesViewComponent(BowlingDbContext temp) //constructor
        {
            context = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.Teams = RouteData?.Values["teamname"];
            var teams = context.Teams //instructs where to get the teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(teams); 
        }

    }
}
