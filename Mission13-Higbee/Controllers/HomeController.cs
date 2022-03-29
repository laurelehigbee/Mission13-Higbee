using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13_Higbee.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13_Higbee.Controllers
{
    public class HomeController : Controller
    {
        private BowlingDbContext context { get; set; } //connects to the bowling db context
        public HomeController(BowlingDbContext temp) //constructor
        {
            context = temp;
        }
        public IQueryable<Bowler> Bowlers => context.Bowlers;
        public IQueryable<Team> Teams => context.Teams;

        public IActionResult Index(string teamname) //returns what the user will see if the Index is requested
        {
            var x = context.Bowlers //where to get the bowlers from
                 .Where(p => p.Team.TeamName == teamname || teamname == null)
                 .ToList();
            ViewBag.Message = teamname;
   
            return View(x);
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid) //what to do when delete is pressed
        {
            var record = context.Bowlers.Single(x => x.BowlerID == bowlerid); //selects appropriate bowler to delete
            return View(record);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b) //what to do when delete is confirmed
        {
            context.Bowlers.Remove(b); //removes record 
            context.SaveChanges(); //saves changes

            return RedirectToAction("Index"); //returns to home view
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid) //what to do when edit page is requested
        {
            var record = context.Bowlers.Single(x => x.BowlerID == bowlerid); //pulls the appropriate information
            ViewBag.Teams = context.Teams.ToList();
            return View(record); //returns the appropriate view
        }
        [HttpPost]
        public IActionResult Edit(Bowler record) //what to do when edit is confirmed
        {
            context.Bowlers.Update(record); //updates record
            context.SaveChanges(); //saves changes
            return RedirectToAction("Index"); //redirects to home view
        }

        [HttpGet]
        public IActionResult AddBowler() //what to do when add button is pressed
        {
            ViewBag.Teams = context.Teams.ToList();
            return View(); //returns addbowler view
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler bowler) //what to do when add is submitted
        {
            context.Add(bowler); //adds record 
            context.SaveChanges();//saves changes

            return RedirectToAction("Index"); //returns to home view

        }




    }
}
