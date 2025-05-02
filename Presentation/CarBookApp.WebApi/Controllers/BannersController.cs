using CarBookApp.Application.Features.CQRS.Commands.BannerCommands;
using CarBookApp.Application.Features.CQRS.Handlers.BannerHandlers.Read;
using CarBookApp.Application.Features.CQRS.Handlers.BannerHandlers.Write;
using CarBookApp.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(
        GetBannerQueryHandler getBannerQueryHandler,
        GetBannerByIdQueryHandler getBannerByIdQueryHandler,
        CreateBannerCommandHandler createBannerCommandHandler,
        UpdateBannerCommandHandler updateBannerCommandHandler,
        RemoveBannerCommandHandler removeBannerCommandHansler) : ControllerBase
    {
        private readonly GetBannerQueryHandler _getBannerQueryHandler = getBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        private readonly CreateBannerCommandHandler _createBannerCommandHandler = createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler = updateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHansler = removeBannerCommandHansler;

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var result = await _getBannerQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var result = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBanner(CreateBannerCommand command)
        {
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeBannerCommandHansler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner bilgisi güncellendi.");
        }
    }
}
