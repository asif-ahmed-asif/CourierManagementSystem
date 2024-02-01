using Microsoft.AspNetCore.Mvc;
using CourierManagementSystem.Services.CourierServices;
using CourierManagementSystem.Data;

namespace CourierManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly ICourierService _courierService;

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _db;

        public ReportController(ICourierService courierService, IWebHostEnvironment webHostEnvironment, DataContext db)
        {
            _courierService = courierService;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }
    }
}
