using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KiwiLadyShoes.Controllers
{
    //Ira made the contoller and addded authorization 16/10/23

    [Authorize(Roles = "Manager,Salesperson,Administrator")]  
    public class ManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
