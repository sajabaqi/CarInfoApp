using CarInfoApiApp.DTOs;
using CarInfoApiApp.Models;
using System.Text.Json;

namespace CarInfoApiApp.Services
{
    public class MakeService : IMakeService
    {
        private readonly HttpClient _httpClient;

        private const string baseUrl = "https://vpic.nhtsa.dot.gov/api/vehicles";

        public MakeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Makes>> GetAllMakesAsync()
        {
            try
            {
                var url = $"{baseUrl}/getallmakes?format=json";
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var makeResponse = JsonSerializer.Deserialize<MakesResponse>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return makeResponse?.Results ?? new List<Makes>();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<List<VehicleType>> GetVehicleTypesForMakeAsync(int makeId)
        {
            try
            {
                var url = $"{baseUrl}/GetVehicleTypesForMakeId/{makeId}?format=json";
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var vehicleTypeResponse = JsonSerializer.Deserialize<VehicleTypeResponse>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });


                return vehicleTypeResponse?.Results ?? new List<VehicleType>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MakeModel>> GetModelsForMakeAndYearAsync(int makeId, int year)
        {
            try
            {
                var url = $"{baseUrl}/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json";
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var jsonContent = await response.Content.ReadAsStringAsync();
                var modelMakeResponse = JsonSerializer.Deserialize<MakeModelResponse>(jsonContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return modelMakeResponse?.Results ?? new List<MakeModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
