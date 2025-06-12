using CarBookApp.Application.Features.CQRS.Commands.ContactCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
    public class UpdateContactCommandHandler(IRepository<Contact> repository)
    {
        private readonly IRepository<Contact> _repository = repository;

        public async Task Handle(UpdateContactCommand command)
        {
            var contact = await _repository.GetByIdAsync(command.Id);
            if (contact != null)
            {
                contact.Name = command.Name;
                contact.Email = command.Email;
                contact.PhoneNumber = command.PhoneNumber;
                contact.Subject = command.Subject;
                contact.Message = command.Message;
                contact.CreatedAt = command.CreatedAt;  
                await _repository.UpdateAsync(contact);
            }
        }
    }
}
