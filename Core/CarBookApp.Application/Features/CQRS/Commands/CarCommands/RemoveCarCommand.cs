﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Commands.CarCommands
{
    public class RemoveCarCommand(int id)
    {
        public int Id { get; set; } = id;
    }
}
