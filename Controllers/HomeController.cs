using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // Index method returns a ViewResult object named MyView, which is found in the Views Home folder

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon"; 
            return View("MyView");
        }


        // Action method called w/o argument - MVC renders the default view assoc w/the action method 
        // -- a view w/the same name as the action method (RsvpForm.cshtml)
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            Repository.AddResponse(guestResponse);            
            return View("Thanks", guestResponse);
        }

        public ViewResult ListResponses()
        {
           return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
        
    }
}
