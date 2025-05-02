using CarBookApp.Application.Features.CQRS.Results.BrandResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.BrandHandlers.Read
{
    public class GetBrandQueryHandler(IRepository<Brand> repository)
    {
        private readonly IRepository<Brand> _repository = repository;

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(a => new GetBrandQueryResult
            {
                Id = a.Id,
                Name = a.Name,
            }).ToList();
            return result;
        }
    }
}
