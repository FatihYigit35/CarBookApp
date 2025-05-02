using CarBookApp.Application.Features.CQRS.Commands.BrandCommands;
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
    public class RemoveCarCommandHandler(IRepository<Car> repository)
    {
        private readonly IRepository<Car> _repository = repository;
        public async Task Handle(RemoveCarCommand command)
        {
            var car = await _repository.GetByIdAsync(command.Id);
            if (car != null)
            {
                await _repository.DeleteAsync(car);
            }
        }
    }
}
