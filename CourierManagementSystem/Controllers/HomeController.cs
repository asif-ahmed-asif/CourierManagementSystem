using CourierManagementSystem.Models;
using CourierManagementSystem.Services.CourierServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourierManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICourierService _courierService;

        public HomeController(ICourierService courierService)
        {
            _courierService = courierService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string search)
        {
            var courier = await _courierService.TrackCourier(search);
            if (courier is null)
            {
                TempData["Result"] = "No Courier Found!";
            }
            return View(courier);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var courier = await _courierService.CourierDetails(id);

            if (courier is null)
            {
                return NotFound();
            }

            return View(courier);
        }

    }
}