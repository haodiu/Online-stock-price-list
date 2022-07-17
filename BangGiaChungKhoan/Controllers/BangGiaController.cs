using Microsoft.AspNetCore.Mvc;

namespace BangGiaChungKhoan.Controllers
{
    public class BangGiaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
