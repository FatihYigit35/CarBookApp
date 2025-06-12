using CarBookApp.Application.Features.CQRS.Results.ContactResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.ContactHandlers.Read
{
    public class GetContactQueryHandler(IRepository<Contact> repository)
    {
        private readonly IRepository<Contact> _repository = repository;
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(a => new GetContactQueryResult
            {
                Id = a.Id,
                Name = a.Name,
                Email = a.Email,
                PhoneNumber = a.PhoneNumber,
                Subject = a.Subject,
                Message = a.Message,
                CreatedAt = a.CreatedAt
            }).ToList();
            return result;
        }
    }
}
