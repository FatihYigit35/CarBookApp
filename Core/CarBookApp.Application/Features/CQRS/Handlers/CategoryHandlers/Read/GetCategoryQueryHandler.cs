using CarBookApp.Application.Features.CQRS.Results.CategoryResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.CategoryHandlers.Read
{
    public class GetCategoryQueryHandler(IRepository<Category> repository)
    {
        private readonly IRepository<Category> _repository = repository;
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(a => new GetCategoryQueryResult
            {
                Id = a.Id,
                Name = a.Name,
            }).ToList();
            return result;
        }
    }
}
