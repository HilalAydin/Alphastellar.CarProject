using CarProject.Core.Entities;
using CarProject.Core.Enums;
using CarProject.Core.Models;
using CarProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarProject.Application.Services
{
    public class VehicleService : IVehicleService
    {
        protected ApplicationDbContext _context;
        public VehicleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteCarAsync(int carId)
        {
            var entity = await _context.Cars.FindAsync(carId);

            _context.Cars.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public List<BoatModel> GetBoatsByColorAsync(VehicleColor color)
        {
            var boats = _context.Boats.Where(x => x.Color == color)
                .Select(x => new BoatModel
                {
                    Id = x.Id,
                    Color = x.Color,
                    Model = x.Model
                }).ToList();
            return boats;
        }

        public List<BusModel> GetBussesByColorAsync(VehicleColor color)
        {
            var busses = _context.Busses.Where(x => x.Color == color)
                .Select(x => new BusModel
                {
                    Id = x.Id,
                    Color = x.Color,
                    Model = x.Model
                }).ToList();
            return busses;
        }

        public List<CarModel> GetCarsByColorAsync(VehicleColor color)
        {
            var cars = _context.Cars.Where(x => x.Color == color)
                .Select(x => new CarModel
                {
                    Id = x.Id,
                    Color = x.Color,
                    Model = x.Model,
                    IsHeadlightsOn = x.IsHeadlightsOn,
                    Wheels = x.Wheels
                }).ToList();
            return cars;
        }

        public async Task<BoatModel> PostBoatAsync(BoatPostModel request)
        {
            var entity = new BoatEntity
            {
                Color = request.Color,
                Model = request.Model
            };
            await _context.Boats.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new BoatModel
            {
                Id = entity.Id,
                Color = entity.Color,
                Model = entity.Model
            };
        }

        public async Task<BusModel> PostBusAsync(BusPostModel request)
        {
            var entity = new BusEntity
            {
                Color = request.Color,
                Model = request.Model
            };
            await _context.Busses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new BusModel
            {
                Id = entity.Id,
                Color = entity.Color,
                Model = entity.Model
            };
        }

        public async Task<CarModel> PostCarAsync(CarPostModel request)
        {
            var entity = new CarEntity
            {
                Color = request.Color,
                Model = request.Model,
                Wheels = request.Wheels,
                IsHeadlightsOn = request.IsHeadlightsOn
            };
            await _context.Cars.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new CarModel
            {
                Id = entity.Id,
                Color = entity.Color,
                Model = entity.Model,
                Wheels = entity.Wheels,
                IsHeadlightsOn = entity.IsHeadlightsOn
            };
        }

        public async Task<CarModel> SwitchCarHeadlightsByIdAsync(int carId)
        {
            var entity = _context.Cars.Where(x => x.Id == carId).FirstOrDefault();
            entity.IsHeadlightsOn = !entity.IsHeadlightsOn;
            _context.Cars.Update(entity);
            await _context.SaveChangesAsync();
            return new CarModel
            {
                Id = entity.Id,
                Color = entity.Color,
                Model = entity.Model,
                Wheels = entity.Wheels,
                IsHeadlightsOn = entity.IsHeadlightsOn
            };
        }
    }
}
