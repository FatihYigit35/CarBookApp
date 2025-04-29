using CarBookApp.Application.Features.CQRS.Commands.BannerCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.BannerHandlers.Write
{
    public class CreateBannerCommandHandler(IRepository<Banner> repository)
    {
        private readonly IRepository<Banner> _repository = repository;

        public async Task Handle(CreateBannerCommand command)
        {
            var banner = new Banner
            {
                Title = command.Title,
                Description = command.Description,
                VideoDescription = command.VideoDescription,
                VideoUrl = command.VideoUrl
            };
            if (banner != null)
            {
                await _repository.AddAsync(banner);
            }
        }
    }
}
