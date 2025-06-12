using CarBookApp.Application.Features.CQRS.Queries.ContactQueries;
using CarBookApp.Application.Features.CQRS.Results.ContactResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;

namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers.Read
{
    public class GetContactByIdQueryHandler(IRepository<Contact> repository)
    {
        private readonly IRepository<Contact> _repository = repository;

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var result = new GetContactByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
                Email = value.Email,
                PhoneNumber = value.PhoneNumber,
                Subject = value.Subject,
                Message = value.Message,
                CreatedAt = value.CreatedAt
            };
            return result;
        }
    }
}
