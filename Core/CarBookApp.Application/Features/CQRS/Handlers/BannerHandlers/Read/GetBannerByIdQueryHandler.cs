using CarBookApp.Application.Features.CQRS.Queries.BannerQueries;
using CarBookApp.Application.Features.CQRS.Results.BannerResult;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.BannerHandlers.Read
{
    public class GetBannerByIdQueryHandler(IRepository<Banner> repository)
    {
        private readonly IRepository<Banner> _repository = repository;

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            var result = new GetBannerByIdQueryResult
            {
                Id = value.Id,
                Title = value.Title,
                Description = value.Description,
                VideoDescription = value.VideoDescription,
                VideoUrl = value.VideoUrl
            };
            return result;
        }
    }
}
