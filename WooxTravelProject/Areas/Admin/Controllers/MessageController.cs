using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WooxTravelProject.Entities;
using WooxTravelProject.Context;

namespace WooxTravelProject.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        // GET: Admin/Message
        TravelContext context = new TravelContext();
        public ActionResult Inbox() //gelen kutusu
        {
            var a = Session["x"]; // giriş yapan kullanıcının  username getiyriyor bu. bunu nereden biliyor aldık. login controllerda.
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault(); //kullanıcının adına göre email adresini aldık.
            var values = context.Messages.Where(x => x.ReceiverMail == email).ToList();

            return View(values);
        }

        public ActionResult SendBox() //gönderen 
        {
            var a = Session["x"]; // giriş yapan kullanıcının  username getiyriyor bu. bunu nereden biliyor aldık. login controllerda.
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault(); 
            var values = context.Messages.Where(x => x.SenderMail == email).ToList();

            return View(values);
        }

        public ActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(Message message)
        {
            var a = Session["x"]; // giriş yapan kullanıcının  username getiyriyor bu. bunu nereden biliyor aldık. login controllerda.
            var email = context.Admins.Where(x => x.UserName == a).Select(y => y.Email).FirstOrDefault();
            message.SenderMail = email;
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            context.Messages.Add(message);
            context.SaveChanges();

            return RedirectToAction("Sendbox", "Message", new { area = "Admin" });
        }
    }
}