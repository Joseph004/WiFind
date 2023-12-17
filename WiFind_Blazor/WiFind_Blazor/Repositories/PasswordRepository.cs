using Microsoft.EntityFrameworkCore;
using WiFind_Blazor.Data;
using WiFind_Blazor.Models.Dtos;

namespace WiFind_Blazor.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly WiFindDbContext _wiFindDbContext;
        public PasswordRepository(WiFindDbContext wiFindDbContext)
        {
            _wiFindDbContext = wiFindDbContext;
        }

        public async Task<List<LocationDto>> GetLocations()
        {
            var locations = await _wiFindDbContext.Locations.ToListAsync();
            return locations.OrderByDescending(y => y.CreatedTime).Select(x => new LocationDto
            {
                Id = x.Id,
                LocationName = x.LocationName,
                WiFiName = x.WiFiName,
                Password = x.Password,
                City = x.City,
                CreatedTime = x.CreatedTime
            }).ToList();
        }
        public async Task<LocationDto> PostPassword(PostPasswordCommand request)
        {
            var id = Guid.NewGuid();
            _wiFindDbContext.Locations.Add(new Models.Location
            {
                Id = id,
                LocationName = request.Location,
                WiFiName = request.WiFiName,
                Password = request.Password,
                City = request.Where,
                CreatedTime = DateTime.UtcNow
            });

            _wiFindDbContext.SaveChanges();

            var newSavedData = await _wiFindDbContext.Locations.FirstOrDefaultAsync(x => x.Id == id);

            return newSavedData != null ? new LocationDto
            {
                Id = newSavedData.Id,
                LocationName = newSavedData.LocationName,
                WiFiName = newSavedData.WiFiName,
                Password = newSavedData.Password,
                City = newSavedData.City,
                CreatedTime = newSavedData.CreatedTime
            } : new LocationDto();
        }
    }
}