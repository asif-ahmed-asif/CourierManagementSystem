using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourierManagementSystem.Data;
using CourierManagementSystem.Models;
using CourierManagementSystem.Services.CourierServices;
using Microsoft.AspNetCore.Authorization;

namespace CourierManagementSystem.Controllers
{
    public class CouriersController : Controller
    {
        private readonly ICourierService _courierService;

        public CouriersController(ICourierService courierService)
        {
            _courierService = courierService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _courierService.GetAllCouriers());
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,CustomerEmail,CustomerAddress,CustomerMobile,RecipientName,RecipientAddress,RecipientMobile,ConsignmentNo,CourierCharge")] Courier courier)
        {
            if (ModelState.IsValid)
            {
                var result = await _courierService.AddCourier(courier);
                if (result is true)
                {
                    TempData["success"] = "Courier Successfully Added!";
                    return RedirectToAction(nameof(Index));
                }               
            }

            return View(courier);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
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

            ViewBag.Statuses = await _courierService.GetStatuses();
            return View(courier);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ConsignmentNo,CustomerName,CustomerEmail,CustomerAddress,CustomerMobile,RecipientName,RecipientAddress,RecipientMobile,CourierCharge,StatusId")] Courier courier)
        {
            if (ModelState.IsValid)
            {
                var result = await _courierService.UpdateCourier(courier);
                if (result is true)
                {
                    TempData["success"] = "Courier Successfully Edited!";
                    return RedirectToAction(nameof(Index));
                }             
            }

            ViewBag.Statuses = await _courierService.GetStatuses();
            return View(courier);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
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

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var result = await _courierService.Delete(id);
            if (result is false)
            {
                return Problem("Something Went Wrong!");
            }
            TempData["success"] = "Courier Successfully Deleted!";
            return RedirectToAction(nameof(Index));
        }
    }
}
