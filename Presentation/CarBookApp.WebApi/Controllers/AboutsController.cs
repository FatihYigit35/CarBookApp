using CarBookApp.Application.Features.CQRS.Commands.AboutCommands;
using CarBookApp.Application.Features.CQRS.Handlers.AboutHandlers.Read;
using CarBookApp.Application.Features.CQRS.Handlers.AboutHandlers.Write;
using CarBookApp.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(
        GetAboutQueryHandler getAboutQueryHandler,
        GetAboutByIdQueryHandler getAboutByIdQueryHandler,
        CreateAboutCommandHandler createAboutCommandHandler,
        UpdateAboutCommandHandler updateAboutCommandHandler,
        RemoveAboutCommandHansler removeAboutCommandHansler) : ControllerBase
    {
        private readonly GetAboutQueryHandler _getAboutQueryHandler = getAboutQueryHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
        private readonly CreateAboutCommandHandler _createAboutCommandHandler = createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler = updateAboutCommandHandler;
        private readonly RemoveAboutCommandHansler _removeAboutCommandHansler = removeAboutCommandHansler;

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var result = await _getAboutQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var result = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeAboutCommandHansler.Handle(new RemoveAboutCommand(id));
            return Ok("Hakkımda bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi güncellendi.");
        }
    }
}
