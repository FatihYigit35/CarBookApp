using CarBookApp.Application.Features.CQRS.Commands.CarCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.CarHandlers.Write
{
    public class CreateCarCommandHandler(IRepository<Car> repository)
    {
        private readonly IRepository<Car> _repository = repository;
        public async Task Handle(CreateCarCommand command)
        {
            var car = new Car
            {
                BrandId = command.BrandId,
                Model = command.Model,
                CoveredImageUrl = command.CoveredImageUrl,
                Km = command.Km,
                Transmission = command.Transmission,
                Seat = command.Seat,
                Luggage = command.Luggage,
                FuelType = command.FuelType,
                BigImageUrl = command.BigImageUrl,
            };
            if (car != null)
            {
                await _repository.AddAsync(car);
            }
        }
    }
}
