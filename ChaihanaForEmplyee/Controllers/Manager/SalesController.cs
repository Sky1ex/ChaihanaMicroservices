using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChaihanaForEmplyee.Controllers.Manager
{
    [Authorize(Roles = "manager")]
    public class SalesController : Controller
    {
        // ПРЕДСЬАВЛЕНИЕ ДОДЕЛАТЬ!!!
        [HttpGet("Manager/Sales")]
        public IActionResult Index()
        {
            return View("~/Views/Manager/Sales/Index.cshtml");
        }
    }

}
