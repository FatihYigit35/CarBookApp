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
    public class RemoveResultCommandHansler(IRepository<Banner> repository)
    {
        private readonly IRepository<Banner> _repository = repository;
        public async Task Handle(RemoveBannerCommand command)
        {
            var banner = await _repository.GetByIdAsync(command.Id);
            if (banner != null)
            {
                await _repository.DeleteAsync(banner);
            }
        }
    }
}

