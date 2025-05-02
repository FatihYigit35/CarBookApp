using CarBookApp.Application.Features.CQRS.Commands.AboutCommands;
using CarBookApp.Application.Interfaces;
using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Handlers.AboutHandlers.Write
{
    public class RemoveAboutCommandHandler(IRepository<About> repository)
    {
        private readonly IRepository<About> _repository = repository;
        public async Task Handle(RemoveAboutCommand command)
        {
            var about = await _repository.GetByIdAsync(command.Id);
            if (about != null)
            {
                await _repository.DeleteAsync(about);
            }
        }
    }
}

