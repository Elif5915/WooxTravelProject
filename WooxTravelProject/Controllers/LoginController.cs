
using System.Web.Mvc;
using WooxTravelProject.Context;
using WooxTravelProject.Entities;
using System.Web.Security;
using System.Linq;

namespace WooxTravelProject.Controllers
{
    public class LoginController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(values != null)
            {   // FormsAuthentication kullanmanı sağlayan kütühane : using System.Web.Security; budur.
                // SetAuthCookie sitenin sağ clik incele deki application alanındaki cookies de ne key verirsen onu tut
                // dedik. Daha sonra ikinci paramtere false olması da şu  beni hatırla işini yapsın ve hatırlasın mı seçimi. false diyerek hayır beni hatırlama demiş olduk.
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["x"] = values.UserName;
                return RedirectToAction("Index", "Profile", "Admin");
            }
            else
            {
                return View();
            }

        }
    }
}