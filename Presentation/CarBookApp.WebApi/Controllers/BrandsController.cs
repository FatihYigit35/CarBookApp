using CarBookApp.Application.Features.CQRS.Commands.BrandCommands;
using CarBookApp.Application.Features.CQRS.Handlers.BrandHandlers.Read;
using CarBookApp.Application.Features.CQRS.Handlers.BrandHandlers.Write;
using CarBookApp.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(
        GetBrandQueryHandler getBrandQueryHandler,
        GetBrandByIdQueryHandler getBrandByIdQueryHandler,
        CreateBrandCommandHandler createBrandCommandHandler,
        UpdateBrandCommandHandler updateBrandCommandHandler,
        RemoveBrandCommandHandler removeBrandCommandHansler) : ControllerBase
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler = getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler = createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler = updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHansler = removeBrandCommandHansler;

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var result = await _getBrandQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var result = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeBrandCommandHansler.Handle(new RemoveBrandCommand(id));
            return Ok("Brand bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Brand bilgisi güncellendi.");
        }
    }
}
