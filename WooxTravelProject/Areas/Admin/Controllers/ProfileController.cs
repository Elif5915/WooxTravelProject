using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravelProject.Context;
using WooxTravelProject.Entities;

namespace WooxTravelProject.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Admin/Profile
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            var a = Session["x"];
            var values = context.Admins.Where(x => x.UserName == a).FirstOrDefault();
            return View(values);
        }
    }
}