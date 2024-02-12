using KiwiLadyShoes.Models;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLadyShoes.Controllers
{
    public class ContactUsController : Controller  // <!--Started to create on 29/10/23 Ira-->
    {
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Contact
        [HttpPost]
        public ActionResult Index(ContactUs model)
        {
            // Some code is here

            
            return RedirectToAction("ThankYou");
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
