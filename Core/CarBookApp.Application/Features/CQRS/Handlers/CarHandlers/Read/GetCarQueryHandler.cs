using CarBookApp.Application.Features.CQRS.Results.BrandResult;
using CarBookApp.Application.Features.CQRS.Results.CarResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers.Read
{
    public class GetCarQueryHandler(IRepository<Car> repository)
    {
        private readonly IRepository<Car> _repository = repository;
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(a => new GetCarQueryResult
            {
                Id = a.Id,
                BrandId = a.BrandId,
                Model = a.Model,
                CoveredImageUrl = a.CoveredImageUrl,
                Km = a.Km,
                Transmission = a.Transmission,
                Seat = a.Seat,
                Luggage = a.Luggage,
                FuelType = a.FuelType,
                BigImageUrl = a.BigImageUrl,
            }).ToList();
            return result;
        }
    }
}
