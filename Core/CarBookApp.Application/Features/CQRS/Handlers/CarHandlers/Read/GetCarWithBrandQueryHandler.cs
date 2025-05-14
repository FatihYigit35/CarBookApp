using CarBookApp.Application.Features.CQRS.Results.CarResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Application.Interfaces.CarInterfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers.Read
{
    public class GetCarWithBrandQueryHandler(ICarRepository repository)
    {
        private readonly ICarRepository _repository = repository;
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarListWithBrands();
            var result = values.Select(a => new GetCarWithBrandQueryResult
            {
                Id = a.Id,
                BrandId = a.BrandId,
                BrandName = a.Brand.Name,
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
