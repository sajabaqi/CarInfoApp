using CarInfoApiApp.DTOs;
using CarInfoApiApp.Models;

namespace CarInfoApiApp.Services
{
    public interface IMakeService
    {
        Task<List<Makes>> GetAllMakesAsync();
        Task<List<VehicleType>> GetVehicleTypesForMakeAsync(int makeId);
        Task<List<MakeModel>> GetModelsForMakeAndYearAsync(int makeId, int year);
    }
}
