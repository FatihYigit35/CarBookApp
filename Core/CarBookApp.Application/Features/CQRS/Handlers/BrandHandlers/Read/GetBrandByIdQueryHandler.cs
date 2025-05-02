using CarBookApp.Application.Features.CQRS.Queries.BrandQueries;
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
    public class GetBrandByIdQueryHandler(IRepository<Brand> repository)
    {
        private readonly IRepository<Brand> _repository = repository;
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var result = new GetBrandByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
            };
            return result;
        }
    }
}
