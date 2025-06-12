using CarBookApp.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
    public class UpdateCategoryCommandHandler(IRepository<Category> repository)
    {
        private readonly IRepository<Category> _repository = repository;

        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            if (category != null)
            {
                category.Name = command.Name;
                await _repository.UpdateAsync(category);
            }
        }
    }
}
