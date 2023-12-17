using WiFind_Blazor.Models.Dtos;

namespace WiFind_Blazor.Repositories;

public interface IPasswordRepository
{
    Task<LocationDto> PostPassword(PostPasswordCommand request);
    Task<List<LocationDto>> GetLocations();
}