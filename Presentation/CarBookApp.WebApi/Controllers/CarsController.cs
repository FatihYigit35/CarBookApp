using CarBookApp.Application.Features.CQRS.Commands.CarCommands;
using CarBookApp.Application.Features.CQRS.Handlers.CarHandlers.Read;
using CarBookApp.Application.Features.CQRS.Handlers.CarHandlers.Write;
using CarBookApp.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController(
        GetCarQueryHandler getCarQueryHandler,
        GetCarByIdQueryHandler getCarByIdQueryHandler,
        CreateCarCommandHandler createCarCommandHandler,
        UpdateCarCommandHandler updateCarCommandHandler,
        RemoveCarCommandHandler removeCarCommandHansler) : ControllerBase
    {
        private readonly GetCarQueryHandler _getCarQueryHandler = getCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler = getCarByIdQueryHandler;
        private readonly CreateCarCommandHandler _createCarCommandHandler = createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler = updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHansler = removeCarCommandHansler;

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var result = await _getCarQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var result = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Car bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await _removeCarCommandHansler.Handle(new RemoveCarCommand(id));
            return Ok("Car bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car bilgisi güncellendi.");
        }
    }
}
