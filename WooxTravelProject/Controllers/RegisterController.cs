using WooxTravelProject.Context;
using WooxTravelProject.Entities;
using System.Web.Mvc;

namespace WooxTravelProject.Controllers
{
    public class RegisterController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            context.Admins.Add(admin);
            context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}