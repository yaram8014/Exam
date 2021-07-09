using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Exam.Models;

namespace Exam.Controllers
{
public class ActivitymController : Controller{
     private MyContext _db;
        private int? uid
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
        }
        private bool isLoggedIn
        {
            get { return uid != null; }
        }
        public ActivitymController(MyContext context)
        {
            _db = context;
        }
        [HttpGet("Home")]
        public IActionResult Dashboard()
        {
            if( !isLoggedIn )
            {
                return RedirectToAction("Index" , "Home"); 
            }
            
            List<Activitym> allActivitym = _db.Activityms
                .Include(a => a.Plane) // one to many
                .Include(a => a.par) // many to many 
                .ThenInclude(j => j.parti)
                .Where(a => a.Date > DateTime.Today)
                .OrderBy(a =>a.Date)
                .ToList();

            List<Activitym> expiredActivityms = _db.Activityms
                // .Include(w => w.Planner) // one to many
                // .Include(w => w.Guests) // many to many 
                // .ThenInclude(g => g.Guest)
                .Where(w => w.Date < DateTime.Today)
                .ToList();

            foreach(Activitym activitym in expiredActivityms)
            {
                _db.Activityms.Remove(activitym);
                _db.SaveChanges();
            }

            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;

            return View(allActivitym);
        }
        
        [HttpGet("new")]
        public IActionResult NewActivity()
        {
            if( !isLoggedIn )
            {
                return RedirectToAction("Index" , "Home"); 
            }
            return View();
        }
[HttpPost("create")]
        public IActionResult CreateActivitym(Activitym activitym)
        {
            if( !isLoggedIn )
            {
                return RedirectToAction("Index" , "Home"); 
            }
            if( activitym.Date < DateTime.Now )
            {
                ModelState.AddModelError("Date" , "Activity Date must be in the Future");
            }
            if(ModelState.IsValid)
            {
                activitym.UserId = (int)uid;
                _db.Activityms.Add(activitym);
                _db.SaveChanges();
                //return RedirectToAction("WeddingInfo" , );
                 return Redirect($"/activity/{activitym.ActivitymId}");
            }
            // User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            // ViewBag.User = u;
            return View("NewActivity");
        }
        [HttpGet("activity/{activitymId}")]
        public IActionResult ActivityInfo(int activitymId)
        {
            // Movie thisMovie = _db.Movies
            //     .Include(m => m.PostedBy) // grab the posted by
            //     .Include(m => m.Fans) // grab all fans
            //     .ThenInclude(f => f.Fan) // grab a speifc fan
            //     .FirstOrDefault(m => m.MovieId == movieId);
            if( !isLoggedIn )
            {
                return RedirectToAction("Index" , "Home"); 
            }
            Activitym thisActivitym = _db.Activityms
                .Include(a => a.Plane)
                .Include(a => a.par)
                .ThenInclude(j => j.parti)
                .FirstOrDefault(a => a.ActivitymId == activitymId);

            User u = _db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.User = u;

            return View(thisActivitym);
        }
        [HttpGet("delete/{activitymId}")]
        public IActionResult DeleteActivity(int activitymId){
            if( !isLoggedIn )
            {
                return RedirectToAction("Index" , "Home");
            }
            // query weddings db by id
            Activitym deletedActivity= _db.Activityms.FirstOrDefault(a => a.ActivitymId == activitymId);
            // remove from db
            _db.Activityms.Remove(deletedActivity);
            // save changes
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("join/{activitymId}")]
        public IActionResult Join(int activitymId)
        {
            // create RSVP instance
            Join join = new Join();
            // reassign UserId and WeddingId
            join.UserId = (int)uid;
            join.ActivitymId = activitymId;
            // Add to Like Table in db
            _db.Joins.Add(join);
            // save Changes
            _db.SaveChanges();
            // redirect dashboard
            return RedirectToAction("Dashboard");
        }

        [HttpGet("unjoin/{activitymId}")]
        public IActionResult UnJoin(int activitymId)
        {
            // query RSVP from db
            // must match wedding id and user id in the RSVP relationship
            Join unJoin = _db.Joins
                .FirstOrDefault(y => y.JoinOf.ActivitymId == activitymId && y.parti.UserId == (int)uid );
            // remove the Like  from Table in db
            _db.Joins.Remove(unJoin);
            // save Changes
            _db.SaveChanges();
            // redirect dashboard
            return RedirectToAction("Dashboard");
        }
    }
}

