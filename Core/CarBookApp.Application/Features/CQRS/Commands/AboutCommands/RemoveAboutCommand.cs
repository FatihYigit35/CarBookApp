using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand(int ıd)
    {
        public int Id { get; set; } = ıd;
    }
}
