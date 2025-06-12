using CarBookApp.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
    public class RemoveCategoryCommandHandler(IRepository<Category> repository)
    {
        private readonly IRepository<Category> _repository = repository;
        public async Task Handle(RemoveCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            if (category != null)
            {
                await _repository.DeleteAsync(category);
            }
        }
    }
}
