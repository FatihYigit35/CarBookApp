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
    public class UpdateBannerCommandHandler(IRepository<Banner> repository)
    {
        private readonly IRepository<Banner> _repository = repository;

        public async Task Handle(UpdateBannerCommand command)
        {
            var banner = await _repository.GetByIdAsync(command.Id);
            if (banner != null)
            {
                banner.Title = command.Title;
                banner.Description = command.Description;
                banner.VideoDescription = command.VideoDescription;
                banner.VideoUrl = command.VideoUrl;
                await _repository.UpdateAsync(banner);
            }
        }
    }
}
