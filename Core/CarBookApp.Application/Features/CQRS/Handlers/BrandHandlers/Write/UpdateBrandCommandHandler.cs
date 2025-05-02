using CarBookApp.Application.Features.CQRS.Commands.BrandCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.BrandHandlers.Write
{
    public class UpdateBrandCommandHandler(IRepository<Brand> repository)
    {
        private readonly IRepository<Brand> _repository = repository;

        public async Task Handle(UpdateBrandCommand command)
        {
            var brand = await _repository.GetByIdAsync(command.Id);
            if (brand != null)
            {
                brand.Name = command.Name;
                await _repository.UpdateAsync(brand);
            }
        }
    }
}
