using CarBookApp.Application.Features.CQRS.Commands.ContactCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
    public class CreateContactCommandHandler(IRepository<Contact> repository)
    {
        private readonly IRepository<Contact> _repository = repository;
        public async Task Handle(CreateContactCommand command)
        {
            var contact = new Contact
            {
                Name = command.Name,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Subject = command.Subject,
                Message = command.Message,
                CreatedAt = command.CreatedAt
            };
            if (contact != null)
            {
                await _repository.AddAsync(contact);
            }
        }
    }
}
