using CourierManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourierManagementSystem.Services.CourierServices
{
    public interface ICourierService
    {
        Task<IEnumerable<Courier?>?> GetAllCouriers();

        Task<bool?> AddCourier(Courier courier);

        Task<Courier?> CourierDetails(Guid? consignmentNo);

        Task<bool?> UpdateCourier(Courier courier);

        Task<bool?> Delete(Guid? consignmentNo);

        Task<IEnumerable<SelectListItem>> GetStatuses();

        Task<Courier?> TrackCourier(string trackingNo);
    }
}
