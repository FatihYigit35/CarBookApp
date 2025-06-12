using CarBookApp.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookApp.Application.Features.CQRS.Handlers.CategoryHandlers.Read;
using CarBookApp.Application.Features.CQRS.Handlers.CategoryHandlers.Write;
using CarBookApp.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(
        GetCategoryQueryHandler getCategoryQueryHandler,
        GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
        CreateCategoryCommandHandler createCategoryCommandHandler,
        UpdateCategoryCommandHandler updateCategoryCommandHandler,
        RemoveCategoryCommandHandler removeCategoryCommandHansler) : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler = getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler = createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler = updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHansler = removeCategoryCommandHansler;

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var result = await _getCategoryQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var result = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Category bilgisi eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryCommandHansler.Handle(new RemoveCategoryCommand(id));
            return Ok("Category bilgisi silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Category bilgisi güncellendi.");
        }
    }
}
