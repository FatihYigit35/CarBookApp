using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand(int id)
    {
        public int Id { get; set; } = id;
    }
}
