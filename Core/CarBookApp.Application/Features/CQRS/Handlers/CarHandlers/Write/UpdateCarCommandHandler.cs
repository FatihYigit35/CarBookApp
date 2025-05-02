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
    public class UpdateCarCommandHandler(IRepository<Car> repository)
    {
        private readonly IRepository<Car> _repository = repository;

        public async Task Handle(UpdateCarCommand command)
        {
            var car = await _repository.GetByIdAsync(command.Id);
            if (car != null)
            {
                car.BrandId = command.BrandId;
                car.Model = command.Model;
                car.CoveredImageUrl = command.CoveredImageUrl;
                car.Km = command.Km;
                car.Transmission = command.Transmission;
                car.Seat = command.Seat;
                car.Luggage = command.Luggage;
                car.FuelType = command.FuelType;
                car.BigImageUrl = command.BigImageUrl;
                await _repository.UpdateAsync(car);
            }
        }
    }
}
