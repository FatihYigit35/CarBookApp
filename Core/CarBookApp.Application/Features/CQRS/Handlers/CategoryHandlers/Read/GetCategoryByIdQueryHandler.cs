using CarBookApp.Application.Features.CQRS.Queries.CategoryQueries;
using CarBookApp.Application.Features.CQRS.Results.CategoryResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CategoryHandlers.Read
{
    public class GetCategoryByIdQueryHandler(IRepository<Category> repository)
    {
        private readonly IRepository<Category> _repository = repository;

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var result = new GetCategoryByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
            };
            return result;
        }
    }
}
