using CourierManagementSystem.Data;
using CourierManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CourierManagementSystem.Services.CourierServices
{
    public class CourierService : ICourierService
    {
        private readonly DataContext _db;

        public CourierService(DataContext db)
        {
            _db = db;
        }

        public async Task<bool?> AddCourier(Courier courier)
        {
            if(courier is null)
            {
                return false;
            }

            courier.ConsignmentNo = Guid.NewGuid();
            courier.DateOfPlace = DateTime.Now;
            courier.DateOfDelivered = null;
            courier.StatusId = 1;
            _db.Add(courier);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Courier?> CourierDetails(Guid? consignmentNo)
        {
            return await _db.Couriers.Include(c => c.Status)
                                     .FirstOrDefaultAsync(m => m.ConsignmentNo == consignmentNo);
        }

        public async Task<bool?> Delete(Guid? consignmentNo)
        {
            var courier = await CourierDetails(consignmentNo);

            if(courier is null)
            {
                return false;
            }

            _db.Couriers.Remove(courier);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Courier?>?> GetAllCouriers()
        {
            return await _db.Couriers.Include(c => c.Status)
                                     .ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetStatuses()
        {
            return await _db.Statuses.Select(x => 
                                                new SelectListItem
                                                {
                                                    Value = x.Id.ToString(),
                                                    Text = x.Name
                                                }).ToListAsync();

        }

        public async Task<Courier?> TrackCourier(string trackingNo)
        {
            var courier = await _db.Couriers.Where(c => c.ConsignmentNo.ToString() == trackingNo ||
                                                        c.RecipientMobile == trackingNo)
                                            .Include(c => c.Status)
                                            .FirstOrDefaultAsync();
            return courier;
        }

        public async Task<bool?> UpdateCourier(Courier courier)
        {
            if (courier is null)
            {
                return false;
            }

            if(courier.StatusId == 3)
            {
                courier.DateOfDelivered = DateTime.Now;
            }
            else
            {
                courier.DateOfDelivered = null;
            }

            var entity = _db.Couriers.Update(courier);
            entity.Property(p => p.DateOfPlace).IsModified = false;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
