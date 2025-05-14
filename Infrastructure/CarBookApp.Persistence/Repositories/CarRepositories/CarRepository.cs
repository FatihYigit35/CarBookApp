using CarBookApp.Application.Interfaces.CarInterfaces;
using CarBookApp.Domain.Entities;
using CarBookApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Persistence.Repositories.CarRepositories
{
    public class CarRepository(CarBookContext context) : ICarRepository
    {
        private readonly CarBookContext _context = context;

        public Task<List<Car>> GetCarListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToListAsync();
            return values;
        }
    }
}
