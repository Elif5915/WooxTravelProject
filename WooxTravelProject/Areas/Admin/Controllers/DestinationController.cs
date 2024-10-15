using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravelProject.Context;
using WooxTravelProject.Entities;

namespace WooxTravelProject.Areas.Admin.Controllers
{
    public class DestinationController : Controller
    {
        // GET: Admin/Destination

        TravelContext context = new TravelContext();
        public ActionResult DestinationList()
        {
            var values = context.Destinations.ToList();
            return View(values);
        }
        //attribute yazılmazsa default u gettir. httpget
        public ActionResult createDestination()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createDestination(Destination destination)
        {
            context.Destinations.Add(destination);
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin"); //method ismi,controller ismi, controllerın olduğu kısım areanın admininde
        }

        public ActionResult deleteDestination(int id)
        {
            var value = context.Destinations.Find(id);
            context.Destinations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }

        [HttpGet]
        public ActionResult updateDestination(int id)
        {
            var value = context.Destinations.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult updateDestination(Destination destination)
        {
            var value = context.Destinations.Find(destination.DestinationId);
            value.Description = destination.Description;
            value.Country = destination.Country;
            value.City = destination.City;
            value.DayNight = destination.DayNight;
            value.ImageUrl = destination.ImageUrl;
            value.Price = destination.Price;
            value.Title = destination.Title;
            context.SaveChanges();

            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
    }
}