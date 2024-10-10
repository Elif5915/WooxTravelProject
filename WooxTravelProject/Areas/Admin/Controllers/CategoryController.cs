using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravelProject.Context;

namespace WooxTravelProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category

        TravelContext context = new TravelContext();
        public ActionResult CategoryList()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
     
    }
}