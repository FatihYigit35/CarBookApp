using CarBookApp.Application.Features.CQRS.Results.AboutResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.AboutHandlers.Read
{
    public class GetAboutQueryHandler(IRepository<About> repository)
    {
        private readonly IRepository<About> _repository = repository;


        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var values =  await _repository.GetAllAsync();
            var result = values.Select(a => new GetAboutQueryResult
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                ImageUrl = a.ImageUrl
            }).ToList();
            return result;
        }
    }
}