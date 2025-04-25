using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Commands.BannerCommands
{
    public class UpdateBannerCommand
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string VideoDescription { get; set; }
        public required string VideoUrl { get; set; }
    }
}
