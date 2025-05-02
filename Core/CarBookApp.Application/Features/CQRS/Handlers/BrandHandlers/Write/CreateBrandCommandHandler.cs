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
    public class CreateBrandCommandHandler(IRepository<Brand> repository)
    {
        private readonly IRepository<Brand> _repository = repository;
        public async Task Handle(CreateBrandCommand command)
        {
            var brand = new Brand
            {
                Name = command.Name,
            };
            if (brand != null)
            {
                await _repository.AddAsync(brand);
            }
        }
    }
}
