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
    public class GetBannerQueryHandler(IRepository<Banner> repository)
    {
        private readonly IRepository<Banner> _repository = repository;

        public async Task<List<GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            var result = values.Select(a => new GetBannerQueryResult
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                VideoDescription = a.VideoDescription,
                VideoUrl = a.VideoUrl
            }).ToList();
            return result;
        }
    }
}
