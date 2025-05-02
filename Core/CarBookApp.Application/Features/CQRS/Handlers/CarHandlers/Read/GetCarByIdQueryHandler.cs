using CarBookApp.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetCarByIdQueryHandler(IRepository<Car> repository)
    {
        private readonly IRepository<Car> _repository = repository;

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var result = new GetCarByIdQueryResult
            {
                Id = value.Id,
                BrandId = value.BrandId,
                Model = value.Model,
                CoveredImageUrl = value.CoveredImageUrl,
                Km = value.Km,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Luggage = value.Luggage,
                FuelType = value.FuelType,
                BigImageUrl = value.BigImageUrl,
            };
            return result;
        }
    }
}
