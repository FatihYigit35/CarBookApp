using CarBookApp.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
    public class CreateCategoryCommandHandler(IRepository<Category> repository)
    {
        private readonly IRepository<Category> _repository = repository;
        public async Task Handle(CreateCategoryCommand command)
        {
            var category = new Category
            {
                Name = command.Name
            };
            if (category != null)
            {
                await _repository.AddAsync(category);
            }
        }
    }
}
