using CarBookApp.Application.Features.CQRS.Commands.ContactCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
    public class RemoveContactCommandHandler(IRepository<Contact> repository)
    {
        private readonly IRepository<Contact> _repository = repository;
        public async Task Handle(RemoveContactCommand command)
        {
            var contact = await _repository.GetByIdAsync(command.Id);
            if (contact != null)
            {
                await _repository.DeleteAsync(contact);
            }
        }
    }
}
