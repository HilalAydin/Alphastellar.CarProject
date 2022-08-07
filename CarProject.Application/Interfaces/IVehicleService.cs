using CarProject.Core.Enums;
using CarProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarProject.Application.Services
{
    public interface IVehicleService
    {
        Task<CarModel> PostCarAsync(CarPostModel request);
        Task<BusModel> PostBusAsync(BusPostModel request);
        Task<BoatModel> PostBoatAsync(BoatPostModel request);
        List<BusModel> GetBussesByColorAsync(VehicleColor color);
        List<CarModel> GetCarsByColorAsync(VehicleColor color);
        List<BoatModel> GetBoatsByColorAsync(VehicleColor color);
        Task<CarModel> SwitchCarHeadlightsByIdAsync(int carId);
        Task<bool> DeleteCarAsync(int carId);
    }
}
