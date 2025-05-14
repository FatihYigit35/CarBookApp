using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookApp.Application.Features.CQRS.Results.CarResult
{
    public class GetCarWithBrandQueryResult:GetCarQueryResult
    {
        public string BrandName { get; set; } = string.Empty;
    }
}
