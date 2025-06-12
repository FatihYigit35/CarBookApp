using CarBookApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Results.CategoryResult
{
    public class GetCategoryQueryResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
